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
using System.Linq;
using WindowsDeviceManager.Helpers;

namespace WindowsDeviceManager.ValueConverters
{
    public class BooleanConverter : ValueConverter<bool>
    {
        private byte FalseValue = 0x00;
        private byte TrueValue = 0xFF;

        public override bool BufferToValue(Api.Buffer buffer)
        {
            buffer.ThrowIfNull("buffer");

            var bytes = buffer.GetBytes();
            return bytes.Any(b => b != 0);
        }

        public override Api.Buffer ValueToBuffer(bool value)
        {
            var bytes = new byte[] { value ? TrueValue : FalseValue };
            return new Api.Buffer(bytes);
        }
    }
}
