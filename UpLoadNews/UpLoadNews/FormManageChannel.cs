using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Threading;
using System.IO;
using System.Reflection;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using DaoUploadNews;
using System.Diagnostics;

namespace UpLoadNews
{
    public partial class FormManageChannel : Form
    {
        public FormManageChannel(int id,string mail,string pass,string mailkhoiphuc,string linkkenh)
        {
            InitializeComponent();
            m_LinhKenh = linkkenh;
            txtidchannel.Text = linkkenh;
            m_ID = id;
            m_Mail = mail;
            m_Pass = pass;
            m_MailKhoiPhuc = mailkhoiphuc;
        }
        #region // các biến
        private string m_LinhKenh;
        public string LinhKenh
        {
            get
            {
                return m_LinhKenh;
            }

            set
            {
                m_LinhKenh = value;
            }
        }
        public int ID
        {
            get
            {
                return m_ID;
            }

            set
            {
                m_ID = value;
            }
        }

        public string Mail
        {
            get
            {
                return m_Mail;
            }

            set
            {
                m_Mail = value;
            }
        }

        public string Pass
        {
            get
            {
                return m_Pass;
            }

            set
            {
                m_Pass = value;
            }
        }

        public string MailKhoiPhuc
        {
            get
            {
                return m_MailKhoiPhuc;
            }

            set
            {
                m_MailKhoiPhuc = value;
            }
        }

        private int m_ID;
        private string m_Mail;
        private string m_Pass;
        private string m_MailKhoiPhuc;
        #endregion

        private void listvideo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("STT", typeof(int));
            dt.Columns.Add("Xoa", typeof(bool));
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("TieuDe", typeof(string));

            YouTubeService yt = new YouTubeService(new BaseClientService.Initializer() { ApiKey =txttextchannel.Text });           
            var searchListRequest = yt.Search.List("snippet");
            var nextPageToken = txtpage.Text;
            int stt = 0;
            while (nextPageToken != null)
            {
                searchListRequest.MaxResults = 50;
                searchListRequest.PageToken = nextPageToken;
                searchListRequest.ChannelId = txtidchannel.Text.Trim().Replace("https://www.youtube.com/channel/", "");
                var searchListResult = searchListRequest.Execute();
                 
                foreach (var item in searchListResult.Items)
                {
                    stt = stt + 1;
                    dt.Rows.Add(stt,false, item.Id.VideoId, item.Snippet.Title);
                }
                nextPageToken = searchListResult.NextPageToken;
                if(nextPageToken != null)
                {
                    txtpage.Text = nextPageToken;
                }
            }
            //dt.DefaultView.Sort = "TieuDe desc";
            //dt = dt.DefaultView.ToTable();
            dataListVideo.DataSource = dt;
        }
        private void FormManageChannel_Load(object sender, EventArgs e)
        {

        }
        private async Task ChomeClose()
        {
            try
            {
                PropretiesCollection.driver.Close();
                PropretiesCollection.driver.Quit();
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
        private void btngetlist_Click(object sender, EventArgs e)
        {
            if(checkbyselenium.Checked==false)
            {
                listvideo();
            }
            else
            {
                try
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
                    PropretiesCollection.driver.Navigate().GoToUrl(txtidchannel.Text + "/videos");
                    daWS_FakeAuto getlinkmoinhat = new daWS_FakeAuto();

                    ManagerChannel listvideo = new ManagerChannel();
                    DataTable dt = new DataTable();
                    dt = listvideo.LoadListVideoV2("");
                    dataListVideo.DataSource = dt;
                    ChomeClose().Wait();
                }
                catch { }
            }
           
        }

        private async Task DeleteVideo(string idvideo)
        {
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
            var videosDeleteRequest=  youtubeService.ChannelSections.Delete(idvideo);
            //youtubeService.SetRequestSerailizedContent
            //youtubeService.setOnBehalfOfContentOwner(parameters.get("onBehalfOfContentOwner").toString());


           // youtubeService.();
            //var videosDeleteRequest = youtubeService.Videos.Delete(idvideo);
            await videosDeleteRequest.ExecuteAsync();
        }
        private void btndeletevideo_Click(object sender, EventArgs e)
        {
            //DeleteVideo("kd3OD_NQu8I").Wait();
          
            //foreach (DataGridViewRow row in dataListVideo.Rows)
            //{
            //    DataGridViewCheckBoxCell chk = row.Cells[0] as DataGridViewCheckBoxCell;
            //    if (Convert.ToBoolean(chk.Value) == true)
            //    {
            //        string idvideo = row.Cells[1].Value.ToString();
            //        DeleteVideo(idvideo).Wait();
            //    }
            //}

        }

        private void btnvideotrunglap_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("STT", typeof(int));
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("TieuDe", typeof(string));
            DataTable dt = (DataTable)dataListVideo.DataSource;
            int stt = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = i + 1; j < dt.Rows.Count; j++)
                {
                    string tieudecu = dt.Rows[i]["TieuDe"].ToString();
                    string tieudemoi = dt.Rows[j]["TieuDe"].ToString();
                   
                    if (tieudemoi == tieudecu)
                    {
                        stt = stt + 1;
                        table.Rows.Add(stt,dt.Rows[i]["ID"].ToString(), dt.Rows[i]["TieuDe"].ToString());
                    }
                }
            }
            dataListtrunglap.DataSource = table;
        }
    }
}
