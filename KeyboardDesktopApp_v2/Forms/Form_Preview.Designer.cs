namespace KeyboardDesktopApp_v2._0 {
    partial class Form_Preview {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pictureBox_left = new System.Windows.Forms.PictureBox();
            this.pictureBox_right = new System.Windows.Forms.PictureBox();
            this.trackBar_leftThresh = new System.Windows.Forms.TrackBar();
            this.trackBar_rightThresh = new System.Windows.Forms.TrackBar();
            this.button_accept = new System.Windows.Forms.Button();
            this.checkBox_leftInvert = new System.Windows.Forms.CheckBox();
            this.checkBox_rightInvert = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_leftThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_rightThresh)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_left
            // 
            this.pictureBox_left.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox_left.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_left.Name = "pictureBox_left";
            this.pictureBox_left.Size = new System.Drawing.Size(108, 72);
            this.pictureBox_left.TabIndex = 0;
            this.pictureBox_left.TabStop = false;
            // 
            // pictureBox_right
            // 
            this.pictureBox_right.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox_right.Location = new System.Drawing.Point(153, 12);
            this.pictureBox_right.Name = "pictureBox_right";
            this.pictureBox_right.Size = new System.Drawing.Size(108, 72);
            this.pictureBox_right.TabIndex = 1;
            this.pictureBox_right.TabStop = false;
            // 
            // trackBar_leftThresh
            // 
            this.trackBar_leftThresh.LargeChange = 2;
            this.trackBar_leftThresh.Location = new System.Drawing.Point(12, 90);
            this.trackBar_leftThresh.Maximum = 20;
            this.trackBar_leftThresh.Name = "trackBar_leftThresh";
            this.trackBar_leftThresh.Size = new System.Drawing.Size(108, 45);
            this.trackBar_leftThresh.TabIndex = 2;
            this.trackBar_leftThresh.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_leftThresh.Scroll += new System.EventHandler(this.trackBar_leftThresh_Scroll);
            // 
            // trackBar_rightThresh
            // 
            this.trackBar_rightThresh.LargeChange = 2;
            this.trackBar_rightThresh.Location = new System.Drawing.Point(153, 91);
            this.trackBar_rightThresh.Maximum = 20;
            this.trackBar_rightThresh.Name = "trackBar_rightThresh";
            this.trackBar_rightThresh.Size = new System.Drawing.Size(108, 45);
            this.trackBar_rightThresh.TabIndex = 3;
            this.trackBar_rightThresh.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar_rightThresh.Scroll += new System.EventHandler(this.trackBar_rightThresh_Scroll);
            // 
            // button_accept
            // 
            this.button_accept.Location = new System.Drawing.Point(186, 187);
            this.button_accept.Name = "button_accept";
            this.button_accept.Size = new System.Drawing.Size(75, 23);
            this.button_accept.TabIndex = 4;
            this.button_accept.Text = "Accept";
            this.button_accept.UseVisualStyleBackColor = true;
            this.button_accept.Click += new System.EventHandler(this.button_accept_Click);
            // 
            // checkBox_leftInvert
            // 
            this.checkBox_leftInvert.AutoSize = true;
            this.checkBox_leftInvert.Location = new System.Drawing.Point(12, 117);
            this.checkBox_leftInvert.Name = "checkBox_leftInvert";
            this.checkBox_leftInvert.Size = new System.Drawing.Size(53, 17);
            this.checkBox_leftInvert.TabIndex = 5;
            this.checkBox_leftInvert.Text = "Invert";
            this.checkBox_leftInvert.UseVisualStyleBackColor = true;
            this.checkBox_leftInvert.CheckedChanged += new System.EventHandler(this.checkBox_leftInvert_CheckedChanged);
            // 
            // checkBox_rightInvert
            // 
            this.checkBox_rightInvert.AutoSize = true;
            this.checkBox_rightInvert.Location = new System.Drawing.Point(153, 117);
            this.checkBox_rightInvert.Name = "checkBox_rightInvert";
            this.checkBox_rightInvert.Size = new System.Drawing.Size(53, 17);
            this.checkBox_rightInvert.TabIndex = 6;
            this.checkBox_rightInvert.Text = "Invert";
            this.checkBox_rightInvert.UseVisualStyleBackColor = true;
            this.checkBox_rightInvert.CheckedChanged += new System.EventHandler(this.checkBox_rightInvert_CheckedChanged);
            // 
            // Form_Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 222);
            this.Controls.Add(this.checkBox_rightInvert);
            this.Controls.Add(this.checkBox_leftInvert);
            this.Controls.Add(this.button_accept);
            this.Controls.Add(this.trackBar_rightThresh);
            this.Controls.Add(this.trackBar_leftThresh);
            this.Controls.Add(this.pictureBox_right);
            this.Controls.Add(this.pictureBox_left);
            this.Name = "Form_Preview";
            this.Text = "Form_Preview";
            this.Shown += new System.EventHandler(this.Form_Preview_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_leftThresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_rightThresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_left;
        private System.Windows.Forms.PictureBox pictureBox_right;
        private System.Windows.Forms.TrackBar trackBar_leftThresh;
        private System.Windows.Forms.TrackBar trackBar_rightThresh;
        private System.Windows.Forms.Button button_accept;
        private System.Windows.Forms.CheckBox checkBox_leftInvert;
        private System.Windows.Forms.CheckBox checkBox_rightInvert;
    }
}