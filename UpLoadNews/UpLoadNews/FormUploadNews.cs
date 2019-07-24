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
using System.IO;

using UpLoadNews.Properties;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon;
using Amazon.Polly.Model;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Reflection;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Web;

namespace UpLoadNews
{
    public partial class FormUploadNews : Form
    {
        public FormUploadNews(int idtaikhoan)
        {
            InitializeComponent();
            IDTaiKhoan = idtaikhoan;
        }
        #region // hien thi danh sach kenh
        private int m_IDTaiKhoan;
        public int IDTaiKhoan
        {
            get
            {
                return m_IDTaiKhoan;
            }

            set
            {
                m_IDTaiKhoan = value;
            }
        }

        private void hienthicmbkenh()
        {
            try
            {
                daWS_FakeAuto kenh = new daWS_FakeAuto();
                DataTable dt = new DataTable();
                dt = kenh.DanhSachKenh(m_IDTaiKhoan);
                cmbchannel.DataSource = dt;
                cmbchannel.DisplayMember = "Mail";
                cmbchannel.ValueMember = "ID";


            }
            catch { }
        }
        #endregion

        private void hienthibaiviet()
        {
            daWS_FakeAuto baiviet = new daWS_FakeAuto();
            DataTable dt = new DataTable();
            dt = baiviet.DanhSachBaiVietDaRenderProshow(int.Parse(cmbchannel.SelectedValue.ToString()));
            dataGridViewList.DataSource = dt;

            //Thông tin kênh
            daWS_FakeAuto thongtin = new daWS_FakeAuto();
            DataTable tt = new DataTable();
            tt = thongtin.ThongTinKenh(m_IDTaiKhoan, int.Parse(cmbchannel.SelectedValue.ToString()));
            if (tt.Rows.Count > 0)
            {
                DataRow r = tt.Rows[0];
                txtadddesc.Text = r["MoTa"].ToString();              
            }
        }
        private string Randomtext()
        {
            var chars = "01234567834233224112288889";
            var stringChars = new char[5];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            string finalString = new String(stringChars);
            return finalString;
        }
        #region // load folder output
        private void configinputandoutput()
        {
            try
            {
                if (ConfigurationManager.AppSettings["OutputFolder"].ToString() == "")
                {
                    if (!Directory.Exists("D:\\_OutputFolder"))
                    {
                        Directory.CreateDirectory("D:\\_OutputFolder");
                    }
                    txtfoldervideo.Text = @"D:\_OutputFolder";
                }
                else
                {
                    txtfoldervideo.Text = ConfigurationManager.AppSettings["OutputFolder"].ToString();
                }
            }
            catch { }
        }
        #endregion
        private void khoitao()
        {
            txttextchannel.Text = "ChangeChannel" + Randomtext();          
            hienthicmbkenh();
            configinputandoutput();
            hienthibaiviet();          
            hienthisoluongdaup();
            layngayhientai();

        }
        private void layngayhientai()
        {
            if (txtdatenow.Text != DateTime.Now.ToString("yyyyMMdd") & txtvideoupload.Value>=txtvideomax.Value)
            {
                txtdatenow.Text = DateTime.Now.ToString("yyyyMMdd");
                hienthisoluongdaup();
            }
            else
            {
                txtdatenow.Text = DateTime.Now.ToString("yyyyMMdd");
            }
        }
        private void FormUploadNews_Load(object sender, EventArgs e)
        {

            CheckForIllegalCrossThreadCalls = false;
            khoitao();
        }
        #region // upload youtube
        private string m_IDVideoUpload;
        private async Task RunUpload(string path, string title, string desc, string tag, string flat)
        {
            m_IDVideoUpload = "";
            UserCredential credential;
            using (var stream = new FileStream(Application.StartupPath + @"\client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { YouTubeService.Scope.YoutubeUpload },
                   txttextchannel.Text,// "user",
                    CancellationToken.None
                ).Result;
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = Assembly.GetExecutingAssembly().GetName().Name

            });

