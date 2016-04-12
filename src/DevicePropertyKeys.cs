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
    public static class DevicePropertyKeys
    {
        public static readonly DevicePropertyKey Name = new DevicePropertyKey(new Guid("b725f130-47ef-101a-a5f1-02608c9eebac"), 10, "Name", DevicePropertyType.String);

        public static class Device
        {
            //
            // Device properties
            // These DEVPKEYs correspond to the SetupAPI SPDRP_XXX device properties.
            //
            public static readonly DevicePropertyKey DeviceDesc = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 2, "Description", DevicePropertyType.String);
            public static readonly DevicePropertyKey HardwareIds = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 3, "Hardware IDs", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey CompatibleIds = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 4, "Compatible IDs", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey Service = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 6, "Service", DevicePropertyType.String);
            public static readonly DevicePropertyKey Class = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 9, "Class", DevicePropertyType.String);
            public static readonly DevicePropertyKey ClassGuid = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 10, "Class GUID", DevicePropertyType.Guid);
            public static readonly DevicePropertyKey Driver = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 11, "Driver", DevicePropertyType.String);
            public static readonly DevicePropertyKey ConfigFlags = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 12, "Configuration Flags", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey Manufacturer = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 13, "Manufacturer", DevicePropertyType.String);
            public static readonly DevicePropertyKey FriendlyName = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 14, "Friendly Name", DevicePropertyType.String);
            public static readonly DevicePropertyKey LocationInfo = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 15, "Location Info", DevicePropertyType.String);
            public static readonly DevicePropertyKey PDOName = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 16, "PDO Name", DevicePropertyType.String);
            public static readonly DevicePropertyKey Capabilities = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 17, "Capabilities", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey UINumber = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 18, "UI Number", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey UpperFilters = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 19, "Upper Filters", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey LowerFilters = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 20, "Lower Filters", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey BusTypeGuid = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 21, "Bus Type GUID", DevicePropertyType.Guid);
            public static readonly DevicePropertyKey LegacyBusType = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 22, "Legacy Bus Type", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey BusNumber = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 23, "BusNumber", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey EnumeratorName = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 24, "Enumerator Name", DevicePropertyType.String);
            public static readonly DevicePropertyKey Security = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 25, "Security", DevicePropertyType.SecurityDescriptor);
            public static readonly DevicePropertyKey SecuritySDS = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 26, "Security SDS", DevicePropertyType.SecurityDescriptorString);
            public static readonly DevicePropertyKey DevType = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 27, "Device Type", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey Exclusive = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 28, "Exclusive", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey Characteristics = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 29, "Characteristics", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey Address = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 30, "Address", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey UINumberDescFormat = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 31, "UI Number Description Format", DevicePropertyType.String);
            public static readonly DevicePropertyKey PowerData = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 32, "Power Data", DevicePropertyType.Binary);
            public static readonly DevicePropertyKey RemovalPolicy = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 33, "Removal Policy", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey RemovalPolicyDefault = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 34, "Removal Policy Default", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey RemovalPolicyOverride = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 35, "Removal Policy Override", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey InstallState = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 36, "Install State", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey LocationPaths = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 37, "Location Paths", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey BaseContainerId = new DevicePropertyKey(new Guid("a45c254e-df1c-4efd-8020-67d146a850e0"), 38, "Base Container ID", DevicePropertyType.Guid);

            //
            // Device and Device Interface property
            // Common DEVPKEY used to retrieve the device instance id associated with devices and device interfaces.
            //
            public static readonly DevicePropertyKey InstanceId = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 256, "Instance ID", DevicePropertyType.String);

            //
            // Device properties
            // These DEVPKEYs correspond to a device's status and problem code.
            //
            public static readonly DevicePropertyKey DevNodeStatus = new DevicePropertyKey(new Guid("4340a6c5-93fa-4706-972c-7b648008a5a7"), 2, "Device Node Status", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey ProblemCode = new DevicePropertyKey(new Guid("4340a6c5-93fa-4706-972c-7b648008a5a7"), 3, "Problem Code", DevicePropertyType.UInt32);

            //
            // Device properties
            // These DEVPKEYs correspond to a device's relations.
            //
            public static readonly DevicePropertyKey EjectionRelations = new DevicePropertyKey(new Guid("4340a6c5-93fa-4706-972c-7b648008a5a7"), 4, "Ejection Relations", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey RemovalRelations = new DevicePropertyKey(new Guid("4340a6c5-93fa-4706-972c-7b648008a5a7"), 5, "Removal Relations", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey PowerRelations = new DevicePropertyKey(new Guid("4340a6c5-93fa-4706-972c-7b648008a5a7"), 6, "Power Relations", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey BusRelations = new DevicePropertyKey(new Guid("4340a6c5-93fa-4706-972c-7b648008a5a7"), 7, "Bus Relations", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey Parent = new DevicePropertyKey(new Guid("4340a6c5-93fa-4706-972c-7b648008a5a7"), 8, "Parent", DevicePropertyType.String);
            public static readonly DevicePropertyKey Children = new DevicePropertyKey(new Guid("4340a6c5-93fa-4706-972c-7b648008a5a7"), 9, "Children", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey Siblings = new DevicePropertyKey(new Guid("4340a6c5-93fa-4706-972c-7b648008a5a7"), 10, "Siblings", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey TransportRelations = new DevicePropertyKey(new Guid("4340a6c5-93fa-4706-972c-7b648008a5a7"), 11, "Transport Relations", DevicePropertyType.StringList);

            //
            // Device property
            // This DEVPKEY corresponds to a the status code that resulted in a device to be in a problem state.
            //
            public static readonly DevicePropertyKey ProblemStatus = new DevicePropertyKey(new Guid("4340a6c5-93fa-4706-972c-7b648008a5a7"), 12, "Problem Status", DevicePropertyType.NtStatus);

            //
            // Device properties
            // These DEVPKEYs are set for the corresponding types of root-enumerated devices.
            //
            public static readonly DevicePropertyKey Reported = new DevicePropertyKey(new Guid("80497100-8c73-48b9-aad9-ce387e19c56e"), 2, "Reported", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey Legacy = new DevicePropertyKey(new Guid("80497100-8c73-48b9-aad9-ce387e19c56e"), 3, "Legacy", DevicePropertyType.Boolean);

                        //
            // Device Container Id
            //
            public static readonly DevicePropertyKey ContainerId = new DevicePropertyKey(new Guid("8c7ed206-3f8a-4827-b3ab-ae9e1faefc6c"), 2, "Container ID", DevicePropertyType.Guid);
            public static readonly DevicePropertyKey InLocalMachineContainer = new DevicePropertyKey(new Guid("8c7ed206-3f8a-4827-b3ab-ae9e1faefc6c"), 4, "In Local Machine Container", DevicePropertyType.Boolean);

            //
            // Device property
            // This DEVPKEY correspond to a device's model.
            //
            public static readonly DevicePropertyKey Model = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 39, "Model", DevicePropertyType.String);

            //
            // Device Experience related Keys
            //
            public static readonly DevicePropertyKey ModelId = new DevicePropertyKey(new Guid("80d81ea6-7473-4b0c-8216-efc11a2c4c8b"), 2, "Model ID", DevicePropertyType.Guid);
            public static readonly DevicePropertyKey FriendlyNameAttributes = new DevicePropertyKey(new Guid("80d81ea6-7473-4b0c-8216-efc11a2c4c8b"), 3, "Friendly Name Attributes", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey ManufacturerAttributes = new DevicePropertyKey(new Guid("80d81ea6-7473-4b0c-8216-efc11a2c4c8b"), 4, "Manufacturer Attributes", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey PresenceNotForDevice = new DevicePropertyKey(new Guid("80d81ea6-7473-4b0c-8216-efc11a2c4c8b"), 5, "Presence Not For Device", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey SignalStrength = new DevicePropertyKey(new Guid("80d81ea6-7473-4b0c-8216-efc11a2c4c8b"), 6, "Signal Strength", DevicePropertyType.Int32);
            public static readonly DevicePropertyKey IsAssociateableByUserAction = new DevicePropertyKey(new Guid("80d81ea6-7473-4b0c-8216-efc11a2c4c8b"), 7, "Is Associateable By User Action", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey ShowInUninstallUI = new DevicePropertyKey(new Guid("80d81ea6-7473-4b0c-8216-efc11a2c4c8b"), 8, "Show In Uninstall UI", DevicePropertyType.Boolean);

            //
            // Other Device properties
            //
            public static readonly DevicePropertyKey NumaProximityDomain = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 1, "NUMA Proximity Domain", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey DhpRebalancePolicy = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 2, "DHP Rebalance Policy", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey NumaNode = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 3, "NUMA Node", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey BusReportedDeviceDesc = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 4, "Bus Reported Device Description", DevicePropertyType.String);
            public static readonly DevicePropertyKey IsPresent = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 5, "Is Present", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey HasProblem = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 6, "Has Problem", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey ConfigurationId = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 7, "Configuration ID", DevicePropertyType.String);
            public static readonly DevicePropertyKey ReportedDeviceIdsHash = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 8, "Reported Device IDs Hash", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey PhysicalDeviceLocation = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 9, "Physical Device Location", DevicePropertyType.Binary);
            public static readonly DevicePropertyKey BiosDeviceName = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 10, "BIOS Device Name", DevicePropertyType.String);
            public static readonly DevicePropertyKey DriverProblemDesc = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 11, "Driver Problem Description", DevicePropertyType.String);
            public static readonly DevicePropertyKey DebuggerSafe = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 12, "Debugger Safe", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey PostInstallInProgress = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 13, "Post Install In Progress", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey Stack = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 14, "Stack", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey ExtendedConfigurationIds = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 15, "Extended Configuration IDs", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey IsRebootRequired = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 16, "Is Reboot Required", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey FirmwareDate = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 17, "Firmware Date", DevicePropertyType.FileTime);
            public static readonly DevicePropertyKey FirmwareVersion = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 18, "Firmware Version", DevicePropertyType.String);
            public static readonly DevicePropertyKey FirmwareRevision = new DevicePropertyKey(new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"), 19, "Firmware Revision", DevicePropertyType.String);

            //
            // Device Session Id
            //
            public static readonly DevicePropertyKey SessionId = new DevicePropertyKey(new Guid("83da6326-97a6-4088-9453-a1923f573b29"), 6, "Session ID", DevicePropertyType.UInt32);

            //
            // Device activity timestamp properties
            //
            public static readonly DevicePropertyKey InstallDate = new DevicePropertyKey(new Guid("83da6326-97a6-4088-9453-a1923f573b29"), 100, "Install Date", DevicePropertyType.FileTime);
            public static readonly DevicePropertyKey FirstInstallDate = new DevicePropertyKey(new Guid("83da6326-97a6-4088-9453-a1923f573b29"), 101, "First Install Date", DevicePropertyType.FileTime);
            public static readonly DevicePropertyKey LastArrivalDate = new DevicePropertyKey(new Guid("83da6326-97a6-4088-9453-a1923f573b29"), 102, "Last Arrival Date", DevicePropertyType.FileTime);
            public static readonly DevicePropertyKey LastRemovalDate = new DevicePropertyKey(new Guid("83da6326-97a6-4088-9453-a1923f573b29"), 103, "Last Removal Date", DevicePropertyType.FileTime);

            //
            // Device driver properties
            //
            public static readonly DevicePropertyKey DriverDate = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 2, "Driver Date", DevicePropertyType.FileTime);
            public static readonly DevicePropertyKey DriverVersion = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 3, "Driver Version", DevicePropertyType.String);
            public static readonly DevicePropertyKey DriverDesc = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 4, "Driver Description", DevicePropertyType.String);
            public static readonly DevicePropertyKey DriverInfPath = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 5, "Driver Inf Path", DevicePropertyType.String);
            public static readonly DevicePropertyKey DriverInfSection = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 6, "Driver Inf Section", DevicePropertyType.String);
            public static readonly DevicePropertyKey DriverInfSectionExt = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 7, "Driver Inf Section Ext", DevicePropertyType.String);
            public static readonly DevicePropertyKey MatchingDeviceId = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 8, "Matching Device ID", DevicePropertyType.String);
            public static readonly DevicePropertyKey DriverProvider = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 9, "Driver Provider", DevicePropertyType.String);
            public static readonly DevicePropertyKey DriverPropPageProvider = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 10, "Driver Property Page Provider", DevicePropertyType.String);
            public static readonly DevicePropertyKey DriverCoInstallers = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 11, "Driver CoInstallers", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey ResourcePickerTags = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 12, "Resource Picker Tags", DevicePropertyType.String);
            public static readonly DevicePropertyKey ResourcePickerExceptions = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 13, "Resource Picker Exceptions", DevicePropertyType.String);
            public static readonly DevicePropertyKey DriverRank = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 14, "Driver Rank", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey DriverLogoLevel = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 15, "Driver Logo Level", DevicePropertyType.UInt32);

            //
            // Device properties
            // These DEVPKEYs may be set by the driver package installed for a device.
            //
            public static readonly DevicePropertyKey NoConnectSound = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 17, "No Connect Sound", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey GenericDriverInstalled = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 18, "Generic Driver Installed", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey AdditionalSoftwareRequested = new DevicePropertyKey(new Guid("a8b865dd-2e3d-4094-ad97-e593a70c75d6"), 19, "Additional Software Requested", DevicePropertyType.Boolean);

            //
            // Device safe-removal properties
            //
            public static readonly DevicePropertyKey SafeRemovalRequired = new DevicePropertyKey(new Guid("afd97640-86a3-4210-b67c-289c41aabe55"), 2, "Safe Removal Required", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey SafeRemovalRequiredOverride = new DevicePropertyKey(new Guid("afd97640-86a3-4210-b67c-289c41aabe55"), 3, "Safe Removal Required Override", DevicePropertyType.Boolean);
        }

        public static class DriverPackage
        {
            //
            // Device properties
            // These DEVPKEYs may be set by the driver package installed for a device.
            //
            public static readonly DevicePropertyKey Model = new DevicePropertyKey(new Guid("cf73bb51-3abf-44a2-85e0-9a3dc7a12132"), 2, "Model", DevicePropertyType.String);
            public static readonly DevicePropertyKey VendorWebSite = new DevicePropertyKey(new Guid("cf73bb51-3abf-44a2-85e0-9a3dc7a12132"), 3, "Vendor Web Site", DevicePropertyType.String);
            public static readonly DevicePropertyKey DetailedDescription = new DevicePropertyKey(new Guid("cf73bb51-3abf-44a2-85e0-9a3dc7a12132"), 4, "Detailed Description", DevicePropertyType.String);
            public static readonly DevicePropertyKey DocumentationLink = new DevicePropertyKey(new Guid("cf73bb51-3abf-44a2-85e0-9a3dc7a12132"), 5, "Documentation Link", DevicePropertyType.String);
            public static readonly DevicePropertyKey Icon = new DevicePropertyKey(new Guid("cf73bb51-3abf-44a2-85e0-9a3dc7a12132"), 6, "Icon", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey BrandingIcon = new DevicePropertyKey(new Guid("cf73bb51-3abf-44a2-85e0-9a3dc7a12132"), 7, "Branding Icon", DevicePropertyType.StringList);
        }

        public static class DeviceClass
        {
            //
            // Device setup class properties
            // These DEVPKEYs correspond to the SetupAPI SPCRP_XXX setup class properties.
            //
            public static readonly DevicePropertyKey UpperFilters = new DevicePropertyKey(new Guid("4321918b-f69e-470d-a5de-4d88c75ad24b"), 19, "Upper Filters", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey LowerFilters = new DevicePropertyKey(new Guid("4321918b-f69e-470d-a5de-4d88c75ad24b"), 20, "Lower Filters", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey Security = new DevicePropertyKey(new Guid("4321918b-f69e-470d-a5de-4d88c75ad24b"), 25, "Security", DevicePropertyType.SecurityDescriptor);
            public static readonly DevicePropertyKey SecuritySDS = new DevicePropertyKey(new Guid("4321918b-f69e-470d-a5de-4d88c75ad24b"), 26, "Security SDS", DevicePropertyType.SecurityDescriptorString);
            public static readonly DevicePropertyKey DevType = new DevicePropertyKey(new Guid("4321918b-f69e-470d-a5de-4d88c75ad24b"), 27, "Device Type", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey Exclusive = new DevicePropertyKey(new Guid("4321918b-f69e-470d-a5de-4d88c75ad24b"), 28, "Exclusive", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey Characteristics = new DevicePropertyKey(new Guid("4321918b-f69e-470d-a5de-4d88c75ad24b"), 29, "Characteristics", DevicePropertyType.UInt32);

            //
            // Device setup class properties
            //
            public static readonly DevicePropertyKey Name = new DevicePropertyKey(new Guid("259abffc-50a7-47ce-af08-68c9a7d73366"), 2, "Name", DevicePropertyType.String);
            public static readonly DevicePropertyKey ClassName = new DevicePropertyKey(new Guid("259abffc-50a7-47ce-af08-68c9a7d73366"), 3, "Class Name", DevicePropertyType.String);
            public static readonly DevicePropertyKey Icon = new DevicePropertyKey(new Guid("259abffc-50a7-47ce-af08-68c9a7d73366"), 4, "Icon", DevicePropertyType.String);
            public static readonly DevicePropertyKey ClassInstaller = new DevicePropertyKey(new Guid("259abffc-50a7-47ce-af08-68c9a7d73366"), 5, "Class Installer", DevicePropertyType.String);
            public static readonly DevicePropertyKey PropPageProvider = new DevicePropertyKey(new Guid("259abffc-50a7-47ce-af08-68c9a7d73366"), 6, "Property Page Provider", DevicePropertyType.String);
            public static readonly DevicePropertyKey NoInstallClass = new DevicePropertyKey(new Guid("259abffc-50a7-47ce-af08-68c9a7d73366"), 7, "No Install Class", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey NoDisplayClass = new DevicePropertyKey(new Guid("259abffc-50a7-47ce-af08-68c9a7d73366"), 8, "No Display Class", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey SilentInstall = new DevicePropertyKey(new Guid("259abffc-50a7-47ce-af08-68c9a7d73366"), 9, "Silent Install", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey NoUseClass = new DevicePropertyKey(new Guid("259abffc-50a7-47ce-af08-68c9a7d73366"), 10, "No Use Class", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey DefaultService = new DevicePropertyKey(new Guid("259abffc-50a7-47ce-af08-68c9a7d73366"), 11, "Default Service", DevicePropertyType.String);
            public static readonly DevicePropertyKey IconPath = new DevicePropertyKey(new Guid("259abffc-50a7-47ce-af08-68c9a7d73366"), 12, "Icon Path", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey DHPRebalanceOptOut = new DevicePropertyKey(new Guid("d14d3ef3-66cf-4ba2-9d38-0ddb37ab4701"), 2, "DHP Rebalance Opt-Out", DevicePropertyType.Boolean);

            //
            // Other Device setup class properties
            //
            public static readonly DevicePropertyKey ClassCoInstallers = new DevicePropertyKey(new Guid("713d1703-a2e2-49f5-9214-56472ef3da5c"), 2, "Class CoInstallers", DevicePropertyType.StringList);
        }

        public static class DeviceInterface
        {
            //
            // Device interface properties
            //
            public static readonly DevicePropertyKey FriendlyName = new DevicePropertyKey(new Guid("026e516e-b814-414b-83cd-856d6fef4822"), 2, "Friendly Name", DevicePropertyType.String);
            public static readonly DevicePropertyKey Enabled = new DevicePropertyKey(new Guid("026e516e-b814-414b-83cd-856d6fef4822"), 3, "Enabled", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey ClassGuid = new DevicePropertyKey(new Guid("026e516e-b814-414b-83cd-856d6fef4822"), 4, "Class GUID", DevicePropertyType.Guid);
            public static readonly DevicePropertyKey ReferenceString = new DevicePropertyKey(new Guid("026e516e-b814-414b-83cd-856d6fef4822"), 5, "Reference String", DevicePropertyType.String);
            public static readonly DevicePropertyKey Restricted = new DevicePropertyKey(new Guid("026e516e-b814-414b-83cd-856d6fef4822"), 6, "Restricted", DevicePropertyType.Boolean);
        }

        public static class DeviceInterfaceClass
        {
            //
            // Device interface class properties
            //
            public static readonly DevicePropertyKey DefaultInterface = new DevicePropertyKey(new Guid("14c83a99-0b3f-44b7-be4c-a178d3990564"), 2, "Default Interface", DevicePropertyType.String);
            public static readonly DevicePropertyKey Name = new DevicePropertyKey(new Guid("14c83a99-0b3f-44b7-be4c-a178d3990564"), 3, "Name", DevicePropertyType.String);
        }

        public static class DeviceContainer
        {
            //
            // Device Container Properties
            //
            public static readonly DevicePropertyKey Address = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 51, "Address", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey DiscoveryMethod = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 52, "Discovery Method", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey IsEncrypted = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 53, "Is Encrypted", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey IsAuthenticated = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 54, "Is Authenticated", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey IsConnected = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 55, "Is Connected", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey IsPaired = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 56, "Is Paired", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey Icon = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 57, "Icon", DevicePropertyType.String);
            public static readonly DevicePropertyKey Version = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 65, "Version", DevicePropertyType.String);
            public static readonly DevicePropertyKey LastSeen = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 66, "Last Seen", DevicePropertyType.FileTime);
            public static readonly DevicePropertyKey LastConnected = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 67, "Last Connected", DevicePropertyType.FileTime);
            public static readonly DevicePropertyKey IsShowInDisconnectedState = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 68, "Is Show In Disconnected State", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey IsLocalMachine = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 70, "Is Local Machine", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey MetadataPath = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 71, "Metadata Path", DevicePropertyType.String);
            public static readonly DevicePropertyKey IsMetadataSearchInProgress = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 72, "Is Metadata Search In Progress", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey MetadataChecksum = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 73, "Metadata Checksum", DevicePropertyType.Binary);
            public static readonly DevicePropertyKey IsNotInterestingForDisplay = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 74, "Is Not Interesting For Display", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey LaunchDeviceStageOnDeviceConnect = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 76, "Launch Device Stage On Device Connect", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey LaunchDeviceStageFromExplorer = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 77, "Launch Device Stage From Explorer", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey BaselineExperienceId = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 78, "Baseline Experience ID", DevicePropertyType.Guid);
            public static readonly DevicePropertyKey IsDeviceUniquelyIdentifiable = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 79, "Is Device Uniquely Identifiable", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey AssociationArray = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 80, "Association Array", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey DeviceDescription1 = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 81, "Device Description 1", DevicePropertyType.String);
            public static readonly DevicePropertyKey DeviceDescription2 = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 82, "Device Description 2", DevicePropertyType.String);
            public static readonly DevicePropertyKey HasProblem = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 83, "Has Problem", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey IsSharedDevice = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 84, "Is Shared Device", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey IsNetworkDevice = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 85, "Is Network Device", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey IsDefaultDevice = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 86, "Is Default Device", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey MetadataCabinet = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 87, "Metadata Cabinet", DevicePropertyType.String);
            public static readonly DevicePropertyKey RequiresPairingElevation = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 88, "Requires Pairing Elevation", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey ExperienceId = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 89, "Experience ID", DevicePropertyType.Guid);
            public static readonly DevicePropertyKey Category = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 90, "Category", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey CategoryDescSingular = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 91, "Category Description Singular", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey CategoryDescPlural = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 92, "Category Description Plural", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey CategoryIcon = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 93, "Category Icon", DevicePropertyType.String);
            public static readonly DevicePropertyKey CategoryGroupDesc = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 94, "Category Group Description", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey CategoryGroupIcon = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 95, "Category Group Icon", DevicePropertyType.String);
            public static readonly DevicePropertyKey PrimaryCategory = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 97, "Primary Category", DevicePropertyType.String);
            public static readonly DevicePropertyKey UnpairUninstall = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 98, "Unpair Uninstall", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey RequiresUninstallElevation = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 99, "Requires Uninstall Elevation", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey DeviceFunctionSubRank = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 100, "Device Function Sub Rank", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey AlwaysShowDeviceAsConnected = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 101, "Always Show Device As Connected", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey ConfigFlags = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 105, "Configuration Flags", DevicePropertyType.UInt32);
            public static readonly DevicePropertyKey PrivilegedPackageFamilyNames = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 106, "Privileged Package Family Names", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey CustomPrivilegedPackageFamilyNames = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 107, "Custom Privileged Package Family Names", DevicePropertyType.StringList);
            public static readonly DevicePropertyKey IsRebootRequired = new DevicePropertyKey(new Guid("78c34fc8-104a-4aca-9ea4-524d52996e57"), 108, "Is Reboot Required", DevicePropertyType.Boolean);

            public static readonly DevicePropertyKey FriendlyName = new DevicePropertyKey(new Guid("656A3BB3-ECC0-43FD-8477-4AE0404A96CD"), 12288, "Friendly Name", DevicePropertyType.String);
            public static readonly DevicePropertyKey Manufacturer = new DevicePropertyKey(new Guid("656A3BB3-ECC0-43FD-8477-4AE0404A96CD"), 8192, "Manufacturer", DevicePropertyType.String);
            public static readonly DevicePropertyKey ModelName = new DevicePropertyKey(new Guid("656A3BB3-ECC0-43FD-8477-4AE0404A96CD"), 8194, "Model Name", DevicePropertyType.String);
            public static readonly DevicePropertyKey ModelNumber = new DevicePropertyKey(new Guid("656A3BB3-ECC0-43FD-8477-4AE0404A96CD"), 8195, "Model Number", DevicePropertyType.String);

            public static readonly DevicePropertyKey InstallInProgress = new DevicePropertyKey(new Guid("83da6326-97a6-4088-9453-a1923f573b29"), 9, "Install In Progress", DevicePropertyType.Boolean);
        }

        public static class DeviceDisplay
        {
            //
            // DeviceContainer properties that can be set on a devnode.
            // These used to be defined as DeviceDisplay
            //
            public static readonly DevicePropertyKey DiscoveryMethod = DevicePropertyKeys.DeviceContainer.DiscoveryMethod;
            public static readonly DevicePropertyKey IsShowInDisconnectedState = DevicePropertyKeys.DeviceContainer.IsShowInDisconnectedState;
            public static readonly DevicePropertyKey IsNotInterestingForDisplay = DevicePropertyKeys.DeviceContainer.IsNotInterestingForDisplay;
            public static readonly DevicePropertyKey IsNetworkDevice = DevicePropertyKeys.DeviceContainer.IsNetworkDevice;
            public static readonly DevicePropertyKey Category = DevicePropertyKeys.DeviceContainer.Category;
            public static readonly DevicePropertyKey UnpairUninstall = DevicePropertyKeys.DeviceContainer.UnpairUninstall;
            public static readonly DevicePropertyKey RequiresUninstallElevation = DevicePropertyKeys.DeviceContainer.RequiresUninstallElevation;
            public static readonly DevicePropertyKey AlwaysShowDeviceAsConnected = DevicePropertyKeys.DeviceContainer.AlwaysShowDeviceAsConnected;
        }

        public static class HumanInterfaceDevice
        {
            //
            // HID device interface properties
            //
            public static readonly DevicePropertyKey UsagePage = new DevicePropertyKey(new Guid("cbf38310-4a17-4310-a1eb-247f0b67593b"), 2, "Usage Page", DevicePropertyType.UInt16);
            public static readonly DevicePropertyKey UsageId = new DevicePropertyKey(new Guid("cbf38310-4a17-4310-a1eb-247f0b67593b"), 3, "Usage ID", DevicePropertyType.UInt16);
            public static readonly DevicePropertyKey IsReadOnly = new DevicePropertyKey(new Guid("cbf38310-4a17-4310-a1eb-247f0b67593b"), 4, "Is Read-Only", DevicePropertyType.Boolean);
            public static readonly DevicePropertyKey VendorId = new DevicePropertyKey(new Guid("cbf38310-4a17-4310-a1eb-247f0b67593b"), 5, "Vendor ID", DevicePropertyType.UInt16);
            public static readonly DevicePropertyKey ProductId = new DevicePropertyKey(new Guid("cbf38310-4a17-4310-a1eb-247f0b67593b"), 6, "Product ID", DevicePropertyType.UInt16);
            public static readonly DevicePropertyKey VersionNumber = new DevicePropertyKey(new Guid("cbf38310-4a17-4310-a1eb-247f0b67593b"), 7, "Version Number", DevicePropertyType.UInt16);
        }
    }
}
