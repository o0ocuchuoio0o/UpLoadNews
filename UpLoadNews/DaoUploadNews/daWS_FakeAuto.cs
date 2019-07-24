using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DaoUploadNews
{
    public  class daWS_FakeAuto
    {
        public DataTable DangNhap(string taikhoan, string matkhau)
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto dn = new WS_FakeAuto.WS_FakeAuto();
            dt = dn.DangNhap(taikhoan, matkhau);
            return dt;
        }

       
        public DataTable DanhSachKenh(int idtaikhoan)
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.DanhSachKenh(idtaikhoan);
            return dt;
        }

        public DataTable ThongTinKenh(int idtaikhoan,int idkenh)
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.ThongTinKenh(idtaikhoan,idkenh);
            return dt;
        }

        public DataTable DanhSachBaiViet(int idkenh)
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.DanhSachBaiViet(idkenh);
            return dt;
        }
        public DataTable DanhSachBaiVietProshow()
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.DanhSachBaiVietProshowCanRender();
            return dt;
        }
        public DataTable DanhSachBaiVietProshowTheoKenh(int idkenh)
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.DanhSachBaiVietProshowCanRenderTheoKenh(idkenh);
            return dt;
        }

        public DataTable DanhSachBaiVietProshowTheoKenhVoiceSelenium(int idkenh)
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.DanhSachBaiVietProshowCanRenderTheoKenh_VoiceSelenium(idkenh);
            return dt;
        }

        public DataTable DanhSachBaiVietDaRenderProshow(int idkenh)
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.DanhSachBaiVietProshowDaRender(idkenh);
            return dt;
        }
        public DataTable CauHinhMCKenh(int idkenh)
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.ThongTinMCTheoKenh(idkenh);
            return dt;
        }
        public DataTable ChiTietBaiViet(int idbaiviet)
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.ChiTietBaiViet(idbaiviet);
            return dt;
        }
        public DataTable DanhSachVoiceAMZ()
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.DanhSachVoiceAMZ();
            return dt;
        }

        public int BaiVietDaUpTrongNgay(int idkenh)
        {
            int kq = 0;
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            kq = ds.DanhSachBaiVietDaUp(idkenh);
            return kq;
        }
        public int Vession()
        {          
            WS_FakeAuto.WS_FakeAuto vs = new WS_FakeAuto.WS_FakeAuto();
            return vs.Vession();            
        }
        public DataTable DanhSachFileUpdate()
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.DanhSachFileCapNhat();
            return dt;
        }
        public void InsertBaiVietDaUp(int idkenh,int idbaiviet)
        {
            WS_FakeAuto.WS_FakeAuto baivietdaup = new WS_FakeAuto.WS_FakeAuto();
            baivietdaup.InsertBaiVietDaUp(idkenh,idbaiviet);
        }

        public void UpdateVoiceKenh(int idkenh, string mota,string idvoicamz,string idvoicegoogle)
        {
            WS_FakeAuto.WS_FakeAuto upvoice = new WS_FakeAuto.WS_FakeAuto();
            upvoice.UpdateVoiceKenh(idkenh, mota,idvoicamz,idvoicegoogle);
        }
        public void UpdateBaiVietDangRender(int idbaiviet)
        {
            WS_FakeAuto.WS_FakeAuto baivietdangrender = new WS_FakeAuto.WS_FakeAuto();
            baivietdangrender.UpdateBaiVietDangRender(idbaiviet);
        }
        public void UpdateBaiVietDaRender(int idbaiviet)
        {
            WS_FakeAuto.WS_FakeAuto baivietdarender = new WS_FakeAuto.WS_FakeAuto();
            baivietdarender.UpdateBaiVietDaRender(idbaiviet);
        }

        public DataTable DanhSachNgonNgu()
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.DanhSachNgonNgu();
            return dt;
        }
        public DataTable DanhSachVoiceNgonNgu(string ngonngu)
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.DanhSachVoiceNgonNgu(ngonngu);
            return dt;
        }
        public DataTable DanhSachEffect()
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.DanhSachEffect();
            return dt;
        }
        public DataTable DanhSachEffectLevel(string effect)
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.DanhSachEffectLevel(effect);
            return dt;
        }
        public void ThemSuaCauHinhVoiceKenh(int idkenh, string ngonngu, string voice, string effect,string effectlevel)
        {
            WS_FakeAuto.WS_FakeAuto ch = new WS_FakeAuto.WS_FakeAuto();
            ch.InsertCauHinhVoiceKenh(idkenh, ngonngu, voice, effect,effectlevel);
        }
        public DataTable ThongTinCauHinhVoiceKenh(int idkenh)
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.ThongTinCauHinhVoiceKenh(idkenh);
            return dt;
        }
        // du lieu lay voice
        public DataTable DanhSachVoiceCanLay(int idkenh)
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.DanhSachTinCanLayVoiceTheoKenh(idkenh);
            return dt;
        }
        public DataTable DanhSachVoiceCanLayTop1(int idkenh)
        {
            DataTable dt = new DataTable();
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            dt = ds.DanhSachTinCanLayVoiceTheoKenhTop(idkenh);
            return dt;
        }
        public void SuaPathVoice(int idchitiet, string pathvoice)
        {
            WS_FakeAuto.WS_FakeAuto ch = new WS_FakeAuto.WS_FakeAuto();
            ch.UpdateDaLayVoice(idchitiet, pathvoice);
        }
        public void UpdateDaRenderVoice(int idbaiviet)
        {
            WS_FakeAuto.WS_FakeAuto ch = new WS_FakeAuto.WS_FakeAuto();
            ch.UpdateBaiVietDaLayVoice(idbaiviet);
        }

        #region // tao psh tren server
        public static string _InTro(string i, string pathintro, string timeintro)
        {
            string ex = "";
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            ex = ds._InTro(i, pathintro, timeintro);
            return ex;
        }
        public static string _Head(string cell, string localFoder, string musicbg)
        {
            string ex = "";
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            ex = ds._Head(cell,localFoder,musicbg);
            return ex;
        }
        public static string _Slide(string i, string pathsub, string pathimage, string timeslide, string pathvoice, string timevoice)
        {
            string ex = "";
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            ex = ds._Silde(i, pathsub, pathimage, timeslide, pathvoice, timevoice);
            return ex;
        }
        public static string _Slidemc(string i,string pathmc, string pathsub, string pathimage, string timeslide, string pathvoice, string timevoice)
        {
            string ex = "";
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            ex = ds._SildeMC(i,pathmc, pathsub, pathimage, timeslide, pathvoice, timevoice);
            return ex;
        }
        public static string _TranSlide(string i)
        {
            string ex = "";
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            ex = ds._TranSlide(i);
            return ex;
        }
        public static string _OutTro(string i, string pathouttro, string timeouttro)
        {
            string ex = "";
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            ex = ds._OutTro(i, pathouttro, timeouttro);
            return ex;
        }
        public static string _Footer()
        {
            string ex = "";
            WS_FakeAuto.WS_FakeAuto ds = new WS_FakeAuto.WS_FakeAuto();
            ex = ds._Footer();
            return ex;
        }
        #endregion
    }
}
