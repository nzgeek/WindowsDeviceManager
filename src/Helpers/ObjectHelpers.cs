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

namespace WindowsDeviceManager.Helpers
{
    internal static class ObjectHelpers
    {
        public static bool Equals<T>(T lhs, object rhs, params Func<T, object>[] includeValues)
        {
            lhs.ThrowIfNull("lhs");
            includeValues.ThrowIfNull("includeValues");

            // Check whether both values point to the same object.
            if (ReferenceEquals(lhs, rhs))
            {
                return true;
            }

            // The left-hand side can't be null. If the right-hand side is null, it can't be equal.
            if (ReferenceEquals(rhs, null))
            {
                return false;
            }

            // If the right hand side is not of the same type, it can't be equal.
            if (!(rhs is T))
            {
                return false;
            }

            // Check the included values to check if they're equal.
            foreach (var includeValue in includeValues)
            {
                object lhsValue = includeValue(lhs);
                object rhsValue = includeValue((T)rhs);

                // Check if both values point to the same object (or both are null).
                if (!ReferenceEquals(lhsValue, rhsValue))
                {
                    // If either value is null, they can't be equal.
                    if (ReferenceEquals(lhsValue, null) || ReferenceEquals(rhsValue, null))
                    {
                        return false;
                    }

                    // Check for equality.
                    if (!lhsValue.Equals(rhsValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static int GetHashCode<T>(T obj, params Func<T, object>[] includeValues)
        {
            obj.ThrowIfNull("obj");
            includeValues.ThrowIfNull("includeValues");

            // Start with an empty hash code.
            int hashCode = 0;

            // The hash code needs to take into account the specified values.
            foreach (var includeValue in includeValues)
            {
                var value = includeValue(obj);

                // Update the hash code according to the value.
                unchecked
                {
                    hashCode *= 23;

                    if (value != null)
                        hashCode ^= value.GetHashCode();
                }
            }

            return hashCode;
        }

        public static int GetHashCode<T>(T obj, params object[] values)
        {
            obj.ThrowIfNull("obj");
            values.ThrowIfNull("values");

            // Start with an empty hash code.
            int hashCode = 0;

            // The hash code needs to take into account the specified values.
            foreach (var value in values)
            {
                // Update the hash code according to the value.
                unchecked
                {
                    hashCode *= 23;

                    if (value != null)
                        hashCode ^= value.GetHashCode();
                }
            }

            return hashCode;
        }
    }
}
