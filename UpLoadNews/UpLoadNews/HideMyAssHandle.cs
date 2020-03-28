using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UpLoadNews
{
    public static class HideMyAssHandle
    {
        #region Windows API - user32.dll configs
        [DllImport("user32.dll")]
        private static extern int FindWindow(string lpClassName, String lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);

        [DllImport("user32.dll")]
        private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 dwData, IntPtr dwExtraInfo);

        private const UInt32 MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const UInt32 MOUSEEVENTF_LEFTUP = 0x0004;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)] //http://msdn.microsoft.com/en-us/library/windows/desktop/ms646291(v=vs.85).aspx
        private static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        //const uint WM_KEYDOWN = 0x0100;
        //const uint WM_KEYUP = 0x0101;
        //const uint WM_CHAR = 0x0102;
        //const int VK_TAB = 0x09;
        //const int VK_ENTER = 0x0D;
        //const int VK_UP = 0x26;
        //const int VK_DOWN = 0x28;
        //const int VK_RIGHT = 0x27;
        //public const int WM_CLEAR = 0x0303;
        private const int BN_CLICKED = 245;
        private const int WM_LBUTTONDBLCLK = 0x0203;
        private const int WM_SETTEXT = 0x000C;
        private const int WM_PASTE = 0x0302;
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        private static extern IntPtr SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);
        //[DllImport("user32.dll")]
        //public static extern int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        //[DllImport("user32.dll")]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);
        #endregion

        private static string AppFolder { set; get; }
        private static string AppName { set; get; }
        private static string AppLogFile { set; get; }

        public static string FirefoxUsed = "";

        public static bool Connect()
        {
            bool Connected = false;

            //Detect App Folder
            AppName = "HMA! Pro VPN";
            AppFolder = @"C:\Program Files (x86)\HMA! Pro VPN\bin\";
            AppLogFile = AppFolder.Replace(@"\bin\", @"\log\ip_history.log");
            if (File.Exists(AppFolder + AppName + ".exe") == false)
            {
                AppFolder = @"C:\Program Files\HMA! Pro VPN\bin\";
                AppLogFile = AppFolder.Replace(@"\bin\", @"\log\ip_history.log");
                if (File.Exists(AppFolder + AppName + ".exe") == false)
                {
                    return Connected;
                }
            }


            StartHMA:

            // Delete log file before start new connect
            while (File.Exists(AppLogFile))
            {
                try
                {
                    File.Delete(AppLogFile);
                    Thread.Sleep(1000);
                }
                catch { }
            }

            // If HMA.exe exists then Disconnect
            Process[] prs = Process.GetProcessesByName(AppName);
            if (prs.Length > 0)
            {
                if (prs[0].Responding == false)
                {
                    while (prs.Length > 0)
                    {
                        try
                        {
                            prs[0].Kill();
                            prs[0].Close();
                        }
                        catch { }
                        prs = Process.GetProcessesByName(AppName);
                    }
                    Thread.Sleep(2000);

                    // Start HMA.exe & Connect
                    Process.Start(AppFolder + AppName + ".exe");
                    CheckWarningUpdate();
                }
            }
            // Update Registry before start HMA.exe
            else
            {
                //Registry.SetValue(@"HKEY_CURRENT_USER\Software\Privax\HMA! Pro VPN\Settings", "LoginID", hmaAcc[0]);
                //Registry.SetValue(@"HKEY_CURRENT_USER\Software\Privax\HMA! Pro VPN\Settings", "LoginKey", hmaAcc[1]);
                //Registry.SetValue(@"HKEY_CURRENT_USER\Software\Privax\HMA! Pro VPN\Settings", "ProtocolType2", "1");//1: OpenVPN, 2: PPTP
                //Registry.SetValue(@"HKEY_CURRENT_USER\Software\Privax\HMA! Pro VPN\Settings", "Region", hmaAcc[2]);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Privax\HMA! Pro VPN\Settings", "LogIPHistory", "True");

                // Start HMA.exe & Connect
                Process.Start(AppFolder + AppName + ".exe");
                CheckWarningUpdate();
            }


            // Connect
            Process.Start(AppFolder + AppName + ".exe", "-disconnect");
            Thread.Sleep(3000);
            Process.Start(AppFolder + AppName + ".exe", "-connect");

            // Check Connected and Kill Error, Crash
            for (int i = 0; i < 120; i++)
            {
                Thread.Sleep(1000);

                if (i % 5 == 0)
                {
                    // Check CrashReport
                    if (FindWindow(default(string), "CrashReport") > 0)
                    {
                        prs = Process.GetProcessesByName(AppName);
                        while (prs.Length > 0)
                        {
                            try
                            {
                                prs[0].Kill();
                                prs[0].Close();
                            }
                            catch { }
                            prs = Process.GetProcessesByName(AppName);
                        }

                        goto StartHMA;
                    }
                }

                // Check new IP Address
                if ((i > 15) && (i % 3 == 0))
                {
                    if (File.Exists(AppLogFile))
                    {
                        Connected = true;
                        break;
                    }

                    //foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                    //{
                    //    if ((nic.Description.Contains("TAP-Win32 Adapter V9") || nic.NetworkInterfaceType == NetworkInterfaceType.Ppp) && nic.OperationalStatus == OperationalStatus.Up)
                    //    {
                    //        Connected = true;
                    //        break;
                    //    }
                    //}
                    //if (Connected) break;
                }
            }

            if (Connected == false)
            {
                prs = Process.GetProcessesByName(AppName);
                while (prs.Length > 0)
                {
                    try
                    {
                        prs[0].Kill();
                        prs[0].Close();
                    }
                    catch { }
                    prs = Process.GetProcessesByName(AppName);
                }
            }


            return Connected;
        }

        public static void Disconnect()
        {
            try
            {
                Process.Start(AppFolder + AppName + ".exe", "-disconnect");
            }
            catch { }
        }


        private static void CheckWarningUpdate()
        {
            for (int i = 0; i < 15; i++)
            {
                Thread.Sleep(1000);

                if (i % 3 == 0)
                {
                    // Disable Warning Update new version
                    int WarningBox = FindWindow(default(string), "Warning");
                    if (WarningBox > 0)
                    {
                        try
                        {
                            IntPtr btnNoThanks = FindWindowEx((IntPtr)WarningBox, IntPtr.Zero, default(string), "No thanks");
                            SendMessage(btnNoThanks, BN_CLICKED, IntPtr.Zero, null);
                        }
                        catch { }
                    }
                }
            }
        }
    }
}
