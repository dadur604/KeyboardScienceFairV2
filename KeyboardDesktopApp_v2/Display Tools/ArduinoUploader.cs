using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArduinoUploader;

namespace KeyboardDesktopApp_v2._0.Display_Tools {
    class HexUploader {
        //public void UploadHex(string filepath, SerialPort ser, ProgressBar progressBar) {
        //    var options = new ArduinoSketchUploaderOptions {
        //        ArduinoModel = ArduinoUploader.Hardware.ArduinoModel.UnoR3,
        //        FileName = filepath,
        //        PortName = ser.PortName
        //    };
        //    var asu = new ArduinoSketchUploader(options, progress:new ProgressListener(progressBar));

        //    asu.UploadSketch();
        //}

        public void UploadHex(string filepath, SerialPort ser, DataReceivedEventHandler listener){
            ser.Close();
            Process cmd = SetupCMD(filepath, ser.PortName);

            cmd.OutputDataReceived += listener;
            cmd.ErrorDataReceived += listener;

            cmd.Start();
            cmd.BeginOutputReadLine();
            cmd.BeginErrorReadLine();

            cmd.WaitForExit();
            ser.Open();
        }

        public Task UploadHexAsync(string filepath, SerialPort ser, DataReceivedEventHandler listener) {
            return Task.Run(() => UploadHex(filepath, ser, listener));
        }

        private Process SetupCMD(string filepath, string comPort) {

            List<string> cmds = new List<string>();

            //           "\\\\?\\" + 
            string bdir = AppDomain.CurrentDomain.BaseDirectory;

            cmds.Add($"-patmega328p ");
            cmds.Add($"-carduino ");
            cmds.Add($"-P\"{comPort}\" ");
            cmds.Add($"-b115200 ");
            cmds.Add($"-D ");

            cmds.Add($"-Uflash:w:{filepath}:i");

            string cmdInput = string.Join("", cmds.ToArray());

            Process cmd = new Process();
            cmd.StartInfo.FileName = "ArduinoUploadObjects/avrdude.exe";
            cmd.StartInfo.Arguments = cmdInput;
            cmd.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardError = true;

            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            return cmd;
        }
    }
}
