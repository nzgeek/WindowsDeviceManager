/***************************************************************************
*                                                                          *
* Copyright 2016 Jamie Anderson                                            *
*                                                                          *
* Licensed under the Apache License, Version 2.0 (the "License");          *
* you may not use this file except in compliance with the License.         *
* You may obtain a copy of the License at                                  *
*                                                                          *
*     http://www.apache.org/licenses/LICENSE-2.0                           *
*                                                                          *
* Unless required by applicable law or agreed to in writing, software      *
* distributed under the License is distributed on an "AS IS" BASIS,        *
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. *
* See the License for the specific language governing permissions and      *
* limitations under the License.                                           *
*                                                                          *
***************************************************************************/

using System;
using System.Collections.Generic;
using WindowsDeviceManager.Api;
using WindowsDeviceManager.Helpers;

namespace WindowsDeviceManager
{
    public class DeviceInterface
    {
        /// <summary>
        /// The device set that this device interface belongs to.
        /// </summary>
        private DeviceInfo _device;

        /// <summary>
        /// The API structure that identifies this device interface.
        /// </summary>
        private SP_DEVICE_INTERFACE_DATA _deviceInterfaceData;

        /// <summary>
        /// Contains a cache of all properties retrieved for this device.
        /// </summary>
        private Dictionary<DevicePropertyKey, DeviceInterfacePropertyValue> _propertyCache =
            new Dictionary<DevicePropertyKey, DeviceInterfacePropertyValue>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="deviceInterfaceData"></param>
        internal DeviceInterface(DeviceInfo device, SP_DEVICE_INTERFACE_DATA deviceInterfaceData)
        {
            device.ThrowIfNull("device");

            _device = device;
            _deviceInterfaceData = deviceInterfaceData;
        }

        /// <summary>
        /// Gets the device that this device interface belongs to.
        /// </summary>
        public DeviceInfo Device
        {
            get { return _device; }
        }

        /// <summary>
        /// Gets the API structure that identifies this device interface.
        /// </summary>
        internal SP_DEVICE_INTERFACE_DATA InterfaceData
        {
            get { return _deviceInterfaceData; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return GetProperty(DevicePropertyKeys.DeviceInterface.FriendlyName).GetValue<string>("<no name>"); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Guid InterfaceClassId
        {
            get { return _deviceInterfaceData.interfaceClassGuid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsActive
        {
            get { return _deviceInterfaceData.flags.IsFlagSet(DeviceInterfaceFlags.SPINT_ACTIVE); }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDefault
        {
            get { return _deviceInterfaceData.flags.IsFlagSet(DeviceInterfaceFlags.SPINT_DEFAULT); }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsRemoved
        {
            get { return _deviceInterfaceData.flags.IsFlagSet(DeviceInterfaceFlags.SPINT_REMOVED); }
        }

        /// <summary>
        /// Refreshes all of the cached device interface properties.
        /// </summary>
        public void Refresh()
        {
            foreach (var value in _propertyCache.Values)
            {
                value.ReadValue(this);
            }
        }

        /// <summary>
        /// Refreshes only the specified device properties, if they're currently cached.
        /// </summary>
        /// <param name="keys">Keys for the device properties to refresh.</param>
        public void Refresh(params DevicePropertyKey[] keys)
        {
            keys.ThrowIfNull("keys");

            foreach (var key in keys)
            {
                DeviceInterfacePropertyValue value;
                if (_propertyCache.TryGetValue(key, out value))
                {
                    value.ReadValue(this);
                }
            }
        }

        /// <summary>
        /// Gets the value of a device property.
        /// </summary>
        /// <param name="key">The key for the device property to get.</param>
        /// <returns>
        /// Return the property's value, if found, or <c>null</c> if the device does not support the property.
        /// </returns>
        /// <remarks>
        /// When a property is retrieved for the first time, its value will be stored in a cache. Further requests for
        /// the same property will be served from the cache.
        /// </remarks>
        public DeviceInterfacePropertyValue GetProperty(DevicePropertyKey key)
        {
            return GetProperty(key, false);
        }

        /// <summary>
        /// Gets the value of a device property.
        /// </summary>
        /// <param name="key">The key for the device property to get.</param>
        /// <param name="forceRefresh">
        /// If <c>true</c>, the cached value will be ignored and the value will be re-retrieved.
        /// </param>
        /// <returns>
        /// Return the property's value, if found, or <c>null</c> if the device does not support the property.
        /// </returns>
        /// <remarks>
        /// When a property is retrieved for the first time, its value will be stored in a cache. Further requests for
        /// the same property will be served from the cache unless <paramref name="forceRefresh"/> is <c>true</c>.
        /// </remarks>
        public DeviceInterfacePropertyValue GetProperty(DevicePropertyKey key, bool forceRefresh)
        {
            key.ThrowIfNull("key");

            DeviceInterfacePropertyValue value;
            // If the value isn't cached, read it.
            if (!_propertyCache.TryGetValue(key, out value))
            {
                value = new DeviceInterfacePropertyValue(key);
                if (value.ReadValue(this))
                    _propertyCache[key] = value;
                else
                    value = null;
            }
            // If the value is cached, it may need to be refreshed.
            else if (forceRefresh)
            {
                value.ReadValue(this);
            }

            return value;
        }
    }
}
