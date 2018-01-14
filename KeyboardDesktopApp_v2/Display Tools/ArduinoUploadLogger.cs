using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardDesktopApp_v2._0.Display_Tools {
    class ArduinoUploadLogger : ArduinoUploader.IArduinoUploaderLogger {
        public void Debug(string message) {
            Console.WriteLine(message);
        }

        public void Error(string message, Exception exception) {
            Console.WriteLine(message);
        }

        public void Info(string message) {
            Console.WriteLine(message);
        }

        public void Trace(string message) {
            Console.WriteLine(message);
        }

        public void Warn(string message) {
            Console.WriteLine(message);
        }
    }
}
