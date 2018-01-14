using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyboardDesktopApp_v2._0.DisplayTools;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace KeyboardDesktopApp_v2._0 {
    public partial class Form_CreateLayout : Form {

        Form_Preview _Form_Preview;
        Form_Main parent;

        public Form_CreateLayout(Form_Main _parent) {
            InitializeComponent();

            parent = _parent;
            _Form_Preview = new Form_Preview(this);
        }

        private void button_preview_Click(object sender, EventArgs e) {
            _Form_Preview.ShowDialog();
        }

        private void pictureBox_left_DoubleClick(object sender, EventArgs e) {
            DialogResult result = openFileDialog_picture.ShowDialog();
            if (result == DialogResult.OK) {
                var image = new Bitmap(openFileDialog_picture.FileName);
                var fixedImage = ImageTools.FixSize(image, pictureBox_left.Width, pictureBox_left.Height);
                pictureBox_left.Image = fixedImage;
                pictureBox_left.Tag = new object[] { openFileDialog_picture.FileName, 0.8f, false };
            }
        }

        private void pictureBox_right_DoubleClick(object sender, EventArgs e) {
            DialogResult result = openFileDialog_picture.ShowDialog();
            if (result == DialogResult.OK) {
                var image = new Bitmap(openFileDialog_picture.FileName);
                var fixedImage = ImageTools.FixSize(image, pictureBox_left.Width, pictureBox_left.Height);
                pictureBox_right.Image = fixedImage;
                pictureBox_right.Tag = new object[] { openFileDialog_picture.FileName, 0.8f, false };
            }
        }

        private void button_save_Click(object sender, EventArgs e) {
            DisplayMaker displayMaker = new DisplayMaker();
            var imageATag = (object[])pictureBox_left.Tag;
            var imageBTag = (object[])pictureBox_right.Tag;
            Image imageA = new Bitmap(imageATag[0].ToString());
            Image imageB = new Bitmap(imageBTag[0].ToString());
            List<List<string>> imageA_C = displayMaker.MakeCImageFromImage(imageA, DisplayMaker.IMAGE_SIZE, (float)imageATag[1], (bool)imageATag[2]);
            List<List<string>> imageB_C = displayMaker.MakeCImageFromImage(imageB, DisplayMaker.IMAGE_SIZE, (float)imageBTag[1], (bool)imageBTag[2]);

            List<string> displayAB_C = displayMaker.MakeCDisplayFromCImage(new List<List<string>>[] { imageA_C, imageB_C });

            var klayout = new KLayout(textBox_name.Text, numericUpDown_ID.Value, displayAB_C);

            var klayoutfile = KLayout.KLayoutToFile(klayout);

            string file;
            saveFileDialog_save.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "layouts\\";
            saveFileDialog_save.FileName = textBox_name.Text + ".klayout";
            var result = saveFileDialog_save.ShowDialog();
            if (result == DialogResult.OK) {
                file = saveFileDialog_save.FileName;
            } else {
                return;
            }
            //Directory.CreateDirectory(file);
            File.AppendAllLines(file, klayoutfile);
        }
    }
}
