using System;
using System.Runtime.InteropServices;

namespace WindowsDeviceManager.Api
{
    /// <summary>
    /// Helper functions to help dealing with Win32 errors.
    /// </summary>
    public static class ErrorHelpers
    {
        /// <summary>
        /// Get the last Win32 error code that resulted from a P/Invoke API call.
        /// </summary>
        /// <returns>The last Win32 error code.</returns>
        public static int GetLastError()
        {
            return Marshal.GetLastWin32Error();
        }

        /// <summary>
        /// Creates an appropriate type of exception for the last Win32 error.
        /// </summary>
        /// <param name="format">A format string for the exception message.</param>
        /// <param name="args">Insertion values for the exception message.</param>
        /// <returns>An exception that is appropriate for the last Win32 error.</returns>
        public static Exception CreateException(string format, params object[] args)
        {
            return CreateException(string.Format(format, args));
        }

        /// <summary>
        /// Creates an appropriate type of exception for the last Win32 error.
        /// </summary>
        /// <param name="message">A message to place in the exception.</param>
        /// <returns>An exception that is appropriate for the last Win32 error.</returns>
        public static Exception CreateException(string message)
        {
            return CreateException(GetLastError(), message);
        }

        /// <summary>
        /// Creates an appropriate type of exception for the specified Win32 error code.
        /// </summary>
        /// <param name="errorCode">The error code to create an exception for.</param>
        /// <param name="format">A format string for the exception message.</param>
        /// <param name="args">Insertion values for the exception message.</param>
        /// <returns>An exception that is appropriate for the specified Win32 error.</returns>
        public static Exception CreateException(int errorCode, string format, params object[] args)
        {
            return CreateException(errorCode, string.Format(format, args));
        }

        /// <summary>
        /// Creates an appropriate type of exception for the specified Win32 error code.
        /// </summary>
        /// <param name="errorCode">The error code to create an exception for.</param>
        /// <param name="message">A message to place in the exception.</param>
        /// <returns>An exception that is appropriate for the specified Win32 error.</returns>
        public static Exception CreateException(int errorCode, string message)
        {
            // Access denied errors have their own exception type.
            if (errorCode == ErrorCode.AccessDenied)
            {
                return new DeviceManagerSecurityException("Insufficient rights to perform the requested operation.");
            }

            // SetupApi reports a custom error code if you try to call 64-bit driver functions from a 32-bit app.
            // This error code isn't documented well, so it's quite confusing if the code is returned.
            // Rather than cause confusion, that error is mapped to a similar Windows error code, making the actual
            // issue easier to diagnose.
            if (errorCode == ErrorCode.SetupApiErrorInWow64)
            {
                errorCode = ErrorCode.ImageMachineTypeMismatch;
            }

            // Return an exception that contains the error code.
            return new DeviceManagerWindowsException(errorCode, message);
        }
    }

    /// <summary>
    /// Win32 error code definitions.
    /// </summary>
    public static class ErrorCode
    {
        /// <summary>
        /// Access is denied.
        /// </summary>
        public const int AccessDenied = 5;

        /// <summary>
        /// The data area passed to a system call is too small.
        /// </summary>
        public const int InsufficientBuffer = 122;

        /// <summary>
        /// No more data is available.
        /// </summary>
        public const int NoMoreItems = 259;

        /// <summary>
        /// The image file %hs is valid, but is for a machine type other than the current machine.
        /// </summary>
        public const int ImageMachineTypeMismatch = 720;

        /// <summary>
        /// Element not found.
        /// </summary>
        public const int NotFound = 1168;

        /// <summary>
        /// Architecture mismatch between x86 and x64.
        /// </summary>
        public const int SetupApiErrorInWow64 = -536870347;
    }
}
