using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;
using System.IO;

namespace Loogn.Common
{
    public static class ImageHelper
    {
        /// <summary>
        /// 判断文件是否有图片的后缀名
        /// </summary>
        /// <param name="fileName">文件</param>
        /// <returns></returns>
        public static bool IsImage(string fileName)
        {
            var ext = System.IO.Path.GetExtension(fileName);
            if (string.IsNullOrEmpty(ext))
                return false;

            switch (ext.ToUpper())
            {
                case "GIF":
                case "JPEG":
                case "JPG":
                case "BMP":
                case "PNG":
                case "ICO":
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// 得到图片格式
        /// </summary>
        /// <param name="ext">图片后缀 如: gif或.gif</param>
        /// <returns></returns>
        public static ImageFormat GetFormate(string ext)
        {
            switch (ext.ToUpper())
            {
                case ".GIF":
                case "GIF":
                    return ImageFormat.Gif;
                case "JPEG":
                case "JPG":
                case ".JPEG":
                case ".JPG":
                    return ImageFormat.Jpeg;
                case ".BMP":
                case "BMP":
                    return ImageFormat.Bmp;
                case ".PNG":
                case "PNG":
                    return ImageFormat.Png;
                case ".ICO":
                case "ICO":
                    return ImageFormat.Icon;
                default:
                    throw new Exception("无效的图片格式！");
            }
        }

        /// <summary>
        /// 缩略图
        /// </summary>
        /// <param name="img">图片对象</param>
        /// <param name="maxWidth">最大宽度</param>
        /// <param name="maxHeight">最大高度</param>
        /// <param name="isAutoSize">是否在最大高宽中自适大小</param>
        /// <returns></returns>
        public static Image GetThumbImage(Image img, int maxWidth, int maxHeight, bool isAutoSize = true)
        {
            int tWidth;
            int tHeight;
            if (!isAutoSize)
            {
                tWidth = maxWidth;
                tHeight = maxHeight;
            }
            else
            {
                if (!(maxHeight > img.Height && maxWidth > img.Width))
                {
                    float HeightMultipier = (float)maxHeight / (float)img.Height;
                    float WidthMultipier = (float)maxWidth / (float)img.Width;
                    if (HeightMultipier > 1) HeightMultipier = 1;
                    if (WidthMultipier > 1) WidthMultipier = 1;
                    float SizeMultiplier = WidthMultipier < HeightMultipier ? WidthMultipier : HeightMultipier;
                    tWidth = (int)(img.Width * SizeMultiplier);
                    tHeight = (int)(img.Height * SizeMultiplier);
                }
                else
                {
                    tWidth = img.Width;
                    tHeight = img.Height;
                }
            }
            Image bitmap = new Bitmap(tWidth, tHeight);
            //新建一个画板
            Graphics g = Graphics.FromImage(bitmap);
            g.CompositingQuality = CompositingQuality.AssumeLinear;

            //设置高质量插值法
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);
            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(img, new Rectangle(0, 0, tWidth, tHeight),
                new Rectangle(1, 1, img.Width - 1, img.Height - 1),
                GraphicsUnit.Pixel);
            return bitmap;
        }

        
        /// <summary>
        /// 剪切图
        /// </summary>
        /// <param name="img"></param>
        /// <param name="width">剪切宽度</param>
        /// <param name="height">剪切高度</param>
        /// <param name="offsetX">右偏移</param>
        /// <param name="offsetY">下偏移</param>
        /// <returns></returns>
        public static Image GetCuteImage(Image img, int width, int height, int offsetX, int offsetY)
        {
            width = Math.Min(img.Width - offsetX, width);
            height = Math.Min(img.Height - offsetY, height);
            Image newBitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.InterpolationMode = InterpolationMode.High;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(img, new Rectangle(0, 0, width, height), new Rectangle(offsetX, offsetY, width, height), GraphicsUnit.Pixel);
                g.Save();
            }
            return newBitmap;
        }

        #region 水印
        /// <summary>
        /// 文字水印
        /// </summary>
        /// <param name="img"></param>
        /// <param name="watermarkText">水印文字</param>
        /// <param name="watermarkStatus">图片水印位置 0=不使用 1=左上 2=中上 3=右上 4=左中  9=右下</param>
        /// <param name="fontname">字体</param>
        /// <param name="fontsize">字体大小</param>
        public static Image TextWatermark(Image img, string watermarkText, int watermarkStatus, Font drawFont)
        {
            Graphics g = Graphics.FromImage(img);
            SizeF crSize;
            crSize = g.MeasureString(watermarkText, drawFont);
            float xpos = 0;
            float ypos = 0;

            switch (watermarkStatus)
            {
                case 1:
                    xpos = (float)img.Width * (float).01;
                    ypos = (float)img.Height * (float).01;
                    break;
                case 2:
                    xpos = ((float)img.Width * (float).50) - (crSize.Width / 2);
                    ypos = (float)img.Height * (float).01;
                    break;
                case 3:
                    xpos = ((float)img.Width * (float).99) - crSize.Width;
                    ypos = (float)img.Height * (float).01;
                    break;
                case 4:
                    xpos = (float)img.Width * (float).01;
                    ypos = ((float)img.Height * (float).50) - (crSize.Height / 2);
                    break;
                case 5:
                    xpos = ((float)img.Width * (float).50) - (crSize.Width / 2);
                    ypos = ((float)img.Height * (float).50) - (crSize.Height / 2);
                    break;
                case 6:
                    xpos = ((float)img.Width * (float).99) - crSize.Width;
                    ypos = ((float)img.Height * (float).50) - (crSize.Height / 2);
                    break;
                case 7:
                    xpos = (float)img.Width * (float).01;
                    ypos = ((float)img.Height * (float).99) - crSize.Height;
                    break;
                case 8:
                    xpos = ((float)img.Width * (float).50) - (crSize.Width / 2);
                    ypos = ((float)img.Height * (float).99) - crSize.Height;
                    break;
                case 9:
                    xpos = ((float)img.Width * (float).99) - crSize.Width;
                    ypos = ((float)img.Height * (float).99) - crSize.Height;
                    break;
            }

            g.DrawString(watermarkText, drawFont, new SolidBrush(Color.White), xpos + 1, ypos + 1);
            g.DrawString(watermarkText, drawFont, new SolidBrush(Color.Black), xpos, ypos);

            return img;
        }

