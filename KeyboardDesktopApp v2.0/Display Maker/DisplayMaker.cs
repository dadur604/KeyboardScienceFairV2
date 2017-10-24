using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace KeyboardDesktopApp_v2._0.DisplayTools {
    class DisplayMaker {

        const int EMPTY_PIXELS = 4;

        public DisplayMaker() {

        }

        public List<string> MakeCDisplay(List<List<string>> cImage) {

            List<string> output = new List<string>();

            for (int i = 0; i < cImage.Count; i++) {

                output.Add($"if (row=={i+1}){{");

                if (i == 0) {
                    output.Add("\tdigitalWrite(flm, HIGH);");
                } else {
                    output.Add("\tdigitalWrite(flm, LOW);");
                }

                output.AddRange(cImage[i]);

                output.Add("\tdigitalWrite(lp, HIGH);");
                output.Add("\tdigitalWrite(lp, LOW);");
                output.Add("}");
            }

            return output;
        }

        public List<List<String>> MakeCImage(Image image, Resolution res) {
            //Scale image to res
            Image resizedImage = ImageTools.FixSize(image, res.x, res.y);

            //Image in array of black (0) and white (1) pixels
            var data = GetBWBytes(resizedImage, res);

            var flatData = data.SelectMany(a => a).ToArray();

            //Image x = ImageTools.ByteArrayToImage(res.x + 4, res.y, flatData, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
               
            //x.Save(AppDomain.CurrentDomain.BaseDirectory + "outimage.png", ImageFormat.Png);

            var fixedData = ImageTools.horizontalFlip(data);

            //Image written in arduino using data-in and pulsing
            var cImage = GetCImage(fixedData);

            return cImage;
        }

        /// <summary>
        /// Gets the image in the Arduino Code (setting the d-in, and pulsing the scp)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private List<List<string>> GetCImage(byte[][] data) {

            List<List<string>> cImage = new List<List<string>>();

            for (int i = 0; i < data.Length; i++) {

                cImage.Add(new List<string>());

                int last = 5;
                for (int j = 0; j < data[0].Length; j++) {
                    if (last != data[i][j]) {
                        last = data[i][j];

                        if (data[i][j] == 1) {
                            cImage[i].Add("\tdigitalWrite(din, HIGH);");
                        } else {
                            cImage[i].Add("\tdigitalWrite(din, LOW);");
                        }

                        cImage[i].Add("\tpulse();");


                    } else {
                        cImage[i].Add("\tpulse();");
                    }
                }
            }

            return cImage;
        }

        public List<List<string>> CombineCImages(List<List<string>> a, List<List<string>> b) {
            if (a.Count != b.Count) {
                throw new ArgumentException("Cannot combine cimages of different length!");
            }

            List<List<string>> output = new List<List<string>>();

            for (int i = 0; i < a.Count; i++) {
                output.Add(a[i].Concat(b[i]).ToList());
            }

            return output;

        }

        /// <summary>
        /// Get an array of all the pixels of a specified image as eiether 1 or 0
        /// </summary>
        /// <param name="image"></param>
        /// <param name="res"></param>
        /// <returns>An array of rows of pixels</returns>
        private byte[][] GetBWBytes(Image image, Resolution res) { 
            Bitmap greyscaleImage = new Bitmap(image);
            ImageTools.MakeBW(greyscaleImage);
            //Bitmap greyscaleImage = ImageTools.MakeGrayscale(bitmapImage);

            Rectangle rect = new Rectangle(0, 0, greyscaleImage.Width, greyscaleImage.Height);
            BitmapData imageData = greyscaleImage.LockBits(rect, ImageLockMode.ReadOnly, greyscaleImage.PixelFormat);

            // Get the address of the first line.
            IntPtr ptr = imageData.Scan0;

            // Declare an array to hold the bytes of the bitmap.
            int bytes = Math.Abs(imageData.Stride) * greyscaleImage.Height;
            byte[] values = new byte[bytes];

            // Copy the RGB values into the array.
            Marshal.Copy(ptr, values, 0, bytes);

            byte[] greyValues = new byte[values.Length / 4];


            for (int i = 0; i < greyValues.Length; i++) {
                greyValues[i] = values[i * 4];
            }

            var bwValues = greyValues.Select((x) => {
                if (x == 255) {
                    return (byte)0;
                } else {
                    return (byte)1;
                }
            }).ToArray();

            var data = new byte[res.y][];

            for (int i = 0; i < res.y; i++) {
                data[i] = new byte[res.x + 4];

                for (int j = 0; j < res.x; j++) {
                    data[i][j] = bwValues[j + i*res.x];
                }

                for (int c = 0; c < EMPTY_PIXELS; c++) {
                    data[i][res.x + c] = 0;
                }
            }

            return data;
        }
    }
}
