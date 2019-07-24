using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using DaoUploadNews;
namespace AutoUpdate
{
    public partial class FormAutoUpdate : Form
    {
        public FormAutoUpdate()
        {
            InitializeComponent();
        }
        string TEMP_DIR = "";
        string filedangtai = "";
        private void FormAutoUpdate_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            foreach (Process proc in Process.GetProcessesByName("UpLoadNews"))
            {
                proc.Kill();
            }
            //ngừng 2s để hệ thống main tắt hẳn.
            txthostfileupdate.Text = "http://buudienhanoi.com.vn/ThangBDHN_Luu2/UpdateAppUpload/";
            System.Threading.Thread.Sleep(2000);
            //Tạo thư mục chứa file update
            TEMP_DIR = Application.StartupPath + "\\FolderUpdate";
            if (!Directory.Exists(TEMP_DIR))
            {
                Directory.CreateDirectory(TEMP_DIR);
            }
            else
            {
                //lấy danh sách tất cả các file trong thư mục tạm
                string[] fileList = System.IO.Directory.GetFiles(TEMP_DIR);
                //duyệt từng file và copy đè lên file cũ trong thư mục đang chạy chương trình
                foreach (string sourceFile in fileList)
                {
                    //tách tên file ra khỏi đường dẫn (tên file sẽ dùng để tạo đường dẫn đích cần copy đè)
                    string fileName = System.IO.Path.GetFileName(sourceFile);
                    //tạo đường dẫn đích để copy file mới tới
                    string destinationFile = TEMP_DIR + @"\" + fileName;
                    //thực hiện xóa file cũ
                    System.IO.File.Delete(destinationFile);
                }
            }
        }

        #region // các xử lý tải file chạy
        private void TaiFile()
        {
            DataTable dt = new DataTable();
            daWS_FakeAuto listfile = new daWS_FakeAuto();
            dt = listfile.DanhSachFileUpdate();
            foreach (DataRow r in dt.Rows)
            {
                filedangtai = r["TenFile"].ToString();
                //tạo đường dẫn tạm để lưu file
                string localPath = TEMP_DIR + @"\" + r["TenFile"].ToString();
                //xác định đường dẫn file trên host
                string remotePath = txthostfileupdate.Text.Trim() + "/" + r["TenFile"].ToString();
                //tải file từ host về thư mục tạm
                using (var _client = new WebClient())
                {
                    _client.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                    _client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                    // _client.DownloadFile(remotePath, localPath);
                    _client.DownloadFileAsync(new Uri(remotePath), localPath);
                    while (_client.IsBusy)
                    {
                        Application.DoEvents();
                    }
                }
                //  DownloadFile(remotePath, localPath);
            }
        }
        public static string ToFileSize(long source)
        {
            const int byteConversion = 1024;
            double bytes = Convert.ToDouble(source);

            if (bytes >= Math.Pow(byteConversion, 3)) //GB Range
            {
                return string.Concat(Math.Round(bytes / Math.Pow(byteConversion, 3), 2), " GB");
            }
            else if (bytes >= Math.Pow(byteConversion, 2)) //MB Range
            {
                return string.Concat(Math.Round(bytes / Math.Pow(byteConversion, 2), 2), " MB");
            }
            else if (bytes >= byteConversion) //KB Range
            {
                return string.Concat(Math.Round(bytes / byteConversion, 2), " KB");
            }
            else //Bytes
            {
                return string.Concat(bytes, " Bytes");
            }
        }
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            lblDangTai.Text = "Đang tải " + filedangtai + ":" + ToFileSize(e.BytesReceived) + " / " + ToFileSize(e.TotalBytesToReceive);
            prc.Value = e.ProgressPercentage;
        }
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            lblDangTai.Text = "Đã tải xong dữ liệu!";

        }
        #endregion

        #region // ghi đè lên file đang chạy
        private void CopyFiles()
        {

            //xác định thư mục hiện thời, nơi chương trình đang chạy
            string currentDirectory = Environment.CurrentDirectory;
            //lấy danh sách tất cả các file trong thư mục tạm
            string[] fileList = System.IO.Directory.GetFiles(TEMP_DIR);
            //duyệt từng file và copy đè lên file cũ trong thư mục đang chạy chương trình
            foreach (string sourceFile in fileList)
            {
                //tách tên file ra khỏi đường dẫn (tên file sẽ dùng để tạo đường dẫn đích cần copy đè)
                string fileName = System.IO.Path.GetFileName(sourceFile);
                //tạo đường dẫn đích để copy file mới tới
                string destinationFile = currentDirectory + @"\" + fileName;
                //thực hiện copy đè
                System.IO.File.Copy(sourceFile, destinationFile, true);
            }
            //sau khi copy đè tất cả các file xong, ta sẽ tiến hành gọi lại chương trình chính (Program1.exe) để chạy lại chương trình
            // Process.Start("DieuTinHTKH.exe");
            //và thoát khỏi chương trình update
            // Application.Exit();

        }
        #endregion
        private void btncapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("UpLoadNews"))
                {
                    proc.Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #region // tải bản mới và ghi đè lên file đang chạy
            TaiFile();
            CopyFiles();
            try
            {
                Process.Start("UpLoadNews.exe");
            }
            catch { }
            #endregion
        }
    }
}
