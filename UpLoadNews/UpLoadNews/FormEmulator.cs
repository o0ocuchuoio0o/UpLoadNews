using DaoUploadNews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using KAutoHelper;

namespace UpLoadNews
{
    public partial class FormEmulator : Form
    {
        public FormEmulator(string path,int taikhoan)
        {
            InitializeComponent();
            PathLDplayer = path;
            Taikhoan = taikhoan;
        }
        #region // khai báo biến
        private string m_PathLDplayer;
        public string PathLDplayer
        {
            get
            {
                return m_PathLDplayer;
            }

            set
            {
                m_PathLDplayer = value;
            }
        }

        public int Taikhoan
        {
            get
            {
                return m_taikhoan;
            }

            set
            {
                m_taikhoan = value;
            }
        }

        private int m_taikhoan;

        private int m_IDprosess1=0;
        private int m_IDprosess2=0;
        private int m_IDprosess3=0;
        #endregion

        private DataTable FileToDatatable(string path)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            string[] fileList = System.IO.Directory.GetFiles(path);
            //duyệt từng file và copy đè lên file cũ trong thư mục đang chạy chương trình
            foreach (string sourceFile in fileList)
            {
                //tách tên file ra khỏi đường dẫn (tên file sẽ dùng để tạo đường dẫn đích cần copy đè)
                string fileName = System.IO.Path.GetFileName(sourceFile);
                //tạo đường dẫn đích để copy file mới tới
                if (fileName.IndexOf(".config") != -1 && fileName!= "leidians.config")
                {
                    try
                    {
                        int id = int.Parse(fileName.Replace("leidian", "").Replace(".config", ""));
                        dt.Rows.Add(id);
                    }
                    catch { }

                }

            }
            return dt;
        }
        private void loadmaildaxuly()
        {
            DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
            CheckBox chk = new CheckBox();
            CheckboxColumn.Width = 50;
            dataGridViewList.Columns.Add(CheckboxColumn);          
            daWS_FakeAuto ds = new daWS_FakeAuto();
            DataTable dt = new DataTable();
            dt = ds.DanhSachMailDaXuLy(m_taikhoan);


            string path = txtpathldplayer.Text.Replace("dnplayer.exe", "")+ @"vms\config";
            DataTable table = new DataTable();
            table = FileToDatatable(path);
            DataTable tabledata = new DataTable();
            tabledata = dt.Clone();

            foreach(DataRow r in table.Rows)
            {
                string id = r["ID"].ToString();
                DataRow[] drs = dt.Select("ID='"+id+"' ");
                foreach (DataRow d in drs)
                {
                    tabledata.ImportRow(d);
                }              
               
            }

            dataGridViewList.DataSource = tabledata;
        

        }



