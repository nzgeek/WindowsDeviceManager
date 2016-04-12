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
using System.Globalization;

namespace WindowsDeviceManager.Helpers
{
    internal static class UtilityExtensions
    {
        public static void ThrowIfNull(this object value, string paramName)
        {
            if (ReferenceEquals(value, null))
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void ThrowIfNullOrEmpty(this string value, string paramName, string message)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(message, paramName);
            }
        }

        public static void ThrowIfNullOrEmpty(this string value, string paramName, string format, params object[] args)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(string.Format(format, args), paramName);
            }
        }

        public static bool IsFlagSet<TValue>(this TValue currentFlags, TValue checkFlag)
            where TValue : struct, IConvertible
        {
            var currentValue = currentFlags.ToUInt64(CultureInfo.InvariantCulture);
            var checkValue = checkFlag.ToUInt64(CultureInfo.InvariantCulture);

            return (currentValue & checkValue) == checkValue;
        }
    }
}
