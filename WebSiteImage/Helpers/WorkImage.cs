using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace WebSiteImage.Helpers
{
    public static class WorkImage
    {
        public static Bitmap CreateImage(HttpPostedFileBase hpf, int maxWidth, int maxHeight) //800x600
        {
            if (hpf != null && hpf.ContentLength != 0 && hpf.ContentLength <= 10048576)
            {
                try
                {
                    using (Bitmap originalPic = new Bitmap(hpf.InputStream, true))
                    {
                        int originalWidth = originalPic.Width;  //1920
                        int originalHeight = originalPic.Height; //1080
                        float rationX = (float)maxWidth / (float)originalWidth; //0.4166666666666667
                        float rationY = (float)maxHeight / (float)originalHeight; //0.5555555555555556
                        float ration = Math.Min(rationX, rationY); //0.4166666666666667
                        int width = (int)Math.Round(originalWidth * ration); //800.0000000000001
                        int height = (int)Math.Round(originalHeight * ration);//450
                        Bitmap outBmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                        using (Graphics oGraphics = Graphics.FromImage(outBmp))
                        {
                            oGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            oGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            oGraphics.DrawImage(originalPic, 0, 0, width, height);
                            //Можна далі малювати все що хочете хоть водняний знак
                            return outBmp;
                        }

                    }
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }
    }
}