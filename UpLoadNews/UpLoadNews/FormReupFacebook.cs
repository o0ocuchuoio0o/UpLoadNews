using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpLoadNews
{
    public partial class FormReupFacebook : Form
    {
        public FormReupFacebook()
        {
            InitializeComponent();
        }
        private void configlinkpage()
        {            
            try
            {
                if (ConfigurationManager.AppSettings["LinkPage"].ToString() == "")
                {
                    txtlinkpage.Text = "";
                }
                else
                {
                    txtlinkpage.Text = ConfigurationManager.AppSettings["LinkPage"].ToString();
                }
            }
            catch { }
            
        }
        private void FormReupFacebook_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            configlinkpage();
        }


        #region // chọn folder file video
        private void ListFile(string path)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name",typeof(string));
            dt.Columns.Add("Path", typeof(string));
            string[] fileList = System.IO.Directory.GetFiles(path);
            //duyệt từng file và copy đè lên file cũ trong thư mục đang chạy chương trình
            foreach (string sourceFile in fileList)
            {
                //tách tên file ra khỏi đường dẫn (tên file sẽ dùng để tạo đường dẫn đích cần copy đè)
                string fileName = System.IO.Path.GetFileName(sourceFile);
                //tạo đường dẫn đích để copy file mới tới
                if (fileName.IndexOf(".mp4")!=-1 || fileName.IndexOf(".avi")!=-1)
                {
                    dt.Rows.Add(fileName.Replace(".mp4","").Replace(".avi",""), path+@"\"+fileName);
                }

            }
            dataListFile.DataSource = dt;
        }
        private void btninputfolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                txtfoldervideo.Text = fl.SelectedPath;
                ListFile(txtfoldervideo.Text);
            }
        }
        #endregion

        private void btnsavelink_Click(object sender, EventArgs e)
        {
            ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
            exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
            //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
            cf.AppSettings.Settings.Remove("LinkPage");
            cf.AppSettings.Settings.Add("LinkPage", txtlinkpage.Text);
            cf.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        #region // upload facebook
        private void btnrender_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bgwrender.IsBusy)
                {
                    timerrender.Enabled = false;
                    timerrender.Stop();
                    bgwrender.RunWorkerAsync();

                }
            }
            catch
            {
                lblxuly.Text = string.Empty;
                timerrender.Enabled = true;
                timerrender.Interval = 15000;
                timerrender.Start();
            }
        }
        private void hamxoafile(string path)
        {
            string[] fileList = System.IO.Directory.GetFiles(path);
            //duyệt từng file và copy đè lên file cũ trong thư mục đang chạy chương trình
            foreach (string sourceFile in fileList)
            {
                //tách tên file ra khỏi đường dẫn (tên file sẽ dùng để tạo đường dẫn đích cần copy đè)
                string fileName = System.IO.Path.GetFileName(sourceFile);
                //tạo đường dẫn đích để copy file mới tới
                string destinationFile = path + @"\" + fileName;
                //thực hiện xóa file
                System.IO.File.Delete(destinationFile);
            }
        }
        private void bgwrender_DoWork(object sender, DoWorkEventArgs e)
        {
            #region // render vids
            try
            {              

                #region // thực hiện upload               
                if (txtvideoupload.Value < txtvideomax.Value)
                {

                    DataTable tablelist = (DataTable)dataListFile.DataSource;
                    lblxuly.Text = "Đang đọc dữ liệu....";
                
                    prs.Maximum = tablelist.Rows.Count;
                    int k = 1;
                    prs.Value = 0;

                    foreach (DataRow r in tablelist.Rows)
                    {
                        lblxuly.Text = "Upload :" + r["Name"].ToString();
                        #region // title
                        string _title = r["Name"].ToString();

                        if (_title.Length > 100)
                        {
                            _title = (_title.Substring(0, 100));
                        }
                        else { }

                        #endregion
                        #region desc

                        string _desc = "";
                        string mota = _title;
                        #endregion
                        string _path = r["Path"].ToString();
                       // string _tag ="";
                        try
                        {
                            ChromeOptions options = new ChromeOptions();
                            options.AddArguments("user-data-dir=C:/Users/" + Environment.GetEnvironmentVariable("UserName") + "/AppData/Local/Google/Chrome/User Data");
                            options.AddArguments("--start-maximized");
                            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                            service.HideCommandPromptWindow = false;
                            PropretiesCollection.driver = new ChromeDriver(service, options);
                            PropretiesCollection.driver.Navigate().GoToUrl(txtlinkpage.Text);
                            UploadFacebook fb = new UploadFacebook();
                            fb.Upload(_path, _title, _desc.Replace("<", "").Replace(">", ""), "", "").Wait();
                            if (checkdelfolder.Checked == true)
                            {
                                System.IO.File.Delete(_path);
                            }
                        }
                        catch { }
                        txtvideoupload.Value = txtvideoupload.Value + 1;
                        k = k + 1;
                        Thread.Sleep(15000);
                      
                        try
                        {
                            PropretiesCollection.driver.Close();
                            foreach (Process proc in Process.GetProcessesByName("chromedriver"))
                            {
                                proc.Kill();
                            }
                        }
                        catch { }
                    }
                    #endregion
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); return; }
            #endregion

        }

        private void bgwrender_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
            }
            else
            {
                if (!bgwrender.IsBusy)
                {

                    prs.Value = 0;
                    lblxuly.Text = "Complete!";
                    ListFile(txtfoldervideo.Text);
                    Thread.Sleep(15000);
                    timerrender.Enabled = true;
                    timerrender.Start();
                }
            }
        }

        private void timerrender_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!bgwrender.IsBusy)
                {
                    bgwrender.RunWorkerAsync();
                    timerrender.Enabled = false;
                    timerrender.Stop();
                }

            }
            catch
            {
                timerrender.Enabled = true;
                timerrender.Interval = 15000;
                timerrender.Start();
            }
        }
        #endregion
    }
}
