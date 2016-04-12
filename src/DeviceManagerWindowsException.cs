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
using WindowsDeviceManager.Api;

namespace WindowsDeviceManager
{
    public class DeviceManagerWindowsException : DeviceManagerException
    {
        private const string ErrorCodeKey = "WindowsErrorCode";
        private const string ErrorMessageKey = "WindowsErrorMessage";

        public DeviceManagerWindowsException(string message)
            : base(message)
        {
            Initialize();
        }

        public DeviceManagerWindowsException(string format, params object[] args)
            : base(format, args)
        {
            Initialize();
        }

        public DeviceManagerWindowsException(Exception innerException, string message)
            : base(innerException, message)
        {
            Initialize();
        }

        public DeviceManagerWindowsException(Exception innerException, string format, params object[] args)
            : base(innerException, format, args)
        {
            Initialize();
        }

        private void Initialize()
        {
            int lastError = ErrorHelpers.GetLastError();
            Data[ErrorCodeKey] = lastError;
            Data[ErrorMessageKey] = ErrorHelpers.GetErrorMessage(lastError);
        }

        public int WindowsErrorCode
        {
            get { return (int)Data[ErrorCodeKey]; }
            set
            {
                Data[ErrorCodeKey] = value;
                Data[ErrorMessageKey] = ErrorHelpers.GetErrorMessage(value);
            }
        }

        public string WindowsErrorMessage
        {
            get { return (string)Data[ErrorMessageKey]; }
        }
    }
}
