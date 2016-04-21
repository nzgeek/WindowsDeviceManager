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
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="installFunction"></param>
        public static void CallClassInstaller(DeviceInfo device, DeviceInstallFunction installFunction)
        {
            var deviceInfoList = device.InfoSet.InfoSet;
            var deviceInfoData = device.InfoData;

            var result = CallClassInstaller(installFunction, deviceInfoList, ref deviceInfoData);

            if (!result)
            {
                throw ErrorHelpers.CreateException("Unable to call class installer.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="stateChange"></param>
        /// <param name="scope"></param>
        /// <param name="hardwareProfile"></param>
        public static void ChangeDeviceStateProperty(DeviceInfo device, DevicePropertyChangeState stateChange,
            DevicePropertyChangeScope scope = DevicePropertyChangeScope.DICS_FLAG_CONFIGSPECIFIC,
            uint hardwareProfile = 0)
        {
            SP_PROPCHANGE_PARAMS propChangeParams = new SP_PROPCHANGE_PARAMS();
            propChangeParams.Initialize(stateChange, scope, hardwareProfile);

            using (var buffer = new Buffer())
            {
                var deviceInfoList = device.InfoSet.InfoSet;
                var deviceInfoData = device.InfoData;

                buffer.CopyStructure(propChangeParams);

                var result = SetClassInstallParams(deviceInfoList, ref deviceInfoData, buffer.Data, buffer.Length);

                if (!result)
                {
                    throw ErrorHelpers.CreateException("Unable to change property state.");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceInfoSet"></param>
        /// <param name="index"></param>
        /// <param name="deviceInfo"></param>
        /// <returns></returns>
        public static bool EnumDeviceInfo(DeviceInfoSet deviceInfoSet, int index, out DeviceInfo deviceInfo)
        {
            var deviceInfoData = new SP_DEVINFO_DATA();
            deviceInfoData.Initialize();

            if (EnumDeviceInfo(deviceInfoSet.InfoSet, index, ref deviceInfoData))
            {
                deviceInfo = new DeviceInfo(deviceInfoSet, deviceInfoData);
                return true;
            }

            deviceInfo = null;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="index"></param>
        /// <param name="deviceInterface"></param>
        /// <returns></returns>
        public static bool EnumDeviceInterfaces(DeviceInfo device, Guid deviceInterfaceId, int index,
            out DeviceInterface deviceInterface)
        {
            var deviceInfoList = device.InfoSet.InfoSet;
            var deviceInfoData = device.InfoData;

            var deviceInterfaceData = new SP_DEVICE_INTERFACE_DATA();
            deviceInterfaceData.Initialize();

            if (EnumDeviceInterfaces(deviceInfoList, ref deviceInfoData, deviceInterfaceId, index,
                ref deviceInterfaceData))
            {
                deviceInterface = new DeviceInterface(device, deviceInterfaceData);
                return true;
            }

            deviceInterface = null;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceInterfaceId"></param>
        /// <param name="enumerator"></param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public static DeviceInfoSet GetClassDevs(Guid deviceInterfaceId, string enumerator, GetClassDevsFlags flags)
        {
            var handle = GetClassDevs(deviceInterfaceId, enumerator, IntPtr.Zero, flags);
            if (handle != InvalidHandleValue)
                return new DeviceInfoSet(handle);

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="propertyKey"></param>
        /// <param name="propertyDataType"></param>
        /// <param name="requiredSize"></param>
        /// <returns></returns>
        public static bool GetDeviceInterfaceProperty(DeviceInterface deviceInterface, DevicePropertyKey propertyKey,
            out DevicePropertyType propertyDataType, out int requiredSize)
        {
            var deviceInfoList = deviceInterface.Device.InfoSet.InfoSet;
            var deviceInterfaceData = deviceInterface.InterfaceData;
            var devicePropertyKey = propertyKey.PropertyKey;

            var success = GetDeviceInterfaceProperty(deviceInfoList, ref deviceInterfaceData, ref devicePropertyKey,
                out propertyDataType, IntPtr.Zero, 0, out requiredSize, 0);

            if (!success)
            {
                var lastError = ErrorHelpers.GetLastError();
                return lastError == ErrorCode.InsufficientBuffer;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="propertyKey"></param>
        /// <param name="propertyDataType"></param>
        /// <param name="propertyData"></param>
        /// <returns></returns>
        public static bool GetDeviceInterfaceProperty(DeviceInterface deviceInterface, DevicePropertyKey propertyKey,
            out DevicePropertyType propertyDataType, out Api.Buffer propertyData)
        {
            var deviceInfoList = deviceInterface.Device.InfoSet.InfoSet;
            var deviceInterfaceData = deviceInterface.InterfaceData;
            var devicePropertyKey = propertyKey.PropertyKey;
            propertyData = new Api.Buffer();
            int requiredSize;

            // Keep trying until we've got success or an unrecoverable error.
            while (true)
            {
                var success = GetDeviceInterfaceProperty(deviceInfoList, ref deviceInterfaceData, ref devicePropertyKey,
                    out propertyDataType, propertyData.Data, propertyData.Length, out requiredSize, 0);

                // If the data was read successfully, truncate the buffer to match the length read.
                if (success)
                {
                    propertyData.Truncate(requiredSize);
                    return true;
                }

                // If the last error was for anything except the buffer being too small, cleanly get rid of the buffer
                // before returning failure.
                var lastError = ErrorHelpers.GetLastError();
                if (lastError != ErrorCode.InsufficientBuffer)
                {
                    propertyData.Dispose();
                    propertyData = null;

                    return false;
                }

                // Resize the buffer to the required length before trying again.
                propertyData.Resize(requiredSize);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="propertyKey"></param>
        /// <param name="propertyDataType"></param>
        /// <param name="requiredSize"></param>
        /// <returns></returns>
        public static bool GetDeviceProperty(DeviceInfo device, DevicePropertyKey propertyKey,
            out DevicePropertyType propertyDataType, out int requiredSize)
        {
            var deviceInfoList = device.InfoSet.InfoSet;
            var deviceInfoData = device.InfoData;
            var devicePropertyKey = propertyKey.PropertyKey;

            var success = GetDeviceProperty(deviceInfoList, ref deviceInfoData, ref devicePropertyKey,
                out propertyDataType, IntPtr.Zero, 0, out requiredSize, 0);

            if (!success)
            {
                var lastError = ErrorHelpers.GetLastError();
                return lastError == ErrorCode.InsufficientBuffer;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        /// <param name="propertyKey"></param>
        /// <param name="propertyDataType"></param>
        /// <param name="propertyData"></param>
        /// <returns></returns>
        public static bool GetDeviceProperty(DeviceInfo device, DevicePropertyKey propertyKey,
            out DevicePropertyType propertyDataType, out Api.Buffer propertyData)
        {
            var deviceInfoList = device.InfoSet.InfoSet;
            var deviceInfoData = device.InfoData;
            var devicePropertyKey = propertyKey.PropertyKey;
            propertyData = new Api.Buffer();
            int requiredSize;

            // Keep trying until we've got success or an unrecoverable error.
            while (true)
            {
                var success = GetDeviceProperty(deviceInfoList, ref deviceInfoData, ref devicePropertyKey,
                    out propertyDataType, propertyData.Data, propertyData.Length, out requiredSize, 0);

                // If the data was read successfully, truncate the buffer to match the length read.
                if (success)
                {
                    propertyData.Truncate(requiredSize);
                    return true;
                }

                // If the last error was for anything except the buffer being too small, cleanly get rid of the buffer
                // before returning failure.
                var lastError = ErrorHelpers.GetLastError();
                if (lastError != ErrorCode.InsufficientBuffer)
                {
                    propertyData.Dispose();
                    propertyData = null;

                    return false;
                }

                // Resize the buffer to the required length before trying again.
                propertyData.Resize(requiredSize);
            }
        }

        /// <summary>
        /// Gets the size of a registry-based property for the specified device.
        /// </summary>
        /// <param name="device">The device to get the registry property for.</param>
        /// <param name="propertyKey">A key for identifying the property to get.</param>
        /// <param name="propertyType">Receives the data type of the property.</param>
        /// <param name="requiredSize">Receives the size of the property's value, in bytes.</param>
        /// <returns>Returns <c>true</c> if the property was read correctly, or <c>false</c> if it was not.</returns>
        public static bool GetDeviceRegistryProperty(DeviceInfo device, DeviceRegistryPropertyKey propertyKey,
            out DeviceRegistryPropertyType propertyType, out int requiredSize)
        {
            var deviceInfoList = device.InfoSet.InfoSet;
            var deviceInfoData = device.InfoData;

            var success = GetDeviceRegistryProperty(deviceInfoList, ref deviceInfoData, propertyKey.PropertyCode,
                out propertyType, IntPtr.Zero, 0, out requiredSize);

            if (!success)
            {
                var lastError = ErrorHelpers.GetLastError();
                return lastError == ErrorCode.InsufficientBuffer;
            }

            return true;
        }

        /// <summary>
        /// Gets a registry-based property for the specified device.
        /// </summary>
        /// <param name="device">The device to get the registry property for.</param>
        /// <param name="propertyKey">A key for identifying the property to get.</param>
        /// <param name="propertyType">Receives the data type of the property.</param>
        /// <param name="propertyData">Receives the raw data that contain the property value.</param>
        /// <returns>Returns <c>true</c> if the property was read correctly, or <c>false</c> if it was not.</returns>
        public static bool GetDeviceRegistryProperty(DeviceInfo device, DeviceRegistryPropertyKey propertyKey,
            out DeviceRegistryPropertyType propertyType, out Api.Buffer propertyData)
        {
            var deviceInfoList = device.InfoSet.InfoSet;
            var deviceInfoData = device.InfoData;
            propertyData = new Api.Buffer();
            int requiredSize;

            // Keep trying until we've got success or an unrecoverable error.
            while (true)
            {
                var success = GetDeviceRegistryProperty(deviceInfoList, ref deviceInfoData, propertyKey.PropertyCode,
                    out propertyType, propertyData.Data, propertyData.Length, out requiredSize);

                // If the data was read successfully, truncate the buffer to match the length read.
                if (success)
                {
                    propertyData.Truncate(requiredSize);
                    return true;
                }

                // If the last error was for anything except the buffer being too small, cleanly get rid of the buffer
                // before returning failure.
                var lastError = ErrorHelpers.GetLastError();
                if (lastError != ErrorCode.InsufficientBuffer)
                {
                    propertyData.Dispose();
                    propertyData = null;

                    return false;
                }

                // Resize the buffer to the required length before trying again.
                propertyData.Resize(requiredSize);
            }
        }

    }
}
