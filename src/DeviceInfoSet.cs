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
using WindowsDeviceManager.Api;

namespace WindowsDeviceManager
{
    public class DeviceInfoSet : IDisposable
    {
        #region IDisposable Support
        private bool _disposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects).
                    // Nothing here yet, but there could be in the future.
                }

                // Correctly dispose of the information set handle.
                if (_handle != IntPtr.Zero)
                {
                    SetupDi.DestroyDeviceInfoList(_handle);
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }

        ~DeviceInfoSet()
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

        private IntPtr _handle = IntPtr.Zero;

        /// <summary>
        /// Creates a new device information set.
        /// </summary>
        /// <param name="handle">An unmanaged handle representing the device information set.</param>
        internal DeviceInfoSet(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Gets an unmanaged handle representing the device information set.
        /// </summary>
        internal IntPtr InfoSet
        {
            get { return _handle; }
        }

        /// <summary>
        /// Gets an enumerator that allows all devices in the <see cref="DeviceInfoSet"/> to be accessed.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{DeviceInfo}"/> containing all devices in the information set.</returns>
        public IEnumerable<DeviceInfo> GetDevices()
        {
            for (var index = 0; ; ++index)
            {
                DeviceInfo deviceInfo;
                if (!SetupDi.EnumDeviceInfo(this, index, out deviceInfo))
                {
                    // When enumerating past the end of the set, a specific error will be returned.
                    // Any other error is unexpected and should be reported.
                    var lastError = ErrorHelpers.GetLastError();
                    if (lastError != ErrorCode.NoMoreItems)
                    {
                        throw ErrorHelpers.CreateException(lastError, "Unable to enumerate devices.");
                    }

                    yield break;
                }

                yield return deviceInfo;
            }
        }

        /// <summary>
        /// Gets an enumerator that allows all devices in the <see cref="DeviceInfoSet"/> to be accessed.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{DeviceInfo}"/> containing all devices in the information set.</returns>
        public IEnumerable<DeviceInfo> GetDeviceInterfaces()
        {
            for (var index = 0; ; ++index)
            {
                DeviceInfo deviceInfo;
                if (!SetupDi.EnumDeviceInfo(this, index, out deviceInfo))
                {
                    // When enumerating past the end of the set, a specific error will be returned.
                    // Any other error is unexpected and should be reported.
                    var lastError = ErrorHelpers.GetLastError();
                    if (lastError != ErrorCode.NoMoreItems)
                    {
                        throw ErrorHelpers.CreateException(lastError, "Unable to enumerate devices.");
                    }

                    yield break;
                }

                yield return deviceInfo;
            }
        }
    }
}
