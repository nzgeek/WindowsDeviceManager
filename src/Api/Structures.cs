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

namespace WindowsDeviceManager.Api
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DEVPROPKEY
    {
        public Guid formatId;

        public int propertyId;

        public override bool Equals(object obj)
        {
            return ObjectHelpers.Equals(this, obj,
                x => x.formatId,
                x => x.propertyId);
        }

        public override int GetHashCode()
        {
            return ObjectHelpers.GetHashCode(this,
                x => x.formatId,
                x => x.propertyId);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SP_DEVINFO_DATA
    {
        /// <summary>
        /// The size, in bytes, of the <see cref="SP_DEVINFO_DATA"/> structure.
        /// </summary>
        public Int32 cbSize;

        /// <summary>
        /// The GUID of the device's setup class.
        /// </summary>
        public Guid classGuid;

        /// <summary>
        /// An opaque handle to the device instance (also known as a handle to the 'devnode').
        /// </summary>
        public UInt32 devInst;

        /// <summary>
        /// Reserved. For internal use only.
        /// </summary>
        public UIntPtr reserved;

        /// <summary>
        /// Initializes the structure to an empty value.
        /// </summary>
        public void Initialize()
        {
            cbSize = Marshal.SizeOf(this);
            classGuid = Guid.Empty;
            devInst = 0;
            reserved = UIntPtr.Zero;
        }

        public override bool Equals(object obj)
        {
            return ObjectHelpers.Equals(this, obj,
                x => x.cbSize,
                x => x.classGuid,
                x => x.devInst,
                x => x.reserved);
        }

        public override int GetHashCode()
        {
            return ObjectHelpers.GetHashCode(this,
                x => x.cbSize,
                x => x.classGuid,
                x => x.devInst,
                x => x.reserved);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SP_DEVICE_INTERFACE_DATA
    {
        /// <summary>
        /// The size, in bytes, of the <see cref="SP_DEVICE_INTERFACE_DATA"/> structure.
        /// </summary>
        public Int32 cbSize;

        /// <summary>
        /// The GUID for the class to which the device interface belongs.
        /// </summary>
        public Guid interfaceClassGuid;

        /// <summary>
        /// Flags that describe the device interface.
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public DeviceInterfaceFlags flags;

        /// <summary>
        /// Reserved. For internal use only.
        /// </summary>
        public UIntPtr reserved;

        /// <summary>
        /// Initializes the structure to an empty value.
        /// </summary>
        public void Initialize()
        {
            cbSize = Marshal.SizeOf(this);
            interfaceClassGuid = Guid.Empty;
            flags = DeviceInterfaceFlags.SPINT_NONE;
            reserved = UIntPtr.Zero;
        }

        public override bool Equals(object obj)
        {
            return ObjectHelpers.Equals(this, obj,
                x => x.cbSize,
                x => x.interfaceClassGuid,
                x => x.flags,
                x => x.reserved);
        }

        public override int GetHashCode()
        {
            return ObjectHelpers.GetHashCode(this,
                x => x.cbSize,
                x => x.interfaceClassGuid,
                x => x.flags,
                x => x.reserved);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SP_CLASSINSTALL_HEADER
    {
        public int cbSize;

        [MarshalAs(UnmanagedType.U4)]
        public DeviceInstallFunction installFunction;

        public void Initialize(DeviceInstallFunction installFunction)
        {
            cbSize = Marshal.SizeOf(typeof(SP_CLASSINSTALL_HEADER));
            this.installFunction = installFunction;
        }

        public override bool Equals(object obj)
        {
            return ObjectHelpers.Equals(this, obj,
                x => x.cbSize,
                x => x.installFunction);
        }

        public override int GetHashCode()
        {
            return ObjectHelpers.GetHashCode(this,
                x => x.cbSize,
                x => x.installFunction);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SP_PROPCHANGE_PARAMS
    {
        public SP_CLASSINSTALL_HEADER classInstallHeader;

        [MarshalAs(UnmanagedType.U4)]
        public DevicePropertyChangeState stateChange;

        [MarshalAs(UnmanagedType.U4)]
        public DevicePropertyChangeScope scope;

        public UInt32 hwProfile;

        public void Initialize(DevicePropertyChangeState stateChange,
            DevicePropertyChangeScope scope = DevicePropertyChangeScope.DICS_FLAG_CONFIGSPECIFIC,
            uint hwProfile = 0)
        {
            classInstallHeader = new SP_CLASSINSTALL_HEADER();
            classInstallHeader.Initialize(DeviceInstallFunction.DIF_PROPERTYCHANGE);

            this.stateChange = stateChange;
            this.scope = scope;
            this.hwProfile = hwProfile;
        }

        public override bool Equals(object obj)
        {
            return ObjectHelpers.Equals(this, obj,
                x => x.classInstallHeader,
                x => x.stateChange,
                x => x.scope,
                x => x.hwProfile);
        }

        public override int GetHashCode()
        {
            return ObjectHelpers.GetHashCode(this,
                x => x.classInstallHeader,
                x => x.stateChange,
                x => x.scope,
                x => x.hwProfile);
        }
    }
}
