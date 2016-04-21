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
    /// <summary>
    /// A base class for dealing with unmanaged property values for Windows device manager objects.
    /// </summary>
    /// <typeparam name="TObject">The type of object that properties belong to.</typeparam>
    /// <typeparam name="TPropertyKey">The type of object used as a key for properties.</typeparam>
    /// <typeparam name="TPropertyType">A type that helps identify the type of data stored in a value.</typeparam>
    public abstract class PropertyValue<TObject, TPropertyKey, TPropertyType>
    {
        #region Value converter registry

        /// <summary>
        /// Gets the value converter registry for the current property type.
        /// </summary>
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
        /// The value of the property.
        /// </summary>
        /// <remarks>
        /// If a converter is registered for the property's value type, the value should be of the corresponding
        /// managed type. If no such converter is registered, the value should be a <see cref="byte[]"/> containing the
        /// data in its unmanaged representation.
        /// </remarks>
        public object Value { get; set; }

        /// <summary>
        /// Gets the value converted to the specified type.
        /// </summary>
        /// <typeparam name="TValue">The type of value to be retrieved.</typeparam>
        /// <returns>The value converted to the specified type.</returns>
        /// <remarks>
        /// An exception may be thrown if the underlying value cannot be converted to the target type.
        /// </remarks>
        public TValue GetValue<TValue>()
        {
            return ConversionHelpers.Convert<TValue>(Value);
        }

        /// <summary>
        /// Gets the property value converted to the specified type, falling back to a default value if the conversion
        /// was unsuccessful.
        /// </summary>
        /// <typeparam name="TValue">The type of value to be retrieved.</typeparam>
        /// <param name="defaultValue">The value to return if conversion fails.</param>
        /// <returns>
        /// The value converted to the specified type, or <paramref name="defaultValue"/> if the property value could
        /// not successfully be converted.
        /// </returns>
        public TValue GetValue<TValue>(TValue defaultValue)
        {
            TValue value;
            if (ConversionHelpers.TryConvert(Value, out value))
                return value;

            return defaultValue;
        }

        /// <summary>
        /// Reads the property value from the specified object.
        /// </summary>
        /// <param name="obj">The object to read the property value from.</param>
        /// <returns>
        /// Returns <c>true</c> if the property was read successfully, or <c>false</c> if the property is not
        /// available for the specified object.
        /// </returns>
        /// <exception cref="DeviceManagerSecurityException">
        /// Thrown if the property value cannot be read due to the user having insufficient access rights.
        /// </exception>
        /// <exception cref="DeviceManagerException">
        /// Throw if an unexpected error occurs while trying to read the value.
        /// </exception>
        public bool ReadValue(TObject obj)
        {
            obj.ThrowIfNull("obj");

            TPropertyType propertyType;
            Api.Buffer buffer;

            if (!ReadValue(obj, out propertyType, out buffer))
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
        /// Reads the value of the property from the specified object.
        /// </summary>
        /// <param name="obj">The object to read the property from.</param>
        /// <param name="propertyType">Receives the data type of the property.</param>
        /// <param name="buffer">Receives the raw data that contain the property value.</param>
        /// <returns>
        /// Returns <c>true</c> if the property was read successfully, or <c>false</c> if the property is not
        /// available for the specified object.
        /// </returns>
        /// <exception cref="DeviceManagerSecurityException">
        /// Thrown if the property value cannot be read due to the user having insufficient access rights.
        /// </exception>
        /// <exception cref="DeviceManagerException">
        /// Throw if an unexpected error occurs while trying to read the value.
        /// </exception>
        protected abstract bool ReadValue(TObject obj, out TPropertyType propertyType, out Api.Buffer buffer);
    }
}
