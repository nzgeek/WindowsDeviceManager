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
        /// SetupDiGetClassDevs
        /// </summary>
        [DllImport("Setupapi.dll", EntryPoint = "SetupDiGetClassDevsW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern IntPtr GetClassDevs(
            [MarshalAs(UnmanagedType.LPStruct)] Guid deviceInterfaceId,
            [MarshalAs(UnmanagedType.LPWStr)] string enumerator,
            IntPtr hwndParent,
            [MarshalAs(UnmanagedType.U4)] GetClassDevsFlags flags);

        /// <summary>
        /// SetupDiDestroyDeviceInfoList
        /// </summary>
        [DllImport("Setupapi.dll", EntryPoint = "SetupDiDestroyDeviceInfoList", CharSet = CharSet.None, SetLastError = true)]
        internal static extern bool DestroyDeviceInfoList(IntPtr hInfoList);

        /// <summary>
        /// SetupDiEnumDeviceInfo
        /// </summary>
        [DllImport("Setupapi.dll", EntryPoint = "SetupDiEnumDeviceInfo", CharSet = CharSet.None, SetLastError = true)]
        internal static extern bool EnumDeviceInfo(
            IntPtr hInfoList,
            int index,
            ref SP_DEVINFO_DATA deviceInfoData);

        /// <summary>
        /// SetupDiGetDeviceProperty
        /// </summary>
        [DllImport("Setupapi.dll", EntryPoint = "SetupDiGetDevicePropertyW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool GetDeviceProperty(
            IntPtr hInfoList,
            ref SP_DEVINFO_DATA deviceInfoData,
            ref DEVPROPKEY devicePropertyKey,
            [MarshalAs(UnmanagedType.U4)] out DevicePropertyType devicePropertyType,
            IntPtr propertyBuffer,
            int propertyBufferSize,
            out int requiredBufferSize,
            int flags);

        /// <summary>
        /// SetupDiGetDeviceRegistryProperty
        /// </summary>
        [DllImport("Setupapi.dll", EntryPoint = "SetupDiGetDeviceRegistryPropertyW", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool GetDeviceRegistryProperty(
            IntPtr hInfoList,
            ref SP_DEVINFO_DATA deviceInfoData,
            [MarshalAs(UnmanagedType.U4)] DeviceRegistryPropertyCode propertyKey,
            [MarshalAs(UnmanagedType.U4)] out DeviceRegistryPropertyType propertyType,
            IntPtr propertyBuffer,
            int propertyBufferSize,
            out int requiredBufferSize);
    }
}
