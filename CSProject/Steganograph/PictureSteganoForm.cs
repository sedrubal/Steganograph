using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganograph
{
    public partial class PictureSteganoForm : Form
    {
        #region Binding

        private PictureStegano MyPictureStegano = new PictureStegano();

        public PictureSteganoForm()
        {
            InitializeComponent();
            //Binding:
            this.OriginalPicPB.DataBindings.Add("Image", this.MyPictureStegano, "OriginalImage", true);
            this.ModifiedPicPB.DataBindings.Add("Image", this.MyPictureStegano, "ModifiedImage", true);
            this.CryptModeCB.DataSource = this.MyPictureStegano.CryptPlugIns;
            this.CryptModeCB.DisplayMember = "Name";
            this.CryptModeCB.ValueMember = "";
            //this.CryptModeCB.DataBindings.Add("SelectedItem", this.MyPictureStegano, "SelectedMode");
        }

        private void CryptModeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.MyPictureStegano.SelectedMode = (PlugIns.CryptImgPlugIn)this.CryptModeCB.SelectedValue;
        }

        #endregion Binding

        #region Buttons

        #region Load / Save

        private void OpenFileBTN_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Bitmap img = new Bitmap(this.openFileDialog1.FileName);

                    Bitmap newImg = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb); //Format24bppRgb
                    System.Drawing.Graphics gr = Graphics.FromImage(newImg);
                    gr.DrawImage(img, new Point(0, 0));

                    this.MyPictureStegano.OriginalImage = newImg;
                    img.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Das Bild konnte nicht geladen werden: " + Environment.NewLine + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            if (this.MyPictureStegano.ModifiedImage != null)
            {
                if (this.saveFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        this.MyPictureStegano.ModifiedImage.Save(this.saveFileDialog1.FileName);//, System.Drawing.Imaging.ImageFormat.Tiff); //, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Das Bild konnte nicht gespeichert werden: " + Environment.NewLine + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Es wurde noch kein Bild modifiziert. Öffnen Sie ein Bild und Ver-/Ent-schlusseln Sie es.", "Kein modifiziertes Bild", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion Load / Save

        #region En-/Decrypt

        private void EncryptBTN_Click(object sender, EventArgs e)
        {
            if (this.MyPictureStegano.SelectedMode != null)
            {
                if (this.MyPictureStegano.OriginalImage != null)
                {
                    try
                    {
                        this.MyPictureStegano.ModifiedImage = this.MyPictureStegano.SelectedMode.EncryptImg((Bitmap)this.MyPictureStegano.OriginalImage.Clone());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Das PlugIn " + this.MyPictureStegano.SelectedMode.Name + " hat einen Fehler ausgelöst:" + Environment.NewLine + ex.Message, "PlugIn Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Es ist kein Originalbild geladen. Klicken Sie auf Öffnen, um eins zu laden.", "Kein Bild", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, "Es ist kein Verschlüsselungsmodus ausgewählt. Wählen Sie erst einen aus.", "Kein Modus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DecryptBTN_Click(object sender, EventArgs e)
        {
            if (this.MyPictureStegano.SelectedMode != null)
            {
                if (this.MyPictureStegano.OriginalImage != null)
                {
                    try
                    {
                        this.MyPictureStegano.ModifiedImage = this.MyPictureStegano.SelectedMode.DecryptImg((Bitmap)this.MyPictureStegano.OriginalImage.Clone());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Das PlugIn " + this.MyPictureStegano.SelectedMode.Name + " hat einen Fehler ausgelöst:" + Environment.NewLine + ex.Message, "PlugIn Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(this, "Es ist kein Bild geladen. Klicken Sie auf Öffnen, um eins zu laden.", "Kein Bild", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, "Es ist kein Entschlüsselungsmodus ausgewählt. Wählen Sie erst einen aus.", "Kein Modus", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion En-/Decrypt

        #endregion Buttons
    }
}