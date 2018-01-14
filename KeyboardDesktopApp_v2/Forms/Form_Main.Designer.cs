namespace KeyboardDesktopApp_v2._0 {
    partial class Form_Main {
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
            this.progressBar_compileUpload = new System.Windows.Forms.ProgressBar();
            this.button_go = new System.Windows.Forms.Button();
            this.button_createLayout = new System.Windows.Forms.Button();
            this.button_refresh = new System.Windows.Forms.Button();
            this.checkedListBox_layouts = new System.Windows.Forms.CheckedListBox();
            this.button_open = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // progressBar_compileUpload
            // 
            this.progressBar_compileUpload.Location = new System.Drawing.Point(172, 226);
            this.progressBar_compileUpload.Name = "progressBar_compileUpload";
            this.progressBar_compileUpload.Size = new System.Drawing.Size(100, 23);
            this.progressBar_compileUpload.TabIndex = 0;
            // 
            // button_go
            // 
            this.button_go.Location = new System.Drawing.Point(198, 183);
            this.button_go.Name = "button_go";
            this.button_go.Size = new System.Drawing.Size(75, 23);
            this.button_go.TabIndex = 1;
            this.button_go.Text = "go";
            this.button_go.UseVisualStyleBackColor = true;
            this.button_go.Click += new System.EventHandler(this.button_go_Click);
            // 
            // button_createLayout
            // 
            this.button_createLayout.Location = new System.Drawing.Point(198, 154);
            this.button_createLayout.Name = "button_createLayout";
            this.button_createLayout.Size = new System.Drawing.Size(75, 23);
            this.button_createLayout.TabIndex = 6;
            this.button_createLayout.Text = "Create Layout";
            this.button_createLayout.UseVisualStyleBackColor = true;
            this.button_createLayout.Click += new System.EventHandler(this.button_createLayout_Click);
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(13, 13);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(24, 23);
            this.button_refresh.TabIndex = 7;
            this.button_refresh.Text = "R";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // checkedListBox_layouts
            // 
            this.checkedListBox_layouts.FormattingEnabled = true;
            this.checkedListBox_layouts.Location = new System.Drawing.Point(13, 42);
            this.checkedListBox_layouts.Name = "checkedListBox_layouts";
            this.checkedListBox_layouts.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox_layouts.TabIndex = 8;
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(44, 13);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(23, 23);
            this.button_open.TabIndex = 9;
            this.button_open.Text = "O";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 260);
            this.Controls.Add(this.button_open);
            this.Controls.Add(this.checkedListBox_layouts);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.button_createLayout);
            this.Controls.Add(this.button_go);
            this.Controls.Add(this.progressBar_compileUpload);
            this.Name = "Form_Main";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ProgressBar progressBar_compileUpload;
        internal System.Windows.Forms.Button button_go;
        private System.Windows.Forms.Button button_createLayout;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.CheckedListBox checkedListBox_layouts;
        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

