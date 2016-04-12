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
using System.Collections.Generic;
using System.Text;
using WindowsDeviceManager.Helpers;

namespace WindowsDeviceManager.ValueConverters
{
    public class StringListConverter : ValueConverter<string[]>
    {
        public override string[] BufferToValue(Api.Buffer buffer)
        {
            buffer.ThrowIfNull("buffer");

            // All strings to be returned.
            var result = new List<string>();

            // Variables used during the string conversions.
            var data = buffer.GetBytes();
            var offset = 0;
            var length = 0;

            // Don't go past the end of the data.
            while (offset < data.Length)
            {
                // Find out how many bytes are used for the string.
                for (length = 0; length + 2 <= data.Length; length += 2)
                {
                    if (data[offset + length] == 0 && data[offset + length + 1] == 0)
                        break;
                }

                // The list is terminate by a single empty string.
                if (length == 0)
                    break;

                // Get the string and add it to the result.
                var item = Encoding.Unicode.GetString(data, offset, length);
                result.Add(item);

                // Update the offset to point to the next string.
                offset += length + 2;
            }

            // Return the converted strings.
            return result.ToArray();
        }

        public override Api.Buffer ValueToBuffer(string[] value)
        {
            // Total bytes needed for all strings.
            var byteCount = 0;

            // Add up the size needed for each non-empty string.
            if (value != null)
            {
                foreach (var item in value)
                {
                    if (item.Length == 0)
                        continue;

                    // Include 2 bytes for the null terminator.
                    byteCount += Encoding.Unicode.GetByteCount(item) + 2;
                }
            }

            // If there's no data, the buffer should consist of 2 null terminators (4 empty bytes).
            if (byteCount == 0)
                return new Api.Buffer(new byte[4]);

            // The list is terminated by an additional null terminator.
            byteCount += 2;

            // Allocate space for the entire buffer.
            var bytes = new byte[byteCount];
            var offset = 0;

            // Add each string into the buffer.
            foreach (var item in value)
            {
                if (item.Length == 0)
                    continue;

                // Add the string at the next offset.
                var itemLength = Encoding.Unicode.GetBytes(item, 0, item.Length, bytes, offset);

                // Update the offset to include the added string length and null terminator.
                offset += itemLength + 2;
            }

            // Return the data as a buffer.
            return new Api.Buffer(bytes);
        }
    }
}
