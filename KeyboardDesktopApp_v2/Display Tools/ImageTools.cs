using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;

namespace KeyboardDesktopApp_v2._0.DisplayTools {
    class ImageTools {

        static internal Image FixSize(Image imgPhoto, Resolution res) {
            int width = res.x;
            int height = res.y;
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)width / (float)sourceWidth);
            nPercentH = ((float)height / (float)sourceHeight);
            if (nPercentH < nPercentW) {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((width -
                              (sourceWidth * nPercent)) / 2);
            } else {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(width, height,
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

        static internal Image FixSize(Image image, int Width, int Height) {
            return FixSize(image, new Resolution(Width, Height));
        }

        static internal Image ResizeImage(Image image, int width, int height) {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage)) {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes()) {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        static internal Image ResizeImage(Image image, Resolution res) {
            return ResizeImage(image, res.x, res.y);
        }

        internal static byte[][] horizontalFlip(byte[][] data) {
            for (int i = 0; i < data.Length; i++) {
                Array.Reverse(data[i]);
            }
            return data;
        }

        static internal void MakeBW(Image sourceImage, float threshold=0.8f) {
            using (Graphics gr = Graphics.FromImage(sourceImage)) // SourceImage is a Bitmap object
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
                ia.SetThreshold(threshold); // Change this threshold as needed
                var rc = new Rectangle(0, 0, sourceImage.Width, sourceImage.Height);
                gr.DrawImage(sourceImage, rc, 0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel, ia);
                gr.Dispose();
            }
        }

        static internal void InvertImage(Image sourceImage) {
            using (Graphics gr = Graphics.FromImage(sourceImage)) // SourceImage is a Bitmap object
            {
                var gray_matrix = new float[][]
                {
                   new float[] {-1, 0, 0, 0, 0},
                   new float[] {0, -1, 0, 0, 0},
                   new float[] {0, 0, -1, 0, 0},
                   new float[] {0, 0, 0, 1, 0},
                   new float[] {1, 1, 1, 0, 1}
                };

                var ia = new System.Drawing.Imaging.ImageAttributes();
                ia.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(gray_matrix));
                var rc = new Rectangle(0, 0, sourceImage.Width, sourceImage.Height);
                gr.DrawImage(sourceImage, rc, 0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel, ia);
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