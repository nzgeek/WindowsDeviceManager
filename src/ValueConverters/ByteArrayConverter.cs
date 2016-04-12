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
    public class ByteArrayConverter : ValueConverter<byte[]>
    {
        public override byte[] BufferToValue(Api.Buffer buffer)
        {
            buffer.ThrowIfNull("buffer");

            return buffer.GetBytes();
        }

        public override Api.Buffer ValueToBuffer(byte[] value)
        {
            if (value == null || value.Length == 0)
            {
                return new Api.Buffer();
            }

            return new Api.Buffer(value);
        }
    }
}
