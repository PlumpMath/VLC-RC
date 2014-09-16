using System;
using System.IO;
using System.Runtime.InteropServices;

public static class CdBayControl
{
    const int OPEN_EXISTING = 3;
    const uint GENERIC_READ = 0x80000000;
    const uint GENERIC_WRITE = 0x40000000;
    const uint IOCTL_STORAGE_EJECT_MEDIA = 2967560;

    [DllImport("kernel32")]
    private static extern IntPtr CreateFile
        (string filename, uint desiredAccess, 
         uint shareMode, IntPtr securityAttributes,
         int creationDisposition, int flagsAndAttributes, 
         IntPtr templateFile);

    [DllImport("kernel32")]
    private static extern int DeviceIoControl
        (IntPtr deviceHandle, uint ioControlCode, 
         IntPtr inBuffer, int inBufferSize,
         IntPtr outBuffer, int outBufferSize, 
         ref int bytesReturned, IntPtr overlapped);

    [DllImport("kernel32")]
    private static extern int CloseHandle(IntPtr handle);

    public static void EjectMedia(char driveLetter)
    {
        string path = "\\\\.\\" + driveLetter + ":";
        IntPtr handle = CreateFile(path, GENERIC_READ | GENERIC_WRITE, 0, 
                                   IntPtr.Zero, OPEN_EXISTING, 0,
                                   IntPtr.Zero);
        if ((long) handle == -1)
        {
            throw new IOException("Unable to open drive " + driveLetter);
        }
        int dummy = 0;
        DeviceIoControl(handle, IOCTL_STORAGE_EJECT_MEDIA, IntPtr.Zero, 0, 
                        IntPtr.Zero, 0, ref dummy, IntPtr.Zero);
        CloseHandle(handle);
    }
}