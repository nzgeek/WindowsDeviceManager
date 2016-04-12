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
    public class DevicePropertyValue : PropertyValue<DevicePropertyKey, DevicePropertyType>
    {
        #region Default converter registration

        static DevicePropertyValue()
        {
            ConverterRegistry.Register(new BooleanConverter(), DevicePropertyType.Boolean);
            ConverterRegistry.Register(new GuidConverter(), DevicePropertyType.Guid);
            ConverterRegistry.Register(new SByteConverter(), DevicePropertyType.Int8);
            ConverterRegistry.Register(new Int16Converter(), DevicePropertyType.Int16);
            ConverterRegistry.Register(new Int32Converter(), DevicePropertyType.Int32);
            ConverterRegistry.Register(new Int64Converter(), DevicePropertyType.Int64);
            ConverterRegistry.Register(new ByteConverter(), DevicePropertyType.UInt8);
            ConverterRegistry.Register(new UInt16Converter(), DevicePropertyType.UInt16);
            ConverterRegistry.Register(new UInt32Converter(), DevicePropertyType.UInt32);
            ConverterRegistry.Register(new UInt64Converter(), DevicePropertyType.UInt64);
            ConverterRegistry.Register(new SecurityDescriptorConverter(), DevicePropertyType.SecurityDescriptor);
            ConverterRegistry.Register(new StringConverter(), DevicePropertyType.String,
                DevicePropertyType.SecurityDescriptorString);
            ConverterRegistry.Register(new StringListConverter(), DevicePropertyType.StringList);
        }

        #endregion

        public DevicePropertyValue(DevicePropertyKey key)
            : base(key)
        {
        }

        protected override bool LoadValue(DeviceInfo deviceInfo, out DevicePropertyType propertyType, out Api.Buffer buffer)
        {
            if (!SetupDi.GetDeviceProperty(deviceInfo, Key, out propertyType, out buffer))
            {
                // Only "not found" errors are valid failures.
                var lastError = ErrorHelpers.GetLastError();
                if (lastError == ErrorCode.NotFound)
                    return false;

                // Everything else is an unexpected failure.
                throw new DeviceManagerWindowsException("Unable to query device property.");
            }

            return true;
        }
    }
}
