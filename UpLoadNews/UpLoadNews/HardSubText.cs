using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;

namespace UpLoadNews
{
    public class HardSubText
    {
        public void DrawText(String text, Font font, Color textColor, int maxWidth, Color colorborder, int sizeborder, String path)
        {
            //first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);
            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font, maxWidth);
            //set the stringformat flags to rtl
            StringFormat sf = new StringFormat();
            //uncomment the next line for right to left languages
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();
            //create a new image of the right size
            img = new Bitmap((int)textSize.Width, (int)textSize.Height);
            // img = new Bitmap(1280,720);
            drawing = Graphics.FromImage(img);
            //Adjust for high quality
            drawing.CompositingQuality = CompositingQuality.HighQuality;
            drawing.InterpolationMode = InterpolationMode.HighQualityBilinear;
            drawing.PixelOffsetMode = PixelOffsetMode.HighQuality;
            drawing.SmoothingMode = SmoothingMode.HighQuality;
            drawing.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            //paint the background
            drawing.Clear(Color.Transparent);
            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);
            //  drawing.DrawString(text, font, textBrush, new RectangleF(0, 0, textSize.Width, textSize.Height), sf);
            // drawing.DrawString(text, font, textBrush, new PointF(60, 60), sf);
            GraphicsPath p = new GraphicsPath();
            p.AddString(
               text,             // text to draw
                font.FontFamily,  // or any other font family
                (int)font.Style,      // font style (bold, italic, etc.)
                drawing.DpiY * font.Size / 72,       // em size                
                new RectangleF(0, 0, textSize.Width, textSize.Height),              // location where to draw text
                sf);          // set options here (e.g. center alignment)
            drawing.DrawPath(new Pen(colorborder, sizeborder), p);

