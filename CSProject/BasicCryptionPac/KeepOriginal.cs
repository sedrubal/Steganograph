using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Steganograph.PlugIns;

namespace BasicCryptionPac
{
    class KeepOriginal : CryptImgPlugIn
    {
        public string Name
        {
            get { return "Keep-Original"; }
        }

        public Bitmap EncryptImg(Bitmap OriginalImage)
        {
            return OriginalImage;
        }

        public Bitmap DecryptImg(Bitmap CryptedImage)
        {
            return CryptedImage;
        }
    }
}
