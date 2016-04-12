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
using System.ComponentModel;
using System.Reflection;
using WindowsDeviceManager.Helpers;

namespace WindowsDeviceManager.ValueConverters
{
    /// <summary>
    /// Helper functions for converting values between types.
    /// </summary>
    public static class ConversionHelpers
    {
        /// <summary>
        /// Checks whether the supplied value can be converted to a given type.
        /// </summary>
        /// <typeparam name="TResult">The type of value being converted to.</typeparam>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Returns <c>true</c> if the conversion can take place, or <c>false</c> otherwise.</returns>
        /// <remarks>
        /// This function calls <see cref="TryConvert{TResult}(object, out TResult)"/> to check whether the conversion
        /// will succeed or not.
        /// </remarks>
        public static bool CanConvert<TResult>(object value)
        {
            TResult convertedValue;
            return TryConvert(value, out convertedValue);
        }

        /// <summary>
        /// Converts the supplied value to a given type.
        /// </summary>
        /// <typeparam name="TResult">The type of value being converted to.</typeparam>
        /// <param name="value">The value to be converted.</param>
        /// <returns>Returns <paramref name="value"/> converted to a <typeparamref name="TResult"/>.</returns>
        /// <exception cref="InvalidCastException">
        /// Thrown if the value cannot be converted to a <typeparamref name="TResult"/>.
        /// </exception>
        public static TResult Convert<TResult>(object value)
        {
            TResult convertedValue;
            if (!TryConvert(value, out convertedValue))
            {
                var message = string.Format("Cannot convert value to type '{0}'.", typeof(TResult).FullName);
                throw new InvalidCastException(message);
            }

            return convertedValue;
        }

        /// <summary>
        /// Attempts to convert the supplied value to a given type.
        /// </summary>
        /// <typeparam name="TResult">The type of value being converted to.</typeparam>
        /// <param name="value">The value to be converted.</param>
        /// <param name="resultValue">
        /// Upon return, holds the converted form of <paramref name="value"/> if the conversion was successful, or the
        /// default value of <typeparamref name="TResult"/> if the conversion failed.
        /// </param>
        /// <returns>Returns <c>true</c> if the conversion was successful, or <c>false</c> otherwise.</returns>
        public static bool TryConvert<TResult>(object value, out TResult resultValue)
        {
            // If there's no known way to convert between the types, the conversion immediately fails.
            var convertedValue = GetConvertedValueFunction<TResult>(value);
            if (convertedValue == null)
            {
                resultValue = default(TResult);
                return false;
            }

            // Conversions between certain types may fail, even though the types involved support the conversion.
            // Use a try/catch block to handle these types of failures correctly.
            try
            {
                resultValue = convertedValue();
                return true;
            }
            catch
            {
                resultValue = default(TResult);
                return false;
            }
        }

        /// <summary>
        /// Returns a function that gets the value of <paramref name="value"/> as a <typeparamref name="TResult"/>.
        /// </summary>
        /// <typeparam name="TResult">The type of value being converted to.</typeparam>
        /// <param name="value">The value being converted from.</param>
        /// <returns>
        /// A function that returns the cast value, if the cast is possible, or <c>null</c> if the cast is not valid.
        /// </returns>
        internal static Func<TResult> GetConvertedValueFunction<TResult>(object value)
        {
            var targetType = typeof(TResult);

            if (ReferenceEquals(value, null))
            {
                // Null values cannot be converted into a value type.
                if (targetType.IsValueType)
                {
                    return null;
                }

                // Null is a valid value for all reference types.
                return () => (TResult)value;
            }

            var sourceType = value.GetType();

            // If there's an implicit or explicit cast operation between the types, use it.
            var typeCastFunction = GetCastFunction<TResult>(sourceType);
            if (typeCastFunction != null)
            {
                return () => typeCastFunction(value);
            }

            // If converting to an enum and the source type can be converted to a numeric value, allow the conversion.
            var enumFunction = GetEnumFunction<TResult>(sourceType);
            if (enumFunction != null)
            {
                return () => enumFunction(value);
            }

            // If the type converter system supports the conversion, use it.
            var typeConverterFunction = GetConversionFunction<TResult>(sourceType);
            if (typeConverterFunction != null)
            {
                return () => typeConverterFunction(value);
            }

            // No conversion available.
            return null;
        }

