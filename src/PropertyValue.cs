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
using WindowsDeviceManager.Helpers  ;
using WindowsDeviceManager.ValueConverters;

namespace WindowsDeviceManager
{
    public abstract class PropertyValue<TPropertyKey, TPropertyType>
    {
        #region Value converter registry

        public static ValueConverterRegistry<TPropertyType> ConverterRegistry { get; private set; }

        static PropertyValue()
        {
            ConverterRegistry = new ValueConverterRegistry<TPropertyType>();
        }

        #endregion

        /// <summary>
        /// Creates a new <see cref="PropertyValue"/> with an empty value.
        /// </summary>
        protected PropertyValue(TPropertyKey key)
        {
            key.ThrowIfNull("key");

            Key = key;
            ValueType = default(TPropertyType);
            Value = null;
        }

        /// <summary>
        /// The property key associated with this value.
        /// </summary>
        public TPropertyKey Key { get; private set; }

        /// <summary>
        /// The unmanaged type of value contained in this 
        /// </summary>
        public TPropertyType ValueType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public TValue GetValue<TValue>()
        {
            return ConversionHelpers.Convert<TValue>(Value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public TValue GetValue<TValue>(TValue defaultValue)
        {
            TValue value;
            if (ConversionHelpers.TryConvert(Value, out value))
                return value;

            return defaultValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceInfo"></param>
        /// <returns></returns>
        public bool LoadValue(DeviceInfo deviceInfo)
        {
            deviceInfo.ThrowIfNull("deviceInfo");

            TPropertyType propertyType;
            Api.Buffer buffer;

            if (!LoadValue(deviceInfo, out propertyType, out buffer))
            {
                return false;
            }

            using (buffer)
            {
                // If there's no buffer to work with, set a null value.
                if (buffer == null || buffer.Length == 0)
                {
                    Value = null;
                }
                else
                {
                    // Get the appropriate value converter.
                    var valueConverter = ConverterRegistry.GetConverter(propertyType);
                    if (valueConverter == null)
                    {
                        // When there's no converter, just copy the data as a byte array.
                        Value = buffer.GetBytes();
                    }
                    else
                    {
                        // When there is a converter, use it.
                        Value = valueConverter.BufferToObject(buffer);
                    }
                }

                // The type is deliberately set after the value. This allows for errors trying to convert the loaded
                // value, as the existing value and type will be left untouched.
                ValueType = propertyType;

                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceInfo"></param>
        /// <param name="propertyType"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        protected abstract bool LoadValue(DeviceInfo deviceInfo, out TPropertyType propertyType, out Api.Buffer buffer);
    }
}
