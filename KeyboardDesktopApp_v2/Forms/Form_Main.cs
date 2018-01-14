using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyboardDesktopApp_v2._0.DisplayTools;

namespace KeyboardDesktopApp_v2._0 {
    public partial class Form_Main : Form {

        Form_CreateLayout _Form_CreateLayout;

        public Form_Main() {
            InitializeComponent();

            _Form_CreateLayout = new Form_CreateLayout(this);
        }

        private void button_createLayout_Click(object sender, EventArgs e) {
            _Form_CreateLayout.ShowDialog();
        }

#region CheckboxList
        private void button_refresh_Click(object sender, EventArgs e) {
            var layoutfiles = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory + @"layouts\", "*.klayout", SearchOption.AllDirectories);
            foreach (var layoutfile in layoutfiles) {
                if (!Regex.IsMatch(layoutfile, @".*\.klayout")) {
                    continue;
                }

                try {
                    var klayout = KLayout.ReadKlayout(layoutfile);

                    if (checkedListBox_layouts.Items.Cast<KLayout>().Any(x => x.Equals(klayout))) {
                        continue;
                    }
                    checkedListBox_layouts.Items.Add(klayout);
                } catch (ArgumentException) {
                    //TODO: ERROR HANDLE
                    continue;
                }
            }
        }

        private void button_open_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = @"KLayouts | *.klayout";
            var result = openFileDialog1.ShowDialog();
            if (result != DialogResult.OK) {
                return;
            }
            var layoutfiles = openFileDialog1.FileNames;
            foreach (var layoutfile in layoutfiles) {
                if (!Regex.IsMatch(layoutfile, @".*\.klayout")) {
                    continue;
                }

                try {
                    var klayout = KLayout.ReadKlayout(layoutfile);

                    if (checkedListBox_layouts.Items.Cast<KLayout>().Any(x => x.Equals(klayout))) {
                        continue;
                    }
                    checkedListBox_layouts.Items.Add(klayout);
                } catch (ArgumentException) {
                    //TODO: ERROR HANDLE
                    continue;
                }

            }

        }


        #endregion

        private void button_go_Click(object sender, EventArgs e) {
            if (checkedListBox_layouts.CheckedItems.Count < 1) {
                //TODO: ERROR HANDLE
                return;
            } else if(checkedListBox_layouts.CheckedItems.Count > 2) {
                //TODO: ERROR HANDLE
                return;
            }

            var layouts = checkedListBox_layouts.CheckedItems.Cast<KLayout>()
                Program.CreateAndUpload(layouts);
            
        }
    }
}
