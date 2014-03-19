using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using Steganograph.PlugIns;

namespace Steganograph
{
    class PictureStegano : INotifyPropertyChanged
    {
        #region Event

        public event PropertyChangedEventHandler PropertyChanged; 
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion Event

        #region Images

        //private string _originalPicturePath;
        //public string OriginalPicturePath 
        //{
        //    get
        //    {
        //        return this._originalPicturePath;
        //    }
        //    set
        //    {
        //        if (this._originalPicturePath != value)
        //        {
        //            this._originalPicturePath = value;
        //        }
        //    }
        //}

        private Bitmap _originalImage;
        public Bitmap OriginalImage
        {
            get
            {
                return this._originalImage;
            }
            set
            {
                if (this._originalImage != value)
                {
                    if (this._originalImage != null)
                    {
                        this._originalImage.Dispose();
                    }
                    if (value == null)
                    {
                        this._originalImage = value;
                    }
                    else
                    {
                        this._originalImage = (Bitmap) value.Clone();
                    }
                    this.ModifiedImage = null;
                    NotifyPropertyChanged();
                }
            }
        }

        private Bitmap _modifiedImage;
        public Bitmap ModifiedImage
        {
            get
            {
                return this._modifiedImage;
            }
            set
            {
                if (this._modifiedImage != value)
                {
                    if (this._modifiedImage != null)
                    {
                        this._modifiedImage.Dispose();
                    }
                    if (value == null)
                    {
                        this._modifiedImage = value;
                    }
                    else
                    {
                        this._modifiedImage = (Bitmap) value.Clone();
                    }
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion Images

        #region Modes

        private List<CryptImgPlugIn> _cryptPlugIns = new List<CryptImgPlugIn>();
        public List<CryptImgPlugIn> CryptPlugIns
        {
            get
            {
                _cryptPlugIns = PlugIns.PlugInConnector.LoadImgPlugIns(System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath));
                return _cryptPlugIns;
            }
        }

        private CryptImgPlugIn _selectedMode;
        public CryptImgPlugIn SelectedMode
        {
            get
            {
                return this._selectedMode;
            }
            set
            {
                if (this._selectedMode != value)
                {
                    this._selectedMode = value;
                    NotifyPropertyChanged();
                }
            }
        }

        #endregion Modes

        public PictureStegano()
        {
            if (this.CryptPlugIns.Count > 0)
            {
                this.SelectedMode = this.CryptPlugIns[0];
            }
        }
    }
}
