using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KeyboardDesktopApp_v2._0 {
    [Serializable]
    public class KLayout {

        public string Name { get; set; }

        public List<string> cDisplay { get; set; }

        public decimal WID { get; set; }

        //public List<string> images { get; set; }

        public List<PreviewTag> images { get; set; }

        public KLayout(string _name, decimal _wid, List<string> _cdisplay, List<PreviewTag> _images) {
            Name = _name;
            cDisplay = _cdisplay;
            WID = _wid;
            images = _images;
        }

        public KLayout() {

        }

        //static public List<string> KLayoutToFile(KLayout klayout) {
        //    List<string> output = new List<string>();
        //    output.Add($"Name={klayout.Name}");
        //    output.Add($"ID={klayout.WID}");
        //    foreach (var image in klayout.images) {
        //        output.Add($"IMG={image}");
        //    }
        //    output.Add("========");
        //    output.AddRange(klayout.cDisplay);

        //    return output;
        //}

        //static public KLayout ReadKlayout(string filepath) {
        //    var lines = File.ReadLines(filepath);
        //    string name = null;
        //    List<string> cDisplay = new List<string>();
        //    decimal WID = 0;
        //    var images = new List<string>();

        //    foreach (var line in lines) {
                
        //        var nameMatch = Regex.Match(line, @"Name=(.*)");
        //        if (nameMatch.Success) {
        //            name = nameMatch.Groups[1].Value;
        //            continue;
        //        }

        //        var widMatch = Regex.Match(line, @"ID=(.*)");
        //        if (widMatch.Success) {
        //            WID = decimal.Parse(widMatch.Groups[1].Value);
        //            continue;
        //        }

        //        var imgMatch = Regex.Match(line, @"IMG=(.*)");
        //        if (imgMatch.Success) {
        //            images.Add(imgMatch.Groups[1].Value);
        //            continue;
        //        }

        //        var displayMatch = Regex.Match(line, @"={8}");
        //        if (displayMatch.Success) {
        //            continue;
        //        }

        //        cDisplay.Add(line);
        //    }

        //    if (name == null || WID == 0) {
        //        throw new ArgumentException("Invalid klayout file!");
        //    }
        //    var klayout = new KLayout(name, WID, cDisplay, images);
        //    return klayout;
        //}

        public override string ToString() {
            return Name;
        }

        // override object.Equals
        public override bool Equals(object obj) {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }

            var layout = (KLayout)obj;

            if (layout.Name == Name) {
                if (layout.WID == WID) {
                    if (Enumerable.SequenceEqual(layout.cDisplay, cDisplay)) {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
