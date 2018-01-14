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
            if (parent.pictureBox_left.Image != null) {
                var leftTag = (object[])parent.pictureBox_left.Tag;
                trackBar_leftThresh.Value = (int)((float)leftTag[1] * THRESHOLD_SLIDER_CLICKS);
                Image leftImage = new Bitmap(leftTag[0].ToString());
                leftImage = ImageTools.FixSize(leftImage, DisplayMaker.IMAGE_SIZE);
                ImageTools.MakeBW(leftImage, (float)trackBar_leftThresh.Value / THRESHOLD_SLIDER_CLICKS);
                leftImage = ImageTools.ResizeImage(leftImage, pictureBox_left.Width, pictureBox_left.Height);
                pictureBox_left.Image = leftImage;
            } 
            
            if (parent.pictureBox_right.Image != null) {
                var rightTag = (object[])parent.pictureBox_right.Tag;
                trackBar_rightThresh.Value = (int)((float)rightTag[1] * THRESHOLD_SLIDER_CLICKS);
                Image rightImage = new Bitmap(rightTag[0].ToString());
                rightImage = ImageTools.FixSize(rightImage, DisplayMaker.IMAGE_SIZE);
                ImageTools.MakeBW(rightImage, (float)trackBar_rightThresh.Value / THRESHOLD_SLIDER_CLICKS);
                rightImage = ImageTools.ResizeImage(rightImage, pictureBox_right.Width, pictureBox_right.Height);
                pictureBox_right.Image = rightImage;
            }
        }

        private void trackBar_leftThresh_Scroll(object sender, EventArgs e) {
            var leftTag = (object[])parent.pictureBox_left.Tag;
            Image leftImage = new Bitmap(leftTag[0].ToString());
            leftImage = ImageTools.FixSize(leftImage, DisplayMaker.IMAGE_SIZE);
            ImageTools.MakeBW(leftImage, (float)trackBar_leftThresh.Value / THRESHOLD_SLIDER_CLICKS);
            if ((bool)leftTag[2]) {
                ImageTools.InvertImage(leftImage);
            }
            leftImage = ImageTools.ResizeImage(leftImage, pictureBox_left.Width, pictureBox_left.Height);
            pictureBox_left.Image = leftImage;

        }

        private void trackBar_rightThresh_Scroll(object sender, EventArgs e) {
            var rightTag = (object[])parent.pictureBox_right.Tag;
            Image rightImage = new Bitmap(rightTag[0].ToString());
            rightImage = ImageTools.FixSize(rightImage, DisplayMaker.IMAGE_SIZE);
            ImageTools.MakeBW(rightImage, (float)trackBar_rightThresh.Value / THRESHOLD_SLIDER_CLICKS);
            if ((bool)rightTag[2]) {
                ImageTools.InvertImage(rightImage);
            }
            rightImage = ImageTools.ResizeImage(rightImage, pictureBox_right.Width, pictureBox_right.Height);
            pictureBox_right.Image = rightImage;
        }

        private void button_accept_Click(object sender, EventArgs e) {
            var leftTag = (object[])parent.pictureBox_left.Tag;
            var rightTag = (object[])parent.pictureBox_right.Tag;

            leftTag[1] = (float)trackBar_leftThresh.Value / THRESHOLD_SLIDER_CLICKS;
            rightTag[1] = (float)trackBar_rightThresh.Value / THRESHOLD_SLIDER_CLICKS;

            leftTag[2] = checkBox_leftInvert.Checked;
            rightTag[2] = checkBox_rightInvert.Checked;

            parent.pictureBox_left.Tag = leftTag;
            parent.pictureBox_right.Tag = rightTag;

            this.Close();
        }

        private void checkBox_leftInvert_CheckedChanged(object sender, EventArgs e) {
            var leftTag = (object[])parent.pictureBox_left.Tag;
            leftTag[2] = checkBox_leftInvert.Checked;
            parent.pictureBox_left.Tag = leftTag;

            trackBar_leftThresh_Scroll(null, null);
        }

        private void checkBox_rightInvert_CheckedChanged(object sender, EventArgs e) {
            var rightTag = (object[])parent.pictureBox_right.Tag;
            rightTag[2] = checkBox_rightInvert.Checked;
            parent.pictureBox_right.Tag = rightTag;

            trackBar_rightThresh_Scroll(null, null);
        }
    }
}
