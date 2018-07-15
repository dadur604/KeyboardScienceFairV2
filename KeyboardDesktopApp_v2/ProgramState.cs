using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardDesktopApp_v2._0 {
    public class ProgramState {

        public List<KLayout> KLayouts { get; set; }

        public SerializableDictionary<decimal, int> idDictionary { get; set; }

        public int defaultIndex { get; set; }

        public string UploadObjectsPath { get; set; }

        public string CompileObjectsPath { get; set; }

        public ProgramState() {
            UploadObjectsPath = @"C:\WinAVR-20100110\bin\";
            CompileObjectsPath = @"C:\Program Files (x86)\Arduino\";
        }

    }
}
