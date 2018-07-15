using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardDesktopApp_v2._0.DisplayTools {
    class ArduinoCodeMaker {
        private static string defaultTemplate = AppDomain.CurrentDomain.BaseDirectory + "arduinoTemp.txt";

        public ArduinoCodeMaker() {

        }

       /// <summary>
       /// Creates compilable arduino code from multiple cdisplays, allocating secuential layout numbers
       /// </summary>
       /// <param name="KLayouts"></param>
       /// <returns>[0] = List<String> representing arduino code
       /// [1] = int representing number of layouts</returns>
        public Tuple<List<string>, SerializableDictionary<decimal, int>> MakeArduinoCodeFromCDisplay(List<KLayout> KLayouts) {

            List<string> cdisplay = new List<string>();
            SerializableDictionary<decimal, int> idDictionary = new SerializableDictionary<decimal, int>();

            for (int i = 0; i < KLayouts.Count; i++) {
                KLayouts[i].cDisplay.Insert(0, $"if (current == '{i}'){{");
                KLayouts[i].cDisplay.Add("}");
                cdisplay.AddRange(KLayouts[i].cDisplay);
                idDictionary.Add(KLayouts[i].WID, i);
            }



            return new Tuple<List<string>, SerializableDictionary<decimal, int>>(MakeArduinoCodeFromCDisplay(cdisplay), idDictionary);
        }

        /// <summary>
        /// Creates compilable arduino code from cdisplay, using default template
        /// </summary>
        /// <param name="CDisplay"></param>
        public List<string> MakeArduinoCodeFromCDisplay(List<string> CDisplay) {
            return MakeArduinoCodeFromCDisplay(CDisplay, defaultTemplate);
        }

        /// <summary>
        /// Creates compilable arduino code from cdisplay
        /// </summary>
        /// <param name="CDisplay"></param>
        /// <param name="template">full path to template</param>
        public List<string> MakeArduinoCodeFromCDisplay(List<string> CDisplay, string template) {
            var outCode = new List<string>();

            IEnumerable<string> templateLines = File.ReadLines(template);
            bool continueReading = true;
            foreach (string line in templateLines) {
                if (continueReading) {
                    outCode.Add(line);
                    if (line.Contains("//@#")) {
                        continueReading = !continueReading;
                        outCode.AddRange(CDisplay);
                    }
                } else if (line.Contains("//@#")) {
                    outCode.Add(line);
                    continueReading = !continueReading;
                }
            }

            return outCode;
        }
    }
}
