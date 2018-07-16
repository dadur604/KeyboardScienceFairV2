using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace KeyboardDesktopApp_v2._0 {
    internal class ProgressListener {
        private ProgressBar progressBar_compileUpload;

        public ProgressListener(ProgressBar progressBar_compileUpload) {
            this.progressBar_compileUpload = progressBar_compileUpload;
        }

        internal void Message(string data) {
            if (data == null) {
                return;
            }
            var compileMatch = Regex.Match(data, @"===info \|\|\| Progress \{0\} \|\|\| \[(\d+).*\]");
            if (compileMatch.Success) {
                var value = int.Parse(compileMatch.Groups[1].Value);
                if (value == 100) {
                    progressBar_compileUpload.BeginInvoke(new MethodInvoker(() => progressBar_compileUpload.Value = 0));
                    return;
                }
                progressBar_compileUpload.BeginInvoke(new MethodInvoker(() => progressBar_compileUpload.Value = value));
                return;
            }
            var uploadMatch = Regex.Match(data, @"(Reading|Writing) \| #+ \| (\d+)%");
            if (uploadMatch.Success) {
                progressBar_compileUpload.BeginInvoke(new MethodInvoker(() => progressBar_compileUpload.Value += 33));
                return;
            }
            var uploadErrorMatch = Regex.Match(data, @"can't open device");
            if (uploadErrorMatch.Success) {
                throw new Exception("Com port cannot be opened! Make sure device is connected.");
            }

            var compileErrorMatch = Regex.Match(data, @"(?<=\w+Ex )(.+)");
            if (compileErrorMatch.Success) {
                throw new Exception("Error Compiling: " + compileErrorMatch.Groups[0]);
            }

            Console.WriteLine(data);
        }
    }
}