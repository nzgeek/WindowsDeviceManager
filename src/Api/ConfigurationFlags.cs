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
    public enum ConfigurationFlags : uint
    {
        /// <summary>
        /// No flags are enabled.
        /// </summary>
        None = 0x00000,

        /// <summary>
        /// Set if disabled.
        /// </summary>
        Disabled = 0x00001,

        /// <summary>
        /// Set if a present hardware enum device deleted.
        /// </summary>
        Removed = 0x00002,

        /// <summary>
        /// Set if the devnode was manually installed.
        /// </summary>
        ManualInstall = 0x00004,

        /// <summary>
        /// Set if skip the boot config.
        /// </summary>
        IgnoreBootConfig = 0x00008,

        /// <summary>
        /// Load this devnode when in net boot.
        /// </summary>
        NetBoot = 0x00010,

        /// <summary>
        /// Redo install.
        /// </summary>
        Reinstall = 0x00020,

        /// <summary>
        /// Failed the install.
        /// </summary>
        FailedInstall = 0x00040,

        /// <summary>
        /// Can't stop/remove a single child.
        /// </summary>
        CantStopAChild = 0x00080,

        /// <summary>
        /// Can remove even if rom.
        /// </summary>
        OkRemoveRom = 0x00100,

        /// <summary>
        /// Don't remove at exit.
        /// </summary>
        NoRemoveExit = 0x00200,

        /// <summary>
        /// Complete install for devnode running 'raw'.
        /// </summary>
        FinishInstall = 0x00400,

        /// <summary>
        /// This devnode requires a forced config.
        /// </summary>
        NeedsForcedConfig = 0x00800,

        /// <summary>
        /// This is the remote boot network card.
        /// </summary>
        NetBootCard = 0x01000,

        /// <summary>
        /// This device has a partial logconfig.
        /// </summary>
        PartialLogConf = 0x02000,

        /// <summary>
        /// Set if unsafe removals should be ignored.
        /// </summary>
        SuppressSurprise = 0x04000,

        /// <summary>
        /// Set if hardware should be tested for logo failures.
        /// </summary>
        VerifyHardware = 0x08000,

        /// <summary>
        /// Show the finish install wizard pages for the installed device.
        /// </summary>
        FinishInstallUi = 0x10000,

        /// <summary>
        /// Call installer with DIF_FINISHINSTALL_ACTION in client context.
        /// </summary>
        FinishInstallAction = 0x20000,

        /// <summary>
        /// Configured devnode during boot phase.
        /// </summary>
        BootDevice = 0x40000,
    }
}