            var video = new Video();
            video.Snippet = new VideoSnippet();
            video.Snippet.Title = title;// tiêu đề video upload
            video.Snippet.Description = desc;
            var filePath = path;
            video.Snippet.Tags = tag.ToString().Split(new string[] { "," }, StringSplitOptions.None);
            video.Status = new VideoStatus();
            video.Status.PrivacyStatus = flat; // or "private" or "public"
            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var videosInsertRequest = youtubeService.Videos.Insert(video, "snippet,status", fileStream, "video/*");
                videosInsertRequest.ResponseReceived += videosInsertRequest_ResponseReceived;
                await videosInsertRequest.UploadAsync();

            }
        }
        void videosInsertRequest_ResponseReceived(Video video)
        {
            m_IDVideoUpload = video.Id;
        }
        private async Task setThumnail(string PathThumnail, string ID)
        {
            UserCredential credential;
            using (var stream = new FileStream(Application.StartupPath + @"\client_secrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { YouTubeService.Scope.Youtube },
                   cmbchannel.Text,// "user",
                    CancellationToken.None
                ).Result;
            }

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = Assembly.GetExecutingAssembly().GetName().Name

            });
            using (var fileStream = new FileStream(PathThumnail, FileMode.Open))
            {
                //var requeststream = youtubeService.Thumbnails.Set(response.Id.ToString(), fileStream, "image/jpeg");

                //var responsestream = requeststream.UploadAsync();


                ThumbnailsResource tr = new ThumbnailsResource(youtubeService);
                ThumbnailsResource.SetMediaUpload mediaUploadThumbnail = tr.Set(ID.ToString(), fileStream, "image/jpeg");
                //  mediaUploadThumbnail.ChunkSize = 256 * 1024; 
                await mediaUploadThumbnail.UploadAsync();


            }
        }

        #endregion
        private void hienthisoluongdaup()
        {
            try
            {
                daWS_FakeAuto daup = new daWS_FakeAuto();
                txtvideoupload.Value = daup.BaiVietDaUpTrongNgay(int.Parse(cmbchannel.SelectedValue.ToString()));
            }
            catch { }
        }
        // - Giải nén file
        private void ExtractRAR(string rar_file, string path_file)
        {
            ProcessStartInfo ps = new ProcessStartInfo();
            // - File chương trình nén và giải nén Winar
            ps.FileName = @"WinRAR.exe";
            // - Tham số truyền vào câu lệnh (vd: rar.exe x - trong đó x là tham số)
            // - rar_file: tên file nén | path_file: đường dẫn giải nén(file đc giải nén, thư mục đc giải nén)
            // - \" Thêm vào một dấu nháy kép ("")
            ps.Arguments = "x -y \"" + rar_file + "\" \"" + path_file + "\"";
            ps.WindowStyle = ProcessWindowStyle.Hidden;     // - Ẩn cửa sổ giải nén
                                                            // - Chạy câu lệnh giải nén
            Process proc = Process.Start(ps);
            // - Thoát sau khi giải nén xong
            proc.WaitForExit();
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
        #region // upload len kenh youtube
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
                timerrender.Interval = int.Parse(txtthoigiancho.Text);
                timerrender.Start();
            }
        }
        public static String chuanHoa(String _string)
        {
            return System.Text.RegularExpressions.Regex.Replace(_string, "\\s+", " ");
        }
        private void bgwrender_DoWork(object sender, DoWorkEventArgs e)
        {
            #region // render vids
            try
            {
                //layngayhientai();
                //if (txtdatenow.Text == DateTime.Now.ToString("yyyyMMdd") && txtvideoupload.Value < txtvideomax.Value)
                //{
                   // layngayhientai();
                  
                    #region // thực hiện upload
                    hienthisoluongdaup();
                if (txtvideoupload.Value < txtvideomax.Value)
                {

                    DataTable tablelist = (DataTable)dataGridViewList.DataSource;
                    lblxuly.Text = "Đang đọc dữ liệu....";
                    prs.Maximum = tablelist.Rows.Count;
                    int k = 1;
                    prs.Value = 0;

                    foreach (DataRow r in tablelist.Rows)
                    {

                        string title = r["TieuDe"].ToString().Trim();
                        // string link = r["LinkBaiViet"].ToString();
                        k = int.Parse(r["ID"].ToString());
                        prs.Value = prs.Value + 1;
                        string folder = "KenhNews" + cmbchannel.SelectedValue.ToString();
                        lblxuly.Text = "Downloading :" + title.ToString() + " |" + k.ToString() + "/" + prs.Maximum.ToString();
                        #region // cac xu ly he thong tạo video
                        if (!Directory.Exists(txtfoldervideo.Text + "/" + folder + "/" + k.ToString()))
                        {
                            Directory.CreateDirectory(txtfoldervideo.Text + "/" + folder + "/" + k.ToString());
                        }
                        #region // tai file tren server
                        using (WebClient webClient = new WebClient())
                        {

                            byte[] data = webClient.DownloadData("http://buudienhanoi.com.vn/ThangBDHN_Luu2/FileKetQua/" + k.ToString() + ".rar");
                            File.WriteAllBytes(txtfoldervideo.Text + "/" + folder + "/" + k.ToString() + ".rar", data);
                        }
                        #endregion
                        string rar_fileVideo = txtfoldervideo.Text + "/" + folder + "/" + k.ToString() + ".rar";
                        string path_fileVideo = txtfoldervideo.Text + "/" + folder + "/" + k.ToString();
                        ExtractRAR(rar_fileVideo, path_fileVideo);
                        File.Delete(rar_fileVideo);
                        using (WebClient webClient = new WebClient())
                        {

                            byte[] data = webClient.DownloadData("http://buudienhanoi.com.vn/ThangBDHN_Luu2/FileKetQua/" + k.ToString() + "_Thumnail.rar");
                            File.WriteAllBytes(txtfoldervideo.Text + "/" + folder + "/" + k.ToString() + "_Thumnail.rar", data);
                        }
                        string rar_fileThumnail = txtfoldervideo.Text + "/" + folder + "/" + k.ToString() + "_Thumnail.rar";
                        string path_fileThumnail = txtfoldervideo.Text + "/" + folder + "/" + k.ToString();
                        ExtractRAR(rar_fileThumnail, path_fileThumnail);
                        File.Delete(rar_fileThumnail);
                        string[] filePahts = System.IO.Directory.GetFiles((txtfoldervideo.Text + "/" + folder + "/" + k.ToString() + @"/"), "*.jpeg");
                        string outputthumnail = "";
                        if (filePahts.Length > 0)
                        {
                            outputthumnail = filePahts[0].ToString();

                        }
                        if (checkuploadvideo.Checked == true)
                        {

                            #region // title
                            string _title = r["TieuDe"].ToString();

                            if (title.Length > 100)
                            {
                                _title = (title.Substring(0, 100));
                            }
                            else { _title = title; }

                            #endregion
                            #region desc

                            string _desc = "";
                            string mota = title + "\r\n" + txtadddesc.Text + "\r\n" + r["NoiDung"].ToString().Trim();
                            if (mota.Length > 200) { _desc = chuanHoa(mota.Substring(0, 200)); }
                            else { _desc = chuanHoa(mota); }
                            #endregion
                            string _path = (txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\_VideoUp.mp4");
                            string _tag = r["Tag"].ToString();
                            if (_tag == "")
                            {
                                if (checkrapidtags.Checked == true)
                                {
                                    try
                                    {
                                        ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                                        service.HideCommandPromptWindow = false;
                                        PropretiesCollection.driver = new ChromeDriver(service);
                                        PropretiesCollection.driver.Navigate().GoToUrl("https://rapidtags.io/api/index.php?tool=tag-generator&input=" + HttpUtility.UrlEncode(_title));
                                        cl_ReadVoice tag = new cl_ReadVoice();
                                        tag._tag().Wait();
                                        _tag = tag.Tag;
                                        if (_tag == "[]")
                                        {
                                            _tag = (Cl_Tag.GetTag(title));
                                            _desc = _tag.Replace(",", ",#") + "\r\n" + _desc;
                                        }
                                        else
                                        {
                                            _desc = _desc + "\r\n" + _tag;
                                        }
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
                                    catch
                                    {
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
                                else
                                {
                                    _tag = (Cl_Tag.GetTag(title));
                                    _desc = _desc + "\r\n" + _tag.Replace(",", ",#");
                                }
                            }
                            else
                            {
                                if (_tag.IndexOf(",# ") != -1)
                                {
                                    _desc = _tag.Replace(",# ", ",#") + "\r\n" + _desc;
                                }
                                else
                                {
                                    _desc = _tag.Replace(",", ",#") + "\r\n" + _desc;
                                }
                            }
                            string flat = "";
                            if (rabpublic.Checked == true)
                            {
                                flat = "public";
                            }
                            if (radprivate.Checked == true)
                            { flat = "private"; }
                            if (radunlisted.Checked == true)
                            { flat = "unlisted"; }
                            try
                            {
                                if (raduploadapi.Checked == true)
                                {
                                    RunUpload(_path, _title, _desc.Replace("<", "").Replace(">", ""), _tag, flat).Wait();
                                    setThumnail(outputthumnail, m_IDVideoUpload).Wait();
                                }
                                else if (raduploadchome.Checked == true)
                                {
                                    //_path = new FileInfo(_path).Name.Replace(".mp4", "");
                                    if (checkdefaulprofile.Checked == true)
                                    {
                                        try
                                        {
                                            ChromeOptions options = new ChromeOptions();
                                            options.AddArguments("user-data-dir=C:/Users/" + Environment.GetEnvironmentVariable("UserName") + "/AppData/Local/Google/Chrome/User Data");
                                            options.AddArguments("--start-maximized");
                                            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                                            service.HideCommandPromptWindow = false;
                                            PropretiesCollection.driver = new ChromeDriver(service, options);
                                            PropretiesCollection.driver.Navigate().GoToUrl("https://www.youtube.com/upload?redirect_to_classic=true");
                                            UploadYoutube ytb = new UploadYoutube();
                                            int bkt = 0;
                                            if (checksetmotizeion.Checked == true)
                                            {
                                                bkt = 1;
                                            }
                                            ytb.UploadFroFile(_path, title, _desc.Replace("<", "").Replace(">", ""), _tag, outputthumnail, bkt).Wait();

                                        }
                                        catch { }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                                            service.HideCommandPromptWindow = false;
                                            PropretiesCollection.driver = new ChromeDriver(service);
                                            PropretiesCollection.driver.Navigate().GoToUrl("https://www.youtube.com/upload?redirect_to_classic=true");
                                            UploadYoutube ytb = new UploadYoutube();
                                            ytb.Login(txttaikhoan.Text, txtmatkhau.Text, _path).Wait();
                                            int bkt = 0;
                                            if (checksetmotizeion.Checked == true)
                                            {
                                                bkt = 1;
                                            }
                                            ytb.Upload(_title, _desc, _tag, outputthumnail, bkt).Wait();
                                        }
                                        catch { }
                                    }
                                }
                            }
                            catch { }

                        }
                        if(checkuploadfb.Checked==true)
                        {
                            #region // title
                            string _title = r["TieuDe"].ToString();

                            if (title.Length > 100)
                            {
                                _title = (title.Substring(0, 100));
                            }
                            else { _title = title; }

                            #endregion
                            #region desc

                            string _desc = "";
                            string mota = title + "\r\n" + txtadddesc.Text + "\r\n" + r["NoiDung"].ToString().Trim();
                            if (mota.Length > 200) { _desc = chuanHoa(mota.Substring(0, 200)); }
                            else { _desc = chuanHoa(mota); }
                            #endregion
                            string _path = (txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\_VideoUp.mp4");
                            string _tag = r["Tag"].ToString();
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
                                fb.Upload(_path, title, _desc.Replace("<", "").Replace(">", ""), "", outputthumnail).Wait();
                            }
                            catch { }

                        }
                        #endregion

                        #region // them va link log da upload và xóa folder
                        daWS_FakeAuto log = new daWS_FakeAuto();
                        log.InsertBaiVietDaUp(int.Parse(cmbchannel.SelectedValue.ToString()), k);
                        hienthisoluongdaup();
                        if (checkdelfolder.Checked == true)
                        {
                            hamxoafile(txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString());
                        }
                        try
                        {
                            PropretiesCollection.driver.Close();
                            foreach (Process proc in Process.GetProcessesByName("chromedriver"))
                            {
                                proc.Kill();
                            }
                        }
                        catch { }
                        #endregion

                        k = k + 1;
                        Thread.Sleep(int.Parse(txtsleep.Value.ToString()));

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
                    hienthibaiviet();
                    Thread.Sleep(int.Parse(txtthoigiancho.Text));
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
                timerrender.Interval = int.Parse(txtthoigiancho.Text);
                timerrender.Start();
            }
        }
        #endregion

        private void btninputfolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                txtfoldervideo.Text = fl.SelectedPath;
                ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
                exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
                //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
                cf.AppSettings.Settings.Remove("OutputFolder");
                cf.AppSettings.Settings.Add("OutputFolder", txtfoldervideo.Text);
                cf.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void cmbchannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {

                hienthibaiviet();
                hienthisoluongdaup();

            }
            catch { }
            this.Cursor = Cursors.Default;
        }
        

        private void btnsavecfupload_Click(object sender, EventArgs e)
        {
            ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
            exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
            //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
            cf.AppSettings.Settings.Remove("TaiKhoan");
            cf.AppSettings.Settings.Add("TaiKhoan", txttaikhoan.Text);
            cf.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            ExeConfigurationFileMap exmap1 = new ExeConfigurationFileMap();
            exmap1.ExeConfigFilename = @"UpLoadNews.exe.config";
            Configuration cf1 = ConfigurationManager.OpenMappedExeConfiguration(exmap1, ConfigurationUserLevel.None);
            cf1.AppSettings.Settings.Remove("MatKhau");
            cf1.AppSettings.Settings.Add("MatKhau", txtmatkhau.Text);
            cf1.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
