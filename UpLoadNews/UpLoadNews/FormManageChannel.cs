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

namespace UpLoadNews
{
    public partial class FormManageChannel : Form
    {
        public FormManageChannel()
        {
            InitializeComponent();
        }

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

        private void btngetlist_Click(object sender, EventArgs e)
        {
            listvideo();
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
