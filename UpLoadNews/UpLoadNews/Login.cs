using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DaoUploadNews;
using System.Configuration;
using System.Diagnostics;
using System.Speech.Recognition;
using OpenQA.Selenium.Chrome;
using System.Web;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace UpLoadNews
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public int GetInstalledApps()
        {
            int kq = 0;
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                           if(skName.ToString()== "BytescoutLosslessCodec")
                            {
                                kq = 1;
                            }
                        }
                        catch 
                        {
                        }
                    }
                }
            }
            return kq;
        }

        private int GetOSArchitecture()
        {
            string pa =
                Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            return ((String.IsNullOrEmpty(pa) ||
                     String.Compare(pa, 0, "x86", 0, 3, true) == 0) ? 32 : 64);
        }
        private void config()
        {
            string duongdan = "";
            try
            {
                int checkio = GetOSArchitecture();

                if (checkio == 64)
                {
                    duongdan = System.IO.Directory.GetCurrentDirectory() + @"\Win64bit\ffmpeg.exe";
                }
                else
                {
                    duongdan = System.IO.Directory.GetCurrentDirectory() + @"\Win32bit\ffmpeg.exe";
                }
            }
            catch
            {
                duongdan = System.IO.Directory.GetCurrentDirectory() + @"\Win32bit\ffmpeg.exe";
            }
            ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
            exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
            //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
            cf.AppSettings.Settings.Remove("ffmpeg:ExeLocation");
            cf.AppSettings.Settings.Add("ffmpeg:ExeLocation", duongdan);
            cf.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        private int m_vession;
        public int Vession
        {
            get { return m_vession; }
            set { m_vession = value; }
        }
        private void khoitao()
        {
            VessionBE vession = new VessionBE();
            VessionBL vessionxyly = new VessionBL();
            vession = vessionxyly.docdulieu(Environment.CurrentDirectory + "/CauHinhVession.xml");
            Vession = Convert.ToInt32(vession.Vession.ToString());
        }
        private void Login_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            //#region // cai sdk
            //int sdk = 0;
            //sdk = GetInstalledApps();
            //if (sdk == 0)
            //{
            //    if (MessageBox.Show("Máy tính bạn thiếu SDK của hệ thống hãy làm theo các bước hướng dẫn sau", "Cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            //    == DialogResult.Yes)
            //    {
            //        this.Hide();
            //        FormCaiDatSDK sdkistall = new FormCaiDatSDK();
            //        sdkistall.Show();

            //    }
            //}

            //#endregion
            //else if(sdk==1)
            //{
                khoitao();
                #region // kiểm tra vession
                daWS_FakeAuto kiemtravs = new daWS_FakeAuto();
                int vessionmoi = kiemtravs.Vession();
                if (vessionmoi != m_vession)
                {
                    try
                    {
                        try
                        {
                            foreach (Process proc in Process.GetProcessesByName("AutoUpdate"))
                            {
                                proc.Kill();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        Process.Start("AutoUpdate.exe");

                    }
                    catch
                    {
                        return;
                    }
                }

                #endregion
                config();
           // }
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
                #region // xác thực đăng nhập
                string taikhoan = "";
                string matkhau = "";
                try { taikhoan = txtaikhoan.Text.Trim(); }
                catch
                {
                    MessageBox.Show("Loi", "Hay nhap vao tai khoan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try { matkhau = txtatkhau.Text.Trim(); }
                catch
                {
                    MessageBox.Show("Loi", "Hay nhap vao matkhau", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataTable dt = new DataTable();
                daWS_FakeAuto dn = new daWS_FakeAuto();
                dt = dn.DangNhap(taikhoan, matkhau);
                if (dt.Rows.Count > 0)
                {
                    DataRow r = dt.Rows[0];
                    string thongbao = r["ThongBao"].ToString();
                    if (thongbao == "1")
                    {
                        int idtaikhoan = int.Parse(r["ID"].ToString());
                        this.Hide();
                        if (radupload.Checked == true)
                        {
                        FormUploadNews upload = new FormUploadNews(idtaikhoan);
                        upload.Show();
                        }
                        else if (radrender.Checked == true)
                        {
                        FormUpload render = new FormUpload(idtaikhoan);
                        render.Show();
                        }
                        else if (radmanagerchannel.Checked == true)
                        {
                            FormManageChannel manager = new FormManageChannel();
                            manager.Show();
                        }
                        else if (radreupfacebook.Checked == true)
                        {
                            FormReupFacebook reupfb = new FormReupFacebook();
                            reupfb.Show();
                        }
                }
                    else
                    {
                        MessageBox.Show(thongbao, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi trong quá trình đăng nhập", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion
            
        }

        private void btnsdk_Click(object sender, EventArgs e)
        {
            FormCaiDatSDK sdk = new FormCaiDatSDK();
            sdk.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ProcessStartInfo oInfo = new ProcessStartInfo();
            oInfo.FileName = @"C:\web-automation-master\WebAutomation\bin\Debug\WebAutomation.exe";          
                oInfo.CreateNoWindow = true;
                oInfo.WindowStyle = ProcessWindowStyle.Hidden;           
            oInfo.Arguments =@"go(""https://www.youtube.com/channel/UC8PcqYak4pVeKeN1zb6PFOg"");";

            try
            {
                //run the process
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = oInfo;
                proc.Start();
                proc.WaitForExit();
               
                proc.Close();

            }
            catch (Exception)
            {
               
            }
            finally
            {
            
            }
           

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //CoreDriver something = new CoreDriver(); // creating an object
            //                                         // settings
            //something.my_port = 50150; // multiple chrome instances - will be run on different ports
            //                           // I am currently having 4 chrome profiles ;)
            //something.my_name = "mynewprofile"; // full profile name will be: 'profile + my_name'. Check the code of the object.
            //                                    // void
            //something.ConfigureProfile(); // creating new profile or updating existing one, if folder eists
            //something.Initialize();


            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments("user-data-dir=C:/Users/" + Environment.GetEnvironmentVariable("UserName") + "/AppData/Local/Google/Chrome/User Data");
            //options.AddArguments("--start-maximized");
            //ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            //service.HideCommandPromptWindow = false;
            //PropretiesCollection.driver = new ChromeDriver(service, options);
            //PropretiesCollection.driver.Navigate().GoToUrl("https://dailymotion.com/upload");

            //voice.selectIspeech("Korean");

            //UploadDailymotion fb = new UploadDailymotion();
            //string _path = @"D:\681.mp4";
            //fb.Upload(_path, "tieu de", "mo ta", "tag tesst", "News", "").Wait();

            ChromeOptions options = new ChromeOptions();
            // options.AddArgument("headless");
            // PropretiesCollection.driver = new ChromeDriver(service,options);
            PropretiesCollection.driver = new ChromeDriver(options);
            PropretiesCollection.driver.Navigate().GoToUrl("https://ttstool.com/");

            cl_ReadVoice voice = new cl_ReadVoice();
            voice.getvoicemp3_TTSTOOL("Microsoft", "Catalan", "Herena (Catalan)", "sdgdfgdfgdfgd");

            //resizes.ThumnailConfigTitle(@"C:\thumnailboder.jpeg", @"C:\title.jpeg", @"D:\thumnailtitle.jpeg");

            //    string voicexuly = @"C:\a" + @"\KenhNews92\785093";
            //    string name= "6767562.wav";
            //    if (hamkiemtratontaifile(voicexuly,name)==true)
            //    {
            //        int times = (int)Proshow.getDuration(voicexuly + @"\" + name);
            //        MessageBox.Show(times.ToString());
            //    }
            //    else
            //    {
            //        MessageBox.Show("exre");
            //    }
        }
        private bool hamkiemtratontaifile(string path, string name)
        {
            bool kq = false;
            string[] fileList = System.IO.Directory.GetFiles(path);
            //duyệt từng file và copy đè lên file cũ trong thư mục đang chạy chương trình
            foreach (string sourceFile in fileList)
            {
                //tách tên file ra khỏi đường dẫn (tên file sẽ dùng để tạo đường dẫn đích cần copy đè)
                string fileName = System.IO.Path.GetFileName(sourceFile);
                //tạo đường dẫn đích để copy file mới tới
                if (fileName == name)
                {
                    kq = true;
                }

            }
            return kq;
        }


        private async Task downloadFileV2(string url, string path)
        {
            using (WebClient wc = new WebClient())
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                wc.DownloadFileCompleted += wc_DownloadFileCompletedV2;
                wc.DownloadFileAsync(new Uri(url), path);
            }
        }
        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //  progressBar1.Value = e.ProgressPercentage;
        }

        private void wc_DownloadFileCompletedV2(object sender, AsyncCompletedEventArgs e)
        {
          

        }

    }
}
