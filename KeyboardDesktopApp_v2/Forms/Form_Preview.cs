using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyboardDesktopApp_v2._0.DisplayTools;

namespace KeyboardDesktopApp_v2._0 {
    public partial class Form_Preview : Form {

        const int THRESHOLD_SLIDER_CLICKS = 20;
        private Form_CreateLayout parent;



        public Form_Preview(Form_CreateLayout _parent) {
            parent = _parent;
            InitializeComponent();
        }

        private void Form_Preview_Shown(object sender, EventArgs e) {

            panel_Preview.Controls.Clear();

            foreach (var pBox in parent.pictureBoxes.Where((x) => x.Image != null)) {
                var tag = (PreviewTag)pBox.Tag;
                var previewCount = panel_Preview.Controls.OfType<PictureBox>().Count();
                var scrollAmmt = panel_Preview.HorizontalScroll.Value;

                var prevPBox = new PictureBox();
                Point newLocation = new Point(3, 3);
                //              width + margin
                newLocation.X += ((108 + 15) * previewCount) - scrollAmmt;
                prevPBox.Location = newLocation;
                prevPBox.BackColor = Color.Gray;
                prevPBox.Size = new Size(108, 72);

                var prevScroll = new TrackBar();
                newLocation = new Point(3, 90);
                newLocation.X += ((108 + 15) * previewCount) - scrollAmmt;
                prevScroll.Location = newLocation;
                prevScroll.Maximum = 20;
                prevScroll.Value = (int)(tag.threshold * THRESHOLD_SLIDER_CLICKS);
                prevScroll.TickStyle = TickStyle.None;
                prevScroll.Scroll += trackBar_Scroll;

                var prevCheck = new CheckBox();
                newLocation = new Point(3, 118);
                newLocation.X += ((108 + 15) * previewCount) - scrollAmmt;
                prevCheck.Location = newLocation;
                prevCheck.Text = "Invert";
                prevCheck.Checked = tag.invert;
                prevCheck.CheckedChanged += checkBox_CheckedChanged;

                prevPBox.Tag = new object[] { pBox, prevScroll, prevCheck };
                prevScroll.Tag = new object[] { prevPBox, pBox };
                prevCheck.Tag = new object[] { prevPBox, pBox, prevScroll };

                prevPBox.Parent = panel_Preview;
                prevCheck.Parent = panel_Preview;
                prevScroll.Parent = panel_Preview;

                //if (pBox.Image != null) {
                    Image image = tag.image;
                    image = ImageTools.FixSize(image, DisplayMaker.IMAGE_SIZE);
                    ImageTools.MakeBW(image, (float)prevScroll.Value / THRESHOLD_SLIDER_CLICKS);
                    image = ImageTools.ResizeImage(image, prevPBox.Width, prevPBox.Height);
                    prevPBox.Image = image;
                //}

                trackBar_Scroll(prevScroll, null);
            }

        }

        private void trackBar_Scroll(object sender, EventArgs e) {
            var pbox = (PictureBox)((object[])((TrackBar)sender).Tag)[1];
            var prevPBox = (PictureBox)((object[])((TrackBar)sender).Tag)[0];
            var tag = (PreviewTag)pbox.Tag;
            Image image = tag.image;
            image = ImageTools.FixSize(image, DisplayMaker.IMAGE_SIZE);
            ImageTools.MakeBW(image, (float)((TrackBar)sender).Value / THRESHOLD_SLIDER_CLICKS);
            if (tag.invert) {
                ImageTools.InvertImage(image);
            }
            image = ImageTools.ResizeImage(image, prevPBox.Width, prevPBox.Height);
            prevPBox.Image = image;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e) {
            var pbox = (PictureBox)((object[])((CheckBox)sender).Tag)[1];
            var prevPBox = (PictureBox)((object[])((CheckBox)sender).Tag)[0];
            var scroll = ((object[])((CheckBox)sender).Tag)[2];
            var tag = (PreviewTag)pbox.Tag;

            tag.invert = ((CheckBox)sender).Checked;
            pbox.Tag = tag;

            trackBar_Scroll(scroll, null);
        }



        private void button_accept_Click(object sender, EventArgs e) {
            foreach (var prevPBox in panel_Preview.Controls.OfType<PictureBox>()) {
                var temptag = ((object[])prevPBox.Tag);
                var pbox = (PictureBox)temptag[0];
                var scroll = (TrackBar)temptag[1];
                var check = (CheckBox)temptag[2];

                var tag = (PreviewTag)pbox.Tag;
                tag.threshold = (float)scroll.Value / THRESHOLD_SLIDER_CLICKS;
                tag.invert = check.Checked;

                pbox.Tag = tag;
            }

            this.Close();
        }
    }
}
