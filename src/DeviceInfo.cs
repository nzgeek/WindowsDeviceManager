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
    public class DeviceInfo
    {
        /// <summary>
        /// The device information set that this device belongs to.
        /// </summary>
        private DeviceInfoSet _infoSet;

        /// <summary>
        /// The API structure that identifies this device.
        /// </summary>
        private SP_DEVINFO_DATA _deviceInfoData;

        /// <summary>
        /// Contains a cache of all properties retrieved for this device.
        /// </summary>
        private Dictionary<DevicePropertyKey, DevicePropertyValue> _propertyCache =
            new Dictionary<DevicePropertyKey, DevicePropertyValue>();

        /// <summary>
        /// Contains a cache of all registry properties retrieved for this device.
        /// </summary>
        private Dictionary<DeviceRegistryPropertyKey, DeviceRegistryPropertyValue> _registryPropertyCache =
            new Dictionary<DeviceRegistryPropertyKey, DeviceRegistryPropertyValue>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="infoSet"></param>
        /// <param name="deviceInfoData"></param>
        internal DeviceInfo(DeviceInfoSet infoSet, SP_DEVINFO_DATA deviceInfoData)
        {
            infoSet.ThrowIfNull("infoSet");

            _infoSet = infoSet;
            _deviceInfoData = deviceInfoData;
        }

        /// <summary>
        /// Gets the device information set that this device belongs to.
        /// </summary>
        public DeviceInfoSet InfoSet
        {
            get { return _infoSet; }
        }

        /// <summary>
        /// Gets the API structure that identifies this device.
        /// </summary>
        internal SP_DEVINFO_DATA InfoData
        {
            get { return _deviceInfoData; }
        }

        /// <summary>
        /// Gets the display name of the device.
        /// </summary>
        public string Name
        {
            get { return GetProperty(DevicePropertyKeys.Name).GetValue<string>("<no name>"); }
        }

        /// <summary>
        /// Gets the instance ID of the device.
        /// </summary>
        public string InstanceId
        {
            get { return GetProperty(DevicePropertyKeys.Device.InstanceId).GetValue<string>(null); }
        }

        /// <summary>
        /// Gets whether the device is currently enabled.
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                var configFlagsValue = GetRegistryProperty(DeviceRegistryPropertyKeys.ConfigFlags);
                var configFlags = configFlagsValue.GetValue<ConfigurationFlags>(ConfigurationFlags.CONFIGFLAG_NONE);
                return !configFlags.IsFlagSet(ConfigurationFlags.CONFIGFLAG_DISABLED);
            }
        }

        /// <summary>
        /// Gets whether the device requires a reboot to complete a driver operation.
        /// </summary>
        public bool IsRebootNeeded
        {
            get { return GetProperty(DevicePropertyKeys.Device.IsRebootRequired).GetValue<bool>(false); }
        }

        /// <summary>
        /// Refreshes all of the cached device properties and device registry properties.
        /// </summary>
        public void Refresh()
        {
            foreach (var value in _propertyCache.Values)
            {
                value.ReadValue(this);
            }

            foreach (var value in _registryPropertyCache.Values)
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
                DevicePropertyValue value;
                if (_propertyCache.TryGetValue(key, out value))
                {
                    value.ReadValue(this);
                }
            }
        }

        /// <summary>
        /// Refreshes only the specified device registry properties, if they're currently cached.
        /// </summary>
        /// <param name="keys">Keys for the device registry properties to refresh.</param>
        public void Refresh(params DeviceRegistryPropertyKey[] keys)
        {
            keys.ThrowIfNull("keys");

            foreach (var key in keys)
            {
                DeviceRegistryPropertyValue value;
                if (_registryPropertyCache.TryGetValue(key, out value))
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
        public DevicePropertyValue GetProperty(DevicePropertyKey key)
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
        public DevicePropertyValue GetProperty(DevicePropertyKey key, bool forceRefresh)
        {
            key.ThrowIfNull("key");

            DevicePropertyValue value;
            // If the value isn't cached, read it.
            if (!_propertyCache.TryGetValue(key, out value))
            {
                value = new DevicePropertyValue(key);
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

        /// <summary>
        /// Gets the value of a device registry property.
        /// </summary>
        /// <param name="key">The key for the device registry property to get.</param>
        /// <returns>
        /// Return the property's value, if found, or <c>null</c> if the device does not support the property.
        /// </returns>
        /// <remarks>
        /// When a property is retrieved for the first time, its value will be stored in a cache. Further requests for
        /// the same property will be served from the cache.
        /// </remarks>
        public DeviceRegistryPropertyValue GetRegistryProperty(DeviceRegistryPropertyKey key)
        {
            return GetRegistryProperty(key, false);
        }

        /// <summary>
        /// Gets the value of a device registry property.
        /// </summary>
        /// <param name="key">The key for the device registry property to get.</param>
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
        public DeviceRegistryPropertyValue GetRegistryProperty(DeviceRegistryPropertyKey key, bool forceRefresh)
        {
            key.ThrowIfNull("key");

            DeviceRegistryPropertyValue value;
            // If the value isn't cached, read it.
            if (!_registryPropertyCache.TryGetValue(key, out value))
            {
                value = new DeviceRegistryPropertyValue(key);
                if (value.ReadValue(this))
                    _registryPropertyCache[key] = value;
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

        /// <summary>
        /// Gets an enumerator that lists all interfaces of a specific type for this device.
        /// </summary>
        /// <param name="deviceInterfaceId">Identifies the type of device interface to get.</param>
        /// <returns>
        /// An <see cref="IEnumerable{DeviceInterface}"/> containing all interfaces of the specified type for this
        /// device.
        /// </returns>
        public IEnumerable<DeviceInterface> GetInterfaces(Guid deviceInterfaceId)
        {
            for (var index = 0; ; ++index)
            {
                DeviceInterface deviceInterface;
                if (!SetupDi.EnumDeviceInterfaces(this, deviceInterfaceId, index, out deviceInterface))
                {
                    // When enumerating past the end of the set, a specific error will be returned.
                    // Any other error is unexpected and should be reported.
                    var lastError = ErrorHelpers.GetLastError();
                    if (lastError != ErrorCode.NoMoreItems)
                    {
                        throw ErrorHelpers.CreateException(lastError, "Unable to enumerate device interfaces.");
                    }

                    yield break;
                }

                yield return deviceInterface;
            }
        }

        /// <summary>
        /// Sets whether the device is enabled or disabled.
        /// </summary>
        /// <param name="isEnabled">
        /// If <c>true</c>, the device will be enabled. If <c>false</c>, the device will be disabled.
        /// </param>
        /// <remarks>
        /// This function checks the current state of the device. If it's already in the target state, no work is
        /// performed.
        /// 
        /// A reboot may be required for the new device state to take effect.
        /// </remarks>
        public void SetEnabled(bool isEnabled)
        {
            // Only change state if the current state doesn't match.
            if (IsEnabled != isEnabled)
            {
                // API flag for the new state.
                var newState = isEnabled ? DevicePropertyChangeState.DICS_ENABLE : DevicePropertyChangeState.DICS_DISABLE;

                // Set the device state property to the desired state.
                SetupDi.ChangeDeviceStateProperty(this, newState, DevicePropertyChangeScope.DICS_FLAG_GLOBAL);
                // Call the class installer to update the device with the desired state.
                SetupDi.CallClassInstaller(this, DeviceInstallFunction.DIF_PROPERTYCHANGE);

                // Refresh any cached device properties that are likely to have changed.
                Refresh(DevicePropertyKeys.Device.IsPresent, DevicePropertyKeys.Device.IsRebootRequired);
                Refresh(DeviceRegistryPropertyKeys.ConfigFlags);
            }
        }
    }
}
