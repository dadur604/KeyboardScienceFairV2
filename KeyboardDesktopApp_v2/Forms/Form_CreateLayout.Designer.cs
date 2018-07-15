namespace KeyboardDesktopApp_v2._0 {
    partial class Form_CreateLayout {
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
            this.button_preview = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.numericUpDown_ID = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog_picture = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_save = new System.Windows.Forms.SaveFileDialog();
            this.panel_PictureBoxes = new System.Windows.Forms.Panel();
            this.pictureBox_right = new System.Windows.Forms.PictureBox();
            this.button_addImage = new System.Windows.Forms.Button();
            this.button_removeImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ID)).BeginInit();
            this.panel_PictureBoxes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_left
            // 
            this.pictureBox_left.BackColor = System.Drawing.Color.Gray;
            this.pictureBox_left.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_left.Name = "pictureBox_left";
            this.pictureBox_left.Size = new System.Drawing.Size(108, 72);
            this.pictureBox_left.TabIndex = 0;
            this.pictureBox_left.TabStop = false;
            // 
            // button_preview
            // 
            this.button_preview.Location = new System.Drawing.Point(190, 180);
            this.button_preview.Name = "button_preview";
            this.button_preview.Size = new System.Drawing.Size(75, 23);
            this.button_preview.TabIndex = 1;
            this.button_preview.Text = "Preview";
            this.button_preview.UseVisualStyleBackColor = true;
            this.button_preview.Click += new System.EventHandler(this.button_preview_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(190, 210);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 2;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(12, 111);
            this.textBox_name.MaxLength = 20;
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(128, 20);
            this.textBox_name.TabIndex = 3;
            // 
            // numericUpDown_ID
            // 
            this.numericUpDown_ID.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_ID.Location = new System.Drawing.Point(13, 138);
            this.numericUpDown_ID.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numericUpDown_ID.Minimum = new decimal(new int[] {
            1215752191,
            23,
            0,
            -2147483648});
            this.numericUpDown_ID.Name = "numericUpDown_ID";
            this.numericUpDown_ID.Size = new System.Drawing.Size(127, 20);
            this.numericUpDown_ID.TabIndex = 4;
            // 
            // openFileDialog_picture
            // 
            this.openFileDialog_picture.FileName = "openFileDialog_picture";
            // 
            // panel_PictureBoxes
            // 
            this.panel_PictureBoxes.AutoScroll = true;
            this.panel_PictureBoxes.Controls.Add(this.pictureBox_left);
            this.panel_PictureBoxes.Controls.Add(this.pictureBox_right);
            this.panel_PictureBoxes.Location = new System.Drawing.Point(13, 12);
            this.panel_PictureBoxes.Name = "panel_PictureBoxes";
            this.panel_PictureBoxes.Size = new System.Drawing.Size(259, 93);
            this.panel_PictureBoxes.TabIndex = 5;
            // 
            // pictureBox_right
            // 
            this.pictureBox_right.BackColor = System.Drawing.Color.Gray;
            this.pictureBox_right.Location = new System.Drawing.Point(126, 3);
            this.pictureBox_right.Name = "pictureBox_right";
            this.pictureBox_right.Size = new System.Drawing.Size(108, 72);
            this.pictureBox_right.TabIndex = 0;
            this.pictureBox_right.TabStop = false;
            // 
            // button_addImage
            // 
            this.button_addImage.Location = new System.Drawing.Point(248, 112);
            this.button_addImage.Name = "button_addImage";
            this.button_addImage.Size = new System.Drawing.Size(24, 23);
            this.button_addImage.TabIndex = 6;
            this.button_addImage.Text = "+";
            this.button_addImage.UseVisualStyleBackColor = true;
            this.button_addImage.Click += new System.EventHandler(this.button_addImage_Click);
            // 
            // button_removeImage
            // 
            this.button_removeImage.Location = new System.Drawing.Point(219, 113);
            this.button_removeImage.Name = "button_removeImage";
            this.button_removeImage.Size = new System.Drawing.Size(23, 22);
            this.button_removeImage.TabIndex = 7;
            this.button_removeImage.Text = "-";
            this.button_removeImage.UseVisualStyleBackColor = true;
            this.button_removeImage.Click += new System.EventHandler(this.button_removeImage_Click);
            // 
            // Form_CreateLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button_removeImage);
            this.Controls.Add(this.button_addImage);
            this.Controls.Add(this.panel_PictureBoxes);
            this.Controls.Add(this.numericUpDown_ID);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_preview);
            this.Name = "Form_CreateLayout";
            this.Text = "Form_CreateLayout";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ID)).EndInit();
            this.panel_PictureBoxes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_preview;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.NumericUpDown numericUpDown_ID;
        internal System.Windows.Forms.PictureBox pictureBox_left;
        private System.Windows.Forms.OpenFileDialog openFileDialog_picture;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_save;
        private System.Windows.Forms.Panel panel_PictureBoxes;
        private System.Windows.Forms.Button button_addImage;
        internal System.Windows.Forms.PictureBox pictureBox_right;
        private System.Windows.Forms.Button button_removeImage;
    }
}