        /// <summary>
        /// Gets a function that casts <paramref name="value"/> to a <typeparamref name="TResult"/>, if such a cast is
        /// possible.
        /// </summary>
        /// <typeparam name="TResult">The type of value being converted to.</typeparam>
        /// <param name="sourceType">The type of value being converted from.</param>
        /// <returns>Returns a function to perform the cast operation, if one exists, or <c>null</c> otherwise.</returns>
        private static Func<object, TResult> GetCastFunction<TResult>(Type sourceType)
        {
            sourceType.ThrowIfNull("sourceType");
            var targetType = typeof(TResult);

            // Check if this is a direct cast to the value's own type or a superclass.
            if (sourceType == targetType || sourceType.IsSubclassOf(targetType))
            {
                return value => (TResult)value;
            }

            // Check if there's an implicit cast operator method between the types.
            var implicitCast = targetType.GetMethod("op_Implicit", BindingFlags.Public | BindingFlags.Static, null,
                new[] { sourceType }, new ParameterModifier[0]);
            if (implicitCast != null)
            {
                return value => (TResult)implicitCast.Invoke(null, new object[] { value });
            }

            // Check to see if there's an explicit cast operator method between the types.
            var explicitCast = targetType.GetMethod("op_Explicit", BindingFlags.Public | BindingFlags.Static, null,
                new[] { sourceType }, new ParameterModifier[0]);
            if (explicitCast != null)
            {
                return value => (TResult)explicitCast.Invoke(null, new object[] { value });
            }

            // No cast operators are defined.
            return null;
        }

        /// <summary>
        /// Checks a function that converts between the specified types using a <see cref="TypeConverter"/>, if any
        /// such conversion is possible.
        /// </summary>
        /// <typeparam name="TResult">The type of value being converted to.</typeparam>
        /// <param name="sourceType">The type of value being converted from.</param>
        /// <returns>Returns a function to perform the conversion, if one exists, or <c>null</c> otherwise.</returns>
        private static Func<object, TResult> GetConversionFunction<TResult>(Type sourceType)
        {
            sourceType.ThrowIfNull("sourceType");
            var targetType = typeof(TResult);

            // Check whether the TypeConverter system supports the source type being converted to the target type.
            var sourceConverter = TypeDescriptor.GetConverter(sourceType);
            if (sourceConverter != null && sourceConverter.CanConvertTo(targetType))
            {
                return value => (TResult)sourceConverter.ConvertTo(value, targetType);
            }

            // Check whether the TypeConverter system supports the target type being converted from the source type.
            var targetConverter = TypeDescriptor.GetConverter(targetType);
            if (targetConverter != null && targetConverter.CanConvertFrom(sourceType))
            {
                return value => (TResult)targetConverter.ConvertFrom(value);
            }

            // Not supported using the TypeConverter system.
            return null;
        }

        /// <summary>
        /// Checks whether the value can be converted to or from an enum.
        /// </summary>
        /// <typeparam name="TResult">The type of value being converted to.</typeparam>
        /// <param name="sourceType">The type of value being converted from.</param>
        /// <returns>Returns a function to perform the conversion, if one exists, or <c>null</c> otherwise.</returns>
        private static Func<object, TResult> GetEnumFunction<TResult>(Type sourceType)
        {
            sourceType.ThrowIfNull("sourceType");
            var targetType = typeof(TResult);

            // Only support conversions to an enum type.
            if (!targetType.IsEnum)
            {
                return null;
            }

            // See if there's a known way to convert the source value to a 64-bit integer.
            var valueFunction = GetCastFunction<long>(sourceType) ??
                GetConversionFunction<long>(sourceType);

            // If the source value can't be converted to an integer, the result can't be converted.
            if (valueFunction == null)
            {
                return null;
            }

            // Convert the incoming value to an enum of the correct type.
            return value =>
            {
                var numericValue = valueFunction(value);
                return (TResult)Enum.ToObject(targetType, numericValue);
            };
        }
    }
}
