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
using WindowsDeviceManager.Helpers;

namespace WindowsDeviceManager
{

    public class DevicePropertyKey
    {
        private Api.DEVPROPKEY _propertyKey;
        private readonly DevicePropertyType[] _expectedTypes;

        public DevicePropertyKey(Guid formatId, int propertyId, string name, params DevicePropertyType[] expectedTypes)
        {
            Name = name;
            _propertyKey = new Api.DEVPROPKEY
            {
                formatId = formatId,
                propertyId = propertyId,
            };
            _expectedTypes = expectedTypes;
        }

        public string Name { get; private set; }

        public Guid FormatId
        {
            get { return _propertyKey.formatId; }
        }

        public int PropertyId
        {
            get { return _propertyKey.propertyId; }
        }

        public IEnumerable<DevicePropertyType> ExpectedTypes
        {
            get { return _expectedTypes; }
        }

        internal Api.DEVPROPKEY PropertyKey
        {
            get { return _propertyKey; }
        }

        public override bool Equals(object obj)
        {
            return ObjectHelpers.Equals(this, obj,
                x => x.PropertyKey,
                x => x.Name,
                x => x._expectedTypes);
        }

        public override int GetHashCode()
        {
            return ObjectHelpers.GetHashCode(this,
                x => x.PropertyKey);
        }
    }
}
