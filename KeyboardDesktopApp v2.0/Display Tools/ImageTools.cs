using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace KeyboardDesktopApp_v2._0.DisplayTools {
    class ImageTools {

        static internal Image FixSize(Image imgPhoto, int Width, int Height) {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW) {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width -
                              (sourceWidth * nPercent)) / 2);
            } else {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height,
                              PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.White);
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        internal static byte[][] horizontalFlip(byte[][] data) {
            for (int i = 0; i < data.Length; i++) {
                Array.Reverse(data[i]);
            }
            return data;
        }

        static internal void MakeBW(Image SourceImage) {
            using (Graphics gr = Graphics.FromImage(SourceImage)) // SourceImage is a Bitmap object
            {
                var gray_matrix = new float[][] {
                new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                new float[] { 0,      0,      0,      1, 0 },
                new float[] { 0,      0,      0,      0, 1 }
            };

                var ia = new System.Drawing.Imaging.ImageAttributes();
                ia.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(gray_matrix));
                ia.SetThreshold(0.8f); // Change this threshold as needed
                var rc = new Rectangle(0, 0, SourceImage.Width, SourceImage.Height);
                gr.DrawImage(SourceImage, rc, 0, 0, SourceImage.Width, SourceImage.Height, GraphicsUnit.Pixel, ia);
                gr.Dispose();
            }
        }

        static internal Image ByteArrayToImage(int width, int height, byte[] imageData, PixelFormat pixelFormat) {
            byte[] newData = new byte[imageData.Length];

            
            var bmp = new Bitmap(width, height, pixelFormat);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0,
                                                            bmp.Width,
                                                            bmp.Height),
                                                ImageLockMode.ReadWrite,
                                                bmp.PixelFormat);

            IntPtr pNative = bmpData.Scan0;
            Marshal.Copy(imageData, 0, pNative, imageData.Length);

            bmp.UnlockBits(bmpData);

                
            return bmp;
            
        }
    }
}