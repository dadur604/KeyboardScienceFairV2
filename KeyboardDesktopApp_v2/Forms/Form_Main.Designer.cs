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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.progressBar_compileUpload = new System.Windows.Forms.ProgressBar();
            this.button_go = new System.Windows.Forms.Button();
            this.button_createLayout = new System.Windows.Forms.Button();
            this.button_refresh = new System.Windows.Forms.Button();
            this.checkedListBox_layouts = new System.Windows.Forms.CheckedListBox();
            this.button_open = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button_start = new System.Windows.Forms.Button();
            this.tabControl_Main = new System.Windows.Forms.TabControl();
            this.tabPage_Main = new System.Windows.Forms.TabPage();
            this.listBox_activeKLayouts = new System.Windows.Forms.ListBox();
            this.label_threadStatus = new System.Windows.Forms.Label();
            this.tabPage_Layouts = new System.Windows.Forms.TabPage();
            this.pictureBox_defaultLayout = new System.Windows.Forms.PictureBox();
            this.tabPage_Debug = new System.Windows.Forms.TabPage();
            this.textBox_Debug = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl_Main.SuspendLayout();
            this.tabPage_Main.SuspendLayout();
            this.tabPage_Layouts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_defaultLayout)).BeginInit();
            this.tabPage_Debug.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar_compileUpload
            // 
            this.progressBar_compileUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_compileUpload.Location = new System.Drawing.Point(138, 184);
            this.progressBar_compileUpload.Name = "progressBar_compileUpload";
            this.progressBar_compileUpload.Size = new System.Drawing.Size(100, 23);
            this.progressBar_compileUpload.TabIndex = 0;
            // 
            // button_go
            // 
            this.button_go.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_go.Location = new System.Drawing.Point(151, 132);
            this.button_go.Name = "button_go";
            this.button_go.Size = new System.Drawing.Size(75, 23);
            this.button_go.TabIndex = 1;
            this.button_go.Text = "go";
            this.button_go.UseVisualStyleBackColor = true;
            this.button_go.Click += new System.EventHandler(this.button_go_Click);
            // 
            // button_createLayout
            // 
            this.button_createLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_createLayout.Location = new System.Drawing.Point(151, 103);
            this.button_createLayout.Name = "button_createLayout";
            this.button_createLayout.Size = new System.Drawing.Size(75, 23);
            this.button_createLayout.TabIndex = 6;
            this.button_createLayout.Text = "Create Layout";
            this.button_createLayout.UseVisualStyleBackColor = true;
            this.button_createLayout.Click += new System.EventHandler(this.button_createLayout_Click);
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(25, 6);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(24, 23);
            this.button_refresh.TabIndex = 7;
            this.button_refresh.Text = "R";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // checkedListBox_layouts
            // 
            this.checkedListBox_layouts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox_layouts.CheckOnClick = true;
            this.checkedListBox_layouts.FormattingEnabled = true;
            this.checkedListBox_layouts.Location = new System.Drawing.Point(25, 32);
            this.checkedListBox_layouts.Name = "checkedListBox_layouts";
            this.checkedListBox_layouts.Size = new System.Drawing.Size(120, 94);
            this.checkedListBox_layouts.TabIndex = 8;
            this.checkedListBox_layouts.MouseDown += new System.Windows.Forms.MouseEventHandler(this.checkedListBox_layouts_MouseDown);
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(56, 6);
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
            // button_start
            // 
            this.button_start.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_start.Location = new System.Drawing.Point(89, 110);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(88, 23);
            this.button_start.TabIndex = 10;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // tabControl_Main
            // 
            this.tabControl_Main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_Main.Controls.Add(this.tabPage_Main);
            this.tabControl_Main.Controls.Add(this.tabPage_Layouts);
            this.tabControl_Main.Controls.Add(this.tabPage_Debug);
            this.tabControl_Main.Location = new System.Drawing.Point(12, 9);
            this.tabControl_Main.Name = "tabControl_Main";
            this.tabControl_Main.SelectedIndex = 0;
            this.tabControl_Main.Size = new System.Drawing.Size(275, 249);
            this.tabControl_Main.TabIndex = 11;
            // 
            // tabPage_Main
            // 
            this.tabPage_Main.Controls.Add(this.listBox_activeKLayouts);
            this.tabPage_Main.Controls.Add(this.label_threadStatus);
            this.tabPage_Main.Controls.Add(this.button_start);
            this.tabPage_Main.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Main.Name = "tabPage_Main";
            this.tabPage_Main.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Main.Size = new System.Drawing.Size(267, 223);
            this.tabPage_Main.TabIndex = 0;
            this.tabPage_Main.Text = "Main";
            this.tabPage_Main.UseVisualStyleBackColor = true;
            // 
            // listBox_activeKLayouts
            // 
            this.listBox_activeKLayouts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox_activeKLayouts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_activeKLayouts.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox_activeKLayouts.FormattingEnabled = true;
            this.listBox_activeKLayouts.Location = new System.Drawing.Point(155, 200);
            this.listBox_activeKLayouts.Name = "listBox_activeKLayouts";
            this.listBox_activeKLayouts.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox_activeKLayouts.Size = new System.Drawing.Size(106, 13);
            this.listBox_activeKLayouts.TabIndex = 13;
            this.listBox_activeKLayouts.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_activeKLayouts_DrawItem);
            this.listBox_activeKLayouts.DoubleClick += new System.EventHandler(this.listBox_activeKLayouts_DoubleClick);
            // 
            // label_threadStatus
            // 
            this.label_threadStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_threadStatus.ForeColor = System.Drawing.Color.DarkOrange;
            this.label_threadStatus.Location = new System.Drawing.Point(3, 78);
            this.label_threadStatus.Name = "label_threadStatus";
            this.label_threadStatus.Size = new System.Drawing.Size(258, 29);
            this.label_threadStatus.TabIndex = 11;
            this.label_threadStatus.Text = "Status: Not Running";
            this.label_threadStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_threadStatus.Click += new System.EventHandler(this.label_threadStatus_Click);
            // 
            // tabPage_Layouts
            // 
            this.tabPage_Layouts.Controls.Add(this.pictureBox_defaultLayout);
            this.tabPage_Layouts.Controls.Add(this.checkedListBox_layouts);
            this.tabPage_Layouts.Controls.Add(this.button_refresh);
            this.tabPage_Layouts.Controls.Add(this.button_createLayout);
            this.tabPage_Layouts.Controls.Add(this.button_open);
            this.tabPage_Layouts.Controls.Add(this.button_go);
            this.tabPage_Layouts.Controls.Add(this.progressBar_compileUpload);
            this.tabPage_Layouts.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Layouts.Name = "tabPage_Layouts";
            this.tabPage_Layouts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Layouts.Size = new System.Drawing.Size(267, 223);
            this.tabPage_Layouts.TabIndex = 1;
            this.tabPage_Layouts.Text = "Edit Layouts";
            this.tabPage_Layouts.UseVisualStyleBackColor = true;
            // 
            // pictureBox_defaultLayout
            // 
            this.pictureBox_defaultLayout.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_defaultLayout.Image")));
            this.pictureBox_defaultLayout.Location = new System.Drawing.Point(6, 32);
            this.pictureBox_defaultLayout.Name = "pictureBox_defaultLayout";
            this.pictureBox_defaultLayout.Size = new System.Drawing.Size(15, 15);
            this.pictureBox_defaultLayout.TabIndex = 10;
            this.pictureBox_defaultLayout.TabStop = false;
            this.pictureBox_defaultLayout.Visible = false;
            // 
            // tabPage_Debug
            // 
            this.tabPage_Debug.Controls.Add(this.textBox_Debug);
            this.tabPage_Debug.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Debug.Name = "tabPage_Debug";
            this.tabPage_Debug.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Debug.Size = new System.Drawing.Size(267, 223);
            this.tabPage_Debug.TabIndex = 2;
            this.tabPage_Debug.Text = "Debug";
            this.tabPage_Debug.UseVisualStyleBackColor = true;
            // 
            // textBox_Debug
            // 
            this.textBox_Debug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Debug.Location = new System.Drawing.Point(3, 6);
            this.textBox_Debug.Multiline = true;
            this.textBox_Debug.Name = "textBox_Debug";
            this.textBox_Debug.ReadOnly = true;
            this.textBox_Debug.Size = new System.Drawing.Size(261, 214);
            this.textBox_Debug.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusStrip.AutoSize = false;
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.statusStrip.Location = new System.Drawing.Point(0, 261);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(301, 22);
            this.statusStrip.TabIndex = 12;
            this.statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripStatusLabel.Size = new System.Drawing.Size(60, 15);
            this.toolStripStatusLabel.Text = "Welcome!";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel.Click += new System.EventHandler(this.toolStripStatusLabel_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 283);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl_Main);
            this.Name = "Form_Main";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.tabControl_Main.ResumeLayout(false);
            this.tabPage_Main.ResumeLayout(false);
            this.tabPage_Layouts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_defaultLayout)).EndInit();
            this.tabPage_Debug.ResumeLayout(false);
            this.tabPage_Debug.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
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
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.TabControl tabControl_Main;
        private System.Windows.Forms.TabPage tabPage_Main;
        private System.Windows.Forms.TabPage tabPage_Layouts;
        private System.Windows.Forms.Label label_threadStatus;
        private System.Windows.Forms.PictureBox pictureBox_defaultLayout;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TabPage tabPage_Debug;
        private System.Windows.Forms.TextBox textBox_Debug;
        private System.Windows.Forms.ListBox listBox_activeKLayouts;
    }
}

