namespace BasicCryptionPac
{
    partial class InAndOutPut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TxtTB = new System.Windows.Forms.TextBox();
            this.OkBTN = new System.Windows.Forms.Button();
            this.CopyBTN = new System.Windows.Forms.Button();
            this.MessageLBL = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.TxtTB, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.OkBTN, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.CopyBTN, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.MessageLBL, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(525, 263);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TxtTB
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.TxtTB, 2);
            this.TxtTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtTB.Location = new System.Drawing.Point(3, 31);
            this.TxtTB.MinimumSize = new System.Drawing.Size(100, 22);
            this.TxtTB.Multiline = true;
            this.TxtTB.Name = "TxtTB";
            this.TxtTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtTB.Size = new System.Drawing.Size(519, 192);
            this.TxtTB.TabIndex = 0;
            this.TxtTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtTB_KeyDown);
            // 
            // OkBTN
            // 
            this.OkBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OkBTN.Location = new System.Drawing.Point(265, 229);
            this.OkBTN.MinimumSize = new System.Drawing.Size(50, 22);
            this.OkBTN.Name = "OkBTN";
            this.OkBTN.Size = new System.Drawing.Size(257, 31);
            this.OkBTN.TabIndex = 2;
            this.OkBTN.Text = "&OK";
            this.OkBTN.UseVisualStyleBackColor = true;
            this.OkBTN.Click += new System.EventHandler(this.OkBTN_Click);
            // 
            // CopyBTN
            // 
            this.CopyBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CopyBTN.Location = new System.Drawing.Point(3, 229);
            this.CopyBTN.MinimumSize = new System.Drawing.Size(50, 22);
            this.CopyBTN.Name = "CopyBTN";
            this.CopyBTN.Size = new System.Drawing.Size(256, 31);
            this.CopyBTN.TabIndex = 1;
            this.CopyBTN.Text = "&Kopieren";
            this.CopyBTN.UseVisualStyleBackColor = true;
            this.CopyBTN.Click += new System.EventHandler(this.CopyBTN_Click);
            // 
            // MessageLBL
            // 
            this.MessageLBL.AutoEllipsis = true;
            this.MessageLBL.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.MessageLBL, 2);
            this.MessageLBL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageLBL.Location = new System.Drawing.Point(3, 3);
            this.MessageLBL.Margin = new System.Windows.Forms.Padding(3);
            this.MessageLBL.MinimumSize = new System.Drawing.Size(100, 22);
            this.MessageLBL.Name = "MessageLBL";
            this.MessageLBL.Padding = new System.Windows.Forms.Padding(3);
            this.MessageLBL.Size = new System.Drawing.Size(519, 22);
            this.MessageLBL.TabIndex = 3;
            this.MessageLBL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InAndOutPut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(525, 263);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(100, 66);
            this.Name = "InAndOutPut";
            this.Text = "InAndOutPut";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox TxtTB;
        private System.Windows.Forms.Button OkBTN;
        private System.Windows.Forms.Button CopyBTN;
        private System.Windows.Forms.Label MessageLBL;
    }
}