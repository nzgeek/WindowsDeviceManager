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
    public class DeviceRegistryPropertyKey
    {
        private readonly List<DeviceRegistryPropertyType> _expectedTypes;

        internal DeviceRegistryPropertyKey(DeviceRegistryPropertyCode propertyCode, string name,
            params DeviceRegistryPropertyType[] expectedTypes)
        {
            PropertyCode = propertyCode;
            Name = name;
            _expectedTypes = new List<DeviceRegistryPropertyType>(expectedTypes ?? new DeviceRegistryPropertyType[0]);
        }

        public DeviceRegistryPropertyKey(int propertyCode, string name, params DeviceRegistryPropertyType[] expectedTypes)
            : this((DeviceRegistryPropertyCode)propertyCode, name, expectedTypes)
        {
        }

        internal DeviceRegistryPropertyCode PropertyCode { get; private set; }

        public string Name { get; private set; }

        public IEnumerable<DeviceRegistryPropertyType> ExpectedTypes
        {
            get { return _expectedTypes; }
        }
    }
}
