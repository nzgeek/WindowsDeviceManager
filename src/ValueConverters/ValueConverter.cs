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
using WindowsDeviceManager.Helpers;

namespace WindowsDeviceManager.ValueConverters
{
    public abstract class ValueConverter : IValueConverter
    {
        #region Static methods

        /// <summary>
        /// Contains all registered value converters.
        /// </summary>
        public static ValueConverterRegistry<Type> Registry { get; private set; }

        /// <summary>
        /// Initializes the default set of <see cref="ValueConverter">ValueConverters</see>.
        /// </summary>
        static ValueConverter()
        {
            Registry = new ValueConverterRegistry<Type>();

            RegisterConverter(new BooleanConverter());
            RegisterConverter(new ByteArrayConverter());
            RegisterConverter(new GuidConverter());
            RegisterConverter(new SByteConverter());
            RegisterConverter(new Int16Converter());
            RegisterConverter(new Int32Converter());
            RegisterConverter(new Int64Converter());
            RegisterConverter(new ByteConverter());
            RegisterConverter(new UInt16Converter());
            RegisterConverter(new UInt32Converter());
            RegisterConverter(new UInt64Converter());
            RegisterConverter(new SecurityDescriptorConverter());
            RegisterConverter(new StringConverter());
            RegisterConverter(new StringListConverter());
        }

        /// <summary>
        /// Attempts to register a new value converter.
        /// </summary>
        /// <param name="converter"></param>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public static bool RegisterConverter(IValueConverter converter, bool overwrite = false)
        {
            converter.ThrowIfNull("converter");

            return Registry.Register(converter.ValueType, converter, overwrite);
        }

        public static IValueConverter GetConverter<TResult>()
        {
            return GetConverter(typeof(TResult));
        }

        public static IValueConverter GetConverter<TResult>(bool checkParentTypes)
        {
            return GetConverter(typeof(TResult), checkParentTypes);
        }

        public static IValueConverter GetConverter(Type targetType)
        {
            return GetConverter(targetType, false);
        }

        public static IValueConverter GetConverter(Type targetType, bool checkParentTypes)
        {
            targetType.ThrowIfNull("targetType");

            // Allow recursive checking of the type chain.
            while (targetType != null && targetType != typeof(object))
            {
                // Check if there's a type converter for the current type.
                IValueConverter valueConverter = Registry.GetConverter(targetType);
                if (valueConverter != null)
                {
                    return valueConverter;
                }

                // If not checking parent types then return failure now.
                if (!checkParentTypes)
                {
                    return null;
                }

                // Check the parent type next.
                targetType = targetType.BaseType;
            }

            return null;
        }

        #endregion

        /// <summary>
        /// Gets the type of value that this converter handles.
        /// </summary>
        public abstract Type ValueType { get; }

        /// <summary>
        /// Converts a value from an unmanaged format to its supported form.
        /// </summary>
        /// <param name="buffer">A <see cref="Api.Buffer"/> containing the unmanaged form of the value.</param>
        /// <returns>The supported form of the data in the buffer.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="buffer"/> is <c>null</c>.</exception>
        public abstract object BufferToObject(Api.Buffer buffer);

        /// <summary>
        /// Converts a value of the supported type to its unmanaged form.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="Api.Buffer"/> containing the value in its unmanaged form.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not an instance of the supported type.</exception>
        public abstract Api.Buffer ObjectToBuffer(object value);
    }

    public abstract class ValueConverter<TValue> : ValueConverter, IValueConverter<TValue>
    {
        /// <summary>
        /// Gets the type of value that this converter handles.
        /// </summary>
        public override Type ValueType
        {
            get { return typeof(TValue); }
        }

        /// <summary>
        /// Converts a value from an unmanaged format to its supported form.
        /// </summary>
        /// <param name="buffer">A <see cref="Api.Buffer"/> containing the unmanaged form of the value.</param>
        /// <returns>The supported form of the data in the buffer.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="buffer"/> is <c>null</c>.</exception>
        public override object BufferToObject(Api.Buffer buffer)
        {
            buffer.ThrowIfNull("buffer");

            return BufferToValue(buffer);
        }

        /// <summary>
        /// Converts a value from an unmanaged format to its supported form.
        /// </summary>
        /// <param name="buffer">A <see cref="Api.Buffer"/> containing the unmanaged form of the value.</param>
        /// <returns>The supported form of the data in the buffer.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="buffer"/> is <c>null</c>.</exception>
        public abstract TValue BufferToValue(Api.Buffer buffer);

        /// <summary>
        /// Converts a value of the supported type to its unmanaged form.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="Api.Buffer"/> containing the value in its unmanaged form.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not an instance of the supported type.</exception>
        public override Api.Buffer ObjectToBuffer(object value)
        {
            if (typeof(TValue).IsValueType)
            {
                value.ThrowIfNull("value");
            }

            TValue valueToConvert;
            if (!ConversionHelpers.TryConvert(value, out valueToConvert))
            {
                throw new ArgumentException("Value to convert is an unsupported type.", "value");
            }

            return ValueToBuffer(valueToConvert);
        }

        /// <summary>
        /// Converts a value of the supported type to its unmanaged form.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="Api.Buffer"/> containing the value in its unmanaged form.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not an instance of the supported type.</exception>
        public abstract Api.Buffer ValueToBuffer(TValue value);
    }
}
