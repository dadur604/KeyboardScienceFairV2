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
            Console.WriteLine(data);
        }
    }
}