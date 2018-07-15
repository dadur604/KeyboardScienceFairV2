using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardDesktopApp_v2._0 {
    [Serializable]
    public class PreviewTag {
        public Image image;
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
