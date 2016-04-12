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
using System.Text;
using WindowsDeviceManager.Helpers;

namespace WindowsDeviceManager.ValueConverters
{
    public class StringConverter : ValueConverter<string>
    {
        public override string BufferToValue(Api.Buffer buffer)
        {
            buffer.ThrowIfNull("buffer");

            var bytes = buffer.GetBytes();

            // Figure out how much data there is, ignoring any null terminator.
            var byteLength = bytes.Length;
            if (byteLength > 2 && bytes[byteLength - 1] == 0 && bytes[byteLength - 2] == 0)
                byteLength -= 2;

            return Encoding.Unicode.GetString(bytes, 0, byteLength);
        }

        public override Api.Buffer ValueToBuffer(string value)
        {
            // Empty strings become just a null terminator.
            if (string.IsNullOrEmpty(value))
                return new Api.Buffer(new byte[2]);

            // Get the number of bytes needed for the string plus the null terminator.
            var byteCount = Encoding.Unicode.GetByteCount(value) + 2;

            // Convert the string into bytes, leaving room for the null terminator.
            var bytes = new byte[byteCount];
            Encoding.Unicode.GetBytes(value, 0, value.Length, bytes, 0);

            return new Api.Buffer(bytes);
        }
    }
}
