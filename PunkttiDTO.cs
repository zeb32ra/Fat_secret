using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fat_Secret
{
    public class PunkttiDTO
    {
        public bool isCheked;
        public Uri img_path;
        public string title;

        public PunkttiDTO(bool isch, Uri img, string t)
        {
            isCheked = isch;
            img_path = img;
            title = t;
        }
    }
}
