using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Steganograph.PlugIns
{
    public interface CryptImgPlugIn
    {
        string Name
        {
            get;
        }

        Bitmap EncryptImg(Bitmap OriginalImage);

        Bitmap DecryptImg(Bitmap CryptedImage);
    }
}