        /// <summary>
        /// 图片水印
        /// </summary>
        /// <param name="imgPath">服务器图片相对路径</param>
        /// <param name="filename">保存文件名</param>
        /// <param name="watermarkFilename">水印文件相对路径</param>
        /// <param name="watermarkStatus">图片水印位置 0=不使用 1=左上 2=中上 3=右上 4=左中  9=右下</param>
        /// <param name="watermarkTransparency">水印的透明度 1--10 10为不透明</param>
        public static Image AddImageSignPic(Image img, Image watermark, int watermarkStatus, int watermarkTransparency)
        {
            Graphics g = Graphics.FromImage(img);
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (watermark.Height >= img.Height || watermark.Width >= img.Width)
                return null;

            ImageAttributes imageAttributes = new ImageAttributes();
            ColorMap colorMap = new ColorMap();

            colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
            colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
            ColorMap[] remapTable = { colorMap };

            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            float transparency = 0.5F;
            if (watermarkTransparency >= 1 && watermarkTransparency <= 10)
                transparency = (watermarkTransparency / 10.0F);


            float[][] colorMatrixElements = {
												new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
												new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
												new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
												new float[] {0.0f,  0.0f,  0.0f,  transparency, 0.0f},
												new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
											};

            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);

            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            int xpos = 0;
            int ypos = 0;

            switch (watermarkStatus)
            {
                case 1:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 2:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 3:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)(img.Height * (float).01);
                    break;
                case 4:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 5:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 6:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)((img.Height * (float).50) - (watermark.Height / 2));
                    break;
                case 7:
                    xpos = (int)(img.Width * (float).01);
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
                case 8:
                    xpos = (int)((img.Width * (float).50) - (watermark.Width / 2));
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
                case 9:
                    xpos = (int)((img.Width * (float).99) - (watermark.Width));
                    ypos = (int)((img.Height * (float).99) - watermark.Height);
                    break;
            }
            g.DrawImage(watermark, new Rectangle(xpos, ypos, watermark.Width, watermark.Height), 0, 0, watermark.Width, watermark.Height, GraphicsUnit.Pixel, imageAttributes);

            return img;
        }
        #endregion


        public static void WriteCheckCode(HttpContext context,string chkCode)
        {
            //颜色列表，用于验证码、噪线、噪点
            Color[] color = { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Brown, Color.DarkBlue, Color.Teal };

            //字体列表，用于验证码
            string[] font = { "Gungsuh", "宋体" };

            //验证码的字符集

            using (Bitmap bmp = new Bitmap(60, 20))
            {
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.White);
                //画验证码字符串
                Random rnd = new Random();
                Pen borderP = new Pen(color[rnd.Next(color.Length)]);
                for (int i = 0; i < chkCode.Length; i++)
                {
                    string fnt = font[rnd.Next(font.Length)];
                    Font ft = new Font(fnt, 14, FontStyle.Bold);
                    Color clr = color[rnd.Next(color.Length)];
                    g.DrawString(chkCode[i].ToString(), ft, new SolidBrush(clr), i * 13, 0);
                }
                //画噪点
                for (int i = 0; i < 100; i++)
                {
                    int x = rnd.Next(bmp.Width);
                    int y = rnd.Next(bmp.Height);
                    Color clr = color[rnd.Next(color.Length)];
                    bmp.SetPixel(x, y, clr);
                }
                //清除该页输出缓存，设置该页无缓存
                context.Response.Buffer = true;
                context.Response.ExpiresAbsolute = System.DateTime.Now.AddMilliseconds(0);
                context.Response.Expires = 0;
                context.Response.CacheControl = "no-cache";
                context.Response.AppendHeader("Pragma", "No-Cache");
                //将验证码图片写入内存流,并并将其以是 “image/Png” 格式输出
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Png);
                    context.Response.ClearContent();
                    context.Response.ContentType = "image/Png";
                    context.Response.BinaryWrite(ms.ToArray());
                }
            }
        }
    }
}
