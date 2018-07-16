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
using System.Xml.Serialization;

namespace KeyboardDesktopApp_v2._0 {
    public partial class Form_Main : Form {

        Form_CreateLayout _Form_CreateLayout;
        ContextMenuStrip checkedListBoxContextMenu;
        KLayout _selectedMenuItem;
        KLayout defaultLayout;

        public Form_Main() {
            InitializeComponent();

            var editMenuItem = new ToolStripMenuItem("Edit");
            var defaultMenuItem = new ToolStripMenuItem("SetDefault");
            editMenuItem.Click += EditClick;
            defaultMenuItem.Click += DefaultClick;
            checkedListBoxContextMenu = new ContextMenuStrip();
            checkedListBoxContextMenu.Items.AddRange(new ToolStripItem[]{ editMenuItem, defaultMenuItem});

            _Form_CreateLayout = new Form_CreateLayout(this);
            _Form_CreateLayout.FormClosed += new FormClosedEventHandler((s, e) => RefreshActiveLayoutsList());
        }


        private void EditClick(object sender, EventArgs e) {
            _Form_CreateLayout.Show(_selectedMenuItem);
        }



        private void DefaultClick(object sender, EventArgs e) {
            if (defaultLayout == _selectedMenuItem) {

                defaultLayout = null;
                pictureBox_defaultLayout.Visible = false;

                return;
            }
            defaultLayout = _selectedMenuItem;
            var index = checkedListBox_layouts.Items.IndexOf(_selectedMenuItem);
            checkedListBox_layouts.SetItemCheckState(index, CheckState.Checked);

            var point = pictureBox_defaultLayout.Location;
            point.Y = 32 + (15 * (checkedListBox_layouts.Items.IndexOf(_selectedMenuItem)));
            pictureBox_defaultLayout.Location = point;
            pictureBox_defaultLayout.Visible = true;

        }

        private void Form_Main_Load(object sender, EventArgs e) {
            button_refresh_Click(null, null);

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Settings.xml")) {
                var file = File.OpenRead(AppDomain.CurrentDomain.BaseDirectory + "Settings.xml");
                var xlms = new XmlSerializer(typeof(ProgramState));
                try {
                    Program.programState = (ProgramState)xlms.Deserialize(file);
                } catch (Exception ex) {
                    Program.programState = new ProgramState();
                } finally {
                    file.Close();
                }
            } else {
                Program.programState = new ProgramState();
            }

            RefreshActiveLayoutsList();
        }

        internal void RefreshActiveLayoutsList() {
            var activeKLayouts = new List<object>() { "Active Layouts:" };

            activeKLayouts.AddRange(Program.programState.KLayouts);

            listBox_activeKLayouts.Items.Clear();
            listBox_activeKLayouts.Items.AddRange(activeKLayouts.ToArray());
            listBox_activeKLayouts.Height = listBox_activeKLayouts.Items.Count * 17;
            listBox_activeKLayouts.Location = new Point(listBox_activeKLayouts.Location.X, listBox_activeKLayouts.Parent.Height - listBox_activeKLayouts.Height);
        }

