using System;
using System.Runtime.InteropServices;

namespace WindowsDeviceManager.Api
{
    /// <summary>
    /// Extension methods for working with device property keys.
    /// </summary>
    public static class StructureExtensions
    {
        public static int GetSize(this SP_DEVINFO_DATA deviceInfoData)
        {
            return Marshal.SizeOf(deviceInfoData);
        }
    }
}