        private void khoitao()
        {
            txtpathldplayer.Text = m_PathLDplayer;
            loadmaildaxuly();
        }
        private void FormEmulator_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            khoitao();
        }

        private void btnrefesh_Click(object sender, EventArgs e)
        {
            loadmaildaxuly();
        }
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hwc, IntPtr hwp);
        [DllImport("user32.dll")]
        public static extern long SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);
        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 0x10000000;
        //public static int WS_BORDER = 0x00800000; //window with border
        //public static int WS_DLGFRAME = 0x00400000; //window with double border but no title
        //public static int WS_CAPTION = WS_BORDER | WS_DLGFRAME; //window with a title bar
        public int idprosesswait()
        {
            int m_id = 0;
            if(m_IDprosess1==0)
            {
                m_id = 1;
            }
            else if (m_IDprosess2 == 0)
            {
                m_id = 2;
            }
            else if (m_IDprosess3 == 0)
            {
                m_id = 3;
            }           
            return m_id;
        }
        List<Devices> m_devives = new List<Devices>();
        private void btnopenemulator_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            foreach (DataGridViewRow row in dataGridViewList.Rows)
            {
                int i = row.Index;
                bool chk = false;
                try
                {
                    chk = bool.Parse(dataGridViewList.Rows[i].Cells[0].Value.ToString());
                }
                catch { }
                if (chk == true)
                {
                    int id = int.Parse(dataGridViewList.Rows[i].Cells["ID"].Value.ToString());
                    dataGridViewList.Rows[i].DefaultCellStyle.BackColor = Color.Beige;
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
                        p.StartInfo.FileName = txtpathldplayer.Text;
                        p.StartInfo.Arguments = "index =" + idmail.ToString();
                        p.Start();
                        p.WaitForInputIdle();
                        Devices _thietbi = new Devices();
                        _thietbi.IDprosses = p.Id.ToString();
                        _thietbi.Name =mail;
                        m_devives.Add(_thietbi);
                        UC_Emulator a = new UC_Emulator(p.Id.ToString(), mail);
                        flowLayoutPanel.Controls.Add(a);
                        Thread.Sleep(3000);
                        SetParent(p.MainWindowHandle, a.Handle);
                        SetWindowLong(p.MainWindowHandle, GWL_STYLE, WS_VISIBLE);                        
                        MoveWindow(p.MainWindowHandle, 0, 0, 320, 470, true);
                        Thread.Sleep(1000);
                      
                    }
                    catch { }
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Hãy chọn kênh cần open emulator", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #region // skill panel
        private void btnclose1_Click(object sender, EventArgs e)
        {
            Process processToKill = Process.GetProcessById(m_IDprosess1);
            processToKill.Kill();
            m_IDprosess1 = 0;
        }

        private void btnclose2_Click(object sender, EventArgs e)
        {
            Process processToKill = Process.GetProcessById(m_IDprosess2);
            processToKill.Kill();
            m_IDprosess2 = 0;
        }

        private void btnclose3_Click(object sender, EventArgs e)
        {
            Process processToKill = Process.GetProcessById(m_IDprosess3);
            processToKill.Kill();
            m_IDprosess3 = 0;
        }

       
        #endregion
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

        void SUB(string link)
        {
            List<string> devices = new List<string>();
            devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (var deviceID in devices)
            {
                Task t = new Task(() => {


                    #region // thực hiện sub
                    string cmd = "adb -s " + deviceID + " shell am start -a android.intent.action.VIEW '" + link + "'";
                    KAutoHelper.ADBHelper.ExecuteCMD(cmd);
                    Delay(30);
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 13.4, 51.9);
                    Delay(15);
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 87.2, 61.7);
                    Delay(15);
                    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_APP_SWITCH);
                    Delay(2);
                    KAutoHelper.ADBHelper.Swipe(deviceID, 80, 550, 600, 550);
                    Delay(2);
                    #endregion
                }
                );
                t.Start();
                Delay(4);
            }

        }
        void View(string link,int time)
        {
            List<string> devices = new List<string>();
            devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (var deviceID in devices)
            {
                Task t = new Task(() => {


                    #region // thực hiện sub
                    string cmd = "adb -s " + deviceID + " shell am start -a android.intent.action.VIEW '" + link + "'";
                    KAutoHelper.ADBHelper.ExecuteCMD(cmd);
                    Delay(time);                  
                    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_APP_SWITCH);
                    Delay(2);
                    KAutoHelper.ADBHelper.Swipe(deviceID, 80, 550, 600, 550);
                    Delay(2);
                    #endregion
                }
                );
                t.Start();
                Thread.Sleep(4000);
            }

        }

        void FakeIP()
        {
            List<string> devices = new List<string>();
            devices = KAutoHelper.ADBHelper.GetDevices();
            foreach (var deviceID in devices)
            {
                Task t = new Task(() => {

                    #region // thực hiện fake ip
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 9.4, 33.4);
                    Delay(20);
                    try
                    {
                        // thực hiện tắt quảng cáo nếu có
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 7.7, 4.1);
                    }
                    catch { }
                    Delay(5);
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 88.9, 35.3);
                    Delay(2);
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 47.3, 88.3);
                    Delay(10);
                    //try
                    //{
                    //    // thực hiện tắt quảng cáo nếu có
                    //    KAutoHelper.ADBHelper.TapByPercent(deviceID, 7.7, 4.1);
                    //}
                    //catch { }
                    //Delay(5);
                    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_APP_SWITCH);
                    Delay(2);
                    KAutoHelper.ADBHelper.Swipe(deviceID, 80, 550, 600, 550);
                    Delay(2);

                    #endregion


              
                }
                );
                t.Start();
                Thread.Sleep(3000);
            }

        }
        private void btnsub_Click(object sender, EventArgs e)
        {
            if(txtlinkvideo.Text=="")
            {
                MessageBox.Show("nhap link video","Loi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            Task t = new Task(() => {
                isStop = false;
                SUB(txtlinkvideo.Text);
            }
           );
            t.Start();
        }

        private void btnfakeip_Click(object sender, EventArgs e)
        {
            Task t = new Task(() => {
                isStop = false;
                FakeIP();
            }
          );
            t.Start();
        }

        private void btncloseall_Click(object sender, EventArgs e)
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

        private void btnview_Click(object sender, EventArgs e)
        {
            if (txtlinkvideo.Text == "")
            {
                MessageBox.Show("nhap link video", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Task t = new Task(() => {
                isStop = false;
                View(txtlinkvideo.Text,int.Parse(txttime.Value.ToString()));
            }
           );
            t.Start();
        }

       
    }
}
