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
using System.Runtime.InteropServices;
using WindowsDeviceManager.Helpers;

namespace WindowsDeviceManager.ValueConverters
{
    class StructConverter<TStruct> : ValueConverter<TStruct>
        where TStruct : struct
    {
        public override TStruct BufferToValue(Api.Buffer buffer)
        {
            buffer.ThrowIfNull("buffer");

            // Construct a new TStruct from the data in the buffer.
            var value = Marshal.PtrToStructure(buffer.Data, typeof(TStruct));
            return (TStruct)value;
        }

        public override Api.Buffer ValueToBuffer(TStruct value)
        {
            // Allocate a new buffer of the right size to hold the value.
            var valueSize = Marshal.SizeOf(typeof(TStruct));
            var buffer = new Api.Buffer(valueSize);

            // Copy the struct's contents into the buffer. The existing value doesn't need to be freed because the
            // buffer hasn't held anything yet.
            Marshal.StructureToPtr(value, buffer.Data, false);

            return buffer;
        }
    }
}
