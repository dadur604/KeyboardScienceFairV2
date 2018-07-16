namespace KeyboardDesktopApp_v2._0 {
    partial class Form_Settings {
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
            this.textBox_compilePath = new System.Windows.Forms.TextBox();
            this.button_compileBrowse = new System.Windows.Forms.Button();
            this.label_compile = new System.Windows.Forms.Label();
            this.label_upload = new System.Windows.Forms.Label();
            this.button_uploadBrowse = new System.Windows.Forms.Button();
            this.textBox_uploadPath = new System.Windows.Forms.TextBox();
            this.button_save = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // textBox_compilePath
            // 
            this.textBox_compilePath.Location = new System.Drawing.Point(46, 69);
            this.textBox_compilePath.Name = "textBox_compilePath";
            this.textBox_compilePath.Size = new System.Drawing.Size(324, 20);
            this.textBox_compilePath.TabIndex = 0;
            // 
            // button_compileBrowse
            // 
            this.button_compileBrowse.Location = new System.Drawing.Point(374, 69);
            this.button_compileBrowse.Name = "button_compileBrowse";
            this.button_compileBrowse.Size = new System.Drawing.Size(26, 21);
            this.button_compileBrowse.TabIndex = 1;
            this.button_compileBrowse.Text = "...";
            this.button_compileBrowse.UseVisualStyleBackColor = true;
            this.button_compileBrowse.Click += new System.EventHandler(this.button_compileBrowse_Click);
            // 
            // label_compile
            // 
            this.label_compile.AutoSize = true;
            this.label_compile.Location = new System.Drawing.Point(49, 53);
            this.label_compile.Name = "label_compile";
            this.label_compile.Size = new System.Drawing.Size(147, 13);
            this.label_compile.TabIndex = 2;
            this.label_compile.Text = "Arduino Compile Objects Path";
            // 
            // label_upload
            // 
            this.label_upload.AutoSize = true;
            this.label_upload.Location = new System.Drawing.Point(49, 108);
            this.label_upload.Name = "label_upload";
            this.label_upload.Size = new System.Drawing.Size(144, 13);
            this.label_upload.TabIndex = 5;
            this.label_upload.Text = "Arduino Upload Objects Path";
            // 
            // button_uploadBrowse
            // 
            this.button_uploadBrowse.Location = new System.Drawing.Point(374, 124);
            this.button_uploadBrowse.Name = "button_uploadBrowse";
            this.button_uploadBrowse.Size = new System.Drawing.Size(26, 21);
            this.button_uploadBrowse.TabIndex = 4;
            this.button_uploadBrowse.Text = "...";
            this.button_uploadBrowse.UseVisualStyleBackColor = true;
            this.button_uploadBrowse.Click += new System.EventHandler(this.button_uploadBrowse_Click);
            // 
            // textBox_uploadPath
            // 
            this.textBox_uploadPath.Location = new System.Drawing.Point(46, 124);
            this.textBox_uploadPath.Name = "textBox_uploadPath";
            this.textBox_uploadPath.ReadOnly = true;
            this.textBox_uploadPath.Size = new System.Drawing.Size(324, 20);
            this.textBox_uploadPath.TabIndex = 3;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(364, 182);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 6;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 217);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.label_upload);
            this.Controls.Add(this.button_uploadBrowse);
            this.Controls.Add(this.textBox_uploadPath);
            this.Controls.Add(this.label_compile);
            this.Controls.Add(this.button_compileBrowse);
            this.Controls.Add(this.textBox_compilePath);
            this.Name = "Form_Settings";
            this.Text = "Form_Settings";
            this.Load += new System.EventHandler(this.Form_Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_compilePath;
        private System.Windows.Forms.Button button_compileBrowse;
        private System.Windows.Forms.Label label_compile;
        private System.Windows.Forms.Label label_upload;
        private System.Windows.Forms.Button button_uploadBrowse;
        private System.Windows.Forms.TextBox textBox_uploadPath;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}