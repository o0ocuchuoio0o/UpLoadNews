using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpLoadNews
{
    class thumnail
    {
        //public bool renderThumbnail(Video video)
        //{
        //    this.setTrangThai("Đang Tạo Thumbnail", video);
        //    try
        //    {
        //        string path = video.ThuMucTemp + @"\Thumbnail- " + video.id + ".jpg";
        //        string filename = video.ThuMucTemp + @"\Thumbnail1- " + video.id + ".jpg";
        //        string str3 = video.ThuMucTemp + @"\Thumbnail2- " + video.id + ".jpg";
        //        string str4 = video.thongSo.ThongSoThumbnail_txtTempThumbnail;
        //        if (video.thongSo.ThongSoThumbnail_randomTempThumbnail)
        //        {
        //            str4 = Controller.getRandomFileInFoder(Application.StartupPath + @"\1.ThongSo\TemplateThumbnail");
        //        }
        //        Process process = null;
        //        ProcessStartInfo info = null;
        //        string format = "";
        //        try
        //        {
        //            if (File.Exists(path))
        //            {
        //                File.Delete(path);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        Thread.Sleep(0x3e8);
        //        try
        //        {
        //            using (Bitmap bitmap = new Bitmap(video.thumbnailUploadVideo))
        //            {
        //                double width = bitmap.Width;
        //                double height = bitmap.Height;
        //                double num3 = width / height;
        //                if (num3 <= 0.8)
        //                {
        //                    string[] textArray1 = new string[] { "-y -i \"", video.thumbnailUploadVideo, "\" -vf \"crop = iw:iw*9/16:0:0,scale=1280:720\" \"", path, "\"" };
        //                    format = string.Concat(textArray1);
        //                    info = new ProcessStartInfo
        //                    {
        //                        FileName = Controller.localFFmpeg,
        //                        Arguments = format,
        //                        UseShellExecute = false,
        //                        CreateNoWindow = true,
        //                        RedirectStandardError = true,
        //                        RedirectStandardOutput = true,
        //                        WindowStyle = ProcessWindowStyle.Normal
        //                    };
        //                    process = new Process
        //                    {
        //                        StartInfo = info
        //                    };
        //                    process.ErrorDataReceived += new DataReceivedEventHandler(Controller.p_ErrorDataReceived);
        //                    process.Start();
        //                    process.BeginErrorReadLine();
        //                    process.WaitForExit();
        //                }
        //                else
        //                {
        //                    string[] textArray2 = new string[] { "-y -i \"", video.thumbnailUploadVideo, "\" -filter_complex \"scale = 1280:720\" \"", path, "\"" };
        //                    format = string.Concat(textArray2);
        //                    info = new ProcessStartInfo
        //                    {
        //                        FileName = Controller.localFFmpeg,
        //                        Arguments = format,
        //                        UseShellExecute = false,
        //                        CreateNoWindow = true,
        //                        RedirectStandardError = true,
        //                        RedirectStandardOutput = true,
        //                        WindowStyle = ProcessWindowStyle.Normal
        //                    };
        //                    process = new Process
        //                    {
        //                        StartInfo = info
        //                    };
        //                    process.ErrorDataReceived += new DataReceivedEventHandler(Controller.p_ErrorDataReceived);
        //                    process.Start();
        //                    process.BeginErrorReadLine();
        //                    process.WaitForExit();
        //                }
        //            }
        //        }
        //        catch (Exception)
        //        {
        //        }
        //        if (video.thongSo.ThongSoThumbnail_tempThumbnail)
        //        {
        //            string[] textArray3 = new string[] { "-y -i \"", path, "\" -i \"", str4, "\" -filter_complex \"[0:v] [1:v] overlay\" \"", path, "\"" };
        //            format = string.Concat(textArray3);
        //            info = new ProcessStartInfo
        //            {
        //                FileName = Controller.localFFmpeg,
        //                Arguments = format,
        //                UseShellExecute = false,
        //                CreateNoWindow = true,
        //                RedirectStandardError = true,
        //                RedirectStandardOutput = true,
        //                WindowStyle = ProcessWindowStyle.Normal
        //            };
        //            process = new Process
        //            {
        //                StartInfo = info
        //            };
        //            process.ErrorDataReceived += new DataReceivedEventHandler(Controller.p_ErrorDataReceived);
        //            process.Start();
        //            process.BeginErrorReadLine();
        //            process.WaitForExit();
        //        }
        //        if (video.thongSo.ThongSoThumbnail_ghiTieuDeVaoThumbnail)
        //        {
        //            string tieuDeBaiViet = video.tieuDeBaiViet;
        //            string str7 = "";
        //            int length = video.thongSo.ThongSoThumbnail_soTuGhiTieuDe;
        //            try
        //            {
        //                if (tieuDeBaiViet.Contains(" "))
        //                {
        //                    char[] separator = new char[] { ' ' };
        //                    string[] strArray = tieuDeBaiViet.Split(separator);
        //                    if (length > strArray.Length)
        //                    {
        //                        str7 = tieuDeBaiViet;
        //                    }
        //                    else
        //                    {
        //                        for (int i = 0; i < length; i++)
        //                        {
        //                            if (i == (length - 1))
        //                            {
        //                                str7 = str7 + strArray[i];
        //                            }
        //                            else
        //                            {
        //                                str7 = str7 + strArray[i] + " ";
        //                            }
        //                        }
        //                    }
        //                }
        //                else if (length > tieuDeBaiViet.Length)
        //                {
        //                    str7 = tieuDeBaiViet;
        //                }
        //                else
        //                {
        //                    str7 = tieuDeBaiViet.Substring(0, length);
        //                }
        //            }
        //            catch (Exception)
        //            {
        //                str7 = tieuDeBaiViet;
        //            }
        //            string contents = "";
        //            try
        //            {
        //                char[] chArray2 = new char[] { ' ' };
        //                string[] strArray2 = str7.Split(chArray2);
        //                int num10 = video.thongSo.ThongSoThumbnail_soTuTren1Dong;
        //                if (strArray2.Length >= num10)
        //                {
        //                    for (int j = 0; j < strArray2.Length; j++)
        //                    {
        //                        contents = contents + strArray2[j] + " ";
        //                        if (j == (num10 - 1))
        //                        {
        //                            num10 += video.thongSo.ThongSoThumbnail_soTuTren1Dong;
        //                            if (video.thongSo.ThongSoThumbnail_cach1dong)
        //                            {
        //                                contents = contents + "\r\n";
        //                            }
        //                            contents = contents + "\r\n";
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    contents = str7 + "\r\n";
        //                }
        //            }
        //            catch (Exception)
        //            {
        //                contents = str7 + "\r\n";
        //            }
        //            string str9 = video.ThuMucTemp + @"\textTieuDe.txt";
        //            File.WriteAllText(str9, contents);
        //            int num5 = video.thongSo.ThongSoThumbnail_coChuGhiTieuDe;
        //            string str10 = (Application.StartupPath + @"\1.ThongSo\Fonts\" + video.thongSo.ThongSoThumbnail_txtFontChu).Replace(@"\", @"\\").Insert(1, @"\");
        //            string str11 = video.thongSo.ThongSoThumbnail_mauGhiTieuDe;
        //            int num6 = video.thongSo.ThongSoThumbnail_cachTrai;
        //            int num7 = video.thongSo.ThongSoThumbnail_cachTren;
        //            string str12 = video.thongSo.ThongSoThumbnail_mauVienGhiTieuDe;
        //            int num8 = video.thongSo.ThongSoThumbnail_doToVien;
        //            str9 = str9.Replace(@"\", @"\\").Insert(1, @"\");
        //            format = " -y -loop 1 -i \"{0}\" -vf \"drawtext=textfile='{1}':fontfile='{2}':fontcolor={3}:fontsize={4}:x={5}:y={6}:shadowx=2:shadowy=2:bordercolor={7}:borderw={8}\" -vframes 1 -f image2 -preset ultrafast \"{9}\"";
        //            format = string.Format(format, new object[] { path, str9, str10, str11, num5, num6, num7, str12, num8, filename });
        //            info = new ProcessStartInfo
        //            {
        //                FileName = Controller.localFFmpeg,
        //                Arguments = format,
        //                UseShellExecute = false,
        //                RedirectStandardError = true,
        //                CreateNoWindow = true,
        //                RedirectStandardOutput = true,
        //                WindowStyle = ProcessWindowStyle.Normal
        //            };
        //            process = new Process
        //            {
        //                StartInfo = info
        //            };
        //            process.ErrorDataReceived += new DataReceivedEventHandler(Controller.p_ErrorDataReceived);
        //            process.Start();
        //            process.BeginErrorReadLine();
        //            process.WaitForExit();
        //        }
        //        else
        //        {
        //            filename = path;
        //        }
        //        if (video.thongSo.ThongSoThumbnail_taoVienThumbnail)
        //        {
        //            using (Bitmap bitmap2 = new Bitmap(filename))
        //            {
        //                using (Graphics graphics = Graphics.FromImage(bitmap2))
        //                {
        //                    graphics.DrawRectangle(new Pen(ColorTranslator.FromHtml(video.thongSo.ThongSoThumbnail_mauVienThumbnail), (float)video.thongSo.ThongSoThumbnail_sizeVienThumbnail), new Rectangle(0, 0, bitmap2.Width, bitmap2.Height));
        //                }
        //                bitmap2.Save(str3);
        //            }
        //        }
        //        else
        //        {
        //            str3 = filename;
        //        }
        //        if (File.Exists(str3))
        //        {
        //            try
        //            {
        //                File.Copy(str3, video.ThumbnailVideoHoanThanh);
        //            }
        //            catch (Exception)
        //            {
        //                this.setTrangThai("Lỗi tạo Thumbnail", video);
        //                return false;
        //            }
        //            this.setTrangThai("Đ\x00e3 tạo xong Thumbnail", video);
        //            return true;
        //        }
        //        this.setTrangThai("Lỗi tạo Thumbnail", video);
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        this.setTrangThai("Lỗi tạo Thumbnail", video);
        //        return false;
        //    }
        //}

    }
}
