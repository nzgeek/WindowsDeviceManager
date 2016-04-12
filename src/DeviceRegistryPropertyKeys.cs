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

using WindowsDeviceManager.Api;

namespace WindowsDeviceManager
{
    public static class DeviceRegistryPropertyKeys
    {
        public static readonly DeviceRegistryPropertyKey Address = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_ADDRESS, "Address", DeviceRegistryPropertyType.DoubleWord);

        public static readonly DeviceRegistryPropertyKey BaseContainerId = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_BASE_CONTAINERID, "Base Container ID", DeviceRegistryPropertyType.String);

        public static readonly DeviceRegistryPropertyKey BusNumber = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_BUSNUMBER, "Bus Number", DeviceRegistryPropertyType.DoubleWord);

        public static readonly DeviceRegistryPropertyKey BusTypeGuid = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_BUSTYPEGUID, "Bus Type GUID", DeviceRegistryPropertyType.Binary);

        public static readonly DeviceRegistryPropertyKey Capabilities = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_CAPABILITIES, "Capabilities", DeviceRegistryPropertyType.DoubleWord);

        public static readonly DeviceRegistryPropertyKey Characteristics = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_CHARACTERISTICS, "Characteristics", DeviceRegistryPropertyType.DoubleWord);

        public static readonly DeviceRegistryPropertyKey Class = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_CLASS, "Class", DeviceRegistryPropertyType.String);

        public static readonly DeviceRegistryPropertyKey ClassGuid = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_CLASSGUID, "Class GUID", DeviceRegistryPropertyType.String);

        public static readonly DeviceRegistryPropertyKey CompatibleIds = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_COMPATIBLEIDS, "Compatible IDs", DeviceRegistryPropertyType.MultiString);

        public static readonly DeviceRegistryPropertyKey ConfigFlags = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_CONFIGFLAGS, "Configuration Flags", DeviceRegistryPropertyType.DoubleWord);

        public static readonly DeviceRegistryPropertyKey DeviceDesc = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_DEVICEDESC, "Device Description", DeviceRegistryPropertyType.String);

        public static readonly DeviceRegistryPropertyKey DevicePowerData = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_DEVICE_POWER_DATA, "Device Power Data", DeviceRegistryPropertyType.Binary);

        public static readonly DeviceRegistryPropertyKey DeviceType = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_DEVTYPE, "Device Type", DeviceRegistryPropertyType.DoubleWord);

        public static readonly DeviceRegistryPropertyKey Driver = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_DRIVER, "Driver", DeviceRegistryPropertyType.String);

        public static readonly DeviceRegistryPropertyKey EnumeratorName = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_ENUMERATOR_NAME, "Enumerator Name", DeviceRegistryPropertyType.String);

        public static readonly DeviceRegistryPropertyKey Exclusive = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_EXCLUSIVE, "Exclusive", DeviceRegistryPropertyType.DoubleWord);

        public static readonly DeviceRegistryPropertyKey FriendlyName = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_FRIENDLYNAME, "Friendly Name", DeviceRegistryPropertyType.String);

        public static readonly DeviceRegistryPropertyKey HardwareId = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_HARDWAREID, "Hardware ID", DeviceRegistryPropertyType.MultiString);

        public static readonly DeviceRegistryPropertyKey InstallState = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_INSTALL_STATE, "Install State", DeviceRegistryPropertyType.DoubleWord);

        public static readonly DeviceRegistryPropertyKey LegacyBusType = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_LEGACYBUSTYPE, "Legacy Bus Type", DeviceRegistryPropertyType.DoubleWord);

        public static readonly DeviceRegistryPropertyKey LocationInformation = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_LOCATION_INFORMATION, "Location Information", DeviceRegistryPropertyType.String);

        public static readonly DeviceRegistryPropertyKey LocationPaths = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_LOCATION_PATHS, "Location Paths", DeviceRegistryPropertyType.MultiString);

        public static readonly DeviceRegistryPropertyKey LowerFilters = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_LOWERFILTERS, "Lower Filters", DeviceRegistryPropertyType.MultiString);

        public static readonly DeviceRegistryPropertyKey Manufacturer = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_MFG, "Manufacturer", DeviceRegistryPropertyType.String);

        public static readonly DeviceRegistryPropertyKey PhysicalDeviceObjectName = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_PHYSICAL_DEVICE_OBJECT_NAME, "Physical Device Object Name",
            DeviceRegistryPropertyType.String);

        public static readonly DeviceRegistryPropertyKey RemovalPolicy = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_REMOVAL_POLICY, "Removal Policy", DeviceRegistryPropertyType.DoubleWord);

        public static readonly DeviceRegistryPropertyKey RemovalPolicyHwDefault = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_REMOVAL_POLICY_HW_DEFAULT, "Removal Policy Hardware Default",
            DeviceRegistryPropertyType.DoubleWord);

        public static readonly DeviceRegistryPropertyKey RemovalPolicyOverride = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_REMOVAL_POLICY_OVERRIDE, "Removal Policy Override",
            DeviceRegistryPropertyType.DoubleWord);

        public static readonly DeviceRegistryPropertyKey Security = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_SECURITY, "Security Descriptor", DeviceRegistryPropertyType.Binary);

        public static readonly DeviceRegistryPropertyKey SecuritySds = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_SECURITY_SDS, "Security Descriptor String", DeviceRegistryPropertyType.String);

        public static readonly DeviceRegistryPropertyKey Service = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_SERVICE, "Service", DeviceRegistryPropertyType.String);

        public static readonly DeviceRegistryPropertyKey UiNumber = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_UI_NUMBER, "UI Number", DeviceRegistryPropertyType.DoubleWord);

        public static readonly DeviceRegistryPropertyKey UiNumberDescFormat = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_UI_NUMBER_DESC_FORMAT, "UI Number Description Format",
            DeviceRegistryPropertyType.String);

        public static readonly DeviceRegistryPropertyKey UpperFilters = new DeviceRegistryPropertyKey(
            DeviceRegistryPropertyCode.SPDRP_UPPERFILTERS, "Upper Filters", DeviceRegistryPropertyType.MultiString);
    }
}
