using System;

namespace WindowsDeviceManager.Api
{
    [Flags]
    public enum GetClassDevsFlags : UInt32
    {
        /// <summary>
        /// No flags are set.
        /// </summary>
        None = 0x00,

        /// <summary>
        /// Return only the device that is associated with the system default device interface, if one is set, for
        /// the specified device interface classes.
        /// </summary>
        Default = 0x01,

        /// <summary>
        /// Return only devices that are currently present in a system.
        /// </summary>
        Present = 0x02,

        /// <summary>
        /// Return a list of installed devices for all device setup classes or all device interface classes.
        /// </summary>
        AllClasses = 0x04,

        /// <summary>
        /// Return only devices that are a part of the current hardware profile.
        /// </summary>
        Profile = 0x08,

        /// <summary>
        /// Return devices that support device interfaces for the specified device interface classes. This flag must be
        /// set in the <c>flags</c> parameter if the <c>enumerator</c> parameter specifies a device instance ID.
        /// </summary>
        DeviceInterface = 0x10,
    }
}
