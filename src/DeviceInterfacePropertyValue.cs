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
    public class DeviceInterfacePropertyValue : PropertyValue<DeviceInterface, DevicePropertyKey, DevicePropertyType>
    {
        #region Default converter registration

        static DeviceInterfacePropertyValue()
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

        /// <summary>
        /// Constructs a device property value.
        /// </summary>
        /// <param name="key">The device property key that this value relates to.</param>
        public DeviceInterfacePropertyValue(DevicePropertyKey key)
            : base(key)
        {
        }

        /// <summary>
        /// Reads the value of the property from the specified device interface.
        /// </summary>
        /// <param name="deviceInterface">The device interface to read the property from.</param>
        /// <param name="propertyType">Receives the data type of the property.</param>
        /// <param name="buffer">Receives the raw data that contain the property value.</param>
        /// <returns>
        /// Returns <c>true</c> if the property was read successfully, or <c>false</c> if the property is not
        /// available for the specified device interface.
        /// </returns>
        /// <exception cref="DeviceManagerSecurityException">
        /// Thrown if the property value cannot be read due to the user having insufficient access rights.
        /// </exception>
        /// <exception cref="DeviceManagerWindowsException">
        /// Throw if an unexpected error occurs while trying to read the value.
        /// </exception>
        protected override bool ReadValue(DeviceInterface deviceInterface, out DevicePropertyType propertyType,
            out Api.Buffer buffer)
        {
            if (!SetupDi.GetDeviceInterfaceProperty(deviceInterface, Key, out propertyType, out buffer))
            {
                // Only "not found" errors are valid failures.
                var lastError = ErrorHelpers.GetLastError();
                if (lastError == ErrorCode.NotFound)
                {
                    return false;
                }

                // Everything else is an unexpected failure.
                throw ErrorHelpers.CreateException(lastError, "Unable to query device interface property.");
            }

            return true;
        }
    }
}
