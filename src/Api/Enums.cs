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
    [Flags]
    public enum ConfigurationFlags : uint
    {
        /// <summary>
        /// No flags are enabled.
        /// </summary>
        CONFIGFLAG_NONE = 0x00000,

        /// <summary>
        /// Set if disabled.
        /// </summary>
        CONFIGFLAG_DISABLED = 0x00001,

        /// <summary>
        /// Set if a present hardware enum device deleted.
        /// </summary>
        CONFIGFLAG_REMOVED = 0x00002,

        /// <summary>
        /// Set if the devnode was manually installed.
        /// </summary>
        CONFIGFLAG_MANUAL_INSTALL = 0x00004,

        /// <summary>
        /// Set if skip the boot config.
        /// </summary>
        CONFIGFLAG_IGNORE_BOOT_LC = 0x00008,

        /// <summary>
        /// Load this devnode when in net boot.
        /// </summary>
        CONFIGFLAG_NET_BOOT = 0x00010,

        /// <summary>
        /// Redo install.
        /// </summary>
        CONFIGFLAG_REINSTALL = 0x00020,

        /// <summary>
        /// Failed the install.
        /// </summary>
        CONFIGFLAG_FAILEDINSTALL = 0x00040,

        /// <summary>
        /// Can't stop/remove a single child.
        /// </summary>
        CONFIGFLAG_CANTSTOPACHILD = 0x00080,

        /// <summary>
        /// Can remove even if rom.
        /// </summary>
        CONFIGFLAG_OKREMOVEROM = 0x00100,

        /// <summary>
        /// Don't remove at exit.
        /// </summary>
        CONFIGFLAG_NOREMOVEEXIT = 0x00200,

        /// <summary>
        /// Complete install for devnode running 'raw'.
        /// </summary>
        CONFIGFLAG_FINISH_INSTALL = 0x00400,

        /// <summary>
        /// This devnode requires a forced config.
        /// </summary>
        CONFIGFLAG_NEEDS_FORCED_CONFIG = 0x00800,

        /// <summary>
        /// This is the remote boot network card.
        /// </summary>
        CONFIGFLAG_NETBOOT_CARD = 0x01000,

        /// <summary>
        /// This device has a partial logconfig.
        /// </summary>
        CONFIGFLAG_PARTIAL_LOG_CONF = 0x02000,

        /// <summary>
        /// Set if unsafe removals should be ignored.
        /// </summary>
        CONFIGFLAG_SUPPRESS_SURPRISE = 0x04000,

        /// <summary>
        /// Set if hardware should be tested for logo failures.
        /// </summary>
        CONFIGFLAG_VERIFY_HARDWARE = 0x08000,

        /// <summary>
        /// Show the finish install wizard pages for the installed device.
        /// </summary>
        CONFIGFLAG_FINISHINSTALL_UI = 0x10000,

        /// <summary>
        /// Call installer with DIF_FINISHINSTALL_ACTION in client context.
        /// </summary>
        CONFIGFLAG_FINISHINSTALL_ACTION = 0x20000,

        /// <summary>
        /// Configured devnode during boot phase.
        /// </summary>
        CONFIGFLAG_BOOT_DEVICE = 0x40000,
    }

    [Flags]
    public enum DeviceInterfaceFlags : uint
    {
        SPINT_NONE      = 0x0000,
        SPINT_ACTIVE    = 0x0001,
        SPINT_DEFAULT   = 0x0002,
        SPINT_REMOVED   = 0x0004,
    }

    public enum DeviceInstallFunction : uint
    {
        DIF_SELECTDEVICE                    = 0x0001,
        DIF_INSTALLDEVICE                   = 0x0002,
        DIF_ASSIGNRESOURCES                 = 0x0003,
        DIF_PROPERTIES                      = 0x0004,
        DIF_REMOVE                          = 0x0005,
        DIF_FIRSTTIMESETUP                  = 0x0006,
        DIF_FOUNDDEVICE                     = 0x0007,
        DIF_SELECTCLASSDRIVERS              = 0x0008,
        DIF_VALIDATECLASSDRIVERS            = 0x0009,
        DIF_INSTALLCLASSDRIVERS             = 0x000A,
        DIF_CALCDISKSPACE                   = 0x000B,
        DIF_DESTROYPRIVATEDATA              = 0x000C,
        DIF_VALIDATEDRIVER                  = 0x000D,
        DIF_DETECT                          = 0x000F,
        DIF_INSTALLWIZARD                   = 0x0010,
        DIF_DESTROYWIZARDDATA               = 0x0011,
        DIF_PROPERTYCHANGE                  = 0x0012,
        DIF_ENABLECLASS                     = 0x0013,
        DIF_DETECTVERIFY                    = 0x0014,
        DIF_INSTALLDEVICEFILES              = 0x0015,
        DIF_UNREMOVE                        = 0x0016,
        DIF_SELECTBESTCOMPATDRV             = 0x0017,
        DIF_ALLOW_INSTALL                   = 0x0018,
        DIF_REGISTERDEVICE                  = 0x0019,
        DIF_NEWDEVICEWIZARD_PRESELECT       = 0x001A,
        DIF_NEWDEVICEWIZARD_SELECT          = 0x001B,
        DIF_NEWDEVICEWIZARD_PREANALYZE      = 0x001C,
        DIF_NEWDEVICEWIZARD_POSTANALYZE     = 0x001D,
        DIF_NEWDEVICEWIZARD_FINISHINSTALL   = 0x001E,
        DIF_INSTALLINTERFACES               = 0x0020,
        DIF_DETECTCANCEL                    = 0x0021,
        DIF_REGISTER_COINSTALLERS           = 0x0022,
        DIF_ADDPROPERTYPAGE_ADVANCED        = 0x0023,
        DIF_ADDPROPERTYPAGE_BASIC           = 0x0024,
        DIF_TROUBLESHOOTER                  = 0x0026,
        DIF_POWERMESSAGEWAKE                = 0x0027,
        DIF_ADDREMOTEPROPERTYPAGE_ADVANCED  = 0x0028,
        DIF_UPDATEDRIVER_UI                 = 0x0029,
        DIF_FINISHINSTALL_ACTION            = 0x002A,
    }

    public enum DevicePropertyChangeScope : uint
    {
        DICS_FLAG_GLOBAL            = 0x00000001,   // make change in all hardware profiles
        DICS_FLAG_CONFIGSPECIFIC    = 0x00000002,   // make change in specified profile only
    }

    public enum DevicePropertyChangeState : uint
    {
        DICS_ENABLE     = 0x00000001,
        DICS_DISABLE    = 0x00000002,
        DICS_PROPCHANGE = 0x00000003,
        DICS_START      = 0x00000004,
        DICS_STOP       = 0x00000005,
    }

    public enum DeviceRegistryPropertyCode : uint
    {
        SPDRP_DEVICEDESC                    = 0x0000,   // DeviceDesc (R/W)
        SPDRP_HARDWAREID                    = 0x0001,   // HardwareID (R/W)
        SPDRP_COMPATIBLEIDS                 = 0x0002,   // CompatibleIDs (R/W)
        SPDRP_SERVICE                       = 0x0004,   // Service (R/W)
        SPDRP_CLASS                         = 0x0007,   // Class (R--tied to ClassGUID)
        SPDRP_CLASSGUID                     = 0x0008,   // ClassGUID (R/W)
        SPDRP_DRIVER                        = 0x0009,   // Driver (R/W)
        SPDRP_CONFIGFLAGS                   = 0x000A,   // ConfigFlags (R/W)
        SPDRP_MFG                           = 0x000B,   // Mfg (R/W)
        SPDRP_FRIENDLYNAME                  = 0x000C,   // FriendlyName (R/W)
        SPDRP_LOCATION_INFORMATION          = 0x000D,   // LocationInformation (R/W)
        SPDRP_PHYSICAL_DEVICE_OBJECT_NAME   = 0x000E,   // PhysicalDeviceObjectName (R)
        SPDRP_CAPABILITIES                  = 0x000F,   // Capabilities (R)
        SPDRP_UI_NUMBER                     = 0x0010,   // UiNumber (R)
        SPDRP_UPPERFILTERS                  = 0x0011,   // UpperFilters (R/W)
        SPDRP_LOWERFILTERS                  = 0x0012,   // LowerFilters (R/W)
        SPDRP_BUSTYPEGUID                   = 0x0013,   // BusTypeGUID (R)
        SPDRP_LEGACYBUSTYPE                 = 0x0014,   // LegacyBusType (R)
        SPDRP_BUSNUMBER                     = 0x0015,   // BusNumber (R)
        SPDRP_ENUMERATOR_NAME               = 0x0016,   // Enumerator Name (R)
        SPDRP_SECURITY                      = 0x0017,   // Security (R/W, binary form)
        SPDRP_SECURITY_SDS                  = 0x0018,   // Security (W, SDS form)
        SPDRP_DEVTYPE                       = 0x0019,   // Device Type (R/W)
        SPDRP_EXCLUSIVE                     = 0x001A,   // Device is exclusive-access (R/W)
        SPDRP_CHARACTERISTICS               = 0x001B,   // Device Characteristics (R/W)
        SPDRP_ADDRESS                       = 0x001C,   // Device Address (R)
        SPDRP_UI_NUMBER_DESC_FORMAT         = 0X001D,   // UiNumberDescFormat (R/W)
        SPDRP_DEVICE_POWER_DATA             = 0x001E,   // Device Power Data (R)
        SPDRP_REMOVAL_POLICY                = 0x001F,   // Removal Policy (R)
        SPDRP_REMOVAL_POLICY_HW_DEFAULT     = 0x0020,   // Hardware Removal Policy (R)
        SPDRP_REMOVAL_POLICY_OVERRIDE       = 0x0021,   // Removal Policy Override (RW)
        SPDRP_INSTALL_STATE                 = 0x0022,   // Device Install State (R)
        SPDRP_LOCATION_PATHS                = 0x0023,   // Device Location Paths (R)
        SPDRP_BASE_CONTAINERID              = 0x0024,   // Base ContainerID (R)
    }

    [Flags]
    public enum GetClassDevsFlags : uint
    {
        /// <summary>
        /// No flags are set.
        /// </summary>
        DIGCF_NONE = 0x00,

        /// <summary>
        /// Return only the device that is associated with the system default device interface, if one is set, for
        /// the specified device interface classes.
        /// </summary>
        DIGCF_DEFAULT = 0x01,

        /// <summary>
        /// Return only devices that are currently present in a system.
        /// </summary>
        DIGCF_PRESENT = 0x02,

        /// <summary>
        /// Return a list of installed devices for all device setup classes or all device interface classes.
        /// </summary>
        DIGCF_ALLCLASSES = 0x04,

        /// <summary>
        /// Return only devices that are a part of the current hardware profile.
        /// </summary>
        DIGCF_PROFILE = 0x08,

        /// <summary>
        /// Return devices that support device interfaces for the specified device interface classes. This flag must be
        /// set in the <c>flags</c> parameter if the <c>enumerator</c> parameter specifies a device instance ID.
        /// </summary>
        DIGCF_DEVICEINTERFACE = 0x10,
    }
}