        private void listBox_activeKLayouts_DrawItem(object sender, DrawItemEventArgs e) {

            if ((e.State & DrawItemState.Focus) > 0) {
                Console.WriteLine();
            }

            string output = listBox_activeKLayouts.Items[e.Index].ToString();
            float olength = e.Graphics.MeasureString(output, e.Font).Width;
            float pos = listBox_activeKLayouts.Width - olength;
            SolidBrush brush = new SolidBrush(e.ForeColor);
            e.Graphics.FillRectangle(new SolidBrush(e.BackColor), new RectangleF(pos, e.Bounds.Top, olength, e.Bounds.Height));
            e.Graphics.DrawString(output, e.Font, brush, pos, e.Bounds.Top);
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e) {
            Program.Stop();

            var xmls = new XmlSerializer(Program.programState.GetType());
            var file = File.Create(AppDomain.CurrentDomain.BaseDirectory + "Settings.xml");
            xmls.Serialize(file, Program.programState);
            file.Close();
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
                    var klayout = BinarySerializer.ReadFromBinaryFile<KLayout>(layoutfile);

                    if (checkedListBox_layouts.Items.Cast<KLayout>().Any(x => x.Equals(klayout))) {
                        continue;
                    }
                    var i = checkedListBox_layouts.Items.Add(klayout);

                    //checkedListBox_layouts.Items[i];
                    // TODO
                } catch (ArgumentException er) {
                    var shortenedFileName = layoutfile.Substring(Math.Max(0, layoutfile.Length - 25));
                    DebugHandle(er.Message + " : ..." + shortenedFileName, true);
                    continue;
                }
            }
        }

        private void checkedListBox_layouts_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Right) return;
            var index = checkedListBox_layouts.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches) {
                _selectedMenuItem = (KLayout)checkedListBox_layouts.Items[index];
                checkedListBoxContextMenu.Show(Cursor.Position);
                checkedListBoxContextMenu.Visible = true;
            } else {
                checkedListBoxContextMenu.Visible = false;
            }
        }
        private void checkedListBox_layouts_MouseClick(object sender, EventArgs e) {
            
        }

        private void button_open_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = @"KLayouts | *.klayout";
            openFileDialog1.FileName = "";
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
                    var klayout = BinarySerializer.ReadFromBinaryFile<KLayout>(layoutfile);

                    if (checkedListBox_layouts.Items.Cast<KLayout>().Any(x => x.Equals(klayout))) {
                        continue;
                    }
                    checkedListBox_layouts.Items.Add(klayout);
                } catch (ArgumentException er) {
                    DebugHandle(er.Message, true);
                    continue;
                }

            }

        }


#endregion

        private void button_go_Click(object sender, EventArgs e) {

            //var checkedItems = checkedListBox_layouts.CheckedItems

            if (checkedListBox_layouts.CheckedItems.Count < 1) {
                DebugHandle("Selected Layouts must be 1 or 2!", true);
                return;
            }
            if (checkedListBox_layouts.CheckedItems.Count > 2) {
                DebugHandle("Selected Layouts must be 1 or 2!", true);
                return;
            }
            if (!checkedListBox_layouts.CheckedItems.Contains(defaultLayout)) {
                DebugHandle("Default layout must be selected!", true);
                return;
            }

            var defaultindex = checkedListBox_layouts.CheckedItems.IndexOf(defaultLayout);
            Program.programState.defaultIndex = defaultindex;

            var layouts = checkedListBox_layouts.CheckedItems.Cast<KLayout>();
            try {
                Program.CreateAndUpload(layouts);
            } catch (Exception er) {
                DebugHandle(er.Message, true);
            }
            
        }

        private void button_start_Click(object sender, EventArgs e) {
            if (button_start.Text == "Start") {
                Program.Start();
                button_start.Text = "Stop";
            } else if (button_start.Text == "Stop") {
                Program.Stop();
                button_start.Text = "Start";
            }
        }

        public void UpdateThreadStatus() {
            if (Program.running) {
                label_threadStatus.Invoke(new MethodInvoker(() => {
                    label_threadStatus.Text = "Satus : Running!";
                    label_threadStatus.ForeColor = Color.DarkGreen;
                }));
                
            } else {
                label_threadStatus.Invoke(new MethodInvoker(() => {
                    label_threadStatus.Text = "Satus : Not Running!";
                    label_threadStatus.ForeColor = Color.DarkOrange;
                }));
            }
        }

        private void label_threadStatus_Click(object sender, EventArgs e) {

        }

        public void DebugHandle(string text, bool error = false) {
            textBox_Debug.Invoke(new MethodInvoker(() => textBox_Debug.AppendText(text + "\n")));
            if (error) {
                Program.errorState = true;
                Program.errorMsg = text;
                statusStrip.Invoke(new MethodInvoker(() => toolStripStatusLabel.Text = text));
            }
        }


        private void toolStripStatusLabel_Click(object sender, EventArgs e) {
            tabControl_Main.Invoke(new MethodInvoker(() => tabControl_Main.SelectedTab = tabPage_Debug));
        }

        private void listBox_activeKLayouts_DoubleClick(object sender, EventArgs e) {
            var klayout = listBox_activeKLayouts.SelectedItem as KLayout;
            if (klayout == null) {
                return;
            }

            _Form_CreateLayout.Show(klayout);
        }
    }
}
