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

namespace KeyboardDesktopApp_v2._0 {
    public partial class Form_Settings : Form {
        public Form_Settings() {
            InitializeComponent();
        }

        private void Form_Settings_Load(object sender, EventArgs e) {

            textBox_compilePath.Text = Program.programState.CompileObjectsPath;
            textBox_uploadPath.Text = Program.programState.UploadObjectsPath;

        }

        private void button_compileBrowse_Click(object sender, EventArgs e) {
            var result = folderBrowserDialog1.ShowDialog();
            if ((result & DialogResult.OK) == 0) {
                return;
            }

            #region compilePathValidity
            if (
                !File.Exists     (folderBrowserDialog1.SelectedPath + "\\arduino-builder.exe")    ||
                !Directory.Exists(folderBrowserDialog1.SelectedPath + "\\hardware\\")             ||
                !Directory.Exists(folderBrowserDialog1.SelectedPath + "\\tools-builder\\")        ||
                !Directory.Exists(folderBrowserDialog1.SelectedPath + "\\hardware\\tools\\avr\\") ||
                !Directory.Exists(folderBrowserDialog1.SelectedPath + "\\libraries\\")
                ) { 
                    Error("Invalid Compile Path Folder!");
                    return;
            }
            #endregion

            textBox_compilePath.Text = folderBrowserDialog1.SelectedPath + "\\";
        }

        private void button_uploadBrowse_Click(object sender, EventArgs e) {
            var result = folderBrowserDialog1.ShowDialog();
            if ((result & DialogResult.OK) == 0) {
                return;
            }

            #region uploadPathValidity
            if (
                !File.Exists(folderBrowserDialog1.SelectedPath + "\\avrdude.exe")) {
                Error("Invalid Upload Path Folder!");
                return;
            }
            #endregion

            textBox_uploadPath.Text = folderBrowserDialog1.SelectedPath + "\\";
        }

        private void button_save_Click(object sender, EventArgs e) {
            Program.programState.CompileObjectsPath = textBox_compilePath.Text;
            Program.programState.UploadObjectsPath = textBox_uploadPath.Text;

            Close();
        }

        private void Error(string message) {
            MessageBox.Show(message, message, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
