using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Automation;
using System.Runtime.InteropServices;

namespace UpLoadNews
{
    class ImageProShow
    {
        public string Image { get; set; }
        public int Time { get; set; }

        public ImageProShow(string image, int time)
        {
            string[] xxx = image.Split('\\');

            Image = xxx[xxx.Length - 2] + "\\" + xxx[xxx.Length - 1];
            Time = time;
        }
    }
    public class Proshow
    {
        public static string getLocalInProshow(string local)
        {
            string goc = Application.StartupPath + "\\Temp\\xxxxxxxx";
            string retun = "";
            for (int i = 0; i < goc.Split('\\').Length; i++)
            {
                retun += "../";
            }
            return retun + local.Replace("\\", "/");
        }
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
        public async Task<double> getDuration(string path)
        {
            try
            {
                string localFFmpeg = Application.StartupPath+ "\\Win32bit\\ffmpeg.exe";

                StreamReader errorreader;

                Process ffmpeg = new Process();

                ffmpeg.StartInfo.UseShellExecute = false;
                ffmpeg.StartInfo.ErrorDialog = false;
                ffmpeg.StartInfo.RedirectStandardError = true;

                ffmpeg.StartInfo.FileName = localFFmpeg;
                ffmpeg.StartInfo.Arguments = "-i \"" + path + "\"";
                ffmpeg.StartInfo.CreateNoWindow = true;

                ffmpeg.Start();

                errorreader = ffmpeg.StandardError;

                ffmpeg.WaitForExit();

                string result = errorreader.ReadToEnd();

                string durations = result.Substring(result.IndexOf("Duration: ") + ("Duration: ").Length, ("00:00:00.00").Length);
                TimeSpan time = TimeSpan.Parse(durations);
                double du = time.TotalSeconds;
                return du;
            }
            catch (Exception)
            {
             

            }
            return 0;
        }

    
        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        internal static extern int AllowSetForegroundWindow(int dwProcessId);
        public Boolean AutomateRunProshow(int id,string localFilePSH,string outVideo,string proshow)
        {
            try
            {
                //var path = Path.Combine(Application.StartupPath + "\\ProShow Producer\\proshow.exe");

                //path = "C:\\Program Files (x86)\\Photodex\\ProShow Producer\\proshow.exe";
                //Process.Start("ProShow Producer");
                System.Diagnostics.ProcessStartInfo oInfo = new System.Diagnostics.ProcessStartInfo();
                string runvideo = proshow;// "C:\\Program Files (x86)\\Photodex\\ProShow Producer\\proshow.exe";// System.IO.Directory.GetCurrentDirectory() + @"\Effect\CreateVideoEffect.exe";
                oInfo.FileName = runvideo;
                System.Diagnostics.Process procvideo = new System.Diagnostics.Process();
                procvideo.StartInfo = oInfo;
                procvideo.Start();

                IntPtr hwnd = IntPtr.Zero;

                try
                {
                    while (true)
                    {
                        hwnd = FindWindow(null, "ProShow Producer - Designerz Zin Thien Tuan");
                        if ((int)hwnd != 0 && hwnd != null)
                        {
                            AllowSetForegroundWindow(int.Parse(hwnd.ToString()));
                            break;
                        }
                        Thread.Sleep(500);
                    }
                }
                catch (Exception)
                {
                }

                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(localFilePSH);
                p.Start();
                string title = "ProShow Producer - Designerz Zin Thien Tuan - " + id + ".psh";
                string title2 = "ProShow Producer - Evaluation Copy - " + id + ".psh";
               

                try
                {
                    while (true)
                    {

                        hwnd = FindWindow(null, title);
                        if ((int)hwnd != 0 && hwnd != null)
                        {
                            break;
                        }
                        //else
                        //{
                        //    Thread.Sleep(1000);
                        //    SendKeys.Send("{ENTER}");
                        //}
                        Thread.Sleep(500);
                    }
                }
                catch (Exception)
                {
                }
                AutomationElement window = null;
                int count = 300;
                while (true)
                {
                    try
                    {
                        window = AutomationElement.FromHandle(hwnd);
                        break;
                    }
                    catch (Exception)
                    {
                        if (count == 0)
                        {
                            return false;
                        }
                        Thread.Sleep(1000);
                        count--;
                        try
                        {
                            while (true)
                            {
                                hwnd = FindWindow(null, title);
                                if ((int)hwnd != 0 && hwnd != null)
                                {
                                    break;
                                }
                                else
                                {
                                    hwnd = FindWindow(null, title2);
                                    if ((int)hwnd != 0 && hwnd != null)
                                    {
                                        break;
                                    }
                                }
                                Thread.Sleep(500);
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                return StartRender(window, title, outVideo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private Boolean StartRender(AutomationElement window, string title,string outVideo)
        {
            try
            {
                Thread.Sleep(1000);                
               
                SendKeys.SendWait("%{F3}");
                var menu = Wait(window, "tbpMainProducer", 300);
              

                var openDialogRecover = window.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window));
                if (openDialogRecover != null)
                {                  
                        var btnYes = Wait(openDialogRecover, "No", 300);// dialogConfirm.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, "Yes"));
                        ((InvokePattern)btnYes.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
                  
                }
               
                //try
                //{
                //    var openDialogMC = WaitForDialog(window, "Unsupported data found.", 300);
                //    var btnok = Wait(openDialogMC, "OK", 300);
                //    ((InvokePattern)btnok.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
                //}
                //catch {  }
                try
                {
                    var buttonVideo = Wait(menu, "Video", 300);
                    ((InvokePattern)buttonVideo.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
                }
                catch (Exception)
                {
                    SendKeys.SendWait("^+%V");

                }
                var openDialog = WaitForDialog(window, "Video for Web, Devices and Computers", 300);
                var buttonCreate = Wait(openDialog, "Create", 300);
                ((InvokePattern)buttonCreate.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
                var openDialogSave = WaitForDialog(window, "Save Video File", 300);
                var cb = openDialogSave.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ComboBox));
                ((ValuePattern)cb.GetCurrentPattern(ValuePattern.Pattern)).SetValue(outVideo);
                Thread.Sleep(500);
                SendKeys.SendWait("^a");
                SendKeys.SendWait("^c");
                SendKeys.SendWait("^x");
                Thread.Sleep(200);
                SendKeys.SendWait("^v");

                var buttonSave = Wait(openDialogSave, "Save", 300);
                ((InvokePattern)buttonSave.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
                Thread.Sleep(1000);
                var dialogConfirm = openDialogSave.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window));
                if (dialogConfirm != null)
                {
                    var btnYes = Wait(dialogConfirm, "Yes", 300);
                    ((InvokePattern)btnYes.GetCurrentPattern(InvokePattern.Pattern)).Invoke();
                }
                var openDialogRender = WaitForDialog(window, "Rendering Video", 300);
                try
                {
                    var openDialogMessage = WaitForDialog(window, "Message", 7200);
                }
                catch (Exception)
                {
                }
                Process[] localByName = Process.GetProcessesByName("proshow");
                localByName[0].Kill();
                return true;
            }
            catch (Exception e)
            {
                try
                {
                    Process[] localByName = Process.GetProcessesByName("proshow");
                    localByName[0].Kill();
                }
                catch (Exception)
                {
                }
                return false;
            }

        }

        private AutomationElement Wait(AutomationElement element, string name, int timeout)
        {
            // note: this should be improved for error checking (timeouts, etc.)
            while (true)
            {
                if (timeout == 0)
                {
                    return null;
                }
                var openDialog = element.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, name));
                if (openDialog != null)
                    return openDialog;
                Thread.Sleep(1000);
                timeout--;
            }
        }

        private AutomationElement WaitForDialog(AutomationElement element, string dialogname, int timeout)
        {
            // note: this should be improved for error checking (timeouts, etc.)

            while (true)
            {
                if (timeout == 0)
                {
                    return null;
                }
                var openDialog = element.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window));
                if (openDialog != null)
                    if (openDialog.Current.Name == dialogname)
                    {
                        return openDialog;
                    }
                Thread.Sleep(1000);
                timeout--;
            }
        }
    }
  
}
