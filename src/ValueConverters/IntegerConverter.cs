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
    public abstract class IntegerConverter<TInteger> : ValueConverter<TInteger>
    {
        protected readonly Func<byte[], TInteger> _fromBytes;
        protected readonly Func<TInteger, byte[]> _toBytes;

        protected IntegerConverter(Func<byte[], TInteger> fromBytes, Func<TInteger, byte[]> toBytes)
        {
            fromBytes.ThrowIfNull("fromBytes");
            toBytes.ThrowIfNull("toBytes");

            _fromBytes = fromBytes;
            _toBytes = toBytes;
        }

        public override TInteger BufferToValue(Api.Buffer buffer)
        {
            buffer.ThrowIfNull("buffer");

            var integerSize = Marshal.SizeOf(typeof(TInteger));
            var bytes = buffer.GetBytes(0, integerSize);
            return _fromBytes(bytes);
        }

        public override Api.Buffer ValueToBuffer(TInteger value)
        {
            var bytes = _toBytes(value);
            return new Api.Buffer(bytes);
        }
    }

    // Signed types

    public class SByteConverter : IntegerConverter<sbyte>
    {
        public SByteConverter()
            : base(bytes => unchecked((sbyte)bytes[0]), value => new byte[] { unchecked((byte)value) })
        {
        }
    }

    public class Int16Converter : IntegerConverter<Int16>
    {
        public Int16Converter()
            : base(bytes => BitConverter.ToInt16(bytes, 0), BitConverter.GetBytes)
        {
        }
    }

    public class Int32Converter : IntegerConverter<Int32>
    {
        public Int32Converter()
            : base(bytes => BitConverter.ToInt32(bytes, 0), BitConverter.GetBytes)
        {
        }
    }

    public class Int64Converter : IntegerConverter<Int64>
    {
        public Int64Converter()
            : base(bytes => BitConverter.ToInt64(bytes, 0), BitConverter.GetBytes)
        {
        }
    }

    // Unsigned types

    public class ByteConverter : IntegerConverter<byte>
    {
        public ByteConverter()
            : base(bytes => bytes[0], value => new byte[] { value })
        {
        }
    }

    public class UInt16Converter : IntegerConverter<UInt16>
    {
        public UInt16Converter()
            : base(bytes => BitConverter.ToUInt16(bytes, 0), BitConverter.GetBytes)
        {
        }
    }

    public class UInt32Converter : IntegerConverter<UInt32>
    {
        public UInt32Converter()
            : base(bytes => BitConverter.ToUInt32(bytes, 0), BitConverter.GetBytes)
        {
        }
    }

    public class UInt64Converter : IntegerConverter<UInt64>
    {
        public UInt64Converter()
            : base(bytes => BitConverter.ToUInt64(bytes, 0), BitConverter.GetBytes)
        {
        }
    }
}
