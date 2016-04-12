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

namespace WindowsDeviceManager
{
    public enum DevicePropertyType
    {
        Empty                       = 0x00,
        Null                        = 0x01,
        Int8                        = 0x02,
        UInt8                       = 0x03,
        Int16                       = 0x04,
        UInt16                      = 0x05,
        Int32                       = 0x06,
        UInt32                      = 0x07,
        Int64                       = 0x08,
        UInt64                      = 0x09,
        Float                       = 0x0A,
        Double                      = 0x0B,
        Decimal                     = 0x0C,
        Guid                        = 0x0D,
        Currency                    = 0x0E,
        Date                        = 0x0F,
        FileTime                    = 0x10,
        Boolean                     = 0x11,
        String                      = 0x12,
        StringList                  = 0x2012,
        SecurityDescriptor          = 0x13,
        SecurityDescriptorString    = 0x14,
        PropertyKey                 = 0x15,
        PropertyType                = 0x16,
        Binary                      = 0x1016,
        Error                       = 0x17,
        NtStatus                    = 0x18,
        StringIndirect              = 0x19,
    }
}
