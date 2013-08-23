using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Ideas4AppsHub.Domain
{
    public class Photo
    {
        public byte[] RawPhoto { get; set; }

        public Bitmap Bitmap
        {
            get
            {
                if (RawPhoto == null) return null;
                using (MemoryStream ms = new MemoryStream(RawPhoto))
                {
                    Bitmap img = (Bitmap)Image.FromStream(ms);
                    return img;
                }
            }
        }
    }
}
