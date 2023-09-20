
namespace ExcelDosyaOkuma
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.DosyayiSec = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSoyagaci = new DevExpress.XtraEditors.SimpleButton();
            this.BtnDosyayiSec = new DevExpress.XtraEditors.SimpleButton();
            this.btnDosyaSec = new DevExpress.XtraEditors.SimpleButton();
            this.btnSoyagac = new DevExpress.XtraEditors.SimpleButton();
            this.btnCocuksuz = new DevExpress.XtraEditors.SimpleButton();
            this.textBox = new System.Windows.Forms.TextBox();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnKanAra = new DevExpress.XtraEditors.SimpleButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // DosyayiSec
            // 
            this.DosyayiSec.Location = new System.Drawing.Point(2174, 885);
            this.DosyayiSec.Margin = new System.Windows.Forms.Padding(9);
            this.DosyayiSec.Name = "DosyayiSec";
            this.DosyayiSec.Size = new System.Drawing.Size(378, 114);
            this.DosyayiSec.TabIndex = 0;
            this.DosyayiSec.Text = "Dosyayı Seç";
            this.DosyayiSec.Click += new System.EventHandler(this.DosyayiSec_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(776, 211);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnSoyagaci
            // 
            this.btnSoyagaci.Location = new System.Drawing.Point(1437, 717);
            this.btnSoyagaci.Margin = new System.Windows.Forms.Padding(9);
            this.btnSoyagaci.Name = "btnSoyagaci";
            this.btnSoyagaci.Size = new System.Drawing.Size(252, 76);
            this.btnSoyagaci.TabIndex = 2;
            this.btnSoyagaci.Text = "Soy Ağacı Yap";
            this.btnSoyagaci.Click += new System.EventHandler(this.btnSoyagaci_Click);
            // 
            // BtnDosyayiSec
            // 
            this.BtnDosyayiSec.Location = new System.Drawing.Point(1437, 618);
            this.BtnDosyayiSec.Margin = new System.Windows.Forms.Padding(14);
            this.BtnDosyayiSec.Name = "BtnDosyayiSec";
            this.BtnDosyayiSec.Size = new System.Drawing.Size(252, 76);
            this.BtnDosyayiSec.TabIndex = 3;
            this.BtnDosyayiSec.Text = "Dosya Seç";
            this.BtnDosyayiSec.Click += new System.EventHandler(this.BtnDosyayiSec_Click);
            // 
            // btnDosyaSec
            // 
            this.btnDosyaSec.Location = new System.Drawing.Point(614, 256);
            this.btnDosyaSec.Name = "btnDosyaSec";
            this.btnDosyaSec.Size = new System.Drawing.Size(141, 34);
            this.btnDosyaSec.TabIndex = 4;
            this.btnDosyaSec.Text = "Dosya Seç";
            this.btnDosyaSec.Click += new System.EventHandler(this.btnDosyaSec_Click);
            // 
            // btnSoyagac
            // 
            this.btnSoyagac.Location = new System.Drawing.Point(614, 315);
            this.btnSoyagac.Name = "btnSoyagac";
            this.btnSoyagac.Size = new System.Drawing.Size(141, 34);
            this.btnSoyagac.TabIndex = 5;
            this.btnSoyagac.Text = "Soyağacı oluştur";
            this.btnSoyagac.Click += new System.EventHandler(this.btnSoyagac_Click);
            // 
            // btnCocuksuz
            // 
            this.btnCocuksuz.Location = new System.Drawing.Point(614, 365);
            this.btnCocuksuz.Name = "btnCocuksuz";
            this.btnCocuksuz.Size = new System.Drawing.Size(141, 34);
            this.btnCocuksuz.TabIndex = 6;
            this.btnCocuksuz.Text = "cocuksuz";
            this.btnCocuksuz.Click += new System.EventHandler(this.btnCocuksuz_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(29, 256);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(100, 26);
            this.textBox.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(193, 256);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(112, 34);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Ara";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnKanAra
            // 
            this.btnKanAra.Location = new System.Drawing.Point(193, 315);
            this.btnKanAra.Name = "btnKanAra";
            this.btnKanAra.Size = new System.Drawing.Size(112, 34);
            this.btnKanAra.TabIndex = 10;
            this.btnKanAra.Text = "Kan Grubu";
            this.btnKanAra.Click += new System.EventHandler(this.btnKanAra_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 315);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 9;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(193, 384);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(112, 34);
            this.simpleButton1.TabIndex = 11;
            this.simpleButton1.Text = "Üvey Kardeşler";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnKanAra);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.btnCocuksuz);
            this.Controls.Add(this.btnSoyagac);
            this.Controls.Add(this.btnDosyaSec);
            this.Controls.Add(this.BtnDosyayiSec);
            this.Controls.Add(this.btnSoyagaci);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.DosyayiSec);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraEditors.SimpleButton DosyayiSec;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevExpress.XtraEditors.SimpleButton btnSoyagaci;
        private DevExpress.XtraEditors.SimpleButton BtnDosyayiSec;
        private DevExpress.XtraEditors.SimpleButton btnDosyaSec;
        private DevExpress.XtraEditors.SimpleButton btnSoyagac;
        private DevExpress.XtraEditors.SimpleButton btnCocuksuz;
        private System.Windows.Forms.TextBox textBox;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnKanAra;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}

