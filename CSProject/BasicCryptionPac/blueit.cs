using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Steganograph.PlugIns;

namespace BasicCryptionPac
{
    class blueit : CryptImgPlugIn
    {
        public string Name
        {
            get { return "blueit"; }
        }

        public Bitmap EncryptImg(Bitmap OriginalImage)
        {
            for (int x = 0; x < OriginalImage.Width; x++ )
            {
                for (int y = 0; y < OriginalImage.Height; y++)
                {
                    OriginalImage.SetPixel(x, y, Color.FromArgb(OriginalImage.GetPixel(x, y).R, OriginalImage.GetPixel(x, y).G, shrink(OriginalImage.GetPixel(x, y).B * 2)));
                }
            }
            return OriginalImage;
        }

        public Bitmap DecryptImg(Bitmap CryptedImage)
        {
            for (int x = 0; x < CryptedImage.Width; x++)
            {
                for (int y = 0; y < CryptedImage.Height; y++)
                {
                    CryptedImage.SetPixel(x, y, Color.FromArgb(CryptedImage.GetPixel(x, y).R, CryptedImage.GetPixel(x, y).G, CryptedImage.GetPixel(x, y).B / 2));
                }
            }
            return CryptedImage;
        }

        private static int shrink(int v)
        {
            if (v > 255)
                return 255;
            else
                return v;
        }
    }
}
