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

namespace WindowsDeviceManager.ValueConverters
{
    /// <summary>
    /// Converts values of a specific type to an from an unmanaged form.
    /// </summary>
    public interface IValueConverter
    {
        /// <summary>
        /// Gets the type of value that this converter handles.
        /// </summary>
        Type ValueType { get; }

        /// <summary>
        /// Converts a value from an unmanaged format to its supported form.
        /// </summary>
        /// <param name="buffer">A <see cref="Api.Buffer"/> containing the unmanaged form of the value.</param>
        /// <returns>The supported form of the data in the buffer.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="buffer"/> is <c>null</c>.</exception>
        object BufferToObject(Api.Buffer buffer);

        /// <summary>
        /// Converts a value of the supported type to its unmanaged form.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="Api.Buffer"/> containing the value in its unmanaged form.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not an instance of the supported type.</exception>
        Api.Buffer ObjectToBuffer(object value);
    }

    /// <summary>
    /// Converts values of a specific type to an from an unmanaged form.
    /// </summary>
    /// <typeparam name="TValue">The supported type of data.</typeparam>
    public interface IValueConverter<TValue> : IValueConverter
    {
        /// <summary>
        /// Converts a value from an unmanaged format to its supported form.
        /// </summary>
        /// <param name="buffer">A <see cref="Api.Buffer"/> containing the unmanaged form of the value.</param>
        /// <returns>The supported form of the data in the buffer.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="buffer"/> is <c>null</c>.</exception>
        TValue BufferToValue(Api.Buffer buffer);

        /// <summary>
        /// Converts a value of the supported type to its unmanaged form.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A <see cref="Api.Buffer"/> containing the value in its unmanaged form.</returns>
        /// <exception cref="ArgumentException">Thrown if <paramref name="value"/> is not an instance of the supported type.</exception>
        Api.Buffer ValueToBuffer(TValue value);
    }
}
