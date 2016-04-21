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
    public static partial class SetupDi
    {
        /// <summary>
        /// Invalid handle to a device information set.
        /// </summary>
        public static readonly IntPtr InvalidHandleValue = new IntPtr(-1);

        /// <summary>
        /// SetupDiCallClassInstaller
        /// </summary>
        [DllImport("Setupapi.dll", EntryPoint = "SetupDiCallClassInstaller", CharSet = CharSet.None, SetLastError = true)]
        internal static extern bool CallClassInstaller(
            [In, MarshalAs(UnmanagedType.U4)] DeviceInstallFunction installFunction,
            [In] IntPtr hInfoList,
            [In] ref SP_DEVINFO_DATA deviceInfoData);

        /// <summary>
        /// SetupDiDestroyDeviceInfoList
        /// </summary>
        [DllImport("Setupapi.dll", EntryPoint = "SetupDiDestroyDeviceInfoList", CharSet = CharSet.None, SetLastError = true)]
        internal static extern bool DestroyDeviceInfoList(
            [In] IntPtr hInfoList);

        /// <summary>
        /// SetupDiEnumDeviceInfo
        /// </summary>
        [DllImport("Setupapi.dll", EntryPoint = "SetupDiEnumDeviceInfo", CharSet = CharSet.None, SetLastError = true)]
        internal static extern bool EnumDeviceInfo(
            [In] IntPtr hInfoList,
            [In] int index,
            [In, Out] ref SP_DEVINFO_DATA deviceInfoData);

        /// <summary>
        /// SetupDiEnumDeviceInterfaces
        /// </summary>
        [DllImport("Setupapi.dll", EntryPoint = "SetupDiEnumDeviceInterfaces", CharSet = CharSet.None, SetLastError = true)]
        internal static extern bool EnumDeviceInterfaces(
            [In] IntPtr hInfoList,
            [In] ref SP_DEVINFO_DATA deviceInfoData,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid interfaceClassId,
            [In] int index,
            [In, Out] ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

        /// <summary>
        /// SetupDiGetClassDevs
        /// </summary>
        [DllImport("Setupapi.dll", EntryPoint = "SetupDiGetClassDevsW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern IntPtr GetClassDevs(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid deviceInterfaceId,
            [In, MarshalAs(UnmanagedType.LPWStr)] string enumerator,
            [In] IntPtr hwndParent,
            [In, MarshalAs(UnmanagedType.U4)] GetClassDevsFlags flags);

        /// <summary>
        /// SetupDiGetDeviceInterfaceProperty
        /// </summary>
        [DllImport("Setupapi.dll", EntryPoint = "SetupDiGetDeviceInterfacePropertyW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool GetDeviceInterfaceProperty(
            [In] IntPtr hInfoList,
            [In] ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
            [In] ref DEVPROPKEY devicePropertyKey,
            [Out, MarshalAs(UnmanagedType.U4)] out DevicePropertyType devicePropertyType,
            [In] IntPtr propertyBuffer,
            [In] int propertyBufferSize,
            [Out] out int requiredBufferSize,
            [In] int flags);

        /// <summary>
        /// SetupDiGetDeviceProperty
        /// </summary>
        [DllImport("Setupapi.dll", EntryPoint = "SetupDiGetDevicePropertyW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool GetDeviceProperty(
            [In] IntPtr hInfoList,
            [In] ref SP_DEVINFO_DATA deviceInfoData,
            [In] ref DEVPROPKEY devicePropertyKey,
            [Out, MarshalAs(UnmanagedType.U4)] out DevicePropertyType devicePropertyType,
            [In] IntPtr propertyBuffer,
            [In] int propertyBufferSize,
            [Out] out int requiredBufferSize,
            [In] int flags);

        /// <summary>
        /// SetupDiGetDeviceRegistryProperty
        /// </summary>
        [DllImport("Setupapi.dll", EntryPoint = "SetupDiGetDeviceRegistryPropertyW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool GetDeviceRegistryProperty(
            [In] IntPtr hInfoList,
            [In] ref SP_DEVINFO_DATA deviceInfoData,
            [In, MarshalAs(UnmanagedType.U4)] DeviceRegistryPropertyCode propertyKey,
            [Out, MarshalAs(UnmanagedType.U4)] out DeviceRegistryPropertyType propertyType,
            [In] IntPtr propertyBuffer,
            [In] int propertyBufferSize,
            [Out] out int requiredBufferSize);

        /// <summary>
        /// SetupDiSetClassInstallParams
        /// </summary>
        [DllImport("Setupapi.dll", EntryPoint = "SetupDiSetClassInstallParamsW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool SetClassInstallParams(
            [In] IntPtr hInfoList,
            [In] ref SP_DEVINFO_DATA deviceInfoData,
            [In] IntPtr installParams,
            [In] int installParamsSize);
    }
}