            GraphicsPath p2 = new GraphicsPath();
            Brush b = new SolidBrush(textColor);
            p2.AddString(
               text,             // text to draw
                font.FontFamily,  // or any other font family
                (int)font.Style,      // font style (bold, italic, etc.)
                drawing.DpiY * font.Size / 72,       // em size                
                new RectangleF(0, 0, textSize.Width, textSize.Height),              // location where to draw text
                sf);          // set options here (e.g. center alignment)
            drawing.FillPath(b, p2);


            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            img.Save(path, ImageFormat.Png);
            img.Dispose();

        }

        public void DrawTextTitle(String text, Font font, Color textColor, int maxWidth, Color colorborder, int sizeborder, String path)
        {
            //first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);
            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font, maxWidth);
            //set the stringformat flags to rtl
            StringFormat sf = new StringFormat();
            //uncomment the next line for right to left languages
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();
            //create a new image of the right size
            img = new Bitmap((int)textSize.Width, (int)textSize.Height);
            // img = new Bitmap(1280,720);
            drawing = Graphics.FromImage(img);
            //Adjust for high quality
            drawing.CompositingQuality = CompositingQuality.HighQuality;
            drawing.InterpolationMode = InterpolationMode.HighQualityBilinear;
            drawing.PixelOffsetMode = PixelOffsetMode.HighQuality;
            drawing.SmoothingMode = SmoothingMode.HighQuality;
            drawing.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            //paint the background
            drawing.Clear(Color.Transparent);
            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);
            //  drawing.DrawString(text, font, textBrush, new RectangleF(0, 0, textSize.Width, textSize.Height), sf);
            // drawing.DrawString(text, font, textBrush, new PointF(60, 60), sf);
            GraphicsPath p = new GraphicsPath();
            p.AddString(
               text,             // text to draw
                font.FontFamily,  // or any other font family
                (int)font.Style,      // font style (bold, italic, etc.)
                drawing.DpiY * font.Size / 72,       // em size                
                new RectangleF(0, 0, textSize.Width, textSize.Height),              // location where to draw text
                sf);          // set options here (e.g. center alignment)
            drawing.DrawPath(new Pen(colorborder, sizeborder), p);

            GraphicsPath p2 = new GraphicsPath();
            Brush b = new SolidBrush(textColor);
            p2.AddString(
               text,             // text to draw
                font.FontFamily,  // or any other font family
                (int)font.Style,      // font style (bold, italic, etc.)
                drawing.DpiY * font.Size / 72,       // em size                
                new RectangleF(0, 0, textSize.Width, textSize.Height),              // location where to draw text
                sf);          // set options here (e.g. center alignment)
            drawing.FillPath(b, p2);


            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            img.Save(path, ImageFormat.Jpeg);
            img.Dispose();

        }

        public void DrawTextLeft(String text, Font font, Color textColor, int maxWidth, Color colorborder, int sizeborder, String path)
        {
            //first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);
            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font, maxWidth);
            //set the stringformat flags to rtl
            StringFormat sf = new StringFormat();
            //uncomment the next line for right to left languages
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Near;
            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();
            //create a new image of the right size
            img = new Bitmap((int)textSize.Width, (int)textSize.Height);
            // img = new Bitmap(1280,720);
            drawing = Graphics.FromImage(img);
            //Adjust for high quality
            drawing.CompositingQuality = CompositingQuality.HighQuality;
            drawing.InterpolationMode = InterpolationMode.HighQualityBilinear;
            drawing.PixelOffsetMode = PixelOffsetMode.HighQuality;
            drawing.SmoothingMode = SmoothingMode.HighQuality;
            drawing.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            //paint the background
            drawing.Clear(Color.Transparent);
            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);
            //  drawing.DrawString(text, font, textBrush, new RectangleF(0, 0, textSize.Width, textSize.Height), sf);
            // drawing.DrawString(text, font, textBrush, new PointF(60, 60), sf);
            GraphicsPath p = new GraphicsPath();
            p.AddString(
               text,             // text to draw
                font.FontFamily,  // or any other font family
                (int)font.Style,      // font style (bold, italic, etc.)
                drawing.DpiY * font.Size / 72,       // em size                
                new RectangleF(0, 0, textSize.Width, textSize.Height),              // location where to draw text
                sf);          // set options here (e.g. center alignment)
            drawing.DrawPath(new Pen(colorborder, sizeborder), p);

            GraphicsPath p2 = new GraphicsPath();
            Brush b = new SolidBrush(textColor);
            p2.AddString(
               text,             // text to draw
                font.FontFamily,  // or any other font family
                (int)font.Style,      // font style (bold, italic, etc.)
                drawing.DpiY * font.Size / 72,       // em size                
                new RectangleF(0, 0, textSize.Width, textSize.Height),              // location where to draw text
                sf);          // set options here (e.g. center alignment)
            drawing.FillPath(b, p2);


            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            img.Save(path, ImageFormat.Png);
            img.Dispose();

        }

        public void DrawTextProshow(string input, string fileoutput)
        {

            Image img1 = Image.FromFile(input);            
            String jpg3 = fileoutput;
            Bitmap img3 = new Bitmap(1290, 960);
            Graphics g = Graphics.FromImage(img3);
            g.DrawImage(img1, new Point(1290 / 2 - img1.Width / 2, 960 - img1.Height - 4));
            g.Dispose();
            img1.Dispose();
           
            img3.Save(jpg3, System.Drawing.Imaging.ImageFormat.Png);
            img3.Dispose();

        }
        public void DrawTextProshow2(string input, string fileoutput)
        {

            Image img1 = Image.FromFile(input);
            String jpg3 = fileoutput;
            Bitmap img3 = new Bitmap(1750, 960);
            Graphics g = Graphics.FromImage(img3);
            g.DrawImage(img1, new Point(1750 / 2 - img1.Width / 2, 960 - img1.Height - 4));
            g.Dispose();
            img1.Dispose();

            img3.Save(jpg3, System.Drawing.Imaging.ImageFormat.Png);
            img3.Dispose();

        }
        public void MegPic(string[] manganh, string output)
        {
            int width = 0;
            int height = 0;
            Image imganhdautien = Image.FromFile(manganh[0].ToString());
            width = imganhdautien.Width;
            for (int i = 0; i < manganh.Length; i++)
            {
                string duongdananh = manganh[i].ToString();
                Image imganh = Image.FromFile(duongdananh);
                if (width < imganh.Width)
                {
                    width = imganh.Width;
                }
                height = height + imganh.Height;
                imganh.Dispose();
            }
            Bitmap imguotput = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(imguotput);
            int poin_y = 0;
            for (int i = 0; i < manganh.Length; i++)
            {
                string duongdananh = manganh[i].ToString();
                Image imganh = Image.FromFile(duongdananh);
                g.DrawImage(imganh, new Point(0, poin_y));
                poin_y = poin_y + imganh.Height + 2;
                imganh.Dispose();
            }
            g.Dispose();

            imguotput.Save(output, System.Drawing.Imaging.ImageFormat.Png);
            imguotput.Dispose();
        }

        public void MegPicLeft(string[] manganh, string output)
        {
            int width = 0;
            int height = 0;
            Image imganhdautien = Image.FromFile(manganh[0].ToString());
            height = imganhdautien.Height;
            for (int i = 0; i < manganh.Length; i++)
            {
                string duongdananh = manganh[i].ToString();
                Image imganh = Image.FromFile(duongdananh);
                if (height < imganh.Height)
                {
                    height = imganh.Height;
                }
                width = width + imganh.Width + 5;
                imganh.Dispose();
            }
            Bitmap imguotput = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(imguotput);
            int poin_x = 0;
            for (int i = 0; i < manganh.Length; i++)
            {

                string duongdananh = manganh[i].ToString();

                Image imganh1 = Image.FromFile(duongdananh);
                Bitmap bitmapnew = ResizeImage(imganh1, 100, GetHeight(duongdananh));
                bitmapnew.Save(duongdananh, System.Drawing.Imaging.ImageFormat.Png);
                bitmapnew.Dispose();

                Image imganh = Image.FromFile(duongdananh);
                g.DrawImage(imganh, new Point(poin_x, 0));
                poin_x = poin_x + imganh.Width + 2;
                imganh.Dispose();

            }
            g.Dispose();

            imguotput.Save(output, System.Drawing.Imaging.ImageFormat.Png);
            imguotput.Dispose();
        }
        public void MergeImageToCenter(string[] manganh, string fileoutput)
        {

            Image img1 = Image.FromFile(manganh[0].ToString());
            // img1 = (Image)ResizeImage(img1, 1080, 720);
            Image img2 = Image.FromFile(manganh[1].ToString());
            img2 = (Image)ResizeImage(img2, 1080, 720);
            int width = img2.Width;
            int height = img2.Height;
            String jpg3 = fileoutput;
            Bitmap img3 = new Bitmap(1080, 720);
            Graphics g = Graphics.FromImage(img3);
            //  g.Clear(Color.Black);
            g.DrawImage(img2, new Point(0, 0));
            g.DrawImage(img1, new Point(width / 2 - img1.Width / 2, height / 2 - img1.Height / 2));
            g.Dispose();
            img1.Dispose();
            img2.Dispose();
            img3.Save(jpg3, System.Drawing.Imaging.ImageFormat.Png);
            img3.Dispose();

        }
        public void MergeImageThumnail(string[] manganh, string fileoutput)
        {

            Image img1 = Image.FromFile(manganh[0].ToString());
            // img1 = (Image)ResizeImage(img1, 1080, 720);
            Image img2 = Image.FromFile(manganh[1].ToString());
            img2 = (Image)ResizeImage(img2, 1080, 720);
            int width = img2.Width;
            int height = img2.Height;

            //Image img4 = Image.FromFile(manganh[2].ToString());
            //img4= (Image)ResizeImage(img4, img1.Width+10, img1.Height+10);


            String jpg3 = fileoutput;
            Bitmap img3 = new Bitmap(1080, 720);
            Graphics g = Graphics.FromImage(img3);
            //  g.Clear(Color.Black);
            Bitmap bitmap = (Bitmap)img2;

            g.DrawImage(ResizeImage(bitmap, 1080, 720), new Point(0, 0));
            Rectangle rect = new Rectangle(width / 2 - img1.Width / 2 - 3, height - img1.Height - 3, img1.Width + 4, img1.Height + 4);
            g.DrawRectangle(new Pen(Color.YellowGreen, 8), rect);
            SolidBrush redBrush = new SolidBrush(Color.OrangeRed);
            g.FillRectangle(redBrush, rect);
            g.DrawImage(img1, new Point(width / 2 - img1.Width / 2, height - img1.Height - 4));
            g.Dispose();
            img1.Dispose();
            img2.Dispose();
            //  img4.Dispose();
            img3.Save(jpg3, System.Drawing.Imaging.ImageFormat.Png);
            img3.Dispose();

        }
        public void MergeImageToBottom(string[] manganh, string fileoutput)
        {

            Image img1 = Image.FromFile(manganh[0].ToString());
            // img1 = (Image)ResizeImage(img1, 1080, 720);
            Image img2 = Image.FromFile(manganh[1].ToString());
            img2 = (Image)ResizeImage(img2, 1080, 720);
            int width = img2.Width;
            int height = img2.Height;
            String jpg3 = fileoutput;
            Bitmap img3 = new Bitmap(1080, 720);
            Graphics g = Graphics.FromImage(img3);
            //  g.Clear(Color.Black);
            g.DrawImage(img2, new Point(0, 0));
            g.DrawImage(img1, new Point(width / 2 - img1.Width / 2, height - img1.Height - 4));
            g.Dispose();
            img1.Dispose();
            img2.Dispose();
            img3.Save(jpg3, System.Drawing.Imaging.ImageFormat.Png);
            img3.Dispose();

        }
        public void MergeImageGiuNguyen(string[] manganh, string fileoutput)
        {

            Image img1 = Image.FromFile(manganh[0].ToString());
            // img1 = (Image)ResizeImage(img1, 1080, 720);
            Image img2 = Image.FromFile(manganh[1].ToString());
            img2 = (Image)ResizeImage(img2, 1080, 720);
            int width = img2.Width;
            int height = img2.Height;
            String jpg3 = fileoutput;
            Bitmap img3 = new Bitmap(1080, 720);
            Graphics g = Graphics.FromImage(img3);
            //  g.Clear(Color.Black);
            g.DrawImage(img2, new Point(0, 0));
            g.DrawImage(img1, new Point(width / 2 - img1.Width / 2, height - img1.Height - 4));
            g.Dispose();
            img1.Dispose();
            img2.Dispose();
            img3.Save(jpg3, System.Drawing.Imaging.ImageFormat.Png);
            img3.Dispose();

        }
        public Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

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

            return destImage;
        }

        public int GetHeight(string duongdan)
        {
            int height;
            Image imganh = Image.FromFile(duongdan);
            height = imganh.Height;
            imganh.Dispose();
            return height;
        }
        public int GetWidth(string duongdan)
        {
            int width;
            Image imganh = Image.FromFile(duongdan);
            width = imganh.Width;
            imganh.Dispose();
            return width;
        }
    }
}
