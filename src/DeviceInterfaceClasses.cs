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
    public static class DeviceInterfaceClasses
    {
        public static readonly Guid All = Guid.Empty;

        // Device classes from https://msdn.microsoft.com/en-us/library/windows/hardware/ff553412(v=vs.85).aspx

        // IEEE-1394 and IEC-61883 devices
        public static readonly Guid Firewire = new Guid("6BDD1FC1-810F-11D0-BEC7-08002BE2092F");
        public static readonly Guid FirewireAV = new Guid("7EBEFBC0-3200-11D2-B4C2-00A0C9697D07");

        // Battery and ACPI devices
        public static readonly Guid ApplicationLaunchButton = new Guid("629758EE-986E-4D9E-8E47-DE27F8AB054D");
        public static readonly Guid Battery = new Guid("72631E54-78A4-11D0-BCF7-00AA00B7B32A");
        public static readonly Guid Lid = new Guid("4AFA3D52-74A7-11D0-BE5E-00A0C9062857");
        public static readonly Guid Memory = new Guid("3FD0F03D-92E0-45FB-B75C-5ED8FFB01021");
        public static readonly Guid MessageIndicator = new Guid("CD48A365-FA94-4CE2-A232-A1B764E5D8B4");
        public static readonly Guid Processor = new Guid("97FADB10-4E33-40AE-359C-8BEF029DBDD0");
        public static readonly Guid SystemButton = new Guid("4AFA3D53-74A7-11D0-BE5E-00A0C9062857");
        public static readonly Guid ThermalZone = new Guid("4AFA3D51-74A7-11D0-BE5E-00A0C9062857");

        // Bluetooth devices
        public static readonly Guid Bluetooth = new Guid("0850302A-B344-4FDA-9BE9-90576B8D46F0");

        // Display and image devices
        public static readonly Guid Brightness = new Guid("FDE5BBA4-B3F9-46FB-BDAA-0728CE3100B4");
        public static readonly Guid DisplayAdapter = new Guid("5B45201D-F2F2-4F3B-85BB-30FF1F953599");
        public static readonly Guid DisplayDeviceArrival = new Guid("1CA05180-A699-450A-9A0C-DE4FBE3DDD89");
        public static readonly Guid DisplayI2C = new Guid("2564AA4F-DDDB-4495-B497-6AD4A84163D7");
        public static readonly Guid DisplayOutputProtectionManagement = new Guid("BF4672DE-6B4E-4BE4-A325-68A91EA49C09");
        public static readonly Guid ImageCapture = new Guid("6BDD1FC6-810F-11D0-BEC7-08002BE2092F");
        public static readonly Guid Monitor = new Guid("E6F07B5F-EE97-4A90-B076-33F57BF4EAA7");

        // Interactive input devices
        public static readonly Guid HumanInterfaceDevice = new Guid("4D1E55B2-F16F-11CF-88CB-001111000030");
        public static readonly Guid Keyboard = new Guid("884B96C3-56EF-11D1-BC8C-00A0C91405DD");
        public static readonly Guid Mouse = new Guid("378DE44C-56EF-11D1-BC8C-00A0C91405DD");

        // Modem devices
        public static readonly Guid Modem = new Guid("2C7089AA-2E0E-11D1-B114-00C04FC2AAE4");

        // Network devices
        public static readonly Guid Network = new Guid("CAC88484-7515-4C03-82E6-71A87ABAC361");

        // Sensor devices
        public static readonly Guid Sensor = new Guid("BA1BB692-9B7A-4833-9A1E-525ED134E7E2");

        // Serial and parallel port devices
        public static readonly Guid ComPort = new Guid("86E0D1E0-8089-11D0-9CE4-08003E301F73");
        public static readonly Guid ParallelDevice = new Guid("811FC6A5-F728-11D0-A537-0000F8753ED1");
        public static readonly Guid ParallelPort = new Guid("97F76EF0-F883-11D0-AF1F-0000F800845C");
        public static readonly Guid SerialBusEnumerator = new Guid("4D36E978-E325-11CE-BFC1-08002BE10318");

        // Storage devices
        public static readonly Guid CdChanger = new Guid("53F56312-B6BF-11D0-94F2-00A0C91EFB8B");
        public static readonly Guid CdRom = new Guid("53F56308-B6BF-11D0-94F2-00A0C91EFB8B");
        public static readonly Guid Disk = new Guid("53F56307-B6BF-11D0-94F2-00A0C91EFB8B");
        public static readonly Guid Floppy = new Guid("53F56311-B6BF-11D0-94F2-00A0C91EFB8B");
        public static readonly Guid MediumChanger = new Guid("53F56310-B6BF-11D0-94F2-00A0C91EFB8B");
        public static readonly Guid Partition = new Guid("53F5630A-B6BF-11D0-94F2-00A0C91EFB8B");
        public static readonly Guid StoragePort = new Guid("2ACCFE60-C130-11D2-B082-00A0C91EFB8B");
        public static readonly Guid Tape = new Guid("53F5630B-B6BF-11D0-94F2-00A0C91EFB8B");
        public static readonly Guid Volume = new Guid("53F5630D-B6BF-11D0-94F2-00A0C91EFB8B");
        public static readonly Guid WriteOnceDisk = new Guid("53F5630C-B6BF-11D0-94F2-00A0C91EFB8B");

        // USB devices
        public static readonly Guid UsbDevice = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED");
        public static readonly Guid UsbHostController = new Guid("3ABF6F2D-71C4-462A-8A92-1E6861E6AF27");
        public static readonly Guid UsbHub = new Guid("F18A0E88-C30C-11D0-8815-00A0C906BED8");

        // Windows portable devices
        public static readonly Guid WindowsPortableDevice = new Guid("6AC27878-A6FA-4155-BA85-F98F491D4F33");
        public static readonly Guid WindowsPortableDevicePrivate = new Guid("BA0C718F-4DED-49B7-BDD3-FABE28661211");

        // Windows SideShow devices
        public static readonly Guid WindowsSideShow = new Guid("152E5811-FEB9-4B00-90F4-D32947AE1681");

        // System devices
        public static readonly Guid Biometric = new Guid("53D29EF7-377C-4D14-864B-EB3A85769359");
        public static readonly Guid System = new Guid("4D36E97D-E325-11CE-BFC1-08002BE10318");
    }
}
