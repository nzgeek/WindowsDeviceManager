using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WindowsDeviceManager.Api
{
    public static class ErrorHelpers
    {
        public static int GetLastError()
        {
            return Marshal.GetLastWin32Error();
        }

        public static string GetErrorMessage(int errorCode)
        {
            const int formatMessageFromSystem = 0x1000;

            using (var buffer = new Api.Buffer(4096))
            {
                int messageLen = FormatMessage(formatMessageFromSystem, IntPtr.Zero, errorCode, 0, buffer.Data, buffer.Length, IntPtr.Zero);
                if (messageLen == 0)
                    return string.Format("Unknown error code [0].", errorCode);

                var messageBytes = buffer.GetBytes(0, messageLen * 2);
                return Encoding.Unicode.GetString(messageBytes);
            }
        }

        [DllImport("Kernel32.dll", EntryPoint = "FormatMessageW", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int FormatMessage(int flags,
            IntPtr source,
            int messageId,
            int languageId,
            IntPtr buffer,
            int bufferLen,
            IntPtr varArgs);
    }

    public static class ErrorCode
    {
        public const int InsufficientBuffer = 122;
        public const int NoMoreItems = 259;
        public const int NotFound = 1168;
    }
}
