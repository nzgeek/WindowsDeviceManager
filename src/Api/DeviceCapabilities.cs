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

namespace WindowsDeviceManager.Api
{
    [Flags]
    public enum DeviceCapabilities : uint
    {
        None = 0x000,
        LockSupported = 0x001,
        EjectSupported = 0x002,
        Removeable = 0x004,
        DockDevice = 0x008,
        UniqueId = 0x010,
        SilentInstall = 0x020,
        RawDeviceOk = 0x040,
        SurpriseRemovalOk = 0x080,
        HardwareDisabled = 0x100,
        NonDynamic = 0x200,
    }
}
