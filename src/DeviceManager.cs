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
using System.Linq;
using System.Text;
using WindowsDeviceManager.Api;

namespace WindowsDeviceManager
{
    public static class DeviceManager
    {
        #region All devices

        public static DeviceInfoSet GetDevices()
        {
            return GetDevices(true, true);
        }

        public static DeviceInfoSet GetDevices(bool presentDevices, bool currentProfile)
        {
            return GetDevicesInternal(DeviceInterfaceClasses.All, null, presentDevices, currentProfile);
        }

        #endregion

        #region Devices by class / enumerator

        public static DeviceInfoSet GetDevices(Guid classInterfaceId)
        {
            return GetDevices(classInterfaceId, null, true, true);
        }

        public static DeviceInfoSet GetDevices(Guid classInterfaceId, bool presentDevices, bool currentProfile)
        {
            return GetDevices(classInterfaceId, null, presentDevices, currentProfile);
        }

        public static DeviceInfoSet GetDevices(string enumerator)
        {
            return GetDevices(DeviceInterfaceClasses.All, enumerator, true, true);
        }

        public static DeviceInfoSet GetDevices(string enumerator, bool presentDevices, bool currentProfile)
        {
            return GetDevices(DeviceInterfaceClasses.All, enumerator, presentDevices, currentProfile);
        }

        public static DeviceInfoSet GetDevices(Guid classInterfaceId, string enumerator)
        {
            return GetDevices(classInterfaceId, enumerator, true, true);
        }

        public static DeviceInfoSet GetDevices(Guid classInterfaceId, string enumerator, bool presentDevices, bool currentProfile)
        {
            return GetDevicesInternal(classInterfaceId, enumerator, presentDevices, currentProfile);
        }

        #endregion

        #region Single device

        public static DeviceInfoSet GetDevice(string deviceInstanceID)
        {
            return GetDevice(deviceInstanceID, DeviceInterfaceClasses.All, true, true);
        }

        public static DeviceInfoSet GetDevice(string deviceInstanceID, bool presentDevices, bool currentProfile)
        {
            return GetDevice(deviceInstanceID, DeviceInterfaceClasses.All, presentDevices, currentProfile);
        }

        public static DeviceInfoSet GetDevice(string deviceInstanceID, Guid classInterfaceId)
        {
            return GetDevice(deviceInstanceID, classInterfaceId, true, true);
        }

        public static DeviceInfoSet GetDevice(string deviceInstanceID, Guid classInterfaceId, bool presentDevices, bool currentProfile)
        {
            return GetDevicesInternal(classInterfaceId, deviceInstanceID, presentDevices, currentProfile, GetClassDevsFlags.DIGCF_DEVICEINTERFACE);
        }

        #endregion

        private static DeviceInfoSet GetDevicesInternal(Guid deviceInterfaceId, string enumerator,
            bool presentDevices, bool currentProfile, GetClassDevsFlags flags = GetClassDevsFlags.DIGCF_NONE)
        {
            if (deviceInterfaceId == DeviceInterfaceClasses.All)
                flags |= GetClassDevsFlags.DIGCF_ALLCLASSES;

            if (presentDevices)
                flags |= GetClassDevsFlags.DIGCF_PRESENT;

            if (currentProfile)
                flags |= GetClassDevsFlags.DIGCF_PROFILE;

            var deviceInfoSet = SetupDi.GetClassDevs(deviceInterfaceId, enumerator, flags);
            if (deviceInfoSet != null)
                return deviceInfoSet;

            throw ErrorHelpers.CreateException("Unable to enumerate devices.");
        }
    }
}
