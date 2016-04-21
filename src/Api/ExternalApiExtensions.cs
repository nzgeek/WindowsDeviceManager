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
    /// <summary>
    /// Provides a way for external code to access the values that are passed to the raw API functions.
    /// </summary>
    public static class ExternalApiExtensions
    {
        /// <summary>
        /// Gets the handle that represents a <see cref="DeviceInfoSet"/> at the API level.
        /// </summary>
        /// <param name="deviceInfoSet">
        /// The <see cref="DeviceInfoSet"/> being referenced in an API call.
        /// </param>
        /// <returns>A <see cref="IntPtr"/> containing the handle value.</returns>
        public static IntPtr ToApiValue(this DeviceInfoSet deviceInfoSet)
        {
            return deviceInfoSet.InfoSet;
        }

        /// <summary>
        /// Gets the structure that represents a <see cref="DeviceInfo"/> at the API level.
        /// </summary>
        /// <param name="deviceInfo">
        /// The <see cref="DeviceInfo"/> being referenced in an API call.
        /// </param>
        /// <returns>A <see cref="SP_DEVINFO_DATA"/> structure.</returns>
        public static SP_DEVINFO_DATA ToApiValue(this DeviceInfo deviceInfo)
        {
            return deviceInfo.InfoData;
        }

        /// <summary>
        /// Gets the structure that represents a <see cref="DeviceInterface"/> at the API level.
        /// </summary>
        /// <param name="deviceInterface">
        /// The <see cref="DeviceInterface"/> being referenced in an API call.
        /// </param>
        /// <returns>A <see cref="SP_DEVICE_INTERFACE_DATA"/> structure.</returns>
        public static SP_DEVICE_INTERFACE_DATA ToApiValue(this DeviceInterface deviceInterface)
        {
            return deviceInterface.InterfaceData;
        }

        /// <summary>
        /// Gets the structure that represents a <see cref="DevicePropertyKey"/> at the API level.
        /// </summary>
        /// <param name="propertyKey">
        /// The <see cref="DevicePropertyKey"/> being referenced in an API call.
        /// </param>
        /// <returns>A <see cref="DEVPROPKEY"/> structure.</returns>
        public static DEVPROPKEY ToApiValue(this DevicePropertyKey propertyKey)
        {
            return propertyKey.PropertyKey;
        }

        /// <summary>
        /// Gets the value that represents a <see cref="DeviceRegistryPropertyKey"/> at the API level.
        /// </summary>
        /// <param name="propertyKey">
        /// The <see cref="DeviceRegistryPropertyKey"/> being referenced in an API call.
        /// </param>
        /// <returns>A <see cref="DeviceRegistryPropertyCode"/> value.</returns>
        public static DeviceRegistryPropertyCode ToApiValue(this DeviceRegistryPropertyKey propertyKey)
        {
            return propertyKey.PropertyCode;
        }
    }
}
