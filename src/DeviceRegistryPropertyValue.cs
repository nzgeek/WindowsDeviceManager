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
using WindowsDeviceManager.Api;
using WindowsDeviceManager.ValueConverters;

namespace WindowsDeviceManager
{
    public class DeviceRegistryPropertyValue : PropertyValue<DeviceRegistryPropertyKey, DeviceRegistryPropertyType>
    {
        #region Default converter registration

        static DeviceRegistryPropertyValue()
        {
            ConverterRegistry.Register(new StringConverter(), DeviceRegistryPropertyType.String,
                DeviceRegistryPropertyType.ExpandString, DeviceRegistryPropertyType.ResourceList);

            ConverterRegistry.Register(new StringListConverter(), DeviceRegistryPropertyType.MultiString);

            ConverterRegistry.Register(new UInt32Converter(), DeviceRegistryPropertyType.DoubleWord,
                DeviceRegistryPropertyType.DoubleWordBigEndian);

            ConverterRegistry.Register(new UInt64Converter(), DeviceRegistryPropertyType.QuadWord);

            ConverterRegistry.Register(new ByteArrayConverter(), DeviceRegistryPropertyType.Binary);
        }

        #endregion

        public DeviceRegistryPropertyValue(DeviceRegistryPropertyKey key)
            : base(key)
        {
        }

        protected override bool LoadValue(DeviceInfo deviceInfo, out DeviceRegistryPropertyType propertyType, out Api.Buffer buffer)
        {
            if (!SetupDi.GetDeviceRegistryProperty(deviceInfo, Key, out propertyType, out buffer))
            {
                // Only "not found" errors are valid failures.
                var lastError = ErrorHelpers.GetLastError();
                if (lastError == ErrorCode.NotFound)
                    return false;

                // Everything else is an unexpected failure.
                throw new DeviceManagerWindowsException("Unable to query device registry property.");
            }

            return true;
        }
    }
}
