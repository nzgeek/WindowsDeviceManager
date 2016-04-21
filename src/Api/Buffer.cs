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

namespace WindowsDeviceManager.Api
{
    /// <summary>
    /// A data buffer for working with unmanaged memory.
    /// </summary>
    public class Buffer : IDisposable
    {
        /// <summary>
        /// Maximum amount of memory that can be allocated.
        /// </summary>
        private const int MaxAllocationSize = 0x3FFFFFFF;

        /// <summary>
        /// Memory blocks will always be allocated in multiples of this size in bytes.
        /// </summary>
        private const int AllocationGranularity = 16;

        #region IDisposable Support
        private bool _disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                Free();

                _disposed = true;
            }
        }

        ~Buffer()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        /// <summary>
        /// A pointer to the unmanaged memory region.
        /// </summary>
        private IntPtr _buffer = IntPtr.Zero;

        /// <summary>
        /// The amount of memory currently allocated.
        /// </summary>
        private int _allocatedLength = 0;

        /// <summary>
        /// The amount of memory currently advertised as being allocated.
        /// </summary>
        private int _length = 0;

        /// <summary>
        /// If a structure is marshaled into unmanaged memory, this holds the type of that structure.
        /// </summary>
        private Type _structureType = null;

        /// <summary>
        /// Creates a new, empty buffer.
        /// </summary>
        public Buffer()
        {
        }

        /// <summary>
        /// Creates a new buffer of the given size.
        /// </summary>
        /// <param name="sizeBytes">The amount of memory to allocate, in bytes.</param>
        public Buffer(int sizeBytes)
        {
            Resize(sizeBytes);
        }

        /// <summary>
        /// Creates a buffer with the specified contents.
        /// </summary>
        public Buffer(byte[] value)
        {
            if (value == null)
                throw new ArgumentException("value");

            SetBytes(value, 0, value.Length);
        }

        /// <summary>
        /// Resizes the buffer to the indicated length in bytes.
        /// </summary>
        /// <param name="length">The new length of the buffer, in bytes.</param>
        /// <remarks>
        /// After resizing, the buffer may point to a new block of unmanaged memory. If a new unmanaged memory block is
        /// used, the contents of the memory are not copied across.
        /// </remarks>
        public void Resize(int length)
        {
            if (length < 0 || length > MaxAllocationSize)
                throw new ArgumentOutOfRangeException("length", "Invalid buffer length.");

            // If the memory currently holds a marshaled structure, destroy it.
            if (_structureType != null)
            {
                Marshal.DestroyStructure(_buffer, _structureType);
                _structureType = null;
            }

            // If the amount needed is more than what's currently available, allocate a bigger block.
            if (length > _allocatedLength)
            {
                Free();

                // Round the requested length up to the nearest multiple of AllocationGranularity.
                var allocatedLength = (length + AllocationGranularity - 1) / AllocationGranularity;
                allocatedLength *= AllocationGranularity;

                // Allocate the new buffer.
                _buffer = Marshal.AllocHGlobal(allocatedLength);
                _allocatedLength = allocatedLength;
            }

            // Set the apparent length of the buffer.
            _length = length;
        }

        /// <summary>
        /// Truncates the buffer to the specified length.
        /// </summary>
        /// <param name="length">
        /// The new length of the buffer, in bytes. This must be a value between 0 and the current buffer length;
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the new length is less than 0 or greater than the current buffer length.
        /// </exception>
        /// <remarks>
        /// After truncation, the buffer will continue to point to the same piece of unmanaged memory.
        /// </remarks>
        public void Truncate(int length)
        {
            if (length < 0 || length > _length)
            {
                throw new ArgumentOutOfRangeException("length", "Invalid truncated length.");
            }

            if (_structureType != null)
            {
                throw new InvalidOperationException("Cannot truncate the length of a structure.");
            }

            _length = length;
        }

        /// <summary>
        /// Frees any memory that has been allocated.
        /// </summary>
        public void Free()
        {
            if (_buffer != IntPtr.Zero)
            {
                // If the memory currently holds a marshaled structure, destroy it.
                if (_structureType != null)
                {
                    Marshal.DestroyStructure(_buffer, _structureType);
                    _structureType = null;
                }

                // Free the unmanaged memory.
                Marshal.FreeHGlobal(_buffer);
                _buffer = IntPtr.Zero;

                // Set the length to zero.
                _length = 0;
                _allocatedLength = 0;
            }
        }

        /// <summary>
        /// Gets a pointer to the unmanaged memory block.
        /// </summary>
        public IntPtr Data
        {
            get { return _buffer; }
        }

        /// <summary>
        /// Gets the length of the buffer, in bytes.
        /// </summary>
        public int Length
        {
            get { return _length; }
        }

        /// <summary>
        /// Gets the contents of the unmanaged memory block as a byte array.
        /// </summary>
        /// <returns>A <see cref="byte[]"/> containing the contents of the allocated memory.</returns>
        public byte[] GetBytes()
        {
            return GetBytes(0, _length);
        }

        /// <summary>
        /// Gets the contents of a portion of the unmanaged memory block as a byte array.
        /// </summary>
        /// <param name="offset">The offset into the memory block, in bytes.</param>
        /// <param name="length">The amount of memory to get, in bytes.</param>
        /// <returns>A <see cref="byte[]"/> containing the requested contents of the allocated memory.</returns>
        public byte[] GetBytes(int offset, int length)
        {
            if (offset < 0 || offset >= _length)
            {
                throw new ArgumentOutOfRangeException("offset", "Offset is outside of the allocated memory block.");
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", "Cannot read a negative number of bytes.");
            }

            if (offset + length > _length)
            {
                throw new ArgumentOutOfRangeException("length", "Size to read is too large for the allocated memory block.");
            }

            // Read the data out of unmanaged memory into a byte array.
            var result = new byte[length];
            for (var i = 0; i < length; ++i)
            {
                result[i] = Marshal.ReadByte(_buffer, offset + i);
            }

            return result;
        }

        /// <summary>
        /// Sets the contents of the buffer to the supplied value.
        /// </summary>
        /// <param name="value">The value to place in the buffer.</param>
        public void SetBytes(byte[] value)
        {
            if (value == null)
                throw new ArgumentException("value");

            SetBytes(value, 0, value.Length);
        }

        /// <summary>
        /// Sets the contents of the buffer to a portion of the supplied value.
        /// </summary>
        /// <param name="value">A value containing the portion to set into the buffer.</param>
        /// <param name="offset">The offset into the portion to set, in bytes.</param>
        /// <param name="length">The length of the portion to set, in bytes.</param>
        public void SetBytes(byte[] value, int offset, int length)
        {
            if (value == null)
                throw new ArgumentException("value");

            if (offset < 0 || offset >= value.Length)
                throw new ArgumentOutOfRangeException("offset", "Offset is outside of the supplied value.");

            if (length < 0)
                throw new ArgumentOutOfRangeException("length", "Cannot set a negative number of bytes.");

            if (offset + length > value.Length)
                throw new ArgumentOutOfRangeException("length", "Size to set is too large for the supplied value.");

            Resize(length);

            for (var i = 0; i < length; ++i)
                Marshal.WriteByte(_buffer, i, value[offset + i]);
        }

        /// <summary>
        /// Copies a structure to an unmanaged block of memory.
        /// </summary>
        /// <typeparam name="TStruct">The type of structure to copy.</typeparam>
        /// <param name="value">The structure to copy.</param>
        public void CopyStructure<TStruct>(TStruct value)
            where TStruct : struct
        {
            // Ensure there's enough allocated memory to hold the structure.
            Resize(Marshal.SizeOf(value));

            // Remember the type of structure. This will be needed later.
            _structureType = typeof(TStruct);

            // Copy the contents to the unmanaged memory.
            Marshal.StructureToPtr(value, _buffer, false);
        }
    }
}
