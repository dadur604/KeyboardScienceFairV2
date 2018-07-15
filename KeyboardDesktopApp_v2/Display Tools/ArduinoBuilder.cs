using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KeyboardDesktopApp_v2._0.Display_Tools {
    /// <summary>
    /// Builds arduino ino into .hex file, ready to be uploaded to a board. Build around arduiuno-builder
    /// </summary>
    class ArduinoBuilder {

        public string GetTemporaryDirectory() {
            string tempFolder = Path.GetTempFileName();
            File.Delete(tempFolder);
            Directory.CreateDirectory(tempFolder);

            return tempFolder;
        }

        /// <summary>
        /// Converts ardino .ino file into upload-able .hex file.
        /// </summary>
        /// <param name="filepath">Filepath to .ino file</param>
        /// <param name="baseDirectory">weather or not to append base directory to filepath</param>
        /// <returns></returns>
        public string ArduinoToHex(string filepath, bool baseDirectory) {

            string outdir = GetTemporaryDirectory();
            Process cmd = SetupCMD(filepath, baseDirectory, outdir);

            cmd.Start();
            cmd.BeginOutputReadLine();
            cmd.BeginErrorReadLine();

            cmd.WaitForExit();

            return outdir;
        }

        public string ArduinoToHex(string filepath, bool baseDirectory, DataReceivedEventHandler listener) {

            string outdir = GetTemporaryDirectory();
            Process cmd = SetupCMD(filepath, baseDirectory, outdir);

            cmd.OutputDataReceived += listener;
            cmd.ErrorDataReceived += listener;

            cmd.Start();
            cmd.BeginOutputReadLine();
            cmd.BeginErrorReadLine();

            cmd.WaitForExit();

            return outdir;
            
        }

        public Task<string> ArduinoToHexAsync(string filepath, bool baseDirectory) {
            return Task.Run(() => ArduinoToHex(filepath, baseDirectory));
        }

        public Task<string> ArduinoToHexAsync(string filepath, bool baseDirectory, DataReceivedEventHandler listener) {
            return Task.Run(() => ArduinoToHex(filepath, baseDirectory, listener));
        }

        private Process SetupCMD(string filepath, bool baseDirectory, string outdir) {
            if (baseDirectory) {
                filepath = AppDomain.CurrentDomain.BaseDirectory + filepath;
            }

            List<string> cmds = new List<string>();

            //           "\\\\?\\" + 
            string bdir = AppDomain.CurrentDomain.BaseDirectory;

            //string compileObjectsDir = bdir + "ArduinoCompileObjects\\";
            string compileObjectsDir = Program.programState.CompileObjectsPath;

            cmds.Add("-compile -logger=machine ");
            cmds.Add($"-hardware=\" {compileObjectsDir}hardware\" ");
            cmds.Add($"-tools=\" {compileObjectsDir}tools-builder\" ");
            cmds.Add($"-tools=\" {compileObjectsDir}hardware\\tools\\avr\" ");
            cmds.Add($"-built-in-libraries=\" {compileObjectsDir}libraries\" ");

            cmds.Add($"-fqbn=arduino:avr:uno ");
            cmds.Add($"-ide-version=10607 -warnings=none ");
            cmds.Add($"-build-path \"{outdir}\" ");
            cmds.Add($"-prefs=build.warn_data_percentage=75 ");
            cmds.Add($"-verbose ");
            cmds.Add($"\"{filepath}\"");

            string cmdInput = string.Join("", cmds.ToArray());

            Process cmd = new Process();
            cmd.StartInfo.FileName = $"{compileObjectsDir}/arduino-builder";
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
