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

        internal List<PictureBox> pictureBoxes;

        public Form_CreateLayout(Form_Main _parent) {
            InitializeComponent();

            parent = _parent;
            _Form_Preview = new Form_Preview(this);

            panel_PictureBoxes.ControlAdded += Form_CreateLayout_ControlAdded;
            panel_PictureBoxes.ControlRemoved += Form_CreateLayout_ControlAdded;

            Form_CreateLayout_ControlAdded(null, null);
        }

        private void Form_CreateLayout_ControlAdded(object sender, ControlEventArgs e) {
            pictureBoxes = panel_PictureBoxes.Controls.OfType<PictureBox>().ToList();
            foreach (var pb in pictureBoxes) {
                pb.DoubleClick -= pictureBox_DoubleClick;
                pb.DoubleClick += pictureBox_DoubleClick;
            }
        }

        private void button_preview_Click(object sender, EventArgs e) {
            _Form_Preview.ShowDialog();
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e) {
            PictureBox pBox = (PictureBox)sender;

            openFileDialog_picture.FileName = "";
            DialogResult result = openFileDialog_picture.ShowDialog();
            if (result == DialogResult.OK) {
                var image = new Bitmap(openFileDialog_picture.FileName);
                var fixedImage = ImageTools.FixSize(image, pBox.Width, pBox.Height);
                pBox.Image = fixedImage;
                pBox.Tag = new PreviewTag(image, 0.8f, false);
            }
        }

        private void button_save_Click(object sender, EventArgs e) {
            DisplayMaker displayMaker = new DisplayMaker();
            var cImages = new List<    List<List<string>>    >();
            //var imagesAsStrings = new List<string>();
            var previewTags = new List<PreviewTag>();

            foreach (var pBox in pictureBoxes) {
                var pBoxTag = (PreviewTag)pBox.Tag;
                previewTags.Add(pBoxTag);

                cImages.Add(displayMaker.MakeCImageFromImage(pBoxTag.image, DisplayMaker.IMAGE_SIZE, pBoxTag.threshold, pBoxTag.invert));

                //MemoryStream imageAsStream = new MemoryStream();
                //image = ImageTools.FixSize(image, DisplayMaker.IMAGE_SIZE);
                //image.Save(imageAsStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                //var imageAsString = Convert.ToBase64String(imageAsStream.ToArray());
                //imagesAsStrings.Add(imageAsString);
            }

            List<string> cDisplay = displayMaker.MakeCDisplayFromCImage(cImages.ToArray());

            var klayout = new KLayout(textBox_name.Text, numericUpDown_ID.Value, cDisplay, previewTags);

            //var klayoutfile = KLayout.KLayoutToFile(klayout);

            string file;
            saveFileDialog_save.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "layouts\\";
            saveFileDialog_save.FileName = textBox_name.Text + ".klayout";
            var result = saveFileDialog_save.ShowDialog();
            if (result == DialogResult.OK) {
                file = saveFileDialog_save.FileName;
            } else {
                return;
            }

            BinarySerializer.WriteToBinaryFile<KLayout>(file, klayout);
            Close();
        }

        private void button_addImage_Click(object sender, EventArgs e) {
            var pBox = new PictureBox();
            Point newLocation = new Point(3, 3);
            newLocation.X += ((108 + 15) * pictureBoxes.Count) - panel_PictureBoxes.HorizontalScroll.Value;
            
            pBox.Location = newLocation;
            pBox.BackColor = Color.Gray;
            pBox.Size = new Size(108, 72);
            pBox.Parent = panel_PictureBoxes;
        }

        private void button_removeImage_Click(object sender, EventArgs e) {
            if (pictureBoxes.Count > 0) {
                panel_PictureBoxes.Controls.Remove(pictureBoxes.Last());
            }
        }



        public void Show(KLayout klayout) {

            while (pictureBoxes.Count < klayout.images.Count) {
                button_addImage_Click(null, null);
            }

            while (pictureBoxes.Count > klayout.images.Count) {
                button_removeImage_Click(null, null);
            }

            for (int i = 0; i < klayout.images.Count; i++) {
                //var temp = Convert.FromBase64String(klayout.images[i]);
                //var tempmem = new MemoryStream(temp);
                //Image image = new Bitmap(tempmem);
                //image = ImageTools.ResizeImage(image, pictureBoxes[i].Width, pictureBoxes[i].Height);
                var image = klayout.images[i].image;
                var fixedImage = ImageTools.FixSize(image, pictureBoxes[i].Width, pictureBoxes[i].Height);
                pictureBoxes[i].Image = fixedImage;
                pictureBoxes[i].Tag = klayout.images[i];
            }

            textBox_name.Text = klayout.Name;
            numericUpDown_ID.Value = klayout.WID;

            ShowDialog();
        }
    }
}
