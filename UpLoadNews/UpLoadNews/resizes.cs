using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace UpLoadNews
{
   public  class resizes
    {
        public static System.Drawing.Bitmap getResizedImage(string psFilePath,
        int width, int height)
        {
            var destImage = new Bitmap(width, height);

            try
            {
                Image image = Image.FromFile(psFilePath);
                var destRect = new Rectangle(0, 0, width, height);             

                //destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

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
            }
            catch
            {
                Image image = Image.FromFile(psFilePath);
                var destRect = new Rectangle(0, 0, width, height);
               
                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

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
            }
            return destImage;
        }
        public static System.Drawing.Bitmap getResizedImage_2(Image image,
       int width, int height)
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

        public static void _ResizeImage(string _input,string _output,int width,int height)
        {
            Image img2 = (Image)getResizedImage(_input, width, height);
            String jpg3 = _output;
            Bitmap img3 = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(img3);           
             g.DrawImage(img2, new Point(0, 0));           
            g.Dispose();
            img2.Dispose();
            img3.Save(jpg3, System.Drawing.Imaging.ImageFormat.Png);
            img3.Dispose();

        }

        public static void _BackgroupImage(string _input, string _output,int _blur)
        {
            Image img1 = (Image)getResizedImage(_input, 1280, 720);         
            Bitmap bitmap = new Bitmap(img1);
            bitmap = Blur.Blurs(bitmap, 3);
            Image img2 = (Image)bitmap;
            String jpg3 = _output;
            Bitmap img3 = new Bitmap(1280, 720);
            Graphics g = Graphics.FromImage(img3);
            g.DrawImage(img2, new Point(0, 0));
            g.Dispose();
            img2.Dispose();
            img3.Save(jpg3, System.Drawing.Imaging.ImageFormat.Png);
            img3.Dispose();

        }


        public static void MergeImageNotZoomToCenter(string anh, string fileoutput)
        {
            Image imganh = Image.FromFile(anh);
            Bitmap bitmapnew =CreateVideoNotEffects.ResizeImage(imganh, 1080,720);
            Graphics g = Graphics.FromImage(bitmapnew);
            g.Dispose();
            bitmapnew.Save(fileoutput, System.Drawing.Imaging.ImageFormat.Jpeg);
            bitmapnew.Dispose();

        }

        public static void MergeImageToCenter(string anh, string fileoutput)
        { 
            //Image img1 = (Image)getResizedImage(anh, 1280, 720);
            
            Image img2 = (Image)getResizedImage(anh, 540, 360);
            int width = img2.Width;
            int height = img2.Height;
            String jpg3 = fileoutput;
            Bitmap img3 = new Bitmap(1080, 720);
            Graphics g = Graphics.FromImage(img3);
            Color color = Color.White;
            if (width == 540 && height == 360)
            {
                g.DrawRectangle(new Pen(color, 8), new Rectangle(width - img2.Width / 2, height - img2.Height / 2, img2.Width, img2.Height));
                g.DrawImage(img2, new Point(width - img2.Width / 2, height - img2.Height / 2));
            }
            else
            {
                g.DrawImage(img2, new Point(width - img2.Width / 2, height - img2.Height / 2));
            }
            g.Dispose();           
            img2.Dispose();
            img3.Save(jpg3, System.Drawing.Imaging.ImageFormat.Png);
            img3.Dispose();

        }
        public static void VeThumnail(string anh,string fileoutput,Color color)
        {
            Image img2 = (Image)getResizedImage(anh, 540, 360);
            int width = img2.Width;
            int height = img2.Height;
            String jpg3 = fileoutput;
            Bitmap img3 = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(img3);
            g.DrawRectangle(new Pen(color, 16), new Rectangle(0, 0, img2.Width, img2.Height));
            g.DrawImage(img2, new Point(0,0));
            g.Dispose();
            img2.Dispose();
            img3.Save(jpg3, System.Drawing.Imaging.ImageFormat.Png);
            img3.Dispose();
        }
        public static void MergeImageToCenterBG(string anh,string anhnen,string fileoutput)
        {
            Image img1 = Image.FromFile(anhnen);
            Image img2 = Image.FromFile(anh);
            int width = img2.Width;
            int height = img2.Height;
            String jpg3 = fileoutput;
            Bitmap img3 = new Bitmap(1080, 720);
            Graphics g = Graphics.FromImage(img3);
            Color color = Color.White;
            g.DrawImage(img1, new Point(0,0));
            //g.DrawRectangle(new Pen(color, 8), new Rectangle(width - img2.Width / 2, height - img2.Height / 2, img2.Width, img2.Height));
            g.DrawImage(img2, new Point(0, 0));            
            g.Dispose();
            img1.Dispose();
            img2.Dispose();            
            img3.Save(jpg3, System.Drawing.Imaging.ImageFormat.Png);
            img3.Dispose();

        }

        public static void Thumnail(string anhbg,string logo, string fileoutput)
        {
           
            Image img2 = (Image)getResizedImage(logo, 50, 50);
            int width = img2.Width;
            int height = img2.Height;
            String jpg3 = fileoutput;
            Bitmap img3 = new Bitmap(anhbg);
            Graphics g = Graphics.FromImage(img3);                   
            g.DrawImage(img2, new Point(width - img2.Width / 2, height - img2.Height / 2));            
            g.Dispose();
            img2.Dispose();
            img3.Save(jpg3, System.Drawing.Imaging.ImageFormat.Jpeg);
            img3.Dispose();

        }


        public static void ThumnailConfigBorder(string anhbg,string outputemp,Color m_color,int sizeborder,string output)
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(anhbg))
                {
                    double width = bitmap.Width;
                    double height = bitmap.Height;
                    double num3 = width / height;
                    if (num3 <= 0.8)
                    {
                        RunFFMPEG ffrunscale = new RunFFMPEG();
                       // string.Format(@"-i {0} -filter:a ""volume =1.5"" {1}", _voiceaudio, voicexuly);
                        string textArray1 = string.Format("-i {0} -vf \"crop=iw:iw*9/16:0:0,scale=1280:720\" {1} ",anhbg, outputemp);
                        ffrunscale.RunCommand(textArray1, true);
                    }
                    else
                    {
                        RunFFMPEG ffrunscale = new RunFFMPEG();
                        string textArray2 = string.Format("-i {0} -filter_complex \"scale=1280:720\" {1} ",anhbg, outputemp);
                        ffrunscale.RunCommand(textArray2, true);
                    }
                }
                using (Bitmap bitmap2 = new Bitmap(outputemp))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap2))
                    {
                       
                        graphics.DrawRectangle(new Pen(m_color, sizeborder), new Rectangle(0, 0, bitmap2.Width, bitmap2.Height));
                    }
                    bitmap2.Save(output);
                }

            }
            catch
            {
               
            }
           
        }

        public static void ThumnailConfigLogo(string anhbg,string logo,string logotemp,  string output)
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(logo))
                {
                    double width = bitmap.Width;
                    double height = bitmap.Height;
                    double num3 = width / height;
                    if (num3 <= 0.8)
                    {
                        RunFFMPEG ffrunscale = new RunFFMPEG();
                        // string.Format(@"-i {0} -filter:a ""volume =1.5"" {1}", _voiceaudio, voicexuly);
                        string textArray1 = string.Format("-i {0} -vf \"crop=iw:iw*9/16:0:0,scale=80:80\" {1} ", logo, logotemp);
                        ffrunscale.RunCommand(textArray1, true);
                    }
                    else
                    {
                        RunFFMPEG ffrunscale = new RunFFMPEG();
                        string textArray2 = string.Format("-i {0} -filter_complex \"scale=80:80\" {1} ", logo, logotemp);
                        ffrunscale.RunCommand(textArray2, true);
                    }
                }
                Image img2 = Image.FromFile(logotemp);
                Bitmap img3 = new Bitmap(anhbg);
                Graphics g = Graphics.FromImage(img3);
                g.DrawImage(img2, new Point(15,15));
                g.Dispose();
                img2.Dispose();
                img3.Save(output, System.Drawing.Imaging.ImageFormat.Jpeg);
                img3.Dispose();
            }
            catch
            {

            }

        }

        public static void ThumnailConfigLogoVideo(string anhbg, string logo, string logotemp, string output)
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(logo))
                {
                    double width = bitmap.Width;
                    double height = bitmap.Height;
                    double num3 = width / height;
                    if (num3 <= 0.8)
                    {
                        RunFFMPEG ffrunscale = new RunFFMPEG();
                        // string.Format(@"-i {0} -filter:a ""volume =1.5"" {1}", _voiceaudio, voicexuly);
                        string textArray1 = string.Format("-i {0} -vf \"crop=iw:iw*9/16:0:0,scale=40:40\" {1} ", logo, logotemp);
                        ffrunscale.RunCommand(textArray1, true);
                    }
                    else
                    {
                        RunFFMPEG ffrunscale = new RunFFMPEG();
                        string textArray2 = string.Format("-i {0} -filter_complex \"scale=40:40\" {1} ", logo, logotemp);
                        ffrunscale.RunCommand(textArray2, true);
                    }
                }
                Image img2 = Image.FromFile(logotemp);
                Bitmap img3 = new Bitmap(anhbg);
                Graphics g = Graphics.FromImage(img3);
                g.DrawImage(img2, new Point(15, 15));
                g.Dispose();
                img2.Dispose();
                img3.Save(output, System.Drawing.Imaging.ImageFormat.Jpeg);
                img3.Dispose();
            }
            catch
            {

            }

        }

        public static void ThumnailConfigTitle(string anhbg, string title,  string output)
        {
            Image img1 = Image.FromFile(title);
            String jpg3 = output;
            Bitmap img3 = new Bitmap(anhbg);
            Graphics g = Graphics.FromImage(img3);
            g.DrawImage(img1, new Point(1280 / 2 - img1.Width / 2, 720 - img1.Height - 15));
            g.Dispose();
            img1.Dispose();
            img3.Save(jpg3, System.Drawing.Imaging.ImageFormat.Jpeg);
            img3.Dispose();

        }

    }
}
