using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Molemax.App.Core
{
    public class LanguageLibrary
    {
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
        static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)] string lpFileName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int LoadString(IntPtr hInstance, uint uID, StringBuilder lpBuffer, int nBufferMax);

        private IntPtr ipLibHandle = new IntPtr();

        public LanguageLibrary(string libPath)
        {
            ipLibHandle = LoadWin32Library(libPath);
        }

        private IntPtr LoadWin32Library(string libPath)
        {
            if (String.IsNullOrEmpty(libPath))
                throw new ArgumentNullException("libPath");

            //if (Environment.Is64BitProcess)
            //    throw new Exception(String.Format("Can't load {0} because this is a 64 bit proccess", libPath));

            IntPtr moduleHandle = LoadLibrary(libPath);
            if (moduleHandle == IntPtr.Zero)
            {
                var lasterror = Marshal.GetLastWin32Error();
                var innerEx = new Win32Exception(lasterror);
                innerEx.Data.Add("LastWin32Error", lasterror);

                throw new Exception("can't load DLL " + libPath, innerEx);
            }
            return moduleHandle;
        }

        public String GetString(uint uiStringID)
        {
            StringBuilder sb = new StringBuilder(255);
            LoadString(ipLibHandle, uiStringID, sb, sb.Capacity + 1);
            return sb.ToString();
        }
    }
}
