using AForge.Video.FFMPEG;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace UpLoadNews
{
    public class CreateVideoNotEffects
    {
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

           // destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public void CreateVideo(string[] pathImage, int time, string outputpath)
        {
            try
            {
                int width = 1280;
                int height = 720;
                // get time by mm
                int countFame = 25;
                VideoFileWriter writer = new VideoFileWriter();
                writer.Open(outputpath, width, height, countFame, VideoCodec.MPEG4, 1000000);
                time = time* countFame;
                int countvideo = pathImage.Length;
                float sodu = time % countvideo;
                int thuong = time / countvideo;
                for (int i = 0; i < pathImage.Length; i++)
                {
                    if (sodu == 0)
                    {
                        try
                        {
                            Image imganh = Image.FromFile(pathImage[i].ToString());
                            Bitmap bitmapnew = (Bitmap)ResizeImage(imganh,1280,720);
                            for (int j = 0; j < thuong; j++)
                            {
                                writer.WriteVideoFrame(bitmapnew);
                            }
                            imganh.Dispose();
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            Image imganh = Image.FromFile(pathImage[i].ToString());
                            Bitmap bitmapnew = (Bitmap)ResizeImage(imganh, 1280, 720);
                            if (i == (pathImage.Length - 1))
                            {
                                for (int j = 0; j < thuong + sodu; j++)
                                {
                                    writer.WriteVideoFrame(bitmapnew);
                                }
                            }
                            else
                            {
                                for (int j = 0; j < thuong; j++)
                                {
                                    writer.WriteVideoFrame(bitmapnew);
                                }
                            }
                            imganh.Dispose();
                        }
                        catch { }
                    }

                }

                //Bitmap image = new Bitmap(width, height);
                //Graphics g = Graphics.FromImage(image);              
                //g.Save();
                //g.Dispose();
                //for (int i = 0; i < 125; i++)
                //{
                //    writer.WriteVideoFrame(image);
                //}
                //image.Dispose();
                writer.Close();
            }
            catch { }
        }

    }
}
