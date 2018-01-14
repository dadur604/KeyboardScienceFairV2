using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using KeyboardDesktopApp_v2._0.Display_Tools;
using KeyboardDesktopApp_v2._0.DisplayTools;

namespace KeyboardDesktopApp_v2._0 {

    /// <summary>
    /// Program Class
    /// Here is where the keyboard updating and functionality methods are found.
    /// </summary>
    internal class Program {
        public static Form_Main _Form_Main;

        // Define all external functions
        [DllImport("user32.dll")]
        private static extern IntPtr GetKeyboardLayout(uint idThread);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        // Define a few constant variables
        public static int engLayout = 67699721;

        public static int armLayout = -266009557;

        public static bool engState = false;
        public static bool armState = false;

        // Start the Serial Communication Port
        public static SerialPort ser = new SerialPort("COM3", 9600);

        // Define Send and Recieve threads
        public static Thread threadSend = new Thread(new ThreadStart(SendSerial));

        public static Thread threadRecieve = new Thread(new ThreadStart(RecieveSerial));

        // Initialize error-handling variables
        public static bool errorState { get; set; } = false;

        public static string errorMsg { get; set; } = null;
        public static ManualResetEvent _suspendEvent = new ManualResetEvent(true);

        public static int layout = (int)GetKeyboardLayout(0);

        /// <summary>
        /// Entry point for program. Starts Form1, and runs start method
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        public static void Main(string[] args) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _Form_Main = new Form_Main();

            //Start();
            _Form_Main.button_go.Click += Button_go_Click;


            Application.Run(_Form_Main);
            
        }

         async private static void Button_go_Click(object sender, EventArgs i) {
            //DisplayMaker displayMaker = new DisplayMaker();
            //var imageATag = (object[])_Form_Main.pictureBox_left.Tag;
            //var imageBTag = (object[])_Form_Main.pictureBox_right.Tag;
            //Image imageA = new Bitmap(imageATag[0].ToString());
            //Image imageB = new Bitmap(imageBTag[0].ToString());
            //List<List<string>> imageA_C = displayMaker.MakeCImageFromImage(imageA, DisplayMaker.IMAGE_SIZE, (float)imageATag[1], (bool)imageATag[2]);
            //List<List<string>> imageB_C = displayMaker.MakeCImageFromImage(imageB, DisplayMaker.IMAGE_SIZE, (float)imageBTag[1], (bool)imageBTag[2]);

            //List<String> displayAB_C = displayMaker.MakeCDisplayFromCImage(new List<List<string>>[] { imageA_C, imageB_C });

            //var arduinoCodeMaker = new ArduinoCodeMaker();
            //List<String> displayAB_A = arduinoCodeMaker.MakeArduinoCodeFromCDisplay(displayAB_C);

            //Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "output\\");
            //File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + "output\\output.ino", displayAB_A);
            //var compiler = new ArduinoBuilder();
            //var uploader = new HexUploader();
            //var progressListener = new ProgressListener(_Form_Main.progressBar_compileUpload);
            //var imageAB_H = await compiler.ArduinoToHexAsync("output\\output.ino", true, new System.Diagnostics.DataReceivedEventHandler(
            //    (s, e) => progressListener.Message(e.Data)));
            //await uploader.UploadHexAsync(imageAB_H + "\\output.ino.hex", ser, new System.Diagnostics.DataReceivedEventHandler(
            //    (s, e) => progressListener.Message(e.Data)));
        }

        async internal static void CreateAndUpload(IEnumerable<KLayout> layouts) {

            var arduinoCodeMaker = new ArduinoCodeMaker();
            var cDisplays = layouts.Select(x => x.cDisplay);
            var arduinoCode = arduinoCodeMaker.MakeArduinoCodeFromCDisplay(cDisplays);


            
            

            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "output\\");
            File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + "output\\output.ino", displayAB_A);
            var compiler = new ArduinoBuilder();
            var uploader = new HexUploader();
            var progressListener = new ProgressListener(_Form_Main.progressBar_compileUpload);
            var imageAB_H = await compiler.ArduinoToHexAsync("output\\output.ino", true, new System.Diagnostics.DataReceivedEventHandler(
                (s, e) => progressListener.Message(e.Data)));
            await uploader.UploadHexAsync(imageAB_H + "\\output.ino.hex", ser, new System.Diagnostics.DataReceivedEventHandler(
                (s, e) => progressListener.Message(e.Data)));
        }

        /// <summary>
        /// Main method for checking keyboard layout, and updating keyboard via serial.
        /// </summary>
        private static void SendSerial() {
            //  Console.WriteLine(layout);
            while(true) {
                _suspendEvent.WaitOne(Timeout.Infinite);

                //Get the current window's thread id
                IntPtr w_handle = GetForegroundWindow();
                uint w_tid = GetWindowThreadProcessId(w_handle, IntPtr.Zero);

                int layout_b = layout;
                layout = (int)GetKeyboardLayout(w_tid);

                if(layout != layout_b) {
                    if(layout == engLayout) {
                        ser.Write("1");
                        Console.WriteLine("English");
                        //Form1.("English");
                        //_Form1.AppendTextDebug("English");
                    } else if(layout == armLayout) {
                        ser.Write("2");
                        Console.WriteLine("Armenian");
                        //_Form1.AppendTextDebug("Armenian");
                    } else {
                        ser.Write("1");
                        Console.WriteLine("Unknown");
                        //_Form1.AppendTextDebug("Unknown");
                    }
                }
            }
        }

        /// <summary>
        /// Main method for checking for serial input from keyboard, to type keys.
        /// </summary>
        private static void RecieveSerial() {
            while(true) {
                _suspendEvent.WaitOne(Timeout.Infinite);

                int inserial;

                try {
                    inserial = ser.ReadByte();
                } catch(Exception) {
                    continue;
                }

                if(inserial == 49) {
                    SendKeys.SendWait("e");
                } else if(inserial == 50) {
                    SendKeys.SendWait("n");
                } else {
                    //  Console.WriteLine(inserial);
                }
            }
        }

        /// <summary>
        /// Start method will open serial port, and start threads.
        /// </summary>
        public static void Start() {
            try {
                if(ser.IsOpen) {
                    ser.Close();
                }
                ser.Open();

                if(!threadSend.IsAlive) {
                    threadSend.Start();
                }
                if(!threadRecieve.IsAlive) {
                    threadRecieve.Start();
                }
                //_Form1.buttonStart_Update();
            } catch(Exception e) {
               
            }
        }

    }
}