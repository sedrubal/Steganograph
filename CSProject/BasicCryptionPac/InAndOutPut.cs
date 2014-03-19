using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicCryptionPac
{
    public partial class InAndOutPut : Form, INotifyPropertyChanged
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

        private void SwitchBool(object sender, ConvertEventArgs e)
        {
            e.Value = !((bool)e.Value);
        }

        #endregion Event

        #region Properties

        private bool _isPWInput;
        public bool IsPWInput
        {
            get
            {
                return this._isPWInput;
            }
            set
            {
                if (this._isPWInput != value)
                {
                    this._isPWInput = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        private bool _isOutPut = true;
        public bool isOutPut
        {
            get
            {
                return this._isOutPut;
            }
            set
            {
                if (this._isOutPut != value)
                {
                    this._isOutPut = value;
                    this.NotifyPropertyChanged();
                    this.CopyBTN.Visible = this._isOutPut;
                }
            }
        }

        //private char[] _legalChars;
        //public char[] LegalChars
        //{
        //    get
        //    {
        //        return this._legalChars;
        //    }
        //    set
        //    {
        //        if (this._legalChars != value)
        //        {
        //            this._legalChars = value;
        //            this.NotifyPropertyChanged();
        //        }
        //    }
        //}

        public string StrText
        {
            get
            {
                string txt = this.TxtTB.Text;
                if (this._isPWInput)
                {
                    this.TxtTB.Text = "";
                }
                return txt;
            }
            set
            {
                if (this.TxtTB.Text != value)
                {
                    this.TxtTB.Text = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public string Message
        {
            get
            {
                return this.MessageLBL.Text;
            }
            set
            {
                if (this.MessageLBL.Text != value)
                {
                    this.MessageLBL.Text = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        #endregion Properties

        #region Start

        public InAndOutPut()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel; //Dass es beim Schließen als cancel gilt

            //Binding
            //this.CopyBTN.DataBindings.Add("Visible", this, "IsOutPut");

            this.TxtTB.DataBindings.Add("UseSystemPasswordChar", this, "IsPWInput");
            Binding MultilineBind = new Binding("Multiline", this, "IsPWInput");
            MultilineBind.Format += SwitchBool;
            MultilineBind.Parse += SwitchBool;
            this.TxtTB.DataBindings.Add(MultilineBind);
            this.TxtTB.DataBindings.Add("ReadOnly", this, "IsOutPut");
            
        }

        public DialogResult ShowDialog(bool isOutPut = false, bool isPasswordInput = false, string Message = "", string Title = "InAndOutPut", IWin32Window owner = null) //HACK TODO: Show(...)
        {
            if (isOutPut == true && isPasswordInput == true)
            {
                throw new ArgumentException("This Dialog can't be a password-inputbox and an outputbox at once.", "isPasswordInput", null);
            }
            this.isOutPut = isOutPut;
            this.IsPWInput = isPasswordInput;
            this.Text = Title;
            this.Message = Message;
            return ShowDialog(owner);
        }

        #endregion Start

        #region Buttons

        private void OkBTN_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void TxtTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && this._isPWInput)
            {
                this.OkBTN.PerformClick();
            }
        }

        private void CopyBTN_Click(object sender, EventArgs e)
        {
            this.TxtTB.Copy();
        }

        #endregion Buttons

    }
}
