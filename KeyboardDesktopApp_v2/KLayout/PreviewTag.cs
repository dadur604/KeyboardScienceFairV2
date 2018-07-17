using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace KeyboardDesktopApp_v2._0 {
    [Serializable]
    public class PreviewTag {

        //[XmlIgnore]
        public Image image { get; set; }

        //[XmlElement("Image")]
        //public byte[] imageByte {
        //    get { // serialize
        //        if (image == null) return null;
        //        MemoryStream ms = new MemoryStream();
        //            image.Save(ms, ImageFormat.Bmp);
        //            return ms.ToArray();
                
        //    }
        //    set { // deserialize
        //        if (value == null) {
        //            image = null;
        //        } else {
        //            MemoryStream ms = new MemoryStream(value);
        //                image = new Bitmap(ms);
                    
        //        }
        //    }
        //}

        public float threshold;
        public bool invert;

        public PreviewTag(Image _image, float _threshold, bool _invert) {
            image = _image;
            threshold = _threshold;
            invert = _invert;
        }

        public PreviewTag() {

        }
    }

}
