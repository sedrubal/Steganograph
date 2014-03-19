namespace Steganograph
{
    partial class PictureSteganoForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CryptModeLBL = new System.Windows.Forms.Label();
            this.CryptModeCB = new System.Windows.Forms.ComboBox();
            this.OriginalPicLBL = new System.Windows.Forms.Label();
            this.ModifiedPicLBL = new System.Windows.Forms.Label();
            this.OriginalPicPB = new System.Windows.Forms.PictureBox();
            this.ModifiedPicPB = new System.Windows.Forms.PictureBox();
            this.OpenFileBTN = new System.Windows.Forms.Button();
            this.EncryptBTN = new System.Windows.Forms.Button();
            this.SaveBTN = new System.Windows.Forms.Button();
            this.DecryptBTN = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPicPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedPicPB)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.CryptModeLBL, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.CryptModeCB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.OriginalPicLBL, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.ModifiedPicLBL, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.OriginalPicPB, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ModifiedPicPB, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.OpenFileBTN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.EncryptBTN, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.SaveBTN, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.DecryptBTN, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(781, 462);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // CryptModeLBL
            // 
            this.CryptModeLBL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CryptModeLBL.Location = new System.Drawing.Point(4, 37);
            this.CryptModeLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CryptModeLBL.Name = "CryptModeLBL";
            this.CryptModeLBL.Size = new System.Drawing.Size(382, 37);
            this.CryptModeLBL.TabIndex = 1;
            this.CryptModeLBL.Text = "&Modus:";
            this.CryptModeLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CryptModeCB
            // 
            this.CryptModeCB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CryptModeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CryptModeCB.FormattingEnabled = true;
            this.CryptModeCB.Location = new System.Drawing.Point(394, 41);
            this.CryptModeCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CryptModeCB.Name = "CryptModeCB";
            this.CryptModeCB.Size = new System.Drawing.Size(383, 24);
            this.CryptModeCB.TabIndex = 2;
            this.CryptModeCB.SelectedIndexChanged += new System.EventHandler(this.CryptModeCB_SelectedIndexChanged);
            // 
            // OriginalPicLBL
            // 
            this.OriginalPicLBL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginalPicLBL.Location = new System.Drawing.Point(4, 111);
            this.OriginalPicLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OriginalPicLBL.Name = "OriginalPicLBL";
            this.OriginalPicLBL.Size = new System.Drawing.Size(382, 37);
            this.OriginalPicLBL.TabIndex = 4;
            this.OriginalPicLBL.Text = "Original-Bild:";
            this.OriginalPicLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ModifiedPicLBL
            // 
            this.ModifiedPicLBL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModifiedPicLBL.Location = new System.Drawing.Point(394, 111);
            this.ModifiedPicLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ModifiedPicLBL.Name = "ModifiedPicLBL";
            this.ModifiedPicLBL.Size = new System.Drawing.Size(383, 37);
            this.ModifiedPicLBL.TabIndex = 5;
            this.ModifiedPicLBL.Text = "Modifiziertes-Bild:";
            this.ModifiedPicLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OriginalPicPB
            // 
            this.OriginalPicPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginalPicPB.Location = new System.Drawing.Point(4, 152);
            this.OriginalPicPB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OriginalPicPB.Name = "OriginalPicPB";
            this.OriginalPicPB.Size = new System.Drawing.Size(382, 269);
            this.OriginalPicPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.OriginalPicPB.TabIndex = 6;
            this.OriginalPicPB.TabStop = false;
            // 
            // ModifiedPicPB
            // 
            this.ModifiedPicPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModifiedPicPB.Location = new System.Drawing.Point(394, 152);
            this.ModifiedPicPB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ModifiedPicPB.Name = "ModifiedPicPB";
            this.ModifiedPicPB.Size = new System.Drawing.Size(383, 269);
            this.ModifiedPicPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ModifiedPicPB.TabIndex = 7;
            this.ModifiedPicPB.TabStop = false;
            // 
            // OpenFileBTN
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.OpenFileBTN, 2);
            this.OpenFileBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenFileBTN.Location = new System.Drawing.Point(4, 4);
            this.OpenFileBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.OpenFileBTN.Name = "OpenFileBTN";
            this.OpenFileBTN.Size = new System.Drawing.Size(773, 29);
            this.OpenFileBTN.TabIndex = 3;
            this.OpenFileBTN.Text = "&Öffnen";
            this.OpenFileBTN.UseVisualStyleBackColor = true;
            this.OpenFileBTN.Click += new System.EventHandler(this.OpenFileBTN_Click);
            // 
            // EncryptBTN
            // 
            this.EncryptBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EncryptBTN.Location = new System.Drawing.Point(4, 78);
            this.EncryptBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.EncryptBTN.Name = "EncryptBTN";
            this.EncryptBTN.Size = new System.Drawing.Size(382, 29);
            this.EncryptBTN.TabIndex = 8;
            this.EncryptBTN.Text = "&Verschlüsseln";
            this.EncryptBTN.UseVisualStyleBackColor = true;
            this.EncryptBTN.Click += new System.EventHandler(this.EncryptBTN_Click);
            // 
            // SaveBTN
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.SaveBTN, 2);
            this.SaveBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SaveBTN.Location = new System.Drawing.Point(4, 429);
            this.SaveBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveBTN.Name = "SaveBTN";
            this.SaveBTN.Size = new System.Drawing.Size(773, 29);
            this.SaveBTN.TabIndex = 9;
            this.SaveBTN.Text = "Modifiziertes Bild &speichern";
            this.SaveBTN.UseVisualStyleBackColor = true;
            this.SaveBTN.Click += new System.EventHandler(this.SaveBTN_Click);
            // 
            // DecryptBTN
            // 
            this.DecryptBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DecryptBTN.Location = new System.Drawing.Point(394, 78);
            this.DecryptBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DecryptBTN.Name = "DecryptBTN";
            this.DecryptBTN.Size = new System.Drawing.Size(383, 29);
            this.DecryptBTN.TabIndex = 10;
            this.DecryptBTN.Text = "&Entschlüsseln";
            this.DecryptBTN.UseVisualStyleBackColor = true;
            this.DecryptBTN.Click += new System.EventHandler(this.DecryptBTN_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Bilddateien|*.jpg; *.jpeg; *.jpe; *.bmp; *.ico; *.png; *.gif; *.pic";
            this.openFileDialog1.Title = "Bild öffnen - Steganograph";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "png";
            this.saveFileDialog1.Filter = "Bilddateien|*.jpg; *.jpeg; *.jpe; *.bmp; *.ico; *.png; *.gif; *.pic";
            this.saveFileDialog1.Title = "Modifiziertes Bild speichern - Steganograph";
            // 
            // PictureSteganoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 462);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PictureSteganoForm";
            this.Text = "Steganograph - Bild";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OriginalPicPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModifiedPicPB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label CryptModeLBL;
        private System.Windows.Forms.ComboBox CryptModeCB;
        private System.Windows.Forms.Label OriginalPicLBL;
        private System.Windows.Forms.Label ModifiedPicLBL;
        private System.Windows.Forms.PictureBox OriginalPicPB;
        private System.Windows.Forms.PictureBox ModifiedPicPB;
        private System.Windows.Forms.Button OpenFileBTN;
        private System.Windows.Forms.Button EncryptBTN;
        private System.Windows.Forms.Button SaveBTN;
        private System.Windows.Forms.Button DecryptBTN;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

