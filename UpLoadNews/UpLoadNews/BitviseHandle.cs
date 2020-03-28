using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using ManagedWinapi.Windows;

namespace UpLoadNews
{
    public static class BitviseHandle
    {
        #region Windows API - user32.dll configs
        private const int WM_CLOSE = 16;
        private const int BN_CLICKED = 245;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(int hWnd, int msg, int wParam, IntPtr lParam);
        //Click - Worked Perfect
        //SendMessage((int)hwnd, WM_LBUTTONDOWN, 0, IntPtr.Zero);
        //Thread.Sleep(100);
        //SendMessage((int)hwnd, WM_LBUTTONUP, 0, IntPtr.Zero);
        //---
        //Close Window
        //SendMessage((int)hwnd, WM_CLOSE ,0 , IntPtr.Zero);
        #endregion

        private static Hashtable BitviseList = new Hashtable();
        public static int TimeoutSeconds = 30;

        private static int PortIndex = 1079;
        public static int GetPortAvailable()
        {
            PortIndex++;
            if (PortIndex >= 1181) PortIndex = 1079;
            Process BitviseApp = new Process();
            BitviseList.Add(PortIndex, BitviseApp);
            return PortIndex;
        }

        public static bool Connect(string Host, string User, string Pass, int ForwardPort)
        {
            bool Connected = false;

            //Start Bitvise - Auto Login
            ProcessStartInfo sinfo = new ProcessStartInfo();
            sinfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "BitviseSSHClient\\BvSsh.exe";
            sinfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + "BitviseSSHClient";
            sinfo.Arguments = "-profile=\"" + AppDomain.CurrentDomain.BaseDirectory + "BitviseSSHClient\\" + ForwardPort + ".bscp\" -host=" + Host + " -user=" + User + " -password=" + Pass + " -loginOnStartup -hide=trayIcon";
            Process BitviseApp = Process.Start(sinfo);

            BitviseList[ForwardPort] = BitviseApp;

            Thread.Sleep(2000);

            //Bitvise Login Checking...
            for (int i = 0; i < TimeoutSeconds; i++)
            {
                //Detect Host Key Verification
                SystemWindow[] wins = SystemWindow.FilterToplevelWindows((SystemWindow w) => { return w.Title == "Host Key Verification"; });
                if (wins.Length > 0)
                {
                    SystemWindow[] wins2 = wins[0].FilterDescendantWindows(false, (SystemWindow w) => { return w.Title == "&Accept for This Session"; }); //Accept and &Save
                    if (wins2.Length > 0)
                    {
                        //Click 4 times to effected !
                        SendMessage((int)wins2[0].HWnd, WM_LBUTTONDOWN, 0, IntPtr.Zero);
                        Thread.Sleep(10);
                        SendMessage((int)wins2[0].HWnd, WM_LBUTTONUP, 0, IntPtr.Zero);

                        SendMessage((int)wins2[0].HWnd, WM_LBUTTONDOWN, 0, IntPtr.Zero);
                        Thread.Sleep(10);
                        SendMessage((int)wins2[0].HWnd, WM_LBUTTONUP, 0, IntPtr.Zero);
                    }
                }

                //Detect Connected
                SystemWindow[] wins3 = SystemWindow.FilterToplevelWindows((SystemWindow w) => { return w.Title == "Bitvise SSH Client - " + ForwardPort + ".bscp - " + Host + ":22"; });
                if (wins3.Length > 0)
                {
                    Connected = true;
                    break;
                }

                Thread.Sleep(1000);
            }

            if (Connected == false)
            {
                try
                {
                    BitviseApp.Kill();
                    BitviseApp.Dispose();
                }
                catch { }
            }


            return Connected;
        }

        public static void Disconnect(int ForwardPort)
        {
            if (BitviseList[ForwardPort] == null) return;

            try
            {
                Process BitviseApp = BitviseList[ForwardPort] as Process;
                BitviseApp.Kill();
                BitviseApp.Dispose();
            }
            catch { }
        }

        private static bool GetPort(string Host, int Port)
        {
            return true;

            //using (TcpClient tcpClient = new TcpClient())
            //{
            //    IAsyncResult result = tcpClient.BeginConnect(Host, Port, null, null);
            //    WaitHandle timeoutHandler = result.AsyncWaitHandle;
            //    try
            //    {
            //        if (!result.AsyncWaitHandle.WaitOne(200, false))
            //        {
            //            tcpClient.Close();
            //            return false;
            //        }

            //        tcpClient.EndConnect(result);
            //    }
            //    catch
            //    {
            //        return false;
            //    }
            //    finally
            //    {
            //        timeoutHandler.Close();
            //    }
            //    return true;
            //}
        }
    }
}
