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
using System.IO.Compression;
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
using System.Speech.Synthesis;
using NAudio.Wave;
using NAudio.Lame;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Web;
using OpenQA.Selenium.Firefox;
using HtmlAgilityPack;
using Newtonsoft.Json;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace UpLoadNews
{
    public partial class FormUpload : Form
    {
        public FormUpload(int idtaikhoan)
        {
            InitializeComponent();
            AddInstalledVoicesToList();
            IDTaiKhoan = idtaikhoan;
            List<string> fonts = new List<string>();
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fonts.Add(font.Name);
            }
            cmbfonthardsub.DataSource = fonts;
            cmbfontthumnail.DataSource = fonts;
        }
       
        #region //Voice TTS
        private void AddInstalledVoicesToList()
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                foreach (var voice in synth.GetInstalledVoices())
                {
                    ddlVoices.Items.Add(voice.VoiceInfo.Name);
                }
            }
            ddlVoices.SelectedIndex = 0;
        }
        public static void ConvertWavStreamToMp3File(ref MemoryStream ms, string savetofilename)
        {
           // rewind to beginning of stream
            ms.Seek(0, SeekOrigin.Begin);
            using (var retMs = new MemoryStream())
            using (var rdr = new WaveFileReader(ms))
            using (var wtr = new LameMP3FileWriter(savetofilename, rdr.WaveFormat, LAMEPreset.VBR_90))
            {
                rdr.CopyTo(wtr);
            }
        }
     
        #endregion
        static void synth_SpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            Console.WriteLine("Current word being spoken: " + e.Text + " " + e.AudioPosition);
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
            try
            {
                if (ConfigurationManager.AppSettings["OutputDownLoad"].ToString() == "")
                {
                    if (!Directory.Exists("D:\\OutputDownLoad"))
                    {
                        Directory.CreateDirectory("D:\\OutputDownLoad");
                    }
                    txtuotdownloads.Text = @"D:\OutputDownLoad";
                }
                else
                {
                    txtuotdownloads.Text = ConfigurationManager.AppSettings["OutputDownLoad"].ToString();
                }
            }
            catch { }
            try
            {
                if (ConfigurationManager.AppSettings["BgAudioFolder"].ToString() == "")
                {
                    txtbgaudio.Text = Application.StartupPath + @"\BGAudio";
                }
                else
                {
                    txtbgaudio.Text = ConfigurationManager.AppSettings["BgAudioFolder"].ToString();
                }
            }
            catch { }
            try
            {
                if (ConfigurationManager.AppSettings["PathProshow"].ToString() == "")
                {
                    txtpathproshow.Text ="";
                }
                else
                {
                    txtpathproshow.Text = ConfigurationManager.AppSettings["PathProshow"].ToString();
                }
            }
            catch { }
            try
            {
                if (ConfigurationManager.AppSettings["Listvideobg"].ToString() == "")
                {
                    txtfloderlistbg.Text = "";
                }
                else
                {
                    txtfloderlistbg.Text = ConfigurationManager.AppSettings["Listvideobg"].ToString();
                }
            }
            catch { }
            try
            {
                if (ConfigurationManager.AppSettings["TorPath"].ToString() == "")
                {
                    txtpathtor.Text = "";
                }
                else
                {
                    txtpathtor.Text = ConfigurationManager.AppSettings["TorPath"].ToString();
                }
            }
            catch { }
            try
            {
                if (ConfigurationManager.AppSettings["PathLDPlayer"].ToString() == "")
                {
                    txtpathtor.Text = "";
                }
                else
                {
                    txtpathtor.Text = ConfigurationManager.AppSettings["PathLDPlayer"].ToString();
                }
            }
            catch { }
            
            try
            {
                if (ConfigurationManager.AppSettings["Listpicture"].ToString() == "")
                {
                    txtfloderlistpicture.Text = "";
                }
                else
                {
                    txtfloderlistpicture.Text = ConfigurationManager.AppSettings["Listpicture"].ToString();
                }
            }
            catch { }
            try
            {
                if (ConfigurationManager.AppSettings["InTro"].ToString() == "")
                {
                  tbintro.Text = "";
                }
                else
                {
                    tbintro.Text = ConfigurationManager.AppSettings["InTro"].ToString();
                }
            }
            catch { }
            try
            {
                if (ConfigurationManager.AppSettings["OutTro"].ToString() == "")
                {
                    tbouttro.Text = "";
                }
                else
                {
                    tbouttro.Text = ConfigurationManager.AppSettings["OutTro"].ToString();
                }
            }
            catch { }
            try
            {
                if (ConfigurationManager.AppSettings["FolderMC"].ToString() == "")
                {
                    txtfloderlistmc.Text = "";
                }
                else
                {
                    txtfloderlistmc.Text = ConfigurationManager.AppSettings["FolderMC"].ToString();
                }
            }
            catch { }
            try
            {
                if (ConfigurationManager.AppSettings["LogoVids"].ToString() == "")
                {
                    tblogothumnail.Text = "";
                }
                else
                {
                    tblogothumnail.Text = ConfigurationManager.AppSettings["LogoVids"].ToString();
                }
            }
            catch { }            
            try
            {
                if (ConfigurationManager.AppSettings["LogoThumnail"].ToString() == "")
                {
                    tblogothumnail.Text = "";
                }
                else
                {
                    tblogothumnail.Text = ConfigurationManager.AppSettings["LogoThumnail"].ToString();
                }
            }
            catch { }
            try
            {
                if (ConfigurationManager.AppSettings["TaiKhoan"].ToString() == "")
                {
                    txttaikhoan.Text = "";
                }
                else
                {
                    txttaikhoan.Text = ConfigurationManager.AppSettings["TaiKhoan"].ToString();
                }
            }
            catch { }
            try
            {
                if (ConfigurationManager.AppSettings["MatKhau"].ToString() == "")
                {
                    txtmatkhau.Text = "";
                }
                else
                {
                    txtmatkhau.Text = ConfigurationManager.AppSettings["MatKhau"].ToString();
                }
            }
            catch { }
        }
        #endregion


        #region // hiển thị dữ liệu bài viết
        private void hienthibaiviet()
        {
            daWS_FakeAuto baiviet = new daWS_FakeAuto();
            DataTable dt = new DataTable();
            dt = baiviet.DanhSachBaiViet(int.Parse(cmbchannel.SelectedValue.ToString()));
            dataGridViewList.DataSource = dt;

            //Thông tin kênh
            daWS_FakeAuto thongtin = new daWS_FakeAuto();
            DataTable tt = new DataTable();
            tt = thongtin.ThongTinKenh(m_IDTaiKhoan, int.Parse(cmbchannel.SelectedValue.ToString()));
            if(tt.Rows.Count>0)
            {
                DataRow r = tt.Rows[0];
                txtadddesc.Text = r["MoTa"].ToString();
                cmbvoiceidamz.SelectedValue = r["IDVoiceAMZ"].ToString();
                cmbvoicegoogle.Text = r["IDVoiceGoogle"].ToString();
            }
        }
        private void hienthisoluongdaup()
        {
            try
            {
                daWS_FakeAuto daup = new daWS_FakeAuto();
                txtvideoupload.Value = daup.BaiVietDaUpTrongNgay(int.Parse(cmbchannel.SelectedValue.ToString()));
            }
            catch { }
        }
        #endregion

        #region // lay danh sach voice cua amazon
        private void danhsachvoiceamz()
        {
            try
            {
                BasicAWSCredentials connect = new BasicAWSCredentials("AKIAIRL2344EFVJ6CHJQ", "6X32zlQFiCwLU39s7+dzLc/ZsV+SLSe8IigDUnmt");
                Amazon.Polly.AmazonPollyClient cl = new Amazon.Polly.AmazonPollyClient(connect, RegionEndpoint.USWest1);
                DescribeVoicesRequest describeVoicesRequest = new DescribeVoicesRequest();
                // Synchronously ask Amazon Polly to describe available TTS voices.
                DescribeVoicesResponse describeVoicesResult = cl.DescribeVoices(describeVoicesRequest);
                List<Voice> voices = describeVoicesResult.Voices;
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                for (int i = 0; i < voices.Count; i++)

                {
                    string id = voices[i].Id.ToString();
                    string name = voices[i].LanguageName.ToString() + "-" + voices[i].Name.ToString() + "-" + voices[i].Gender.ToString();
                    dt.Rows.Add(id, name);
                }
                cmbvoiceidamz.DataSource = dt;
                cmbvoiceidamz.DisplayMember = "Name";
                cmbvoiceidamz.ValueMember = "ID";
                //dataGridViewList.DataSource = dt;
            }
            catch { }
        }
        private List<Voice> _VoiceAMZ;
        private void  _LISTVOICE()
        {
            CauHinhServerBE hethong = new CauHinhServerBE();
            CauHinhServerBL tkxuly = new CauHinhServerBL();
            //dog nay de load xml trong debug ne
            hethong = tkxuly.docdulieu(Environment.CurrentDirectory + "/CauHinhAPIAMZ.xml");
            string _AccessKey = hethong.User1;
            string _SecretKey = hethong.Pass1;
            try
            {
                BasicAWSCredentials connect = new BasicAWSCredentials(_AccessKey, _SecretKey);
                Amazon.Polly.AmazonPollyClient cl = new Amazon.Polly.AmazonPollyClient(connect, RegionEndpoint.USWest1);
                DescribeVoicesRequest describeVoicesRequest = new DescribeVoicesRequest();
                // Synchronously ask Amazon Polly to describe available TTS voices.
                DescribeVoicesResponse describeVoicesResult = cl.DescribeVoices(describeVoicesRequest);
                _VoiceAMZ = describeVoicesResult.Voices;
            }
            catch { }
            
        }
        private void hienthicmbvoiceamz()
        {
            daWS_FakeAuto ds = new daWS_FakeAuto();
            cmbvoiceidamz.DataSource = ds.DanhSachVoiceAMZ();
            cmbvoiceidamz.DisplayMember = "Name";
            cmbvoiceidamz.ValueMember = "ID";
        }
        #endregion

        #region //get voice in google and amazon
        public byte[] GetMusic(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                if (dataStream == null)
                    return null;
                using (var sr = new BinaryReader(dataStream))
                {
                    byte[] bytes = sr.ReadBytes(100000000);

                    return bytes;
                }
            }

            return null;
        }

        private Amazon.Polly.VoiceId _Voice;
        private void cmbvoiceidamz_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < _VoiceAMZ.Count; i++)
                {
                    string id = _VoiceAMZ[i].Id.ToString();
                    if (id == cmbvoiceidamz.SelectedValue.ToString())
                    { _Voice = _VoiceAMZ[i].Id; }

                }
            }
            catch { }
        }
        private void CreatevoiceAMZ(string text,string output)
        {
            CauHinhServerBE hethong = new CauHinhServerBE();
            CauHinhServerBL tkxuly = new CauHinhServerBL();
            //dog nay de load xml trong debug ne
            hethong = tkxuly.docdulieu(Environment.CurrentDirectory + "/CauHinhAPIAMZ.xml");
            string _AccessKey = hethong.User1;
            string _SecretKey = hethong.Pass1;
            BasicAWSCredentials connect = new BasicAWSCredentials(_AccessKey, _SecretKey);
            Amazon.Polly.AmazonPollyClient client = new Amazon.Polly.AmazonPollyClient(connect, RegionEndpoint.USWest1);
            Amazon.Polly.Model.SynthesizeSpeechRequest req = new Amazon.Polly.Model.SynthesizeSpeechRequest();
            req.Text = text;
            req.VoiceId = _Voice;
            req.OutputFormat = Amazon.Polly.OutputFormat.Mp3;
            req.SampleRate = "22050";
           // req.TextType = Amazon.Polly.TextType.Text;
            SynthesizeSpeechResponse response = client.SynthesizeSpeech(req);
            //MemoryStream local_stream = new MemoryStream();
            //response.AudioStream.CopyTo(local_stream);
            //FileStream destination = File.Open(output, FileMode.Create);
            //local_stream.WriteTo(destination);
            //local_stream.Position = 0;
              FileStream destination = File.Open(output, FileMode.Create);
                // FileStream destination = File.Open(@"c:\temp\myfirstconversion.mp3", FileMode.Create);
               response.AudioStream.CopyTo(destination);
              destination.Close();
            

        }
        #endregion
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
        #region // khoi tao speed sub va xoa file
        private void Itrack()
        {
            trackhardsub.Minimum = 30;
            trackhardsub.Maximum = 100;
            trackhardsub.Value = 75;
            lblspeedsub.Text = "Speed sub :" + trackhardsub.Value.ToString();
            trackcountchar.Minimum = 35;
            trackcountchar.Maximum = 100;
            trackcountchar.Value = 40;
            lblcountchar.Text = "Count char line :" + trackcountchar.Value.ToString();


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
        private bool hamkiemtratontaifile(string path,string name)
        {
            bool kq = false;
            string[] fileList = System.IO.Directory.GetFiles(path);
            //duyệt từng file và copy đè lên file cũ trong thư mục đang chạy chương trình
            foreach (string sourceFile in fileList)
            {
                //tách tên file ra khỏi đường dẫn (tên file sẽ dùng để tạo đường dẫn đích cần copy đè)
                string fileName = System.IO.Path.GetFileName(sourceFile);
                //tạo đường dẫn đích để copy file mới tới
                if(fileName==name)
                {
                    kq = true;
                }
               
            }
            return kq;
        }

        private void chuyenmp3torender(string path,string pathrender)
        {
            string[] fileList = System.IO.Directory.GetFiles(path);
            //duyệt từng file và copy đè lên file cũ trong thư mục đang chạy chương trình
            foreach (string sourceFile in fileList)
            {
                //tách tên file ra khỏi đường dẫn (tên file sẽ dùng để tạo đường dẫn đích cần copy đè)
                string fileName = System.IO.Path.GetFileName(sourceFile);
                //tạo đường dẫn đích để copy file mới tới
                if (fileName.IndexOf(".mp3")!=-1)
                {
                    string destinationFile = path + @"\" + fileName;
                    // thực hiện copy
                    System.IO.File.Copy(destinationFile, pathrender, true);
                    //thực hiện xóa file
                    System.IO.File.Delete(destinationFile);
                }

            }
        }
        #endregion

      
        private void khoitao()
        {
            txttextchannel.Text = "ChangeChannel" + Randomtext();
            this.cmbvoicegoogle.Items.AddRange(Translator.Languages.ToArray());
            this.cmbngonnguthay.Items.AddRange(Translator.Languages.ToArray());
            this.cmdngonngugoc.Items.AddRange(Translator.Languages.ToArray());

            _LISTVOICE();
            hienthicmbkenh();
            hienthicmbvoiceamz();
            configinputandoutput();
            hienthibaiviet();
          
            hienthisoluongdaup();
            Itrack();
            layngayhientai();
            loadmailchuaxuly();
            loadmaildaxuly();
        }
        private void layngayhientai()
        {
            if (txtdatenow.Text != DateTime.Now.ToString("yyyyMMdd") & txtvideoupload.Value >= txtvideomax.Value)
            {
                txtdatenow.Text = DateTime.Now.ToString("yyyyMMdd");
                hienthisoluongdaup();
            }
            else
            {
                txtdatenow.Text = DateTime.Now.ToString("yyyyMMdd");
            }
        }

        private void FormUpload_Load(object sender, EventArgs e)
        {
           
            CheckForIllegalCrossThreadCalls = false;
            khoitao();
        }


        #region // thoat ung dung
        private void FormUpload_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                try
                {
                    PropretiesCollection.driver.Close();
                }
                catch { }
                foreach (Process proc in Process.GetProcessesByName("chromedriver"))
                {
                    proc.Kill();
                }
            }
            catch { }
            Application.Exit();
        }
        #endregion

        #region // các chỉnh sửa cấu hình
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

        private void radvoiceamz_CheckedChanged(object sender, EventArgs e)
        {
            if(radvoiceamz.Checked==true)
            {
                cmbvoicegoogle.Enabled = false;              
                cmbvoiceidamz.Enabled = true;
                btnkeyamz.Enabled = true;
            }
        }

        private void radvoicegoogle_CheckedChanged(object sender, EventArgs e)
        {
            if (radvoicegoogle.Checked == true)
            {
                cmbvoicegoogle.Enabled = true;            
                cmbvoiceidamz.Enabled = false;
                btnkeyamz.Enabled = false;
            }
        }

        private void btnsubcolor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                lblsubcolor.ForeColor = colorDlg.Color;
            }
        }

        private void btnsubcolorborder_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                lblsubbordercolor.ForeColor = colorDlg.Color;
            }
        }

        private void trackhardsub_Scroll(object sender, EventArgs e)
        {
            lblspeedsub.Text = "speed sub :" + trackhardsub.Value.ToString();
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
        #endregion

        /// <summary>
        /// khai báo biến cục bộ 
        /// </summary>     

        #region // test xu ly anh
        private void test()
        {
            //Bitmap bitmap1  = resizes.getResizedImage(@"D:\download.jpg",1280,720);
            //bitmap1.Save(@"D:\download2.jpg");

            //Bitmap bitmap = new Bitmap(@"D:\download2.jpg");


            //bitmap = Blur.Blurs(bitmap,6);
            //bitmap.Save(@"D:\download3.jpg");
            // resizes.MergeImageToCenter(@"D:\download3.jpg", @"D:\download4.png");

            //tbBackgroundImage.Text = @"D:\download3.jpg";
            //CreateVideoEffect(@"D:\a.wmv", @"D:\download4.png");
            //MessageBox.Show("ok");
        }
        #endregion        

        #region // cấu hình api voice amazon
        private void btnkeyamz_Click(object sender, EventArgs e)
        {
            FormCauHinhAPIAMZ voice = new FormCauHinhAPIAMZ();
            voice.Show();
        }

        #endregion

        #region // upload youtube
        private string m_IDVideoUpload;
        private async Task RunUpload(string path, string title, string desc, string tag, string flat)
        {
            m_IDVideoUpload = "";
            UserCredential credential;
            using (var stream = new FileStream(Application.StartupPath+@"\client_secrets.json", FileMode.Open, FileAccess.Read))
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

        #region // render video
     
        public System.Drawing.Image DownloadImageFromUrl(string imageUrl)
        {
            System.Drawing.Image image = null;

            try
            {
                System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                System.Net.WebResponse webResponse = webRequest.GetResponse();

                System.IO.Stream stream = webResponse.GetResponseStream();

                image = System.Drawing.Image.FromStream(stream);

                webResponse.Close();
            }
            catch
            {
                return null;
            }

            return image;
        }
   

        
        #endregion

        #region // luu cau hinh tao video
        private void txtsave_Click(object sender, EventArgs e)
        {
          
            #region // lưu cấu hình mô tả , voice
            daWS_FakeAuto updatevoice = new daWS_FakeAuto();
            updatevoice.UpdateVoiceKenh(int.Parse(cmbchannel.SelectedValue.ToString()),txtadddesc.Text,cmbvoiceidamz.Text.ToString(),cmbvoicegoogle.Text);
            #endregion
            MessageBox.Show("ok");
        }

        #endregion

        #region // cau hinh intro va outtro
        private void btnintro_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = false;
            dlg.CheckPathExists = false;
            dlg.Multiselect = false;
            dlg.Filter = "Files(*.mp4)|*.mp4|Files(*.avi)|*.avi";
            dlg.Multiselect = true;
            dlg.SupportMultiDottedExtensions = true;
            dlg.Title = "Select intro file mp4";

            //if (String.IsNullOrEmpty(Settings.Default.LastUsedFolder))
            //    Settings.Default.LastUsedFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

            //dlg.InitialDirectory = Settings.Default.LastUsedFolder;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //Settings.Default.LastUsedFolder = Path.GetDirectoryName(dlg.FileNames[0]);
                tbintro.Text = dlg.FileName;
                ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
                exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
                //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
                cf.AppSettings.Settings.Remove("InTro");
                cf.AppSettings.Settings.Add("InTro", tbintro.Text);
                cf.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void btnouttro_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = false;
            dlg.CheckPathExists = false;
            dlg.Multiselect = false;
            dlg.Filter = "Files(*.mp4)|*.mp4|Files(*.avi)|*.avi";
            dlg.Multiselect = true;
            dlg.SupportMultiDottedExtensions = true;
            dlg.Title = "Select outtro file mp4";

            //if (String.IsNullOrEmpty(Settings.Default.LastUsedFolder))
            //    Settings.Default.LastUsedFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

            //dlg.InitialDirectory = Settings.Default.LastUsedFolder;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
               // Settings.Default.LastUsedFolder = Path.GetDirectoryName(dlg.FileNames[0]);
                tbouttro.Text = dlg.FileName;
                ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
                exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
                //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
                cf.AppSettings.Settings.Remove("OutTro");
                cf.AppSettings.Settings.Add("OutTro", tbouttro.Text);
                cf.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void checkhardsub_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkhardsubleft_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnlogothumnail_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = false;
            dlg.CheckPathExists = false;
            dlg.Multiselect = false;
            dlg.Filter = "Image Files(*.JPG;*.PNG;*.BMP)|*.JPG;*.JPEG;*.PNG;*.BMP;|JPEG Files(*.JPG)|*.JPG;*.JPEG|PNG Files(*.PNG)|*.PNG|BMP Files(*.BMP)|*.BMP|All files (*.*)|*.*";
            dlg.Multiselect = true;
            dlg.SupportMultiDottedExtensions = true;
            dlg.Title = "Select logo image";

            //if (String.IsNullOrEmpty(Settings.Default.LastUsedFolder))
            //    Settings.Default.LastUsedFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

        //    dlg.InitialDirectory = Settings.Default.LastUsedFolder;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //Settings.Default.LastUsedFolder = Path.GetDirectoryName(dlg.FileNames[0]);
                tblogothumnail.Text = dlg.FileName;
            }
        }


        #endregion

        #region // render cho serrver
  
        public static String chuanHoa(String _string)
        {
            return System.Text.RegularExpressions.Regex.Replace(_string, "\\s+", " ");
        }

        private string kiemtraduoifile(string path,string name)
        {
            string ex="";
            string[] fileList = System.IO.Directory.GetFiles(path);
            //duyệt từng file và copy đè lên file cũ trong thư mục đang chạy chương trình
            foreach (string sourceFile in fileList)
            {
                //tách tên file ra khỏi đường dẫn (tên file sẽ dùng để tạo đường dẫn đích cần copy đè)
                string fileName = System.IO.Path.GetFileName(sourceFile);
                if( fileName.Substring(0,fileName.IndexOf("."))==name)
                {
                    ex = Path.GetExtension(sourceFile).Trim();
                }
            }
            return ex;
        }


        #endregion


        // - Nén file
        #region // các button cấu hình
        private void CompressRAR(string rar_file, string path_file)
        {
            try
            {
                foreach (Process procs in Process.GetProcessesByName("WinRAR"))
                {
                    procs.Kill();
                }
            }
            catch { }
            ProcessStartInfo ps = new ProcessStartInfo();
            // - File chương trình nén và giải nén Winar
            ps.FileName = @"WinRAR.exe";
            // - Tham số truyền vào câu lệnh (vd: rar.exe a - trong đó a là tham số)
            // - rar_file: tên file nén | path_file: đường dẫn nguồn nén(file đc nén, thư mục đc nén)
            // - \" Thêm vào một dấu nháy kép ("")
            ps.Arguments = "a -r -ep1 \"" + rar_file + "\" \"" + path_file + "\"";
            ps.WindowStyle = ProcessWindowStyle.Hidden;     // - Ẩn cửa sổ nén
                                                            // - Chạy câu lệnh nén
            Process proc = Process.Start(ps);
            // - Thoát sau khi nén xong
            proc.WaitForExit();
        }
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

        private void btnloadmc_Click(object sender, EventArgs e)
        {
            string folder = Application.StartupPath + "/FileMC";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            DataTable dt = new DataTable();
            daWS_FakeAuto ds = new daWS_FakeAuto();
            dt = ds.CauHinhMCKenh(int.Parse(cmbchannel.SelectedValue.ToString()));
            if (dt.Rows.Count > 0)
            {
                #region xoa cac file da down truoc do cua kenh
                foreach (DataRow r in dt.Rows)
                {
                        string filexoa = folder + r["ID"].ToString() + ".mp4";
                        //thực hiện xóa file
                        System.IO.File.Delete(filexoa);
                   
                }

                #endregion
                #region // thuc hien down va xoa am thanh cua file
                foreach (DataRow r in dt.Rows)
                {
                    string linkvid = r["ID"].ToString();
                    string linkdown = "http://buudienhanoi.com.vn/ThangBDHN_Luu2/FileMC/" + linkvid+".rar";
                    using (WebClient webClient = new WebClient())
                    {

                        byte[] data = webClient.DownloadData(linkdown);
                        File.WriteAllBytes(folder, data);
                    }              
                    string path_fileVideo = folder;
                    ExtractRAR(linkdown, path_fileVideo);
                    File.Delete(linkdown);

                }

                #endregion
            }
        }

        private void btnbgaudio_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                txtbgaudio.Text = fl.SelectedPath;
                ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
                exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
                //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
                cf.AppSettings.Settings.Remove("BgAudioFolder");
                cf.AppSettings.Settings.Add("BgAudioFolder", txtbgaudio.Text);
                cf.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        private void btnpathproshow_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = false;
            dlg.CheckPathExists = false;
            dlg.Multiselect = false;
            dlg.Filter = "Files(*.exe)|*.exe";
            dlg.Multiselect = true;
            dlg.SupportMultiDottedExtensions = true;
            dlg.Title = "Select proshow";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //Settings.Default.LastUsedFolder = Path.GetDirectoryName(dlg.FileNames[0]);
                txtpathproshow.Text = dlg.FileName;
                ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
                exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
                //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
                cf.AppSettings.Settings.Remove("PathProshow");
                cf.AppSettings.Settings.Add("PathProshow", txtpathproshow.Text);
                cf.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        private void trackcountchar_Scroll(object sender, EventArgs e)
        {
            lblcountchar.Text = "count char :" + trackcountchar.Value.ToString();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        
        private void btnborderthumnail_Click(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                lblborderthumnail.ForeColor = colorDlg.Color;
            }
        }
        private void btnfloderlistmcbg_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                txtfloderlistbg.Text = fl.SelectedPath;
                ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
                exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
                //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
                cf.AppSettings.Settings.Remove("Listvideobg");
                cf.AppSettings.Settings.Add("Listvideobg", txtfloderlistbg.Text);
                cf.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void btnfloderlistpicbg_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                txtfloderlistpicture.Text = fl.SelectedPath;
                ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
                exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
                //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
                cf.AppSettings.Settings.Remove("Listpicture");
                cf.AppSettings.Settings.Add("Listpicture", txtfloderlistpicture.Text);
                cf.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        #endregion


        #region // lay voice

        private void downloadFile(string url, string path)
        {
            using (WebClient wc = new WebClient())
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                wc.DownloadFileAsync(new Uri(url), path);
            }
        }
        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //  progressBar1.Value = e.ProgressPercentage;
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("WinRAR"))
                {
                    proc.Kill();
                }
            }
            catch { }
            //if (radvoice2.Checked == true)
            //{
            //    ConvertMp3ToWav(_voicetemp, _voice);
            //}
            string urlupload = "http://buudienhanoi.com.vn/ThangBDHN_Luu2/UpLoadVoice.aspx";
            WebClient myWebClient = new WebClient();
            string rar_file = txtfoldervideo.Text + @"\" + idchitiet.ToString() + ".rar";
            // voice tu trang 
            if (radvoice2.Checked == true)
            {
                CompressRAR(rar_file, _voicetemp);
            }
            else if (radvoice3.Checked == true)
            {
                CompressRAR(rar_file, _voicetemp);
            }
            //
            else if (radiovoice3.Checked == true)
            {
                CompressRAR(rar_file, _voicetemp);
            }
            else
            {
                CompressRAR(rar_file, _voice);
            }
            Thread.Sleep(1000);
            byte[] responseArray = myWebClient.UploadFile(urlupload, rar_file);
            myWebClient.Dispose();
            Thread.Sleep(1000);
            daWS_FakeAuto ls = new daWS_FakeAuto();
            int m_idchitiet = idchitiet;
            string m_PathVoice = "http://buudienhanoi.com.vn/ThangBDHN_Luu2/FileVoice/" + idchitiet.ToString() + ".rar";
            ls.SuaPathVoice(m_idchitiet, m_PathVoice);
            if (m_idcu != m_idmoi)
            {
                daWS_FakeAuto voice = new daWS_FakeAuto();
                voice.UpdateDaRenderVoice(int.Parse(m_idcu));
                m_idcu = m_idmoi;
            }
            try
            {
                foreach (Process proc in Process.GetProcessesByName("WinRAR"))
                {
                    proc.Kill();
                }
            }
            catch { }

        }

        #region // voice xử lý đồng bộ
        private async Task downloadFileV2(string url, string path)
        {
            using (WebClient wc = new WebClient())
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;              
                wc.DownloadFileCompleted += wc_DownloadFileCompletedV2;
                wc.DownloadFileAsync(new Uri(url), path);
            }
        }
        private async Task downloadFileV2_Ex(string url, string path)
        {
            xNet.HttpRequest http = new xNet.HttpRequest();
            http.ConnectTimeout = 99999999;
            http.KeepAliveTimeout = 99999999;
            http.ReadWriteTimeout = 99999999;
            var binImg = http.Get(url).ToMemoryStream().ToArray();
            File.WriteAllBytes(path, binImg);
        }

        private async Task ChomeClose()
        {
            try
            {
                try
                {
                    PropretiesCollection.driver.Close();
                    PropretiesCollection.driver.Quit();
                }
                catch { }
                System.Threading.Thread.Sleep(2000);
                try
                {
                    foreach (Process proc in Process.GetProcessesByName("chromedriver"))
                    {
                        proc.Kill();
                    }
                }
                catch { }
                try
                {
                    foreach (Process proc in Process.GetProcessesByName("chrome"))
                    {
                        proc.Kill();
                    }
                }
                catch { }
                try
                {
                    foreach (Process proc in Process.GetProcessesByName("chrome.exe"))
                    {
                        proc.Kill();
                    }
                }
                catch { }
                try
                {
                    foreach (Process proc in Process.GetProcessesByName("geckodriver"))
                    {
                        proc.Kill();
                    }
                }
                catch { }
                try
                {
                    foreach (Process proc in Process.GetProcessesByName("firefox"))
                    {
                        proc.Kill();
                    }
                }
                catch { }
            }
            catch { }
        }
        private void wc_DownloadFileCompletedV2(object sender, AsyncCompletedEventArgs e)
        {
            lblxuly.Text = "Lấy voice done!";
        }

        #endregion

        string _voice;
        string _voicetemp;
        string m_idmoi = "";
        string m_idcu;
        int idchitiet;
        private void btnsavevoicecf_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtfoldervideo.Text))
            {
                Directory.CreateDirectory(txtfoldervideo.Text);
            }
            if (!bgwlayvoice.IsBusy)
            {
                bgwlayvoice.RunWorkerAsync();              
            }
        }
        private static void ConvertMp3ToWav(string _inPath_, string _outPath_)
        {
            using (Mp3FileReader mp3 = new Mp3FileReader(_inPath_))
            {
                using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3))
                {
                    WaveFileWriter.CreateWaveFile(_outPath_, pcm);
                }
            }
        }
        private void bgwlayvoice_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable dt = new DataTable();
            daWS_FakeAuto ds = new daWS_FakeAuto();
            dt = ds.DanhSachVoiceCanLay(int.Parse(cmbchannel.SelectedValue.ToString()));
            if (dt.Rows.Count > 0)
            {
                //ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                //service.HideCommandPromptWindow = true;
                ChromeOptions options = new ChromeOptions();
               // options.AddArgument("headless");
               // PropretiesCollection.driver = new ChromeDriver(service,options);
                PropretiesCollection.driver = new ChromeDriver(options);
                if (radvoicedefault.Checked == true)
                {
                    PropretiesCollection.driver.Navigate().GoToUrl("https://www.vocalware.com/index/demo");
                }
                else if(radiovoice3.Checked==true)
                {
                    PropretiesCollection.driver.Navigate().GoToUrl("https://vtcc.ai/tts");
                }
                else if(radvoice2.Checked==true)
                {
                    PropretiesCollection.driver.Navigate().GoToUrl("http://www.voiceware.co.kr/eng/product/product1.php?fbclid=IwAR3uoWfvMJ6g53aNRf6o3WSm8A4fbq3hg7OVjXRD4K43ktPh9SsyP_zDnQ0");
                }
                else if (radvoice3.Checked == true)
                {
                    PropretiesCollection.driver.Navigate().GoToUrl("https://ws.neospeech.com/");
                }
                m_idcu = dt.Rows[0]["ID"].ToString();
                m_idmoi = "";
                int i = 1;
                int count = dt.Rows.Count;
                if(count>0 && radvoice2.Checked == true)
                {
                    DataRow row1 = dt.Rows[0];
                    string ngonngu2 = row1["NgonNguSelenium"].ToString();
                    string mcvoice = row1["MCVoiceSelenium"].ToString();
                    cl_ReadVoice read = new cl_ReadVoice();
                    read.selectV2(ngonngu2, mcvoice);
                }
                else if (count > 0 && radvoice3.Checked == true)
                {
                    DataRow row1 = dt.Rows[0];
                    string ngonngu2 = row1["NgonNguSelenium"].ToString();
                    cl_ReadVoice read = new cl_ReadVoice();
                    read.selectV3(ngonngu2);
                }
                string _urlvoicecu = "";
                foreach (DataRow r in dt.Rows)
                {
                    try
                    {
                        m_idmoi = r["ID"].ToString();
                        cl_ReadVoice read = new cl_ReadVoice();
                        string url = "";
                        idchitiet = int.Parse(r["IDChiTiet"].ToString());
                        string ngonngu = r["NgonNguSelenium"].ToString();
                        string mcvoice = r["MCVoiceSelenium"].ToString();
                        string effect = r["EffectSelenium"].ToString();
                        string effectlevel = r["EffectLevelSelenium"].ToString();
                        string noidung = "";
                        try
                        {
                            noidung = chuanHoa(r["NoiDung"].ToString().Trim());
                        }
                        catch { }
                        string pathvoice = r["PathVoice"].ToString();
                        if (noidung != "" && pathvoice == "")
                        {
                            if (radvoicedefault.Checked == true)
                            {
                                url = read.getURLMp3(_urlvoicecu,ngonngu, mcvoice, effect, effectlevel, noidung.Trim());
                                _urlvoicecu = url;
                            }
                            else if (radiovoice3.Checked == true)
                            {
                                try
                                {
                                    File.Delete(txtuotdownloads.Text + @"\sound.wav");
                                }
                                catch { }
                                url = read.getURLMp3VietNam(cmbvoicevietnam.Text,noidung.Trim());

                            }
                            else if(radvoice2.Checked==true)
                            {
                                url = read.getURLMp3_V2(_urlvoicecu,noidung.Trim());
                                _urlvoicecu = url;
                            }
                            else if (radvoice3.Checked == true)
                            {
                                url =curl.cull(read.getURLMp3_V3(_urlvoicecu,noidung.Trim()), "audio=", ".mp3")+".mp3";
                                _urlvoicecu = url;
                            }
                            txtthongbaolayvoice.Text = "Lấy voice ok url=" + url.ToString();
                            //lấy để upload lên server

                            _voice = txtfoldervideo.Text + @"\" + idchitiet.ToString() + ".mp3";
                            _voicetemp = txtfoldervideo.Text + @"\" + idchitiet.ToString() + ".wav";
                            #region // download file mp3
                            if (url != "")
                            {
                                if (radvoicedefault.Checked == true)
                                {
                                    downloadFile(url, _voice);
                                }
                                else if (radvoice3.Checked == true)
                                {
                                    downloadFile(url, _voice);
                                }
                                else if (radiovoice3.Checked == true)
                                {
                                    if (File.Exists(txtuotdownloads.Text + @"\sound.wav"))
                                    {
                                        System.IO.File.Copy(txtuotdownloads.Text + @"\sound.wav", _voicetemp, true);
                                        #region // upload file len server
                                        try
                                        {
                                            foreach (Process proc in Process.GetProcessesByName("WinRAR"))
                                            {
                                                proc.Kill();
                                            }
                                        }
                                        catch { }
                                        //if (radvoice2.Checked == true)
                                        //{
                                        //    ConvertMp3ToWav(_voicetemp, _voice);
                                        //}
                                        string urlupload = "http://buudienhanoi.com.vn/ThangBDHN_Luu2/UpLoadVoice.aspx";
                                        WebClient myWebClient = new WebClient();
                                        string rar_file = txtfoldervideo.Text + @"\" + idchitiet.ToString() + ".rar";
                                        CompressRAR(rar_file, _voicetemp);
                                        Thread.Sleep(1000);
                                        byte[] responseArray = myWebClient.UploadFile(urlupload, rar_file);
                                        myWebClient.Dispose();
                                        Thread.Sleep(1000);
                                        daWS_FakeAuto ls = new daWS_FakeAuto();
                                        int m_idchitiet = idchitiet;
                                        string m_PathVoice = "http://buudienhanoi.com.vn/ThangBDHN_Luu2/FileVoice/" + idchitiet.ToString() + ".rar";
                                        ls.SuaPathVoice(m_idchitiet, m_PathVoice);
                                        if (m_idcu != m_idmoi)
                                        {
                                            daWS_FakeAuto voice = new daWS_FakeAuto();
                                            voice.UpdateDaRenderVoice(int.Parse(m_idcu));
                                            m_idcu = m_idmoi;
                                        }
                                        try
                                        {
                                            foreach (Process proc in Process.GetProcessesByName("WinRAR"))
                                            {
                                                proc.Kill();
                                            }
                                        }
                                        catch { }
                                        #endregion
                                    }
                                }
                                else
                                {

                                    downloadFile(url, _voicetemp);

                                }
                                Thread.Sleep(int.Parse(txttimes.Value.ToString()));
                            }
                            #endregion
                            //}
                            //catch{}
                        }
                     
                        lblthongbaolayvoice.Text = "Lay voice :" + i.ToString() + "/" + count.ToString();
                        i = i + 1;
                    }
                    catch { }
                }
                PropretiesCollection.driver.Close();
                foreach (Process proc in Process.GetProcessesByName("chromedriver"))
                {
                    proc.Kill();
                }
            }
        }

        private void bgwlayvoice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PropretiesCollection.driver.Close();
            foreach (Process proc in Process.GetProcessesByName("chromedriver"))
            {
                proc.Kill();
            }
        }

        #endregion

        #region // TEst sub
        private void btnviewtestsub_Click(object sender, EventArgs e)
        {
            try
            {
                HardSubText sub = new HardSubText();
                Font font1 = new Font(cmbfonthardsub.Text, int.Parse(txtsizetext.Value.ToString()));
                string tenfilesub = txtfoldervideo.Text + @"\\testsub.png";
                if (checkhardsub.Checked == true)
                {
                    if (rad720.Checked == true)
                    {
                        sub.DrawText(txttextsubtest.Text, font1, lblsubcolor.ForeColor, 1090, lblsubbordercolor.ForeColor, int.Parse(txtsizeborder.Value.ToString()), tenfilesub);

                    }
                    else
                    {
                        sub.DrawText(txttextsubtest.Text, font1, lblsubcolor.ForeColor, 1750, lblsubbordercolor.ForeColor, int.Parse(txtsizeborder.Value.ToString()), tenfilesub);
                    }
                }
                else if (checkhardsubleft.Checked == true)
                {
                    sub.DrawText(txttextsubtest.Text, font1, lblsubcolor.ForeColor, 999999999, lblsubbordercolor.ForeColor, int.Parse(txtsizeborder.Value.ToString()), tenfilesub);
                }
                else if (checksubnotrun.Checked == true)
                {
                    if (rad720.Checked == true)
                    {
                        sub.DrawText(txttextsubtest.Text, font1, lblsubcolor.ForeColor, 1250, lblsubbordercolor.ForeColor, int.Parse(txtsizeborder.Value.ToString()), tenfilesub);

                        sub.DrawTextProshow2(tenfilesub, txtfoldervideo.Text + @"\\testsub2.png");
                    }
                    else
                    {
                        sub.DrawText(txttextsubtest.Text, font1, lblsubcolor.ForeColor, 1750, lblsubbordercolor.ForeColor, int.Parse(txtsizeborder.Value.ToString()), tenfilesub);
                        sub.DrawTextProshow2(tenfilesub, txtfoldervideo.Text + @"\\testsub2.png");
                    }
                }
                MessageBox.Show("Kiem tra file test: "+tenfilesub);
            }
            catch { }
        }
        #endregion

        #region // render multi video news slide
        private void btnrendermulti_Click(object sender, EventArgs e)
        {
            try
            {
                #region // kiem tra cac dieu kien tham so
                if (tbintro.Text != "") { 
                if (!File.Exists(tbintro.Text))
                {
                    MessageBox.Show("khong tim thay file intro", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                }
                else
                {
                    MessageBox.Show("Bắt buộc phải có intro video", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (tbouttro.Text != "")
                {
                    if (!File.Exists(tbouttro.Text))
                    {
                        MessageBox.Show("khong tim thay file outtro video", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Bắt buộc phải có outtro video", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtpathproshow.Text != "")
                {
                    if (!File.Exists(txtpathproshow.Text))
                    {
                        MessageBox.Show("khong tim thay file proshow", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Bắt buộc phải có proshow", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion

                if (!bgwrendermulti.IsBusy)
                {
                    timerrendermulti.Enabled = false;
                    timerrendermulti.Stop();                    
                    bgwrendermulti.RunWorkerAsync();

                }
            }
            catch
            {
                lblxuly.Text = string.Empty;
                timerrendermulti.Enabled = true;
                timerrendermulti.Interval = int.Parse(txtthoigiancho.Text);
                timerrendermulti.Start();
            }
        }

        private void bgwrendermulti_DoWork(object sender, DoWorkEventArgs e)
        {
            if (checkuploadvideo.Checked == true)
            {
                layngayhientai();
                if (txtdatenow.Text == DateTime.Now.ToString("yyyyMMdd") && txtvideoupload.Value < txtvideomax.Value)
                {
                    hienthisoluongdaup();
                }
            }
            if (txtvideoupload.Value < txtvideomax.Value)
            {
                #region // render vids
                try
                {
                    daWS_FakeAuto bv = new daWS_FakeAuto();
                    DataTable tablelist = new DataTable();
                    if (checkrendervoiceoffline.Checked == true)
                    {
                        tablelist = bv.DanhSachBaiVietProshowTheoKenh(int.Parse(cmbchannel.SelectedValue.ToString()));
                    }
                    else
                    {
                        tablelist = bv.DanhSachBaiVietProshowTheoKenhVoiceSelenium(int.Parse(cmbchannel.SelectedValue.ToString()));
                    }
                    if (tablelist.Rows.Count > 0)
                    {
                        lblxuly.Text = "Đang đọc dữ liệu....";
                        prs.Maximum = tablelist.Rows.Count;
                        int k = 1;
                        prs.Value = 0;

                        foreach (DataRow r in tablelist.Rows)
                        {

                            try
                            {
                                string thumnail = "";
                                string title = r["TieuDe"].ToString().Trim();
                                // string link = r["LinkBaiViet"].ToString();
                                k = int.Parse(r["ID"].ToString());
                                #region // update trang thai dang render
                                daWS_FakeAuto bvdangrender = new daWS_FakeAuto();
                                bvdangrender.UpdateBaiVietDangRender(k);
                                daWS_FakeAuto thongtin = new daWS_FakeAuto();
                                DataTable tt = new DataTable();
                                int idkenh = int.Parse(r["IDKenh"].ToString());
                                tt = thongtin.ThongTinKenh(m_IDTaiKhoan, idkenh);
                                if (tt.Rows.Count > 0)
                                {
                                    DataRow rows = tt.Rows[0];
                                    txtadddesc.Text = rows["MoTa"].ToString();
                                    cmbvoiceidamz.SelectedValue = rows["IDVoiceAMZ"].ToString();
                                    cmbvoicegoogle.Text = rows["IDVoiceGoogle"].ToString();
                                }
                                #region // lay thong tin cau hinh mc tren server
                                daWS_FakeAuto thongtinmc = new daWS_FakeAuto();
                                DataTable mc = new DataTable();
                                mc = thongtinmc.CauHinhMCKenh(idkenh);
                                string m_MC = "";
                                int m_Width = 0;
                                int m_Height = 0;
                                int m_X = 0;
                                int m_Y = 0;
                                if (mc.Rows.Count > 0)
                                {
                                    Random radom = new Random();
                                    int row_i = radom.Next(0, mc.Rows.Count);
                                    m_MC = Application.StartupPath + @"/FileMC/" + mc.Rows[row_i]["ID"].ToString() + ".mp4";
                                    m_Width = int.Parse(mc.Rows[row_i]["Width"].ToString());
                                    m_Height = int.Parse(mc.Rows[row_i]["Height"].ToString());
                                    m_X = int.Parse(mc.Rows[row_i]["X"].ToString());
                                    m_Y = int.Parse(mc.Rows[row_i]["Y"].ToString());
                                }
                                #endregion

                                #endregion
                                prs.Value = prs.Value + 1;
                                string folder = "KenhNews" + cmbchannel.SelectedValue.ToString();
                                lblxuly.Text = "Downloading :" + title.ToString() + " |" + k.ToString() + "/" + prs.Maximum.ToString();
                                #region // cac xu ly he thong tạo video
                                if (!Directory.Exists(txtfoldervideo.Text + "/" + folder + "/" + k.ToString()))
                                {
                                    Directory.CreateDirectory(txtfoldervideo.Text + "/" + folder + "/" + k.ToString());
                                }
                                #region  // biến trang thái ffmpeg
                                bool _AtriHidde = false;
                                if (checkhideffmpeg1.Checked == true)
                                { _AtriHidde = true; }
                                #endregion
                                #region // xử lý từng slide
                                string outputthumnail = "";
                                daWS_FakeAuto slide = new daWS_FakeAuto();
                                DataTable listslide = new DataTable();
                                listslide = slide.ChiTietBaiViet(k);
                                if (listslide.Rows.Count > 0)
                                {
                                    try
                                    {
                                        if (checkrendervoiceoffline.Checked == true)
                                        {
                                            #region // xử lý voice offline
                                            ChromeOptions options = new ChromeOptions();
                                            options.AddArgument("--disable-blink-features=AutomationControlled");
                                            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                                            service.HideCommandPromptWindow = true;
                                            // options.AddArgument("headless");
                                            PropretiesCollection.driver = new ChromeDriver(service,options);                                          
                                            if (radvoicedefault.Checked == true)
                                            {
                                                PropretiesCollection.driver.Navigate().GoToUrl("https://www.vocalware.com/index/demo");
                                            }
                                            else if (radiovoice3.Checked == true)
                                            {
                                                PropretiesCollection.driver.Navigate().GoToUrl("https://vtcc.ai/tts");
                                            }
                                            else if (radvoice2.Checked == true)
                                            {
                                                //if(checktienghan.Checked==true)
                                                //{
                                                    PropretiesCollection.driver.Navigate().GoToUrl("http://www.voiceware.co.kr/kor/product/product1.php");
                                                //}
                                                //else
                                                //{
                                                //    //PropretiesCollection.driver.Navigate().GoToUrl("http://www.voiceware.co.kr/eng/product/product1.php?fbclid=IwAR3uoWfvMJ6g53aNRf6o3WSm8A4fbq3hg7OVjXRD4K43ktPh9SsyP_zDnQ0");
                                                //}

                                            }
                                            else if (radvoice3.Checked == true)
                                            {
                                                PropretiesCollection.driver.Navigate().GoToUrl("https://ws.neospeech.com/");
                                            }
                                            else if (radispeech.Checked == true)
                                            {
                                                PropretiesCollection.driver.Navigate().GoToUrl("https://www.ispeech.org/text.to.speech/");
                                            }
                                            else if (radvoiceibm.Checked == true)
                                            {
                                                PropretiesCollection.driver.Navigate().GoToUrl("https://text-to-speech-demo.ng.bluemix.net/");
                                            }
                                            else if (radnotevibes.Checked == true)
                                            {
                                                PropretiesCollection.driver.Navigate().GoToUrl("https://notevibes.com/");
                                            }
                                            else if (radttsmp3.Checked == true)
                                            {
                                                PropretiesCollection.driver.Navigate().GoToUrl("https://ttsmp3.com/text-to-speech/");
                                            }
                                            else if (radiovoiceamazon.Checked == true)
                                            {
                                                PropretiesCollection.driver.Navigate().GoToUrl("https://ttstool.com/");
                                            }
                                            else if (radiovoiceMicrosoft.Checked == true)
                                            {
                                                PropretiesCollection.driver.Navigate().GoToUrl("https://ttstool.com/");
                                            }
                                            else if (radiovoicereallusion.Checked == true)
                                            {
                                                PropretiesCollection.driver.Navigate().GoToUrl("https://tts.reallusion.com/en/Home/TTS");
                                            }
                                            else if (radiovoicecereproc.Checked == true)
                                            {
                                                PropretiesCollection.driver.Navigate().GoToUrl("https://www.cereproc.com/en/products/cloud");
                                            }
                                            else if (radiovoicewideo.Checked == true)
                                            {
                                                PropretiesCollection.driver.Navigate().GoToUrl("https://wideo.co/text-to-speech/");
                                            }
                                            else if (radiovoicelinguatec.Checked == true)
                                            {
                                                PropretiesCollection.driver.Navigate().GoToUrl("https://www.linguatec.de/en/voice-reader-studio-15-test/");
                                                IJavaScriptExecutor jse = (IJavaScriptExecutor)PropretiesCollection.driver;
                                                jse.ExecuteScript("window.scrollTo(0," + 300 + ")", "");
                                            }
                                            else if (radiovoicesestek.Checked == true)
                                            {
                                                PropretiesCollection.driver.Navigate().GoToUrl("https://www.sestek.com/text-to-speech/tts-demo/");
                                            }
                                            int count = listslide.Rows.Count;
                                            if (count > 0 && radvoice2.Checked == true)
                                            {
                                                DataRow row1 = listslide.Rows[0];
                                                string ngonngu2 = row1["NgonNguSelenium"].ToString();
                                                string mcvoice = row1["MCVoiceSelenium"].ToString();
                                                cl_ReadVoice read = new cl_ReadVoice();
                                                if (checktienghan.Checked == true)
                                                {                                                    
                                                   read.selectV2_TiengHan(ngonngu2, mcvoice);
                                                }
                                                else
                                                {
                                                    read.selectV2(ngonngu2, mcvoice);
                                                }
                                                if(checklager.Checked==true)
                                                {
                                                    read.checklager();
                                                }
                                            }
                                            if (count > 0 && radiovoicereallusion.Checked == true)
                                            {
                                                DataRow row1 = listslide.Rows[0];
                                                string ngonngu2 = row1["NgonNguSelenium"].ToString();
                                                string mcvoice = row1["MCVoiceSelenium"].ToString();
                                                cl_ReadVoice read = new cl_ReadVoice();                                               
                                                 read.select_voice_reall(ngonngu2);                                                
                                            }
                                            if (count > 0 && radiovoicecereproc.Checked == true)
                                            {
                                                DataRow row1 = listslide.Rows[0];
                                                string ngonngu2 = row1["NgonNguSelenium"].ToString();
                                                string mcvoice = row1["MCVoiceSelenium"].ToString();
                                                cl_ReadVoice read = new cl_ReadVoice();
                                                bool giong = false;
                                                if(checkgiongnamcereproc.Checked==true)
                                                {
                                                    giong = true;
                                                }
                                                read.select_voice_cereproc(ngonngu2,giong);
                                            }
                                            else if (count > 0 && radvoice3.Checked == true)
                                            {
                                                DataRow row1 = listslide.Rows[0];
                                                string ngonngu2 = row1["NgonNguSelenium"].ToString();
                                                cl_ReadVoice read = new cl_ReadVoice();
                                                read.selectV3(ngonngu2);
                                            }
                                            else if (count > 0 && radispeech.Checked == true)
                                            {                                               
                                                string ngonngu = cmbispeech.Text;
                                                cl_ReadVoice read = new cl_ReadVoice();
                                                read.selectIspeech(ngonngu);
                                            }
                                            #endregion
                                        }

                                        #region // các biến
                                        int biendemslide = 1;
                                        string _listvideo = "";
                                        string _anhbackground = "";
                                        string mpgjoinvideo = "";
                                        string filevoice = "";
                                        string m_noidung = "";

                                        int bienrancenter = 0;
                                        if (listslide.Rows.Count > 2)
                                        {
                                            bienrancenter = listslide.Rows.Count / 2;
                                        }
                                        #endregion
                                        #region // tạo subtitle
                                        Font fonttitle = new Font(cmbfontthumnail.Text, int.Parse(txtsizetext.Value.ToString()));
                                        string subtitle = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\title.png";
                                        HardSubText subtitlerun = new HardSubText();
                                        subtitlerun.DrawText(title, fonttitle, lblsubcolor.ForeColor, 1100, lblsubbordercolor.ForeColor, int.Parse(txtsizeborder.Value.ToString()), subtitle);

                                        #endregion

                                        #region //xử lý các slide
                                        DataTable slideps = new DataTable();
                                        slideps.Columns.Add("PathMC", typeof(string));
                                        slideps.Columns.Add("PathSub", typeof(string));
                                        slideps.Columns.Add("PathImage", typeof(string));
                                        slideps.Columns.Add("TimeSlide", typeof(string));
                                        slideps.Columns.Add("PathVoice", typeof(string));
                                        slideps.Columns.Add("TimeVoice", typeof(string));
                                        #region // lấy file mc random
                                        string pathmc = "";
                                        //if(checkmcsmall.Checked==true)
                                        //{
                                        //var filesmc = new DirectoryInfo(txtfloderlistmc.Text).GetFiles();
                                        //int indexmc = new Random().Next(0, filesmc.Length);
                                        //pathmc = txtfloderlistmc.Text + @"\" + filesmc[indexmc].Name;
                                        // }
                                        #endregion
                                        string _urlvoicecu = "";
                                        foreach (DataRow row in listslide.Rows)
                                        {
                                            try
                                            {
                                                lblxuly.Text = "Rending :" + title.ToString() + " |" + k.ToString() + "|" + biendemslide.ToString() + "/" + listslide.Rows.Count.ToString();
                                                string _noidung = chuanHoa(row["NoiDung"].ToString());
                                                string _hinhanh = row["HinhAnh"].ToString();
                                                string _pathvoice = row["PathVoice"].ToString();
                                                string _idchitiet = row["ID"].ToString();
                                                string _anhvideo = "";
                                                #region // xử lý ảnh 
                                                if (_hinhanh != "")
                                                {
                                                    _anhvideo = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\imageload" + biendemslide.ToString() + ".jpeg";
                                                    try
                                                    {
                                                        using (WebClient webClient = new WebClient())
                                                        {

                                                            byte[] data = webClient.DownloadData(_hinhanh);
                                                            File.WriteAllBytes(_anhvideo, data);
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        #region // trường hợp không down được ảnh từ web chính lấy 1 ảnh top google
                                                        Picturegoogle getdataanh = new Picturegoogle();
                                                        string html = getdataanh.GetHtmlCode(title);
                                                        Picturegoogle gettableanh = new Picturegoogle();
                                                        DataTable m_DataAnh = gettableanh.GetUrls(html);
                                                        if (m_DataAnh.Rows.Count > 0)
                                                        {
                                                            for (int h = 0; h <= 1; h++)
                                                            {

                                                                DataRow rowanh = m_DataAnh.Rows[h];
                                                                Picturegoogle downpic = new Picturegoogle();
                                                                string linkanh = rowanh["LinkAnh"].ToString();
                                                                byte[] data = downpic.GetImage(linkanh);

                                                                if (data != null)
                                                                {
                                                                    File.WriteAllBytes(_anhvideo, data);
                                                                }
                                                            }
                                                        }
                                                        #endregion
                                                    }
                                                    if (thumnail == "")
                                                    {
                                                        if (File.Exists(txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\imageload" + biendemslide.ToString() + ".jpeg"))
                                                        {
                                                            thumnail = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\imageload" + biendemslide.ToString() + ".jpeg";
                                                            #region // các xử lý sửa thumnail
                                                            if(checkborderthumnail.Checked==true)
                                                            {
                                                                string _thumnailbodertemp = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\thumnailbodertemp.jpeg";
                                                                string _thumnailboder= txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\thumnailboder.jpeg";
                                                                resizes.ThumnailConfigBorder(thumnail, _thumnailbodertemp, lblborderthumnail.ForeColor,int.Parse(txtsizeboderthumnail.Value.ToString()), _thumnailboder);
                                                                thumnail = _thumnailboder;
                                                            }
                                                            if (checklogothumnail.Checked == true)
                                                            {
                                                                string _logo = tblogothumnail.Text;
                                                                string _thumnaillogotemp = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\thumnaillogotemp.jpeg";
                                                                string _thumnaillogo = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\thumnaillogo.jpeg";
                                                                resizes.ThumnailConfigLogo(thumnail, _logo, _thumnaillogotemp, _thumnaillogo);
                                                                thumnail = _thumnaillogo;
                                                            }
                                                            if (checktitlethumnail.Checked == true)
                                                            {
                                                                string _thumnailtitle = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\thumnailtitle.jpeg";
                                                                resizes.ThumnailConfigTitle(thumnail, subtitle, _thumnailtitle);
                                                                thumnail = _thumnailtitle;
                                                            }
                                                            #endregion
                                                        }
                                                    }
                                                    lblxuly.Text = "Xu ly download anh" + biendemslide.ToString();
                                                }
                                                #endregion

                                                #region // tao sub

                                                HardSubText sub = new HardSubText();
                                                Font font1 = new Font(cmbfonthardsub.Text, int.Parse(txtsizetext.Value.ToString()));
                                                string tenfilesub = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\" + biendemslide.ToString() + ".png";
                                                string tenfilesubps = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\" + biendemslide.ToString() + "ps.png";
                                                sub.DrawText(_noidung, font1, lblsubcolor.ForeColor, 1750, lblsubbordercolor.ForeColor, int.Parse(txtsizeborder.Value.ToString()), tenfilesub);
                                                sub.DrawTextProshow2(tenfilesub, tenfilesubps);
                                                lblxuly.Text = "Tao sub" + biendemslide.ToString();

                                                #endregion
                                                #region // lay voice                                           
                                                string _voiceaudio = "";
                                                string voicexuly = "";
                                                try
                                                {
                                                    if (checkrendervoiceoffline.Checked == true)
                                                    {
                                                        #region // download voice tạm xử lý voice dùng hàm đồng bộ task
                                                        cl_ReadVoice read = new cl_ReadVoice();
                                                        string url = "";
                                                        idchitiet = int.Parse(row["ID"].ToString());
                                                        string ngonngu = row["NgonNguSelenium"].ToString();
                                                        string mcvoice = row["MCVoiceSelenium"].ToString();
                                                        string effect = row["EffectSelenium"].ToString();
                                                        string effectlevel = row["EffectLevelSelenium"].ToString();
                                                        string noidung = "";
                                                        try
                                                        {
                                                            noidung = chuanHoa(row["NoiDung"].ToString().Trim());
                                                        }
                                                        catch { }

                                                        if (noidung != "")
                                                        {
                                                            _voice = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\" + idchitiet.ToString() + ".mp3";
                                                            _voicetemp = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\" + idchitiet.ToString() + ".wav";

                                                            #region // lấy link voice

                                                            if (radvoicedefault.Checked == true)
                                                            {
                                                                url = read.getURLMp3(_urlvoicecu, ngonngu, mcvoice, effect, effectlevel, noidung.Trim());
                                                                _urlvoicecu = url;
                                                            }
                                                            else if (radvoice2.Checked == true)
                                                            {
                                                                if (noidung.Length >= 200)
                                                                {
                                                                    url = read.getURLMp3_V2(_urlvoicecu, noidung.Trim().Substring(0, 199));
                                                                    _urlvoicecu = url;
                                                                }
                                                                else
                                                                {
                                                                    url = read.getURLMp3_V2(_urlvoicecu, noidung.Trim());
                                                                    _urlvoicecu = url;
                                                                }


                                                            }
                                                            else if (radiovoicereallusion.Checked == true)
                                                            {
                                                                if (noidung.Length >= 200)
                                                                {
                                                                    url = read.getURLMp3_Voice_Reall(_urlvoicecu, noidung.Trim().Substring(0, 199));
                                                                    _urlvoicecu = url;
                                                                }
                                                                else
                                                                {
                                                                    url = read.getURLMp3_Voice_Reall(_urlvoicecu, noidung.Trim());
                                                                    _urlvoicecu = url;
                                                                }

                                                            }
                                                            else if (radiovoicecereproc.Checked == true)
                                                            {
                                                                if (noidung.Length >= 200)
                                                                {
                                                                    url = read.getURLMp3_Voice_cereproc(_urlvoicecu, noidung.Trim().Substring(0, 199));
                                                                    _urlvoicecu = url;
                                                                }
                                                                else
                                                                {
                                                                    url = read.getURLMp3_Voice_cereproc(_urlvoicecu, noidung.Trim());
                                                                    _urlvoicecu = url;
                                                                }

                                                            }
                                                            else if (radvoice3.Checked == true)
                                                            {
                                                                url = curl.cull(read.getURLMp3_V3(_urlvoicecu, noidung.Trim()), "audio=", ".mp3") + ".mp3";
                                                                _urlvoicecu = url;
                                                            }
                                                            else if (radispeech.Checked == true)
                                                            {
                                                                if (noidung.Length >= 200)
                                                                {
                                                                    url = read.getURLMp3_ispeech(_urlvoicecu, noidung.Trim().Substring(0, 199));
                                                                    _urlvoicecu = url;
                                                                }
                                                                else
                                                                {
                                                                    url = read.getURLMp3_ispeech(_urlvoicecu, noidung.Trim());
                                                                    _urlvoicecu = url;
                                                                }
                                                            }
                                                            else if (radvoiceibm.Checked == true)
                                                            {
                                                                url = read.getURLMp3IBM(_urlvoicecu, cmbngonnguIBM.Text, noidung.Trim());
                                                                _urlvoicecu = url;
                                                            }
                                                            else if (radnotevibes.Checked == true)
                                                            {
                                                                url = read.getURLMp3vibes(_urlvoicecu, cmbnotevibes.Text, noidung.Trim());
                                                                _urlvoicecu = url;
                                                            }
                                                            else if (radttsmp3.Checked == true)
                                                            {
                                                                read.getvoicemp3_TTSmp3(cmbttsmp3.Text, noidung.Trim());
                                                                chuyenmp3torender(txtuotdownloads.Text, _voice);
                                                                _voiceaudio = _voice;
                                                            }
                                                            else if (radiovoiceamazon.Checked == true)
                                                            {
                                                                if (noidung.Length >= 200)
                                                                {
                                                                    read.getvoicemp3_TTSTOOL("Amazon", ddlLaguageamazon.Text, cmbvoiceamazon.Text, noidung.Trim().Substring(0, 199));
                                                                    chuyenmp3torender(txtuotdownloads.Text, _voice);
                                                                    _voiceaudio = _voice;
                                                                }
                                                                else
                                                                {
                                                                    read.getvoicemp3_TTSTOOL("Amazon", ddlLaguageamazon.Text, cmbvoiceamazon.Text, noidung.Trim());
                                                                    chuyenmp3torender(txtuotdownloads.Text, _voice);
                                                                    _voiceaudio = _voice;
                                                                }


                                                            }
                                                            else if (radiovoiceMicrosoft.Checked == true)
                                                            {
                                                                if (noidung.Length >= 200)
                                                                {
                                                                    read.getvoicemp3_TTSTOOL("Microsoft", ddlLaguagemicrosoft.Text, cmbvoicemicrosoft.Text, noidung.Trim().Substring(0, 199));
                                                                    chuyenmp3torender(txtuotdownloads.Text, _voice);
                                                                    _voiceaudio = _voice;
                                                                }
                                                                else
                                                                {
                                                                    read.getvoicemp3_TTSTOOL("Microsoft", ddlLaguagemicrosoft.Text, cmbvoicemicrosoft.Text, noidung.Trim());
                                                                    chuyenmp3torender(txtuotdownloads.Text, _voice);
                                                                    _voiceaudio = _voice;

                                                                }

                                                            }
                                                            else if (radiovoicewideo.Checked == true)
                                                            {
                                                                if (noidung.Length >= 200)
                                                                {
                                                                    url = read.getURLMp3_Wideo(_urlvoicecu,cmbwideo.Text, noidung.Trim().Substring(0, 199));
                                                                    _urlvoicecu = url;
                                                                }
                                                                else
                                                                {
                                                                    url = read.getURLMp3_Wideo(_urlvoicecu, cmbwideo.Text, noidung.Trim());
                                                                    _urlvoicecu = url;
                                                                }
                                                            }
                                                            else if (radiovoicelinguatec.Checked == true)
                                                            {
                                                                if (noidung.Length >= 200)
                                                                {
                                                                    url = read.getURLMp3_Ling(_urlvoicecu, cmblaguageling.Text,cmbvoiceling.Text, noidung.Trim().Substring(0, 199));
                                                                    _urlvoicecu = url;
                                                                }
                                                                else
                                                                {
                                                                    url = read.getURLMp3_Ling(_urlvoicecu, cmblaguageling.Text, cmbvoiceling.Text, noidung.Trim());
                                                                    _urlvoicecu = url;
                                                                }
                                                            }
                                                            else if (radiovoicesestek.Checked == true)
                                                            {
                                                                if (noidung.Length >= 200)
                                                                {
                                                                    url = read.getURLMp3_sestek(_urlvoicecu, cmbsestek.Text,noidung.Trim().Substring(0, 199));
                                                                    _urlvoicecu = url;
                                                                }
                                                                else
                                                                {
                                                                    url = read.getURLMp3_sestek(_urlvoicecu, cmbsestek.Text, noidung.Trim());
                                                                    _urlvoicecu = url;
                                                                }
                                                            }
                                                            #endregion
                                                            lblxuly.Text = "Lấy voice ok url=" + url.ToString();
                                                            //lấy để upload lên server

                                                             #region // download file mp3
                                                            if (url != "")
                                                            {
                                                                if (radvoicedefault.Checked == true)
                                                                {
                                                                    downloadFileV2(url, _voice).Wait();
                                                                    _voiceaudio = _voice;
                                                                }
                                                                else if (radvoice3.Checked == true)
                                                                {
                                                                    downloadFileV2(url, _voice).Wait();
                                                                    _voiceaudio = _voice;
                                                                }
                                                                else if (radispeech.Checked == true)
                                                                {
                                                                    downloadFileV2(url, _voicetemp).Wait();
                                                                    Thread.Sleep(2000);
                                                                    RunFFMPEG fftangmam = new RunFFMPEG();
                                                                    string voicexulytamam = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\" + biendemslide.ToString() + "voicexuly.wav";
                                                                    string tangam = string.Format(@"-i {0} -filter:a loudnorm {1}", _voicetemp, voicexulytamam);
                                                                    fftangmam.RunCommandLoad(tangam, _AtriHidde).Wait();

                                                                    _voiceaudio = voicexulytamam;
                                                                    //_voiceaudio = _voicetemp;
                                                                }
                                                                else if (radvoiceibm.Checked == true)
                                                                {
                                                                    downloadFileV2(url, _voice).Wait();
                                                                    _voiceaudio = _voice;
                                                                }
                                                                else if (radnotevibes.Checked == true)
                                                                {
                                                                    downloadFileV2(url, _voicetemp).Wait();
                                                                    Thread.Sleep(2000);
                                                                    RunFFMPEG fftangmam = new RunFFMPEG();
                                                                    string voicexulytamam = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\voicexuly" + biendemslide.ToString() + ".wav";
                                                                    string tangam = string.Format(@"-i {0} -filter:a loudnorm {1}", _voicetemp, voicexulytamam);
                                                                    fftangmam.RunCommandLoad(tangam, _AtriHidde).Wait();
                                                                    _voiceaudio = voicexulytamam;
                                                                    // _voiceaudio = _voicetemp;
                                                                }
                                                                // if (checkdownxnet.Checked == true) { 
                                                                else if (radiovoicereallusion.Checked == true)
                                                                    {
                                                                        downloadFileV2_Ex(url, _voice).Wait();
                                                                        _voiceaudio = _voice;
                                                                    }
                                                                    else if (radiovoicelinguatec.Checked == true)
                                                                    {
                                                                        downloadFileV2_Ex(url, _voice).Wait();
                                                                        _voiceaudio = _voice;
                                                                    }
                                                               // }
                                                                //else if (radiovoicecereproc.Checked == true)
                                                                //{
                                                                //    downloadFileV2_Ex(url, _voice).Wait();
                                                                //    _voiceaudio = _voice;
                                                                //}
                                                                //else if (radiovoicewideo.Checked == true)
                                                                //{
                                                                //    downloadFileV2_Ex(url, _voice).Wait();
                                                                //    _voiceaudio = _voice;
                                                                //}

                                                                else if (radiovoicesestek.Checked == true)
                                                                {
                                                                    downloadFileV2_Ex(url, _voice).Wait();
                                                                    _voiceaudio = _voice;
                                                                }
                                                                else
                                                                {

                                                                    downloadFileV2(url, _voicetemp).Wait();
                                                                    _voiceaudio = _voicetemp;
                                                                    #region // tang am luong cho voice                                     
                                                                    //RunFFMPEG fftangmam = new RunFFMPEG();
                                                                    //string voicexulytamam = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\voicexuly" + biendemslide.ToString() + ".wav";
                                                                    //string tangam = string.Format(@"-i {0} -filter:a ""volume =1.5"" {1}", _voiceaudio, voicexulytamam);
                                                                    //fftangmam.RunCommand(tangam, _AtriHidde);
                                                                    //_voiceaudio = voicexulytamam;
                                                                    #endregion
                                                                }
                                                                Thread.Sleep(2000);
                                                            }
                                                            #endregion


                                                        }

                                                        #endregion
                                                        voicexuly = _voiceaudio;
                                                        lblxuly.Text = "Xu ly voice" + biendemslide.ToString();
                                                        #region // tang am luong cho voice                                     
                                                        //RunFFMPEG fftangmam = new RunFFMPEG();
                                                        //voicexuly = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\voicexuly" + biendemslide.ToString() + ".mp3";
                                                        //string tangam = string.Format(@"-i {0} -filter:a ""volume =1.5"" {1}", _voiceaudio, voicexuly);
                                                        //fftangmam.RunCommand(tangam, _AtriHidde);

                                                        #endregion
                                                    }
                                                    else
                                                    {
                                                        #region // lấy voice trên server
                                                        using (WebClient webClientvoice = new WebClient())
                                                        {
                                                            byte[] datavoice = webClientvoice.DownloadData(_pathvoice);
                                                            File.WriteAllBytes(txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\" + biendemslide.ToString() + ".rar", datavoice);
                                                        }
                                                        string rar_fileVoice = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\" + biendemslide.ToString() + ".rar";
                                                        string path_fileVoice = txtfoldervideo.Text + "/" + folder + "/" + k.ToString();
                                                        ExtractRAR(rar_fileVoice, path_fileVoice);
                                                        Thread.Sleep(5000);
                                                        string _duoifile = kiemtraduoifile(txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString(), _idchitiet.ToString());
                                                        if (_duoifile == ".wav")
                                                        {
                                                            _voiceaudio = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\" + _idchitiet.ToString() + ".wav";
                                                        }
                                                        else
                                                        {
                                                            _voiceaudio = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\" + _idchitiet.ToString() + ".mp3";
                                                        }
                                                        voicexuly = _voiceaudio;
                                                        lblxuly.Text = "Xu ly voice" + biendemslide.ToString();
                                                        #region // tang am luong cho voice                                     
                                                        RunFFMPEG fftangmam = new RunFFMPEG();
                                                        voicexuly = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\voicexuly" + biendemslide.ToString() + ".mp3";
                                                        string tangam = string.Format(@"-i {0} -filter:a ""volume =1.5"" {1}", _voiceaudio, voicexuly);
                                                        fftangmam.RunCommand(tangam, _AtriHidde);

                                                        #endregion
                                                        #endregion
                                                    }

                                                }
                                                catch { }

                                                #region // lay time
                                                string pathvoice = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString();
                                                string namevoice = "voicexuly" + biendemslide.ToString() + ".mp3";
                                                string namevoicewav= "voicexuly" + biendemslide.ToString() + ".wav";
                                                if (hamkiemtratontaifile(pathvoice,namevoice)==false)
                                                {
                                                    //if (hamkiemtratontaifile(pathvoice, namevoicewav) == false)
                                                    //{
                                                        voicexuly = _voiceaudio;
                                                   // }
                                                }
                                                Proshow _timefile = new Proshow();
                                                int times = 0;
                                                try
                                                {
                                                    //times = (int)_timefile.GetTime(voicexuly);
                                                    //if(times==0)
                                                    //{
                                                        times = (int)_timefile.getDuration(voicexuly).Result;
                                                    //}

                                                    if (times ==0)
                                                    {
                                                        times = 15;
                                                    }
                                                }
                                                catch { times = 15; }
                                                if (checktangtimevoice.Checked == true)
                                                {
                                                    times = times + 4;
                                                }
                                                #endregion

                                                #endregion

                                            
                                                #region // xử lý add logo chống bản quyền :D
                                                if (txtlogovids.Text!="")
                                                    {
                                                        string _logo = txtlogovids.Text;
                                                        string _anhvideologotemp = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\anhvideologotemp" + biendemslide.ToString() + ".jpeg";
                                                        string _anhvideologo = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\anhvideologo" + biendemslide.ToString() + ".jpeg";
                                                        resizes.ThumnailConfigLogoVideo(_anhvideo, _logo, _anhvideologotemp, _anhvideologo);
                                                        _anhvideo = _anhvideologo;
                                                 }
                                                string pathimag = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString();
                                                string image = "imageload" + biendemslide.ToString() + ".jpeg";
                                                if (txtlogovids.Text != "")
                                                {
                                                    image= "anhvideologo"+biendemslide.ToString() + ".jpeg";
                                                }
                                                if (hamkiemtratontaifile(pathimag,image)==false)
                                                {
                                                    _anhvideo = "";
                                                }
                                                #endregion
                                                slideps.Rows.Add(pathmc,tenfilesubps, _anhvideo, times * 1000, voicexuly, times * 1000);
                                              
                                            }
                                            catch { }
                                            biendemslide = biendemslide + 1;
                                        }
                                        #endregion

                                      

                                        #region // lay file bgaudio
                                        var files = new DirectoryInfo(txtbgaudio.Text).GetFiles();
                                        int index = new Random().Next(0, files.Length);
                                        string mp3bg = txtbgaudio.Text + @"\" + files[index].Name;
                                        string audiobg = Application.StartupPath + @"\Temp\bg.mp3";
                                        try
                                        {
                                            File.Delete(audiobg);
                                        }
                                        catch { }
                                        System.IO.File.Copy(mp3bg, audiobg, true);

                                        #endregion

                                        #region //duyệt lại bảng các ảnh không có sẽ thay bằng thumnail
                                        DataTable slidepsproshow = new DataTable();
                                        slidepsproshow.Columns.Add("PathMC", typeof(string));
                                        slidepsproshow.Columns.Add("PathSub", typeof(string));
                                        slidepsproshow.Columns.Add("PathImage", typeof(string));
                                        slidepsproshow.Columns.Add("TimeSlide", typeof(string));
                                        slidepsproshow.Columns.Add("PathVoice", typeof(string));
                                        slidepsproshow.Columns.Add("TimeVoice", typeof(string));
                                        foreach (DataRow rowslide in slideps.Rows)
                                        {
                                            string _PathMC = rowslide["PathMC"].ToString();
                                            string _PathSub = rowslide["PathSub"].ToString();
                                            string _PathImage = rowslide["PathImage"].ToString();
                                            string _TimeSlide = rowslide["TimeSlide"].ToString();
                                            string _PathVoice = rowslide["PathVoice"].ToString();
                                            string _TimeVoice = rowslide["TimeVoice"].ToString();
                                            if(_PathImage=="")
                                            {
                                                _PathImage = thumnail;
                                            }
                                            slidepsproshow.Rows.Add(_PathMC, _PathSub, _PathImage, _TimeSlide, _PathVoice, _TimeVoice);
                                        }

                                        #endregion

                                        #region // tạo video bằng proshow
                                        if (slideps.Rows.Count > 0)
                                        {
                                            string filevideo = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\_VideoUp.mp4";
                                            proshowserver creatvideo = new proshowserver();
                                            Proshow _timefileintro = new Proshow();
                                            Proshow _timefileouttro = new Proshow();
                                            string filePsh = creatvideo._CreatePSH(k.ToString(),
                                                tbintro.Text,((int)_timefileintro.getDuration(tbintro.Text).Result* 1000).ToString(),
                                                tbouttro.Text, ((int)_timefileouttro.getDuration(tbouttro.Text).Result * 1000).ToString(),
                                                txtfoldervideo.Text + @"\" + folder, audiobg, slidepsproshow);
                                            if (filePsh != null && filePsh != "")
                                            {
                                                Proshow creatvideojoin = new Proshow();
                                                creatvideojoin.AutomateRunProshow(k, filePsh, filevideo, txtpathproshow.Text);
                                            }
                                            try
                                            {
                                                File.Delete(filePsh);
                                                File.Delete(txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + ".pxc");
                                            }
                                            catch { }
                                            #region // tách
                                            //string filemp3 = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\_VideoUp.mp3";
                                            //RunFFMPEG fftaomp3 = new RunFFMPEG();
                                            //string taomp3 = string.Format(@"-i {0} -vn -acodec mp3 {1}", filevideo, filemp3);
                                            //fftaomp3.RunCommandLoad(taomp3, true).Wait();
                                            //string filevideotitle = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\"+title+".mp4";
                                            //System.IO.File.Move(filevideo, filevideotitle);
                                            #endregion
                                        }
                                        #endregion

                                    }
                                    catch
                                    {
                                        ChomeClose().Wait();
                                    }

                                    ChomeClose().Wait();
                                }
                                #endregion

                                #endregion
                                string fileFromComputer = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\_VideoUp.mp4";
                                if (checkmcsmall.Checked==true)
                                {
                                    var filesmc = new DirectoryInfo(txtfloderlistmc.Text).GetFiles();
                                    int indexmc = new Random().Next(0, filesmc.Length);
                                    string  pathmc = txtfloderlistmc.Text + @"\" + filesmc[indexmc].Name;
                                    #region // xoa am thanh file mc
                                    string _outputmc = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\mc.mp4";
                                    RunFFMPEG ffrunmutebg = new RunFFMPEG();
                                    string addmutebg = string.Format(@" -y -i  {0} -an -c:a aac -b:a 128k -ar 44100 -c:v libx264 -pix_fmt yuv420p -crf 25 -shortest  -preset superfast  {1}", pathmc, _outputmc);
                                    ffrunmutebg.RunCommand(addmutebg, _AtriHidde);
                                    #endregion
                                    //thu nho video mc
                                    string _outputvideoscale = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\_outputscalemc.mp4";
                                    RunFFMPEG ffrunscale = new RunFFMPEG();
                                    string addscale = string.Format(@" -i {0} -vf scale=""100:100"" {1}", _outputmc, _outputvideoscale);
                                    ffrunscale.RunCommand(addscale, _AtriHidde);
                                    //ghep vao video
                                    string _outputvideoMC = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\_output" + k.ToString() + ".mp4";
                                    RunFFMPEG ffrunmc = new RunFFMPEG();
                                    string addmc = string.Format(@" -y -i {0} -i {1} -filter_complex ""[0:v][1:v]overlay=x=1160:y=15:shortest=0"" -shortest {2}", fileFromComputer, _outputvideoscale, _outputvideoMC);
                                    ffrunmc.RunCommand(addmc, _AtriHidde);
                                    fileFromComputer = _outputvideoMC;
                                }
                                // thêm nền và mc tĩnh
                                if(checkMcBG.Checked==true)
                                {
                                    var filesbg = new DirectoryInfo(txtfloderlistbg.Text).GetFiles();
                                    int indexbg = new Random().Next(0, filesbg.Length);
                                    string pathbg = txtfloderlistbg.Text + @"\" + filesbg[indexbg].Name;
                                    // copy file video bg vào chung thư mục ffmpeg
                                    try { System.IO.File.Delete(Application.StartupPath + @"\" + filesbg[indexbg].Name); }
                                    catch { }
                                    System.IO.File.Copy(pathbg, Application.StartupPath + @"\" + filesbg[indexbg].Name, true);
                                    var filespicture = new DirectoryInfo(txtfloderlistpicture.Text).GetFiles();
                                    int indexpicture = new Random().Next(0, filespicture.Length);
                                    string pathpicture = txtfloderlistpicture.Text + @"\" + filespicture[indexpicture].Name;

                                    //ghep vao video
                                    string _outputvideobg = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\_output" + k.ToString() + ".mp4";
                                    RunFFMPEG ffrunmc = new RunFFMPEG();
                                    string addmc = "";
                                    if (checksmallvids.Checked==true)
                                    {
                                         addmc = string.Format(@" -y -i {0} -i {1} -filter_complex ""[0:v]scale=150:150[v1];movie={2}:loop=999,setpts=N/(FRAME_RATE*TB),scale=854:480,setdar=16/9[v2];[v2][v1]overlay=shortest=1:x=5:y=5[v3];[1:v]scale=854:480[v4];[v3][v4]overlay=0:0"" -vcodec libx264 -pix_fmt yuv420p -r 25 -g 62 -b:v 1200k -shortest -acodec aac -b:a 128k -ar 44100  -preset veryfast {3}", fileFromComputer, pathpicture, filesbg[indexbg].Name, _outputvideobg);
                                    }
                                    else
                                    {
                                         addmc = string.Format(@" -y -i {0} -i {1} -filter_complex ""[0:v]scale=400:280[v1];movie={2}:loop=999,setpts=N/(FRAME_RATE*TB),scale=854:480,setdar=16/9[v2];[v2][v1]overlay=shortest=1:x=5:y=5[v3];[1:v]scale=854:480[v4];[v3][v4]overlay=0:0"" -vcodec libx264 -pix_fmt yuv420p -r 25 -g 62 -b:v 1200k -shortest -acodec aac -b:a 128k -ar 44100  -preset veryfast {3}", fileFromComputer, pathpicture, filesbg[indexbg].Name, _outputvideobg);
                                    }
                                  
                                    ffrunmc.RunCommand(addmc, false);
                                    //thực hiện xóa file videobg sau khi xử lý xong
                                    System.IO.File.Delete(Application.StartupPath + @"\" + filesbg[indexbg].Name);
                                 
                                    fileFromComputer = _outputvideobg;
                                }

                                #region // them va link log da upload và xóa folder
                                try
                                {
                                    string url = "http://buudienhanoi.com.vn/ThangBDHN_Luu2/UpLoadFile.aspx";
                                  //  string fileFromComputer = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\_VideoUp.mp4";
                                    if (checkuploadvideo.Checked == true)
                                    {
                                        #region // upload video lên youtube
                                        if (checkuploadvideo.Checked == true)
                                        {

                                            #region // title
                                            string _title = r["TieuDe"].ToString();

                                            if (_title.Length > 98)
                                            {
                                                _title = (_title.Trim().Substring(0, 98));
                                            }
                                            else { _title = _title.Trim(); }

                                            #endregion
                                            #region desc

                                            string _desc = "";
                                            string mota = title + "\r\n" + txtadddesc.Text + "\r\n" + r["NoiDung"].ToString().Trim();
                                            if (mota.Length > 200) { _desc = chuanHoa(mota.Substring(0, 200)); }
                                            else { _desc = chuanHoa(mota); }
                                            #endregion
                                            string _path = fileFromComputer;
                                            string _tag = r["Tag"].ToString();
                                            if (_tag == "")
                                            {
                                                if (checkrapidtags.Checked == true)
                                                {
                                                    try
                                                    {
                                                        ChromeOptions options = new ChromeOptions();
                                                        options.AddArgument("--disable-blink-features=AutomationControlled");
                                                        ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                                                        service.HideCommandPromptWindow = true;

                                                        PropretiesCollection.driver = new ChromeDriver(service, options);
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
                                                        ChomeClose().Wait();
                                                    }
                                                    try
                                                    {
                                                        ChomeClose().Wait();
                                                    }
                                                    catch { }
                                                }
                                                else
                                                {
                                                    _tag = (Cl_Tag.GetTag(title));
                                                    _desc = _tag.Replace(",", ",#") + "\r\n" + _desc;
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
                                                    #region // upload by API
                                                    RunUpload(_path, _title, _desc.Replace("<", "").Replace(">", ""), _tag, flat).Wait();
                                                    if (checkborderthumnail.Checked == true)
                                                    {
                                                        string thumnailedit = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\thumnail.jpeg";
                                                        resizes.VeThumnail(thumnail, thumnailedit, lblborderthumnail.ForeColor);
                                                        setThumnail(thumnailedit, m_IDVideoUpload).Wait();
                                                    }
                                                    else
                                                    {
                                                        setThumnail(thumnail, m_IDVideoUpload).Wait();
                                                    }
                                                    #endregion
                                                }
                                                else if (raduploadchome.Checked == true)
                                                {
                                                    #region // upload chome
                                                    if (checkdefaulprofile.Checked == true)
                                                    {
                                                        try
                                                        {
                                                            ChromeOptions options = new ChromeOptions();
                                                            options.AddArguments("user-data-dir=C:/Users/" + Environment.GetEnvironmentVariable("UserName") + "/AppData/Local/Google/Chrome/User Data");
                                                            options.AddArguments("--start-maximized");
                                                            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                                                            service.HideCommandPromptWindow = true;
                                                            PropretiesCollection.driver = new ChromeDriver(service, options);
                                                            PropretiesCollection.driver.Navigate().GoToUrl("https://www.youtube.com/upload?redirect_to_classic=true");
                                                            UploadYoutube ytb = new UploadYoutube();
                                                            int bkt = 0;
                                                            if (checksetmotizeion.Checked == true)
                                                            {
                                                                bkt = 1;
                                                            }                                                          
                                                            ytb.UploadFroFile(_path, title, _desc.Replace("<", "").Replace(">", ""), _tag, thumnail, bkt).Wait();
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
                                                            if (checklistgmail.Checked == true)
                                                            {
                                                                string m_takkhoan ="";
                                                                string m_matkhau = "";

                                                                ytb.Login(m_takkhoan, m_matkhau, _path).Wait();
                                                            }
                                                            else
                                                            {
                                                                ytb.Login(txttaikhoan.Text, txtmatkhau.Text, _path).Wait();
                                                            }
                                                            int bkt = 0;
                                                            if (checksetmotizeion.Checked == true)
                                                            {
                                                                bkt = 1;
                                                            }
                                                            ytb.Upload(_title, _desc, _tag, thumnail, bkt).Wait();
                                                        }
                                                        catch { }
                                                    }
                                                    #endregion
                                                }
                                                else if (raduploadchomebeta.Checked == true)
                                                {
                                                    #region // upload chome
                                                  
                                                        try
                                                        {
                                                            ChromeOptions options = new ChromeOptions();
                                                            options.AddArguments("user-data-dir=C:/Users/" + Environment.GetEnvironmentVariable("UserName") + "/AppData/Local/Google/Chrome/User Data");
                                                            options.AddArguments("--start-maximized");
                                                            options.AddArgument("--disable-blink-features=AutomationControlled");
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
                                                            bool m_private = false;
                                                            if(checkprivate.Checked==true)
                                                            { m_private = true; }
                                                            ytb.UploadFroFileBeta(_path, _title, _desc.Replace("<", "").Replace(">", ""), _tag, thumnail, bkt, m_private).Wait();
                                                        }
                                                        catch { }
                                                   
                                                   
                                                    #endregion
                                                }
                                            }
                                            catch { }

                                        }
                                        #endregion

                                        #region // them va link log da upload và xóa folder
                                        daWS_FakeAuto log = new daWS_FakeAuto();
                                        log.InsertBaiVietDaUp(int.Parse(cmbchannel.SelectedValue.ToString()), k);
                                        hienthisoluongdaup();
                                        try
                                        {
                                            ChomeClose().Wait();
                                        }
                                        catch { }
                                        #endregion
                                    }                                    
                                    else
                                    {
                                        WebClient myWebClient = new WebClient();
                                        string rar_file = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + ".rar";
                                        CompressRAR(rar_file, fileFromComputer);
                                        byte[] responseArray = myWebClient.UploadFile(url, rar_file);
                                        //upload thumnail
                                        // thumnail = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + @"\imageload1.jpeg";
                                        string rar_filethumnail = txtfoldervideo.Text + @"\" + folder + @"\" + k.ToString() + "_Thumnail.rar";
                                        CompressRAR(rar_filethumnail, thumnail);
                                        WebClient myWebClient2 = new WebClient();
                                        byte[] responseArray2 = myWebClient.UploadFile(url, rar_filethumnail);
                                        daWS_FakeAuto log = new daWS_FakeAuto();
                                        log.UpdateBaiVietDaRender(k);
                                    }
                                    #region // upload facebook
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
                                        string _path = fileFromComputer;                                        
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
                                            fb.Upload(_path, title, _desc.Replace("<", "").Replace(">", ""), "", thumnail).Wait();
                                        }
                                        catch { }

                                    }
                                    #endregion
                                    if (checkdelfolder.Checked == true)
                                    {
                                        hamxoafile(txtfoldervideo.Text + @"\" + folder);
                                        hamxoafile(txtfoldervideo.Text + @"\" + folder+@"\" + k.ToString());
                                    }
                                }
                                catch { ChomeClose().Wait(); }

                                #endregion
                                if (checkuploadvideo.Checked==true)
                                {
                                    hienthisoluongdaup();
                                }
                            }
                            catch { ChomeClose().Wait(); }
                            k = k + 1;
                            ChomeClose().Wait();
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); return; }
                #endregion
            }
        }

        private void bgwrendermulti_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
            }
            else
            {
                if (!bgwrendermulti.IsBusy)
                {

                    prs.Value = 0;
                    lblxuly.Text = "Complete!";
                   // hienthibaiviet();
                    Thread.Sleep(int.Parse(txtthoigiancho.Text));
                    timerrendermulti.Enabled = true;
                    timerrendermulti.Start();
                }
            }
        }

        private void timerrendermulti_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!bgwrendermulti.IsBusy)
                {
                    bgwrendermulti.RunWorkerAsync();
                    timerrendermulti.Enabled = false;
                    timerrendermulti.Stop();
                }

            }
            catch
            {
                timerrendermulti.Enabled = true;
                timerrendermulti.Interval = int.Parse(txtthoigiancho.Text);
                timerrendermulti.Start();
            }
        }

        #endregion

        #region // cấu hình

        private void btnoutdownload_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                txtuotdownloads.Text = fl.SelectedPath;
                ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
                exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
                //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
                cf.AppSettings.Settings.Remove("OutputDownLoad");
                cf.AppSettings.Settings.Add("OutputDownLoad", txtuotdownloads.Text);
                cf.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnfloderlistmc_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                txtfloderlistmc.Text = fl.SelectedPath;
                ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
                exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
                //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
                cf.AppSettings.Settings.Remove("FolderMC");
                cf.AppSettings.Settings.Add("FolderMC", txtfloderlistmc.Text);
                cf.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void btnborderthumnail_Click_1(object sender, EventArgs e)
        {
            ColorDialog colorDlg = new ColorDialog();
            if (colorDlg.ShowDialog() == DialogResult.OK)
            {
                lblborderthumnail.ForeColor = colorDlg.Color;
            }
        }

        private void btnlogothumnail_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = false;
            dlg.CheckPathExists = false;
            dlg.Multiselect = false;
            dlg.Filter = "Files(*.png)|*.png|Files(*.jpeg)|*.jpeg|Files(*.jpg)|*.jpg";
            dlg.Multiselect = true;
            dlg.SupportMultiDottedExtensions = true;
            dlg.Title = "Select intro file png";

            //if (String.IsNullOrEmpty(Settings.Default.LastUsedFolder))
            //    Settings.Default.LastUsedFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

            //dlg.InitialDirectory = Settings.Default.LastUsedFolder;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //Settings.Default.LastUsedFolder = Path.GetDirectoryName(dlg.FileNames[0]);
                tblogothumnail.Text = dlg.FileName;
                ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
                exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
                //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
                cf.AppSettings.Settings.Remove("LogoThumnail");
                cf.AppSettings.Settings.Add("LogoThumnail", tblogothumnail.Text);
                cf.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void btnlogovids_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = false;
            dlg.CheckPathExists = false;
            dlg.Multiselect = false;
            dlg.Filter = "Files(*.png)|*.png|Files(*.jpeg)|*.jpeg|Files(*.jpg)|*.jpg";
            dlg.Multiselect = true;
            dlg.SupportMultiDottedExtensions = true;
            dlg.Title = "Select intro file png";

            //if (String.IsNullOrEmpty(Settings.Default.LastUsedFolder))
            //    Settings.Default.LastUsedFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);

            //dlg.InitialDirectory = Settings.Default.LastUsedFolder;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //Settings.Default.LastUsedFolder = Path.GetDirectoryName(dlg.FileNames[0]);
                txtlogovids.Text = dlg.FileName;
                ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
                exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
                //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
                cf.AppSettings.Settings.Remove("LogoVids");
                cf.AppSettings.Settings.Add("LogoVids", txtlogovids.Text);
                cf.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void txtfoldervideo_TextChanged(object sender, EventArgs e)
        {

        }

        private void ddlLaguageamazon_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NgonNgu", typeof(string));
            dt.Columns.Add("Voice", typeof(string));
            dt.Rows.Add("Danish", "Mads (Danish)");
            dt.Rows.Add("Danish", "Naja (Danish)");
            dt.Rows.Add("Dutch", "Lotte (Dutch)");
            dt.Rows.Add("Dutch", "Ruben (Dutch)");
            dt.Rows.Add("English", "Nicole (Australian English)");
            dt.Rows.Add("English", "Russell (Australian English)");
            dt.Rows.Add("English", "Amy (British English)");
            dt.Rows.Add("English", "Brian (British English)");
            dt.Rows.Add("English", "Emma (British English)");
            dt.Rows.Add("English", "Aditi (Indian English)");
            dt.Rows.Add("English", "Raveena (Indian English)");
            dt.Rows.Add("English", "Ivy (US English)");
            dt.Rows.Add("English", "Joanna (US English)");
            dt.Rows.Add("English", "Joey (US English)");
            dt.Rows.Add("English", "Justin (US English)");
            dt.Rows.Add("English", "Kendra (US English)");
            dt.Rows.Add("English", "Kimberly (US English)");
            dt.Rows.Add("English", "Matthew (US English)");
            dt.Rows.Add("English", "Salli (US English)");
            dt.Rows.Add("English", "Geraint (Welsh English)");
            dt.Rows.Add("French", "Chantal (Canadian French)");
            dt.Rows.Add("French", "Celine (French)");
            dt.Rows.Add("French", "Mathieu (French)");
            dt.Rows.Add("German", "Hans (German)");
            dt.Rows.Add("German", "Marlene (German)");
            dt.Rows.Add("German", "Vicki (German)");
            dt.Rows.Add("Icelandic", "Dora (Icelandic)");
            dt.Rows.Add("Icelandic", "Karl (Icelandic)");
            dt.Rows.Add("Italian", "Carla (Italian)");
            dt.Rows.Add("Italian", "Giorgio (Italian)");
            dt.Rows.Add("Japanese", "Mizuki (Japanese)");
            dt.Rows.Add("Japanese", "Takumi (Japanese)");
            dt.Rows.Add("Korean", "Seoyeon (Korean)");
            dt.Rows.Add("Norwegian", "Liv (Norwegian)");
            dt.Rows.Add("Polish", "Ewa (Polish)");
            dt.Rows.Add("Polish", "Jacek (Polish)");
            dt.Rows.Add("Polish", "Jan (Polish)");
            dt.Rows.Add("Polish", "Maja (Polish)");
            dt.Rows.Add("Portuguese", "Ricardo (Brazilian Portuguese)");
            dt.Rows.Add("Portuguese", "Vitoria (Brazilian Portuguese)");
            dt.Rows.Add("Portuguese", "Cristiano (Portuguese)");
            dt.Rows.Add("Portuguese", "Ines (Portuguese)");
            dt.Rows.Add("Romanian", "Carmen (Romanian)");
            dt.Rows.Add("Russian", "Maxim (Russian)");
            dt.Rows.Add("Russian", "Tatyana (Russian)");
            dt.Rows.Add("Spanish", "Conchita (Castilian Spanish)");
            dt.Rows.Add("Spanish", "Enrique (Castilian Spanish)");
            dt.Rows.Add("Spanish", "Miguel (US Spanish)");
            dt.Rows.Add("Spanish", "Penelope (US Spanish)");
            dt.Rows.Add("Swedish", "Astrid (Swedish)");
            dt.Rows.Add("Turkish", "Filiz (Turkish)");
            dt.Rows.Add("Welsh", "Gwyneth (Welsh)");           
            DataRow[] rows = dt.Select("NgonNgu LIKE '*" + ddlLaguageamazon.Text + "*' ");
            DataTable table = new DataTable();
            table.Columns.Add("Voice", typeof(string));
            foreach (DataRow row in rows)
            {
                table.Rows.Add(row["Voice"].ToString());
            }
            cmbvoiceamazon.DataSource = table;
            cmbvoiceamazon.DisplayMember = "Voice";
            cmbvoiceamazon.ValueMember = "Voice";
        }

        private void ddlLaguagemicrosoft_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NgonNgu", typeof(string));
            dt.Columns.Add("Voice", typeof(string));
            dt.Rows.Add("Catalan", "Herena (Catalan)");
            dt.Rows.Add("Chinese", "Huihui (Chinese)");
            dt.Rows.Add("Chinese", "Kangkang (Chinese)");
            dt.Rows.Add("Chinese", "Yaoyao (Chinese)");
            dt.Rows.Add("ChineseTW", "Hanhan (ChineseTW)");
            dt.Rows.Add("ChineseTW", "Yating (ChineseTW)");
            dt.Rows.Add("ChineseTW", "Zhiwei (ChineseTW)");
            dt.Rows.Add("Danish", "Helle (Danish)");
            dt.Rows.Add("Dutch", "Bart (Belgian Dutch)");
            dt.Rows.Add("Dutch", "Frank (Dutch)");
            dt.Rows.Add("English", "Catherine (Australian English)");
            dt.Rows.Add("English", "James (Australian English)");
            dt.Rows.Add("English", "George (British English)");
            dt.Rows.Add("English", "Hazel (British English)");
            dt.Rows.Add("English", "Susan (British English)");
            dt.Rows.Add("English", "Linda (Canadian English)");
            dt.Rows.Add("English", "Richard (Canadian English)");
            dt.Rows.Add("English", "Heera (Indian English)");
            dt.Rows.Add("English", "Ravi (Indian English)");
            dt.Rows.Add("English", "David (US English)");
            dt.Rows.Add("English", "Mark (US English)");
            dt.Rows.Add("English", "Zira (US English)");
            dt.Rows.Add("Finnish", "Heidi (Finnish)");
            dt.Rows.Add("French", "Caroline (Canadian French)");
            dt.Rows.Add("French", "Claude (Canadian French)");
            dt.Rows.Add("French", "Nathalie (Canadian French)");
            dt.Rows.Add("French", "Hortense (French)");
            dt.Rows.Add("French", "Julie (French)");
            dt.Rows.Add("French", "Paul (French)");
            dt.Rows.Add("German", "Hedda (German)");
            dt.Rows.Add("German", "Katja (German)");
            dt.Rows.Add("German", "Stefan (German)");
            dt.Rows.Add("Italian", "Cosimo (Italian)");
            dt.Rows.Add("Italian", "Elsa (Italian)");
            dt.Rows.Add("Japanese", "Ayumi (Japanese)");
            dt.Rows.Add("Japanese", "Haruka (Japanese)");
            dt.Rows.Add("Japanese", "Ichiro (Japanese)");
            dt.Rows.Add("Japanese", "Sayaka (Japanese)");
            dt.Rows.Add("Korean", "Heami (Korean)");
            dt.Rows.Add("Norwegian", "Jon (Norwegian)");
            dt.Rows.Add("Polish", "Adam (Polish)");
            dt.Rows.Add("Polish", "Paulina (Polish)");
            dt.Rows.Add("Portuguese", "Daniel (Brazilian Portuguese)");
            dt.Rows.Add("Portuguese", "Maria (Brazilian Portuguese)");
            dt.Rows.Add("Portuguese", "Helia (Portuguese)");
            dt.Rows.Add("Russian", "Irina (Russian)");
            dt.Rows.Add("Russian", "Pavel (Russian)");
            dt.Rows.Add("Spanish", "Raul (Mexican Spanish)");
            dt.Rows.Add("Spanish", "Sabina (Mexican Spanish)");
            dt.Rows.Add("Spanish", "Helena (Spanish)");
            dt.Rows.Add("Spanish", "Laura (Spanish)");
            dt.Rows.Add("Spanish", "Pablo (Spanish)");
            dt.Rows.Add("Swedish", "Bengt (Swedish)");
            dt.Rows.Add("Turkish", "Tolga (Turkish)");
            dt.Rows.Add("Vietnamese", "An (Vietnamese)");           

            DataRow[] rows = dt.Select("NgonNgu LIKE '*" + ddlLaguagemicrosoft.Text + "*' ");
            DataTable table = new DataTable();
            table.Columns.Add("Voice", typeof(string));
            foreach (DataRow row in rows)
            {
                table.Rows.Add(row["Voice"].ToString());
            }
            cmbvoicemicrosoft.DataSource = table;
            cmbvoicemicrosoft.DisplayMember = "Voice";
            cmbvoicemicrosoft.ValueMember = "Voice";
        }
        #endregion


        #region /// phần dành cho reup
        private void btnrefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            loadmailchuaxuly();
            loadmaildaxuly();
            this.Cursor = Cursors.Default;
        }
        private void loadmailchuaxuly()
        {
            daWS_FakeAuto ds = new daWS_FakeAuto();
            DataTable dt = new DataTable();
            dt = ds.DanhSachMailChuaXuLy(m_IDTaiKhoan);
            dataGridViewListKenh.DataSource = dt;
        }

        private void btnchangepassall_Click(object sender, EventArgs e)
        {
            Thread change = new Thread(()=> {
                DataTable dt = new DataTable();
                dt=(DataTable)dataGridViewListKenh.DataSource;
                if(dt.Rows.Count>0)
                {
                    int k = 1;
                    foreach (DataRow r in dt.Rows)
                    {
                        if(k<=txtsoluongmailchange.Value)
                        {
                            #region // thực hiện các bước change mail
                            try
                            {
                                dataGridViewListKenh.Rows[k-1].DefaultCellStyle.BackColor = Color.Beige;
                                string mail = r["Mail"].ToString();
                                string pass = r["Pass"].ToString();
                                string mailkhoiphuc = r["MailKhoiPhuc"].ToString();
                                lblthongbaoreup.Text = "Change info mail :" + mail;
                                string[] temp = mail.Split(new string[] { "@" }, StringSplitOptions.RemoveEmptyEntries);
                                string passmoi = temp[0].ToString() + "." + txttientopass.Text + "@gmail.com";
                                string mailkhoiphucmoi = passmoi;
                                ChromePerformanceLoggingPreferences perfLogPrefs = new ChromePerformanceLoggingPreferences();
                                perfLogPrefs.AddTracingCategories(new string[] { "devtools.timeline" });
                                ChromeOptions options = new ChromeOptions();
                                options.AddArguments("--disable-notifications");
                                if (checktabandanh.Checked == true)
                                { options.AddArguments("--incognito"); }
                                options.PerformanceLoggingPreferences = perfLogPrefs;
                                options.SetLoggingPreference(LogType.Driver, LogLevel.All);
                                options.SetLoggingPreference("performance", LogLevel.All);
                                options.AddAdditionalCapability(CapabilityType.EnableProfiling, true, true);
                                PropretiesCollection.driver = new ChromeDriver(options);
                                try
                                {
                                    PropretiesCollection.driver.Navigate().GoToUrl("https://myaccount.google.com/personal-info");
                                    ManagerChannel changemailkhoiphuc = new ManagerChannel();
                                    int kqthaymail = changemailkhoiphuc.ThayMailKhoiPhuc(mail, pass, mailkhoiphuc, mailkhoiphucmoi);
                                    ChomeClose().Wait();
                                    // thay thanh cong mail moi chuyen sang thay pass
                                    if (kqthaymail == 1)
                                    {
                                        daWS_FakeAuto thaydoi = new daWS_FakeAuto();
                                        thaydoi.UpdateMailKhoiPhuc(mail, passmoi, mailkhoiphucmoi, m_IDTaiKhoan);
                                    }
                                    
                                }
                                catch
                                {
                                }
                                try {
                                    PropretiesCollection.driver.Navigate().GoToUrl("https://myaccount.google.com/personal-info");
                                    ManagerChannel changepass = new ManagerChannel();
                                    int kq = changepass.ThayPassMoi(mail, pass, mailkhoiphucmoi, passmoi);
                                    ChomeClose().Wait();
                                    #region // khi thay thanh cong xong thay đổi trong csdl
                                    if (kq == 1)
                                    {
                                        daWS_FakeAuto thaydoi = new daWS_FakeAuto();
                                        thaydoi.XuLyMail(mail, passmoi, mailkhoiphucmoi, m_IDTaiKhoan);
                                    }

                                    #endregion
                                }
                                catch {

                                    //daWS_FakeAuto thaydoi = new daWS_FakeAuto();
                                    //thaydoi.XuLyMailLoi(mail, passmoi, mailkhoiphucmoi, m_IDTaiKhoan);

                                }


                            }
                            catch {
                                ChomeClose().Wait();
                               
                            }
                            #endregion
                        }
                        k = k + 1;
                    }
                }
            });
            change.Start();
        }


        private void loadmaildaxuly()
        {
            DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
            CheckBox chk = new CheckBox();
            CheckboxColumn.Width = 50;
            dataGridViewListReup.Columns.Add(CheckboxColumn);
            DataGridViewCheckBoxColumn CheckboxColumn1 = new DataGridViewCheckBoxColumn();
            CheckBox chk1 = new CheckBox();
            CheckboxColumn1.Width = 50;
            dataGridViewListReupMobi.Columns.Add(CheckboxColumn1);
            daWS_FakeAuto ds = new daWS_FakeAuto();
            DataTable dt = new DataTable();
            dt = ds.DanhSachMailDaXuLy(m_IDTaiKhoan);
            dataGridViewListReup.DataSource = dt;
            dataGridViewListReupMobi.DataSource = dt;
        }
     

        private void btngetlinkkenh_Click(object sender, EventArgs e)
        {
            try
            {
                Thread getlinkkenh = new Thread(() =>
                {
                    ChromePerformanceLoggingPreferences perfLogPrefs = new ChromePerformanceLoggingPreferences();
                    perfLogPrefs.AddTracingCategories(new string[] { "devtools.timeline" });
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--disable-notifications");
                    options.AddArguments("--incognito");
                    options.PerformanceLoggingPreferences = perfLogPrefs;
                    options.SetLoggingPreference(LogType.Driver, LogLevel.All);
                    options.SetLoggingPreference("performance", LogLevel.All);
                    options.AddAdditionalCapability(CapabilityType.EnableProfiling, true, true);
                    PropretiesCollection.driver = new ChromeDriver(options);
                    PropretiesCollection.driver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=youtube&uilel=3&passive=true&continue=https%3A%2F%2Fwww.youtube.com%2Fsignin%3Faction_handle_signin%3Dtrue%26app%3Ddesktop%26hl%3Dvi%26next%3D%252F&hl=vi&ec=65620&flowName=GlifWebSignIn&flowEntry=ServiceLogin");
                    ManagerChannel getlinkenh = new ManagerChannel();
                    txtlinkkenh.Text = getlinkenh.GetLinkChannel(txtmailreup.Text, lblpass.Text, lblmailkhoiphuc.Text);
                    ChomeClose().Wait();
                }
                );
                getlinkkenh.Start();
            }
            catch { }
        }

        private void btngetlistvideo_Click(object sender, EventArgs e)
        {
            if(txtlinkkenhreup.Text==null ||txtlinkkenhreup.Text=="")
            {
                MessageBox.Show("Nhập vào link kênh cần reup");
                return;
            }
            Thread getlist = new Thread(() =>
            {
                ChromePerformanceLoggingPreferences perfLogPrefs = new ChromePerformanceLoggingPreferences();
                perfLogPrefs.AddTracingCategories(new string[] { "devtools.timeline" });
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--disable-notifications");
                options.AddArguments("--incognito"); 
                options.PerformanceLoggingPreferences = perfLogPrefs;
                options.SetLoggingPreference(LogType.Driver, LogLevel.All);
                options.SetLoggingPreference("performance", LogLevel.All);
                options.AddAdditionalCapability(CapabilityType.EnableProfiling, true, true);
                PropretiesCollection.driver = new ChromeDriver(options);
                PropretiesCollection.driver.Navigate().GoToUrl(txtlinkkenhreup.Text+"/videos");
                daWS_FakeAuto getlinkmoinhat = new daWS_FakeAuto();

                ManagerChannel listvideo = new ManagerChannel();
                DataTable dt = new DataTable();
                dt=listvideo.LoadListVideo(getlinkmoinhat.Linkvideomoinhat(int.Parse(lblIDMail.Text)));
                ChomeClose().Wait();
                if(dt.Rows.Count>0)
                {
                    foreach(DataRow r in dt.Rows)
                    {
                        try
                        {
                            string tieude = r["Ten"].ToString();
                            if ((string)this.cmbngonnguthay.SelectedItem != "" && (string)this.cmdngonngugoc.SelectedItem != "" && (string)this.cmdngonngugoc.SelectedItem != (string)this.cmbngonnguthay.SelectedItem)
                            {
                                Translator t = new Translator();
                                tieude = t.Translate(tieude, (string)this.cmdngonngugoc.SelectedItem, (string)this.cmbngonnguthay.SelectedItem);
                                Thread.Sleep(3000);
                            }
                            string link = r["Link"].ToString();
                            daWS_FakeAuto themchitiet = new daWS_FakeAuto();
                            themchitiet.ThemChiTietReup(link, tieude, int.Parse(lblIDMail.Text));
                            lblxuly.Text = "Thêm vào hệ thống video :" + link;
                        }
                        catch { }
                    }
                    lblxuly.Text = "Done";
                }
            }
            );
            getlist.Start();
         }

        private void btngetlist_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            foreach (DataGridViewRow row in dataGridViewListReup.Rows)
            {
                int i = row.Index;
                bool chk = false;
                try
                {
                    chk = bool.Parse(dataGridViewListReup.Rows[i].Cells[0].Value.ToString());
                }
                catch { }
                if (chk == true)
                {
                    int id = int.Parse(dataGridViewListReup.Rows[i].Cells["ID"].Value.ToString());
                    dataGridViewListReup.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    table.Rows.Add(id);
                }

            }
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    int idmail = int.Parse(row["ID"].ToString());
                    DataTable thongtinkenh = new DataTable();
                    daWS_FakeAuto tt = new daWS_FakeAuto();
                    thongtinkenh = tt.ChiTietMail(idmail);
                    DataRow rthongtin = thongtinkenh.Rows[0];
                    string linkkenh = rthongtin["LinkKenh"].ToString();
                    string mail = rthongtin["Mail"].ToString();
                    string pass = rthongtin["Pass"].ToString();
                    string mailkhoiphuc = rthongtin["MailKhoiPhuc"].ToString();

                    FormManageChannel channel = new FormManageChannel(idmail,mail,pass,mailkhoiphuc,linkkenh);
                    channel.Show();


                }
            }
        }
        private void btnsavecauhinhkenh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            daWS_FakeAuto luu = new daWS_FakeAuto();
            int m_ID = int.Parse(lblIDMail.Text);
            string m_LinkKenh = txtlinkkenh.Text;
            string m_LinkKenhReUp = txtlinkkenhreup.Text;
            int m_SoLuongVideoUp =int.Parse(txtsoluongup.Value.ToString());
            string m_NgonNguGoc = "";
            try
            {
                m_NgonNguGoc= (string)this.cmdngonngugoc.SelectedItem;
            }
            catch { }
            string m_NgonNguThay = "";
            try
            {
                m_NgonNguThay= (string)this.cmbngonnguthay.SelectedItem;
            }
            catch { }
            string m_BotTieuDe = txtbottieude.Text;
            string m_ThemTieuDe = txtthemtieude.Text;
            string m_ThemMoTa = txtthemmota.Text;
            string m_ThemTag = txtthemtag.Text;
            luu.CauHinhMail( m_ID,  m_LinkKenh,  m_LinkKenhReUp,
               m_SoLuongVideoUp,  m_NgonNguGoc,  m_NgonNguThay, m_BotTieuDe,
               m_ThemTieuDe,  m_ThemMoTa,  m_ThemTag);
            MessageBox.Show("OK!");
            this.Cursor = Cursors.Default;
        }
        private void dataGridViewListReup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                  
                    string task = dataGridViewListReup.Rows[e.RowIndex].Cells[19].Value.ToString();
                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Bạn có chắc chắm muốn xóa không?", "Đang xóa...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int r = e.RowIndex;
                            int idmail = int.Parse(dataGridViewListReup.Rows[r].Cells["ID"].Value.ToString());
                            daWS_FakeAuto xoa = new daWS_FakeAuto();
                            xoa.XoaMail(idmail);
                        }
                    }
                 
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void dataGridViewListReup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //int lastRow = e.RowIndex;
                //DataGridViewRow nRow = dataGridViewListReup.Rows[lastRow];
                //DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                //dataGridViewListReup[5, lastRow] = linkCell;
                //nRow.Cells["Delete"].Value = "View";

                int r = e.RowIndex;
                lblIDMail.Text = dataGridViewListReup.Rows[r].Cells["ID"].Value.ToString();
                lblpass.Text = dataGridViewListReup.Rows[r].Cells["Pass"].Value.ToString();
                lblmailkhoiphuc.Text = dataGridViewListReup.Rows[r].Cells["MailKhoiPhuc"].Value.ToString();
                txtmailreup.Text = dataGridViewListReup.Rows[r].Cells["Mail"].Value.ToString();
                txtlinkkenh.Text = dataGridViewListReup.Rows[r].Cells["LinkKenh"].Value.ToString();
                txtlinkkenhreup.Text = dataGridViewListReup.Rows[r].Cells["LinkKenhReUp"].Value.ToString();
                try
                {
                    cmdngonngugoc.SelectedItem = dataGridViewListReup.Rows[r].Cells["NgonNguGoc"].Value.ToString();
                }
                catch { }
                try
                {
                    cmbngonnguthay.SelectedItem = dataGridViewListReup.Rows[r].Cells["NgonNguThay"].Value.ToString();
                }
                catch { }
                txtthemtieude.Text = dataGridViewListReup.Rows[r].Cells["ThemTieuDe"].Value.ToString();
                txtbottieude.Text = dataGridViewListReup.Rows[r].Cells["BotTieuDe"].Value.ToString();
                txtthemmota.Text = dataGridViewListReup.Rows[r].Cells["ThemMoTa"].Value.ToString();
                txtthemtag.Text = dataGridViewListReup.Rows[r].Cells["ThemTag"].Value.ToString();
                txtsoluongup.Value = int.Parse(dataGridViewListReup.Rows[r].Cells["SoLuongVideoUp"].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        #region // lấy view và sub
        public DataTable getViewChannel(string m_LinkWeb)
        {
            DataTable Listlink = new DataTable();
            Listlink.Columns.Add("View", typeof(string));
            Listlink.Columns.Add("Sub", typeof(string));
            Listlink.Columns.Add("NgayTao", typeof(string));
            try
            {

                string data = "";
                string page = m_LinkWeb + "/about";
                var request = (HttpWebRequest)WebRequest.Create(page);
                request.Accept = "text/html, application/xhtml+xml, */*";
                request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                            | SecurityProtocolType.Ssl3;
                var response = (HttpWebResponse)request.GetResponse();

                using (Stream dataStream = response.GetResponseStream())
                {
                    if (dataStream == null)
                        data = "";


                    using (var sr = new StreamReader(dataStream))
                    {
                        data = sr.ReadToEnd();
                    }

                }
                if (data != "")
                {
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(data);
                    HtmlNodeCollection tables = doc.DocumentNode.SelectNodes("//div[@class=\"about-stats\"]");
                    if (tables != null)
                    {
                        string ngay = "";
                        string sub = "";
                        string view = "";
                        foreach (HtmlNode node in tables)
                        {
                            string[] kq = node.InnerText.ToString().Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
                            try
                            {
                                view = kq[0].ToString().Replace("&bull;", "").Trim();
                            }
                            catch { }
                            try
                            {
                                ngay = kq[2].ToString().Trim();
                            }
                            catch { }

                        }
                        HtmlNodeCollection tablessub = doc.DocumentNode.SelectNodes("//span[@class=\"yt-subscription-button-subscriber-count-branded-horizontal subscribed yt-uix-tooltip\"]");
                        if (tablessub != null)
                        {
                            foreach (HtmlNode node in tablessub)
                            {
                                sub = node.InnerText.ToString();
                            }
                        }

                        Listlink.Rows.Add(view, sub, ngay);
                    }
                }
            }

            catch (Exception ex) { }

            return Listlink;
        }
        #endregion
        private void btnrefeshview_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable dt = new DataTable();
            dt = (DataTable)dataGridViewListReup.DataSource;
            if(dt.Rows.Count>0)
            {
                Task get = new Task(()=> {
                    foreach (DataRow r in dt.Rows)
                    {
                        int idkenh = int.Parse(r["ID"].ToString());
                        string linkkenh = r["LinkKenh"].ToString();
                        string mail = r["Mail"].ToString();
                        string stt = r["STT"].ToString();
                        lblxuly.Text = "Đang lấy thông tin kênh của mail :"+mail+" STT:"+stt;
                        if (linkkenh != "")
                        {
                            DataTable table = new DataTable();
                            table = getViewChannel(linkkenh);
                            if (table.Rows.Count > 0)
                            {
                                DataRow row = table.Rows[0];
                                daWS_FakeAuto suaview = new daWS_FakeAuto();
                                suaview.UpdateView(idkenh, row["View"].ToString().Replace("lượt xem", "").Replace(".",""), row["Sub"].ToString(), row["NgayTao"].ToString(), false);
                                Thread.Sleep(2000);
                            }
                        }
                    }
                });
                get.Start();
            }
            loadmaildaxuly();
            this.Cursor = Cursors.Default;
        }
        private string chuyenmp4touotput(string path, string pathoutput)
        {
            string namefile = "";
            string[] fileList = System.IO.Directory.GetFiles(path);
            //duyệt từng file và copy đè lên file cũ trong thư mục đang chạy chương trình
            foreach (string sourceFile in fileList)
            {
                //tách tên file ra khỏi đường dẫn (tên file sẽ dùng để tạo đường dẫn đích cần copy đè)
                string fileName = System.IO.Path.GetFileName(sourceFile);
                //tạo đường dẫn đích để copy file mới tới
                if (fileName.IndexOf(".mp4") != -1|| fileName.IndexOf(".mkv") != -1|| fileName.IndexOf(".avi") != -1|| fileName.IndexOf(".webm") != -1)
                {
                    namefile = fileName;
                    string destinationFile = path + @"\" + fileName;
                    pathoutput= pathoutput + @"\" + fileName;
                    // thực hiện copy
                    System.IO.File.Copy(destinationFile, pathoutput, true);
                    //thực hiện xóa file
                    System.IO.File.Delete(destinationFile);

                }

            }
            return namefile;
        }
        private int kiemtratontaimp4(string path)
        {
            int namefile = 0;
            string[] fileList = System.IO.Directory.GetFiles(path);
            //duyệt từng file và copy đè lên file cũ trong thư mục đang chạy chương trình
            foreach (string sourceFile in fileList)
            {
                //tách tên file ra khỏi đường dẫn (tên file sẽ dùng để tạo đường dẫn đích cần copy đè)
                string fileName = System.IO.Path.GetFileName(sourceFile);
                //tạo đường dẫn đích để copy file mới tới
                if (fileName.IndexOf(".mp4") != -1)
                {
                    namefile = 1;                  

                }
                if (fileName.IndexOf(".webm") != -1)
                {
                    namefile = 1;

                }
                if (fileName.IndexOf(".avi") != -1)
                {
                    namefile = 1;

                }
                if (fileName.IndexOf(".mkv") != -1)
                {
                    namefile = 1;

                }

            }
            return namefile;
        }
        private void DoiTenFileMp4(string path, string pathoutput)
        {
          
            string[] fileList = System.IO.Directory.GetFiles(path);
            //duyệt từng file và copy đè lên file cũ trong thư mục đang chạy chương trình
            foreach (string sourceFile in fileList)
            {
                //tách tên file ra khỏi đường dẫn (tên file sẽ dùng để tạo đường dẫn đích cần copy đè)
                string fileName = System.IO.Path.GetFileName(sourceFile);
                //tạo đường dẫn đích để copy file mới tới
                if (fileName.IndexOf(".mp4") != -1 || fileName.IndexOf(".mkv") != -1 || fileName.IndexOf(".avi") != -1 || fileName.IndexOf(".webm") != -1)
                {

                    string destinationFile = path + @"\" + fileName;                 
                    // thực hiện copy
                    System.IO.File.Copy(destinationFile, pathoutput, true);
                    //thực hiện xóa file
                    System.IO.File.Delete(destinationFile);

                }

            }
          
        }
        private void XoaFileMp4(string pathoutput)
        {

            string[] fileList = System.IO.Directory.GetFiles(pathoutput);
            //duyệt từng file và copy đè lên file cũ trong thư mục đang chạy chương trình
            foreach (string sourceFile in fileList)
            {
                //tách tên file ra khỏi đường dẫn (tên file sẽ dùng để tạo đường dẫn đích cần copy đè)
                string fileName = System.IO.Path.GetFileName(sourceFile);
                //tạo đường dẫn đích để copy file mới tới
                if (fileName.IndexOf(".mp4") != -1 || fileName.IndexOf(".mkv") != -1 || fileName.IndexOf(".avi") != -1 || fileName.IndexOf(".webm") != -1)
                {
                    string destinationFile = pathoutput + @"\" + fileName;                   
                    System.IO.File.Delete(destinationFile);

                }

            }

        }
        private void btnbeginreup_Click(object sender, EventArgs e)
        {

            if (!bgwreup.IsBusy)
            {               
                bgwreup.RunWorkerAsync();

            }


        }

        private void bgwreup_DoWork(object sender, DoWorkEventArgs e)
        {
        DataTable table = new DataTable();
        table.Columns.Add("ID", typeof(int));
        foreach (DataGridViewRow row in dataGridViewListReup.Rows)
        {
            int i = row.Index;
            bool chk = false;
            try
            {
                chk = bool.Parse(dataGridViewListReup.Rows[i].Cells[0].Value.ToString());
            }
            catch { }
            if (chk == true)
            {
                int id = int.Parse(dataGridViewListReup.Rows[i].Cells["ID"].Value.ToString());
                dataGridViewListReup.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                table.Rows.Add(id);
            }

        }
        if (table.Rows.Count > 0)
        {

            foreach (DataRow row in table.Rows)
            {
                int idmail = int.Parse(row["ID"].ToString());
                DataTable thongtinkenh = new DataTable();
                daWS_FakeAuto tt = new daWS_FakeAuto();
                thongtinkenh = tt.ChiTietMail(idmail);
                DataRow rthongtin = thongtinkenh.Rows[0];
                string linkkenhreup = rthongtin["LinkKenhReUp"].ToString();
                string ngonngugoc = rthongtin["NgonNguGoc"].ToString();
                string ngonnguthay = rthongtin["NgonNguThay"].ToString();
                string mail = rthongtin["Mail"].ToString();
                string pass = rthongtin["Pass"].ToString();
                string mailkhoiphuc = rthongtin["MailKhoiPhuc"].ToString();
                string themtieude = rthongtin["ThemTieuDe"].ToString();
                string bottieude = rthongtin["BotTieuDe"].ToString();
                string themmota = rthongtin["ThemMoTa"].ToString();
                string themtag = rthongtin["ThemTag"].ToString();
                int soluongup = int.Parse(rthongtin["SoLuongVideoUp"].ToString());

                #region // load video mới nhất từ kênh reup
                if (checkloadvideomoi.Checked == true)
                {
                    ChromePerformanceLoggingPreferences perfLogPrefs = new ChromePerformanceLoggingPreferences();
                    perfLogPrefs.AddTracingCategories(new string[] { "devtools.timeline" });
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--disable-notifications");
                    options.AddArguments("--incognito");
                    options.AddArguments("--disable-blink-fratures=AutomationControlled");
                    options.PerformanceLoggingPreferences = perfLogPrefs;
                    options.SetLoggingPreference(LogType.Driver, LogLevel.All);
                    options.SetLoggingPreference("performance", LogLevel.All);
                    options.AddAdditionalCapability(CapabilityType.EnableProfiling, true, true);
                    PropretiesCollection.driver = new ChromeDriver(options);
                    PropretiesCollection.driver.Navigate().GoToUrl(linkkenhreup + "/videos");
                    daWS_FakeAuto getlinkmoinhat = new daWS_FakeAuto();

                    ManagerChannel listvideo = new ManagerChannel();
                    DataTable dt = new DataTable();
                    dt = listvideo.LoadListVideo(getlinkmoinhat.Linkvideomoinhat(idmail));
                    ChomeClose().Wait();
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow r in dt.Rows)
                        {
                            try
                            {
                                string tieude = r["Ten"].ToString();
                                if (ngonngugoc != "" && ngonnguthay != "" && ngonngugoc != ngonnguthay)
                                {
                                    Translator t = new Translator();
                                    tieude = t.Translate(tieude, ngonngugoc, ngonnguthay);
                                    Thread.Sleep(3000);
                                }
                                string link = r["Link"].ToString();
                                daWS_FakeAuto themchitiet = new daWS_FakeAuto();
                                themchitiet.ThemChiTietReup(link, tieude, idmail);
                                lblxuly.Text = "Thêm vào hệ thống video :" + link;
                            }
                            catch { }
                        }
                    }
                }
                #endregion



                #region // xử lý down video về
                // lấy list video chưa up theo kênh
                DataTable listlinkvideo = new DataTable();
                daWS_FakeAuto vids = new daWS_FakeAuto();
                listlinkvideo = vids.DanhSachVideoChuaReup(idmail);
                if (listlinkvideo.Rows.Count > 0)
                {
                    int k = 1;
                    int max = listlinkvideo.Rows.Count;
                    foreach (DataRow rvids in listlinkvideo.Rows)
                    {

                            if (k <= soluongup)
                            {
                                ChomeClose().Wait();
                                try
                                {
                                    #region // thuc hien xoa fordel luu tru video
                                    XoaFileMp4(txtfoldervideo.Text);
                                    #endregion
                                    lblxuly.Text = "Xu ly:" + k.ToString()+"/"+max.ToString();
                                    int idvideo = int.Parse(rvids["ID"].ToString());
                                    string linkvideo = rvids["Link"].ToString();
                                    string tieude = rvids["TieuDe"].ToString();
                                    string idlinkvideo = linkvideo.Replace("https://www.youtube.com/watch?v=", "");
                                    #region // thực hiện xác nhận đã reup
                                    daWS_FakeAuto xacnhan = new daWS_FakeAuto();
                                    xacnhan.UpdateDaReup(idvideo);
                                    #endregion

                                    #region // thực hiện chạy download
                                    
                                    if (checkYoutubeExplode.Checked== true)
                                    {
                                        try
                                        {
                                            var client = new YoutubeClient();
                                            var streamInfoSet = client.GetVideoMediaStreamInfosAsync(idlinkvideo).Result;
                                            var streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();
                                            var video = client.GetVideoAsync(idlinkvideo).Result;                                           
                                            var ext = streamInfo.Container.GetFileExtension();
                                            client.DownloadMediaStreamAsync(streamInfo, $"{video.Title}.{ext}").Wait();
                                            
                                        }
                                        catch 
                                        {
                                           
                                        }
                                    }
                                    else
                                    {
                                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                                        startInfo.FileName = @"youtube-dl.exe";
                                        startInfo.Arguments = linkvideo;
                                        process.StartInfo = startInfo;
                                        process.Start();
                                    }
                                    Thread.Sleep(3000);
                                    
                                    #endregion
                                    int kiemtra = 0;
                                    switch (kiemtra)
                                    {
                                        case 0:
                                            if(checkYoutubeExplode.Checked==true)
                                            {
                                                goto case 1;
                                            }
                                            System.Threading.Thread.Sleep(6000);
                                            goto case 1;
                                            break;
                                        case 1:
                                            try
                                            {


                                                int xuly = kiemtratontaimp4(Application.StartupPath);
                                                if (xuly == 1)
                                                {
                                                    #region // thực hiện copy file download sang forder upload
                                                    tieude = chuyenmp4touotput(Application.StartupPath, txtfoldervideo.Text).Replace("-" + idlinkvideo, "").Replace(".mp4", "").Replace(".mkv","").Replace(".avi","").Replace(".webm","");
                                                    lblxuly.Text = "Đã down load xong video" + tieude.ToString();
                                                    string dich = "";
                                                    try
                                                    {
                                                        Translator t = new Translator();
                                                        dich = t.Translate(tieude.Trim(), ngonngugoc, ngonnguthay);
                                                    }
                                                    catch { }
                                                    Thread.Sleep(5000);
                                                    if (dich != "")
                                                    {
                                                        tieude = dich;
                                                    }
                                                    #endregion
                                                    DoiTenFileMp4(txtfoldervideo.Text, txtfoldervideo.Text + @"\" + tieude + ".mp4");
                                                    string _path = txtfoldervideo.Text + @"\" + tieude + ".mp4";

                                                    #region // xử lý gắn claim ID
                                                    if (checkaddclaim.Checked == true)
                                                    {
                                                        var files = new DirectoryInfo(txtbgaudio.Text).GetFiles();
                                                        int index = new Random().Next(0, files.Length);
                                                        string mp3bg = txtbgaudio.Text + @"\" + files[index].Name;
                                                        string audiobg = Application.StartupPath + @"\Temp\bg.mp3";
                                                        try
                                                        {
                                                            File.Delete(audiobg);
                                                        }
                                                        catch { }
                                                        System.IO.File.Copy(mp3bg, audiobg, true);
                                                        string pathvidsin= txtfoldervideo.Text + @"\1.mp4";
                                                        string pathvidsout = txtfoldervideo.Text + @"\1out.mp4";
                                                        System.IO.File.Copy(_path, pathvidsin, true);
                                                        try
                                                        {
                                                            File.Delete(_path);
                                                        }
                                                        catch { }
                                                        RunFFMPEG ffrunaddclaim = new RunFFMPEG();
                                                        string addclaim = string.Format(@"-i {0} -i {1} -filter_complex ""[0:a][1:a]amerge,pan=stereo|c0<c0+c2|c1<c1+c3[out]"" -map 1:v -map ""[out]"" -c:v copy -shortest {2}", audiobg, pathvidsin,pathvidsout);
                                                        ffrunaddclaim.RunCommand(addclaim, false);
                                                        System.IO.File.Copy(pathvidsout, _path, true);
                                                    }
                                                    else
                                                    {
                                                        string pathvidsin = txtfoldervideo.Text + @"\1.mp4";
                                                        System.IO.File.Copy(_path, pathvidsin, true);
                                                        _path = pathvidsin;
                                                    }
                                                    #endregion

                                                    Proshow gettime = new Proshow();
                                                    double time = 0;
                                                    time =(double) gettime.getDuration(_path).Result;
                                                    if (time != 0)
                                                    {
                                                        #region // thực hiện upload lên youtube
                                                        //try
                                                        //{
                                                            if (checkdefaultchome.Checked == true)
                                                            {
                                                                ChromeOptions options = new ChromeOptions();
                                                                options.AddArguments("user-data-dir=C:/Users/" + Environment.GetEnvironmentVariable("UserName") + "/AppData/Local/Google/Chrome/User Data");
                                                                options.AddArguments("--start-maximized");
                                                                options.AddArgument("--disable-blink-features=AutomationControlled");
                                                                ChromeDriverService service = ChromeDriverService.CreateDefaultService();
                                                                service.HideCommandPromptWindow = false;
                                                                PropretiesCollection.driver = new ChromeDriver(service, options);
                                                                PropretiesCollection.driver.Navigate().GoToUrl("https://www.youtube.com/upload?redirect_to_classic=true");

                                                            }
                                                           else  if (radiochome.Checked == true)
                                                            {                                                               
                                                               
                                                                    string profile_add = "Profile";
                                                                    string profile_new = "Profile\\" + mail.ToString();
                                                                    ChromePerformanceLoggingPreferences perfLogPrefs = new ChromePerformanceLoggingPreferences();
                                                                    perfLogPrefs.AddTracingCategories(new string[] { "devtools.timeline" });
                                                                    ChromeOptions options = new ChromeOptions();
                                                                    if (checkcreateprofire.Checked == true)
                                                                    {
                                                                        if (!Directory.Exists(profile_add)) { Directory.CreateDirectory(profile_add); }
                                                                        options.AddArgument("user-data-dir=" + Application.StartupPath + "\\" + profile_new);
                                                                    }
                                                                    options.AddArguments("--disable-notifications");
                                                                    options.AddArguments("--incognito");
                                                                    options.AddArgument("--disable-blink-features=AutomationControlled");
                                                                    options.PerformanceLoggingPreferences = perfLogPrefs;
                                                                    options.SetLoggingPreference(LogType.Driver, LogLevel.All);
                                                                    options.SetLoggingPreference("performance", LogLevel.All);
                                                                    options.AddAdditionalCapability(CapabilityType.EnableProfiling, true, true);
                                                                    PropretiesCollection.driver = new ChromeDriver(options);
                                                                   PropretiesCollection.driver.Navigate().GoToUrl("https://www.youtube.com/upload?redirect_to_classic=true");


                                                            }
                                                            else if (radiofirefox.Checked == true)
                                                            {
                                                                String torBinaryPath = @"D:\Tor\Tor Browser\Browser\firefox.exe";
                                                                Process TorProcess = new Process();
                                                                TorProcess.StartInfo.FileName = torBinaryPath;
                                                                TorProcess.StartInfo.Arguments = "-n";
                                                                TorProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                                                                TorProcess.Start();
                                                                FirefoxOptions optionsfire = new FirefoxOptions();
                                                                optionsfire.SetPreference("network.proxy.type", 1);
                                                                optionsfire.SetPreference("network.proxy.socks", "127.0.0.1");
                                                                optionsfire.SetPreference("network.proxy.socks_port", 9150);
                                                                //optionsfire.SetPreference("webdriver.firefox.profile", "default");
                                                                PropretiesCollection.driver = new FirefoxDriver(optionsfire);
                                                               PropretiesCollection.driver.Navigate().GoToUrl("https://www.youtube.com/upload?redirect_to_classic=true");
                                                            }
                                                            else { }
                                                            /*PropretiesCollection.driver.Navigate().GoToUrl("https://www.youtube.com/upload?redirect_to_classic=true")*/;
                                                            UploadYoutube ytb = new UploadYoutube();
                                                            if (checkdefaultchome.Checked == true)
                                                            {
                                                                #region desc
                                                                string _desc = "";
                                                                string mota = tieude + "\r\n" + themmota + "\r\n";
                                                                if (mota.Length > 200) { _desc = chuanHoa(mota.Substring(0, 200)); }
                                                                else { _desc = chuanHoa(mota); }
                                                                #endregion
                                                                #region // title
                                                                string _title = tieude;

                                                                if (_title.Length > 98)
                                                                {
                                                                    _title = (_title.Substring(0, 98));
                                                                }
                                                                if (bottieude != "")
                                                                {
                                                                    _title = _title.Replace(bottieude, "");
                                                                }
                                                                if (themtieude != "")
                                                                {
                                                                    _title = _title + "|" + themtieude;
                                                                }
                                                                if (_title == "")
                                                                {
                                                                    _title = tieude;
                                                                }
                                                                string _tag = tieude;
                                                                if (themtag != "")
                                                                {
                                                                    _tag = _tag + "," + themtag;
                                                                }
                                                                #endregion

                                                            #region // upload chome
                                                            try
                                                            {
                                                                int bkt = 0;
                                                                if (checksetmotizeion.Checked == true)
                                                                {
                                                                    bkt = 1;
                                                                }
                                                                bool m_private = false;
                                                                if (checkprivate.Checked == true)
                                                                {
                                                                    m_private = true;
                                                                }
                                                                ytb.UploadFroFileBeta(_path, _title, _desc.Replace("<", "").Replace(">", ""), _tag, "", bkt, m_private).Wait();
                                                            }
                                                            catch { }


                                                                    #endregion
                                                            }
                                                            else if(checkdefaultchome.Checked == false)
                                                            {
                                                                ytb.LoginAnDanh(mail, pass, mailkhoiphuc, _path).Wait();
                                                                #region desc
                                                                string _desc = "";
                                                                string mota = tieude + "\r\n" + themmota + "\r\n";
                                                                if (mota.Length > 200) { _desc = chuanHoa(mota.Substring(0, 200)); }
                                                                else { _desc = chuanHoa(mota); }
                                                                #endregion
                                                                #region // title
                                                                string _title = tieude;

                                                                if (_title.Length > 100)
                                                                {
                                                                    _title = (_title.Substring(0, 100));
                                                                }
                                                                if (bottieude != "")
                                                                {
                                                                    _title = _title.Replace(bottieude, "");
                                                                }
                                                                if (themtieude != "")
                                                                {
                                                                    _title = _title + "|" + themtieude;
                                                                }
                                                                if (_title == "")
                                                                {
                                                                    _title = tieude;
                                                                }
                                                                string _tag = tieude;
                                                                if (themtag != "")
                                                                {
                                                                    _tag = _tag + "," + themtag;
                                                                }
                                                                #endregion

                                                                if (raduploadchomebeta.Checked == true)
                                                                {
                                                                    #region // upload chome

                                                                  
                                                                        int bkt = 0;
                                                                        if (checksetmotizeion.Checked == true)
                                                                        {
                                                                            bkt = 1;
                                                                        }
                                                                        bool m_private = false;
                                                                        if (checkprivate.Checked == true)
                                                                        {
                                                                            m_private = true;
                                                                        }
                                                                        ytb.UploadFroFileBeta(_path, _title, _desc.Replace("<", "").Replace(">", ""), _tag, "", bkt, m_private).Wait();
                                                                   


                                                                    #endregion
                                                                }
                                                                else
                                                                {
                                                                    ytb.Upload(_title, _desc, _tag, "", 0).Wait();
                                                                }
                                                            }
                                                            #region // thực hiện xác nhận đã reup
                                                            daWS_FakeAuto xacnhan1 = new daWS_FakeAuto();
                                                            xacnhan1.UpdateDaReup(idvideo);
                                                            #endregion
                                                        //}
                                                        //catch {
                                                         ChomeClose().Wait();
                                                       //}
                                                        #endregion
                                                    }
                                                

                                                    #region // thuc hien xoa fordel luu tru video
                                                    XoaFileMp4(txtfoldervideo.Text);
                                                    ChomeClose().Wait();
                                                    #endregion
                                                }
                                                else
                                                {
                                                    goto case 0;
                                                }
                                            }
                                            catch { goto case 0; }
                                            break;

                                    }
                                }
                                catch { }

                        }
                        k = k + 1;
                    }

                }


                #endregion


            }
            }
            else
            {
                MessageBox.Show("Hãy chọn kênh cần reup", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void bgwreup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
            }
            else
            {   lblxuly.Text = "Complete!";
            }
        }


        #endregion

        #region // path tor 
        private void btnpathtor_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = false;
            dlg.CheckPathExists = false;
            dlg.Multiselect = false;
            dlg.Filter = "Files(*.exe)|*.exe";
            dlg.Multiselect = true;
            dlg.SupportMultiDottedExtensions = true;
            dlg.Title = "Select intro file Tor";  
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //Settings.Default.LastUsedFolder = Path.GetDirectoryName(dlg.FileNames[0]);
                txtpathtor.Text = dlg.FileName;
                ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
                exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
                //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
                cf.AppSettings.Settings.Remove("TorPath");
                cf.AppSettings.Settings.Add("TorPath", txtpathtor.Text);
                cf.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        private void btnstartview_Click(object sender, EventArgs e)
        {
            try
            {

                if (!bgwchayview.IsBusy)
                {
                    timerchayview.Enabled = false;
                    timerchayview.Stop();
                    bgwchayview.RunWorkerAsync();

                }
            }
            catch
            {
                lblxuly.Text = string.Empty;
                timerchayview.Enabled = true;
                timerchayview.Interval = 10000;
                timerchayview.Start();
            }
         
        }
        private void bgwchayview_DoWork(object sender, DoWorkEventArgs e)
        {
            bool flat = false;
            for (int i = 1; i <= int.Parse(txtnumberthread.Value.ToString()); i++)
            {
                Task startI = new Task(() =>
                {
                    switch (flat)
                    {
                        case true:
                            System.Threading.Thread.Sleep(5000);
                            goto case false;
                            break;
                        case false:
                            try
                            {
                                if (flat == false)
                                {
                                    flat = true;
                                    String torBinaryPath = @"D:\Tor\Tor Browser\Browser\firefox.exe";
                                    Process TorProcess = new Process();
                                    TorProcess.StartInfo.FileName = torBinaryPath;
                                    TorProcess.StartInfo.Arguments = "-n";
                                    TorProcess.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                                    TorProcess.Start();
                                    FirefoxOptions options = new FirefoxOptions();
                                    options.SetPreference("network.proxy.type", 1);
                                    options.SetPreference("network.proxy.socks", "127.0.0.1");
                                    options.SetPreference("network.proxy.socks_port", 9150);
                                    options.SetPreference("webdriver.firefox.profile", "default");
                                    FirefoxDriver _Driver = new FirefoxDriver(options);
                                    _Driver.Navigate().GoToUrl(txtlink.Text);

                                    IWebElement video = _Driver.FindElement(By.CssSelector("#movie_player"));
                                    int kiemtra = 0;
                                    switch (kiemtra)
                                    {
                                        case 0:
                                            System.Threading.Thread.Sleep(2000);
                                            goto case 1;
                                            break;
                                        case 1:
                                            try
                                            {
                                                video.Click();

                                            }
                                            catch { goto case 0; }
                                            break;

                                    }
                                    try
                                    {
                                        TorProcess.Kill();
                                        flat = false;
                                        TorProcess.Close();
                                        TorProcess.Dispose();
                                    }
                                    catch { }


                                    Thread.Sleep(int.Parse(txttimeview.Value.ToString()) * 60 * 60 * 1000);

                                    _Driver.Close();
                                    _Driver.Dispose();
                                }

                            }
                            catch { goto case true; }
                            break;

                    }

                   
                });
                startI.Start();
                Thread.Sleep(60000);

            }

        }

        private void bgwchayview_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
            }
            else
            {
                if (!bgwchayview.IsBusy)
                {

                    prs.Value = 0;
                    lblxuly.Text = "Complete!";                  
                    Thread.Sleep(10000);
                    timerchayview.Enabled = true;
                    timerchayview.Start();
                }
            }
        }

        private void timerchayview_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!bgwchayview.IsBusy)
                {
                    bgwchayview.RunWorkerAsync();
                    timerrendermulti.Enabled = false;
                    timerrendermulti.Stop();
                }

            }
            catch
            {
                timerchayview.Enabled = true;
                timerchayview.Interval = 10000;
                timerchayview.Start();
            }
        }




        #endregion

        #region // reup floder
        private void btnreupfolder_Click(object sender, EventArgs e)
        {
            if (!bgwreupfolder.IsBusy)
            {
                bgwreupfolder.RunWorkerAsync();
            }

        }

        private void bgwreupfolder_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bgwreupfolder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
            }
            else
            {
                lblxuly.Text = "Complete!";
            }
        }
        #endregion

        #region // run sub
        private void btnrunsub_Click(object sender, EventArgs e)
        {
            if (!bgwsub.IsBusy)
            {
                bgwsub.RunWorkerAsync();

            }
        }
        private void bgwsub_DoWork(object sender, DoWorkEventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            foreach (DataGridViewRow row in dataGridViewListReup.Rows)
            {
                int i = row.Index;
                bool chk = false;
                try
                {
                    chk = bool.Parse(dataGridViewListReup.Rows[i].Cells[0].Value.ToString());
                }
                catch { }
                if (chk == true)
                {
                    int id = int.Parse(dataGridViewListReup.Rows[i].Cells["ID"].Value.ToString());
                    dataGridViewListReup.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    table.Rows.Add(id);
                }

            }
            if (table.Rows.Count > 0)
            {

                #region //chay sub
                foreach (DataRow row in table.Rows)
                {
                    int idmail = int.Parse(row["ID"].ToString());
                    DataTable thongtinkenh = new DataTable();
                    daWS_FakeAuto tt = new daWS_FakeAuto();
                    thongtinkenh = tt.ChiTietMail(idmail);
                    DataRow rthongtin = thongtinkenh.Rows[0];
                    string linkkenhreup = rthongtin["LinkKenhReUp"].ToString();
                    string ngonngugoc = rthongtin["NgonNguGoc"].ToString();
                    string ngonnguthay = rthongtin["NgonNguThay"].ToString();
                    string mail = rthongtin["Mail"].ToString();
                    string pass = rthongtin["Pass"].ToString();
                    string mailkhoiphuc = rthongtin["MailKhoiPhuc"].ToString();
                    string themtieude = rthongtin["ThemTieuDe"].ToString();
                    string bottieude = rthongtin["BotTieuDe"].ToString();
                    string themmota = rthongtin["ThemMoTa"].ToString();
                    string themtag = rthongtin["ThemTag"].ToString();
                    int soluongup = int.Parse(rthongtin["SoLuongVideoUp"].ToString());
                    try
                    {
                        string profile_add = "Profile";
                        string profile_new = "Profile\\" + mail.ToString();
                        ChromePerformanceLoggingPreferences perfLogPrefs = new ChromePerformanceLoggingPreferences();
                        perfLogPrefs.AddTracingCategories(new string[] { "devtools.timeline" });
                        ChromeOptions options = new ChromeOptions();
                        if (checkcreateprofire.Checked == true)
                        {
                            if (!Directory.Exists(profile_add)) { Directory.CreateDirectory(profile_add); }
                            options.AddArgument("user-data-dir=" + Application.StartupPath + "\\" + profile_new);
                        }
                        options.AddArguments("--disable-notifications");
                        options.AddArguments("--incognito");
                        options.PerformanceLoggingPreferences = perfLogPrefs;
                        options.SetLoggingPreference(LogType.Driver, LogLevel.All);
                        options.SetLoggingPreference("performance", LogLevel.All);
                        options.AddAdditionalCapability(CapabilityType.EnableProfiling, true, true);
                        PropretiesCollection.driver = new ChromeDriver(options);
                        PropretiesCollection.driver.Navigate().GoToUrl(txtadddesc.Text);
                        ManagerChannel sub = new ManagerChannel();
                        sub.SUB(mail,pass,mailkhoiphuc);
                        Thread.Sleep(2000);
                        ChomeClose().Wait();
                    }
                    catch { ChomeClose().Wait(); }
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Hãy chọn kênh cần sub", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
         }
        private void bgwsub_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
            }
            else
            {
                lblxuly.Text = "Complete!";
            }
        }

        #endregion


        #region // mobile
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);
        [DllImport("user32.dll")]
        public static extern long SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);
        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 0x10000000;


        private void buttontaoemulator_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            foreach (DataGridViewRow row in dataGridViewListReupMobi.Rows)
            {
                int i = row.Index;
                bool chk = false;
                try
                {
                    chk = bool.Parse(dataGridViewListReupMobi.Rows[i].Cells[0].Value.ToString());
                }
                catch { }
                if (chk == true)
                {
                    int id = int.Parse(dataGridViewListReupMobi.Rows[i].Cells["ID"].Value.ToString());
                    dataGridViewListReupMobi.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    table.Rows.Add(id);
                }

            }
            if (table.Rows.Count > 0)
            {

                #region //chay tạo emulator
                foreach (DataRow row in table.Rows)
                {
                    int idmail = int.Parse(row["ID"].ToString());
                    DataTable thongtinkenh = new DataTable();
                    daWS_FakeAuto tt = new daWS_FakeAuto();
                    thongtinkenh = tt.ChiTietMail(idmail);
                    DataRow rthongtin = thongtinkenh.Rows[0];
                    string linkkenhreup = rthongtin["LinkKenhReUp"].ToString();
                    string ngonngugoc = rthongtin["NgonNguGoc"].ToString();
                    string ngonnguthay = rthongtin["NgonNguThay"].ToString();
                    string mail = rthongtin["Mail"].ToString();
                    string pass = rthongtin["Pass"].ToString();
                    string mailkhoiphuc = rthongtin["MailKhoiPhuc"].ToString();
                    string themtieude = rthongtin["ThemTieuDe"].ToString();
                    string bottieude = rthongtin["BotTieuDe"].ToString();
                    string themmota = rthongtin["ThemMoTa"].ToString();
                    string themtag = rthongtin["ThemTag"].ToString();
                    int soluongup = int.Parse(rthongtin["SoLuongVideoUp"].ToString());
                    try
                    {
                        Process p = new Process();
                        p.StartInfo.FileName =txtpathldplayer.Text;
                        p.StartInfo.Arguments = "index ="+ idmail.ToString();
                        p.Start();
                        Thread.Sleep(2000);
                        p.WaitForInputIdle();
                        SetParent(p.MainWindowHandle, this.panelmobile.Handle);
                        SetWindowLong(p.MainWindowHandle, GWL_STYLE, WS_VISIBLE);
                        MoveWindow(p.MainWindowHandle, 0, -35, 367, 654, true);
                        Thread.Sleep(2000);


                    }
                    catch { }
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Hãy chọn kênh cần tạo emulator", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #region // config mobile
        public DataTable DerializeDataTable(string json)
        {
            DataTable dt = (DataTable)JsonConvert.DeserializeObject("[" + json + "]", (typeof(DataTable)));
            return dt;
        }

       static public void CopyFolder(string sourceFolder, string destFolder)

        {
            if (!Directory.Exists(destFolder))

                Directory.CreateDirectory(destFolder);

            string[] files = Directory.GetFiles(sourceFolder);

            foreach (string file in files)

            {

                string name = Path.GetFileName(file);

                string dest = Path.Combine(destFolder, name);

                File.Copy(file, dest);

            }

            string[] folders = Directory.GetDirectories(sourceFolder);

            foreach (string folder in folders)

            {

                string name = Path.GetFileName(folder);

                string dest = Path.Combine(destFolder, name);

                CopyFolder(folder, dest);

            }

        }

    
        private void btnrandomconfig_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            foreach (DataGridViewRow row in dataGridViewListReupMobi.Rows)
            {
                int i = row.Index;
                bool chk = false;
                try
                {
                    chk = bool.Parse(dataGridViewListReupMobi.Rows[i].Cells[0].Value.ToString());
                }
                catch { }
                if (chk == true)
                {
                    int id = int.Parse(dataGridViewListReupMobi.Rows[i].Cells["ID"].Value.ToString());
                    dataGridViewListReupMobi.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    table.Rows.Add(id);
                }

            }
            if (table.Rows.Count > 0)
            {

                #region //copy template
                foreach (DataRow row in table.Rows)
                {
                    int idmail = int.Parse(row["ID"].ToString());
                    DataTable thongtinkenh = new DataTable();
                    daWS_FakeAuto tt = new daWS_FakeAuto();
                    thongtinkenh = tt.ChiTietMail(idmail);
                    DataRow rthongtin = thongtinkenh.Rows[0];
                    string linkkenhreup = rthongtin["LinkKenhReUp"].ToString();
                    string ngonngugoc = rthongtin["NgonNguGoc"].ToString();
                    string ngonnguthay = rthongtin["NgonNguThay"].ToString();
                    string mail = rthongtin["Mail"].ToString();
                    string pass = rthongtin["Pass"].ToString();
                    string mailkhoiphuc = rthongtin["MailKhoiPhuc"].ToString();
                    string themtieude = rthongtin["ThemTieuDe"].ToString();
                    string bottieude = rthongtin["BotTieuDe"].ToString();
                    string themmota = rthongtin["ThemMoTa"].ToString();
                    string themtag = rthongtin["ThemTag"].ToString();
                    int soluongup = int.Parse(rthongtin["SoLuongVideoUp"].ToString());
                    try
                    {
                        #region // trước khi đọc file tắt hết ứng dụng 
                        try
                        {
                            foreach (Process proc in Process.GetProcessesByName("dnplayer"))
                            {
                                proc.Kill();
                            }
                        }
                        catch { }
                        #endregion
                        
                        #region đọc các file config random của hệ thống
                        string path = txtpathldplayer.Text.Replace("dnplayer.exe", "");
                        string pathconfig = path + @"vms\config\leidian" + idmail.ToString() + ".config";
                        //string textconfig = File.ReadAllText(pathconfig);
                        //DataTable dt = new DataTable();
                        //dt = DerializeDataTable(textconfig);
                        //DataRow r = dt.Rows[0];
                        //string _phoneIMEI = r["propertySettings.phoneIMEI"].ToString();
                        //string _phoneIMSI = r["propertySettings.phoneIMSI"].ToString();
                        //string _phoneSimSerial = r["propertySettings.phoneSimSerial"].ToString();
                        //string _phoneAndroidId = r["propertySettings.phoneAndroidId"].ToString();
                        //string _phoneModel = r["propertySettings.phoneModel"].ToString();
                        //string _phoneManufacturer = r["propertySettings.phoneManufacturer"].ToString();
                        //string _macAddress = r["propertySettings.macAddress"].ToString();
                        //string _playerName = mail;
                        #endregion
                        #region // đọc dữ liệu template config
                      
                        string pathtemplate = Application.StartupPath + @"\TemplateEmulator\leidian0.config";
                        string texttemplate = File.ReadAllText(pathtemplate);

                        //string _phoneIMEIConfig = curl.cull(texttemplate,"\"propertySettings.phoneIMEI\": \"","\",");
                        //string _phoneIMSIConfig = curl.cull(texttemplate, "\"propertySettings.phoneIMSI\": \"", "\",");
                        //string _phoneSimSerialConfig = curl.cull(texttemplate, "\"propertySettings.phoneSimSerial\": \"", "\",");
                        //string _phoneAndroidIdConfig = curl.cull(texttemplate, "\"propertySettings.phoneAndroidId\": \"", "\",");
                        //string _phoneModelConfig = curl.cull(texttemplate, "\"propertySettings.phoneModel\": \"", "\",");
                        //string _phoneManufacturerConfig = curl.cull(texttemplate, "\"propertySettings.phoneManufacturer\": \"", "\",");
                        //string _macAddressConfig = curl.cull(texttemplate, "\"propertySettings.macAddress\": \"", "\",");
                        //string _playerNameConfig = curl.cull(texttemplate, "\"statusSettings.playerName\": \"", "\",");

                        //texttemplate.Replace(_phoneIMEIConfig, _phoneIMEI).
                        //    Replace(_phoneIMEIConfig, _phoneIMEI).
                        //    Replace(_phoneIMSIConfig, _phoneIMSI).
                        //    Replace(_phoneSimSerialConfig, _phoneSimSerial).
                        //    Replace(_phoneAndroidIdConfig, _phoneAndroidId).
                        //    Replace(_phoneModelConfig, _phoneModel).
                        //    Replace(_phoneManufacturerConfig, _phoneManufacturer).
                        //    Replace(_macAddressConfig, _macAddress).
                        //    Replace(_playerNameConfig, mail);

                        //File.Delete(pathconfig);
                        /*
                        Thread.Sleep(5000);                      
                        FileStream fs = new FileStream(pathconfig, FileMode.Create);//Tạo file mới tên là test.txt            
                        StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);//fs là 1 FileStream                        
                        sWriter.WriteLine(texttemplate);                      
                        sWriter.Flush();
                        fs.Close();
                        */
                        #endregion
                        File.Copy(pathtemplate, pathconfig,true);

                        #region // thuc hien copy cac file may ao
                        string path_vm = path + @"vms\leidian" + idmail.ToString();
                        hamxoafile(path_vm);
                        string path_vmconfig = Application.StartupPath + @"\TemplateEmulator\leidian0";
                        CopyFolder(@path_vmconfig, path_vm);
                        #endregion                     
                        if (MessageBox.Show("Done! Can you next login?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                         == DialogResult.Yes)
                        {
                            Process p = new Process();
                            p.StartInfo.FileName = txtpathldplayer.Text;
                            p.StartInfo.Arguments = "index =" + idmail.ToString();
                            p.Start();
                            Thread.Sleep(2000);
                            p.WaitForInputIdle();
                            SetParent(p.MainWindowHandle, this.panelmobile.Handle);
                            SetWindowLong(p.MainWindowHandle, GWL_STYLE, WS_VISIBLE);
                            MoveWindow(p.MainWindowHandle, 0, -35, 367, 654, true);
                            Thread.Sleep(2000);
                        }

                    }
                    catch(Exception ex) { MessageBox.Show(ex.ToString()); }
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Hãy chọn kênh cần tạo emulator", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #endregion

        private void btnloginmobile_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            foreach (DataGridViewRow row in dataGridViewListReupMobi.Rows)
            {
                int i = row.Index;
                bool chk = false;
                try
                {
                    chk = bool.Parse(dataGridViewListReupMobi.Rows[i].Cells[0].Value.ToString());
                }
                catch { }
                if (chk == true)
                {
                    int id = int.Parse(dataGridViewListReupMobi.Rows[i].Cells["ID"].Value.ToString());
                    dataGridViewListReupMobi.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
                    table.Rows.Add(id);
                }

            }
            if (table.Rows.Count > 0)
            {

                #region //chay login
                foreach (DataRow row in table.Rows)
                {
                    int idmail = int.Parse(row["ID"].ToString());
                    DataTable thongtinkenh = new DataTable();
                    daWS_FakeAuto tt = new daWS_FakeAuto();
                    thongtinkenh = tt.ChiTietMail(idmail);
                    DataRow rthongtin = thongtinkenh.Rows[0];
                    string linkkenhreup = rthongtin["LinkKenhReUp"].ToString();
                    string ngonngugoc = rthongtin["NgonNguGoc"].ToString();
                    string ngonnguthay = rthongtin["NgonNguThay"].ToString();
                    string mail = rthongtin["Mail"].ToString();
                    string pass = rthongtin["Pass"].ToString();
                    string mailkhoiphuc = rthongtin["MailKhoiPhuc"].ToString();
                    string themtieude = rthongtin["ThemTieuDe"].ToString();
                    string bottieude = rthongtin["BotTieuDe"].ToString();
                    string themmota = rthongtin["ThemMoTa"].ToString();
                    string themtag = rthongtin["ThemTag"].ToString();
                    int soluongup = int.Parse(rthongtin["SoLuongVideoUp"].ToString());
                    try
                    {
                        Task t = new Task(() => {
                        isStop = false;                                 
                        Login(mail, pass, mailkhoiphuc);
                          

                        }
                        );
                        t.Start();


                    }
                    catch {  }
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Hãy chọn kênh cần login mobile", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        bool isStop = false;
        void Delay(int delay)
        {
            while (delay > 0)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                delay--;
                if (isStop)
                    break;
            }
        }
        void Login(string taikhoan, string matkhau, string mailkhoiphuc)
        {
            List<string> devices = new List<string>();
            devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (var deviceID in devices)
            {
                Task t = new Task(() => {
                    
                        if (isStop)
                            return;
                      
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 69.8, 19.4);
                        Delay(15);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 91.2, 7.0);
                        Delay(15);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 56.3, 59.4);
                        Delay(15);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 81.2, 48.1);
                        Delay(20);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 20.8, 44.0);
                        Delay(4);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.InputText(deviceID, taikhoan);
                      
                        if (isStop)
                            return;
                        // ennter
                        KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
                        Delay(8);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 19.4, 41.3);
                        Delay(3);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.InputText(deviceID, matkhau);
                        Delay(2);
                        if (isStop)
                            return;
                        // ennter
                        KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
                        Delay(8);
                        // thực hiện kéo chuột
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.Swipe(deviceID, 350, 1200, 350, 150);
                        Delay(2);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 83.2, 84.7);
                        Delay(2);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 87.2, 95.5);
                        Delay(2);
                        if (isStop)
                            return;
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 81.2, 95.7);
                        Delay(5);
                      
                    
                });
                t.Start();
            }
        }
        private void btnpathLDplay_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.CheckFileExists = false;
            dlg.CheckPathExists = false;
            dlg.Multiselect = false;
            dlg.Filter = "Files(*.exe)|*.exe";
            dlg.Multiselect = true;
            dlg.SupportMultiDottedExtensions = true;
            dlg.Title = "Select proshow";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //Settings.Default.LastUsedFolder = Path.GetDirectoryName(dlg.FileNames[0]);
                txtpathldplayer.Text = dlg.FileName;
                ExeConfigurationFileMap exmap = new ExeConfigurationFileMap();
                exmap.ExeConfigFilename = @"UpLoadNews.exe.config";
                //Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exmap, ConfigurationUserLevel.None);
                cf.AppSettings.Settings.Remove("PathLDPlayer");
                cf.AppSettings.Settings.Add("PathLDPlayer", txtpathldplayer.Text);
                cf.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }


        private void btnclose_Click(object sender, EventArgs e)
        {
            #region // tat sau khi dang nhap thanh cong
            try
            {
                foreach (Process proc in Process.GetProcessesByName("dnplayer"))
                {
                    proc.Kill();
                }
            }
            catch { }
            #endregion
        }

        private void btnrunemulator_Click(object sender, EventArgs e)
        {
            string pathldplay = txtpathldplayer.Text;
            if(pathldplay!="")
            {
                FormEmulator run = new FormEmulator(pathldplay,m_IDTaiKhoan);
                run.Show();
            }
            else
            {
                MessageBox.Show("Lỗi phải có pathLDPlayer","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
        }

        #endregion

        #region // create facebook
        private void btncreateFB_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void cmblaguageling_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NgonNgu", typeof(string));
            dt.Columns.Add("Voice", typeof(string));
          
            dt.Rows.Add("Arabic","Tarik");
            dt.Rows.Add("Basque", "Miren");
            dt.Rows.Add("Catalan", "Jordi");
            dt.Rows.Add("Catalan", "Montserrat");
            dt.Rows.Add("Cantonese(Hong Kong)", "Sin-Ji");
            dt.Rows.Add("Czech", "Iveta");
            dt.Rows.Add("Czech", "Zuzana");
            dt.Rows.Add("Danish", "Magnus");
            dt.Rows.Add("Danish", "Sara");
            dt.Rows.Add("Dutch (Netherlands)", "Claire");
            dt.Rows.Add("Dutch (Netherlands)", "Xander");
            dt.Rows.Add("Dutch (Belgium)", "Ellen");
            dt.Rows.Add("English (Australian)", "Karen");
            dt.Rows.Add("English (Australian)", "Lee");
            dt.Rows.Add("English (Irish)", "Moira");
            dt.Rows.Add("English (British)", "Daniel");
            dt.Rows.Add("English (British)", "Kate");
            dt.Rows.Add("English (British)", "Oliver");
            dt.Rows.Add("English (British)", "Serena");           
            dt.Rows.Add("English (Indian)", "Veena");
            dt.Rows.Add("English (Scottisch)", "Fiona");
            dt.Rows.Add("English (American)", "Allison");
            dt.Rows.Add("English (American)", "Ava");
            dt.Rows.Add("English (American)", "Samantha");
            dt.Rows.Add("English (American)", "Susan");
            dt.Rows.Add("English (American)", "Tom");
            dt.Rows.Add("English (South African)", "Tessa");
            dt.Rows.Add("Finnish", "Satu");
            dt.Rows.Add("French (Canadian)", "Amelie");
            dt.Rows.Add("French (Canadian)", "Chantal");
            dt.Rows.Add("French (Canadian)", "Nicolas");
            dt.Rows.Add("French", "Audrey");
            dt.Rows.Add("French", "Aurelie");
            dt.Rows.Add("French", "Thomas");
            dt.Rows.Add("German", "Anna");
            dt.Rows.Add("German", "Markus");
            dt.Rows.Add("German", "Petra");
            dt.Rows.Add("German", "Yannick");
            dt.Rows.Add("Galician", "Carmela");
            dt.Rows.Add("Greek", "Melina");
            dt.Rows.Add("Greek", "Nikos");
            dt.Rows.Add("Hebrew", "Carmit");
            dt.Rows.Add("Hindi", "Lekha");
            dt.Rows.Add("Hungarian", "Mariska");
            dt.Rows.Add("Indonesian", "Damayanti");
            dt.Rows.Add("Italian", "Alice");
            dt.Rows.Add("Italian", "Federica");
            dt.Rows.Add("Italian", "Luca");
            dt.Rows.Add("Italian", "Paola");
            dt.Rows.Add("Japanese", "Kyoko");
            dt.Rows.Add("Japanese", "Otoya");
            dt.Rows.Add("Korean", "Sora");
            dt.Rows.Add("Mandarin (China)", "Tian-Tian");
            dt.Rows.Add("Mandarin (Taiwan)", "Mei-Jia");
            dt.Rows.Add("Norwegian", "Henrik");
            dt.Rows.Add("Norwegian", "Nora");
            dt.Rows.Add("Polish", "Ewa");
            dt.Rows.Add("Polish", "Zosia");
            dt.Rows.Add("Portuguese (Brazilian)", "Felipe");
            dt.Rows.Add("Portuguese (Brazilian)", "Luciana");
            dt.Rows.Add("Portuguese", "Catarina");
            dt.Rows.Add("Portuguese", "Joana");
            dt.Rows.Add("Romanian", "Ioana");
            dt.Rows.Add("Russian", "Katya");
            dt.Rows.Add("Russian", "Milena");
            dt.Rows.Add("Russian", "Yuri");
            dt.Rows.Add("Slovak", "Laura");
            dt.Rows.Add("Spanish (Argentine)", "Diego");
            dt.Rows.Add("Spanish (Colombian)", "Carlos");
            dt.Rows.Add("Spanish (Colombian)", "Soledad");
            dt.Rows.Add("Spanish", "Jorge");
            dt.Rows.Add("Spanish", "Monica");
            dt.Rows.Add("Spanish (Mexican)", "Angelica");
            dt.Rows.Add("Spanish (Mexican)", "Juan");
            dt.Rows.Add("Spanish (Mexican)", "Paulina");
            dt.Rows.Add("Swedish", "Alva");
            dt.Rows.Add("Swedish", "Klara");
            dt.Rows.Add("Swedish", "Oskar");
            dt.Rows.Add("Thai", "Kanya");
            dt.Rows.Add("Turkish", "Cem");
            dt.Rows.Add("Turkish", "Yelda");
            dt.Rows.Add("Valencian", "Empar");

            DataRow[] rows = dt.Select("NgonNgu='" + cmblaguageling.Text + "' ");
            DataTable table = new DataTable();
            table.Columns.Add("Voice", typeof(string));
            foreach (DataRow row in rows)
            {
                table.Rows.Add(row["Voice"].ToString());
            }
            cmbvoiceling.DataSource = table;
            cmbvoiceling.DisplayMember = "Voice";
            cmbvoiceling.ValueMember = "Voice";
        }
    }
}
