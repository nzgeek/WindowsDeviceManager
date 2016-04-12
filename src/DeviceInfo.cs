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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsDeviceManager.Api;
using WindowsDeviceManager.Helpers;

namespace WindowsDeviceManager
{
    public class DeviceInfo
    {
        private DeviceInfoSet _infoSet;
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

        internal DeviceInfo(DeviceInfoSet infoSet, SP_DEVINFO_DATA deviceInfoData)
        {
            infoSet.ThrowIfNull("infoSet");

            _infoSet = infoSet;
            _deviceInfoData = deviceInfoData;
        }

        public DeviceInfoSet InfoSet
        {
            get { return _infoSet; }
        }

        internal SP_DEVINFO_DATA InfoData
        {
            get { return _deviceInfoData; }
        }

        public string Name
        {
            get { return GetProperty(DevicePropertyKeys.Name).GetValue<string>("<no name>"); }
        }

        public string InstanceId
        {
            get { return GetProperty(DevicePropertyKeys.Device.InstanceId).GetValue<string>(null); }
        }

        public bool IsEnabled
        {
            get
            {
                var configFlagsValue = GetRegistryProperty(DeviceRegistryPropertyKeys.ConfigFlags);
                var configFlags = configFlagsValue.GetValue<ConfigurationFlags>(ConfigurationFlags.None);
                return !configFlags.IsFlagSet(ConfigurationFlags.Disabled);
            }
        }

        public void Refresh()
        {
            foreach (var value in _propertyCache.Values)
            {
                value.LoadValue(this);
            }

            foreach (var value in _registryPropertyCache.Values)
            {
                value.LoadValue(this);
            }
        }

        public DevicePropertyValue GetProperty(DevicePropertyKey key)
        {
            key.ThrowIfNull("key");

            DevicePropertyValue value;
            if (!_propertyCache.TryGetValue(key, out value))
            {
                value = new DevicePropertyValue(key);
                if (value.LoadValue(this))
                    _propertyCache[key] = value;
                else
                    value = null;
            }

            return value;
        }

        public DeviceRegistryPropertyValue GetRegistryProperty(DeviceRegistryPropertyKey key)
        {
            key.ThrowIfNull("key");

            DeviceRegistryPropertyValue value;
            if (!_registryPropertyCache.TryGetValue(key, out value))
            {
                value = new DeviceRegistryPropertyValue(key);
                if (value.LoadValue(this))
                    _registryPropertyCache[key] = value;
                else
                    value = null;
            }

            return value;
        }
    }
}
