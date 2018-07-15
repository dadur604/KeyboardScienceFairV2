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
            this.button_accept = new System.Windows.Forms.Button();
            this.panel_Preview = new System.Windows.Forms.Panel();
            this.SuspendLayout();
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
            // panel_Preview
            // 
            this.panel_Preview.AutoScroll = true;
            this.panel_Preview.Location = new System.Drawing.Point(12, 12);
            this.panel_Preview.Name = "panel_Preview";
            this.panel_Preview.Size = new System.Drawing.Size(260, 169);
            this.panel_Preview.TabIndex = 6;
            // 
            // Form_Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 222);
            this.Controls.Add(this.panel_Preview);
            this.Controls.Add(this.button_accept);
            this.Name = "Form_Preview";
            this.Text = "Form_Preview";
            this.Shown += new System.EventHandler(this.Form_Preview_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_accept;
        private System.Windows.Forms.Panel panel_Preview;
    }
}