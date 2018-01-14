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
            this.pictureBox_right = new System.Windows.Forms.PictureBox();
            this.button_preview = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.numericUpDown_ID = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog_picture = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog_save = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ID)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_left
            // 
            this.pictureBox_left.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox_left.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_left.Name = "pictureBox_left";
            this.pictureBox_left.Size = new System.Drawing.Size(108, 72);
            this.pictureBox_left.TabIndex = 0;
            this.pictureBox_left.TabStop = false;
            this.pictureBox_left.DoubleClick += new System.EventHandler(this.pictureBox_left_DoubleClick);
            // 
            // pictureBox_right
            // 
            this.pictureBox_right.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox_right.Location = new System.Drawing.Point(144, 12);
            this.pictureBox_right.Name = "pictureBox_right";
            this.pictureBox_right.Size = new System.Drawing.Size(108, 72);
            this.pictureBox_right.TabIndex = 0;
            this.pictureBox_right.TabStop = false;
            this.pictureBox_right.DoubleClick += new System.EventHandler(this.pictureBox_right_DoubleClick);
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
            999999,
            0,
            0,
            0});
            this.numericUpDown_ID.Name = "numericUpDown_ID";
            this.numericUpDown_ID.Size = new System.Drawing.Size(127, 20);
            this.numericUpDown_ID.TabIndex = 4;
            // 
            // openFileDialog_picture
            // 
            this.openFileDialog_picture.FileName = "openFileDialog_picture";
            // 
            // Form_CreateLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.numericUpDown_ID);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_preview);
            this.Controls.Add(this.pictureBox_right);
            this.Controls.Add(this.pictureBox_left);
            this.Name = "Form_CreateLayout";
            this.Text = "Form_CreateLayout";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_preview;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.NumericUpDown numericUpDown_ID;
        internal System.Windows.Forms.PictureBox pictureBox_left;
        internal System.Windows.Forms.PictureBox pictureBox_right;
        private System.Windows.Forms.OpenFileDialog openFileDialog_picture;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_save;
    }
}