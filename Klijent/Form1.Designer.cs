
namespace Klijent
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
            this.gbLoginKorisnika = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbSaljiSvima = new System.Windows.Forms.GroupBox();
            this.btnSaljiSvima = new System.Windows.Forms.Button();
            this.rtbPorukaZaSve = new System.Windows.Forms.RichTextBox();
            this.gbSaljiOdredjenom = new System.Windows.Forms.GroupBox();
            this.cbKorisnici = new System.Windows.Forms.ComboBox();
            this.btnSaljiKorisniku = new System.Windows.Forms.Button();
            this.rtbPorukaZaKorisnika = new System.Windows.Forms.RichTextBox();
            this.gbPoruke = new System.Windows.Forms.GroupBox();
            this.btnCitajPoruku = new System.Windows.Forms.Button();
            this.dgvOstale = new System.Windows.Forms.DataGridView();
            this.dgvPoslednje3 = new System.Windows.Forms.DataGridView();
            this.gbLoginKorisnika.SuspendLayout();
            this.gbSaljiSvima.SuspendLayout();
            this.gbSaljiOdredjenom.SuspendLayout();
            this.gbPoruke.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOstale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoslednje3)).BeginInit();
            this.SuspendLayout();
            // 
            // gbLoginKorisnika
            // 
            this.gbLoginKorisnika.Controls.Add(this.btnLogin);
            this.gbLoginKorisnika.Controls.Add(this.txtSifra);
            this.gbLoginKorisnika.Controls.Add(this.txtIme);
            this.gbLoginKorisnika.Controls.Add(this.label2);
            this.gbLoginKorisnika.Controls.Add(this.label1);
            this.gbLoginKorisnika.Location = new System.Drawing.Point(40, 29);
            this.gbLoginKorisnika.Name = "gbLoginKorisnika";
            this.gbLoginKorisnika.Size = new System.Drawing.Size(352, 168);
            this.gbLoginKorisnika.TabIndex = 0;
            this.gbLoginKorisnika.TabStop = false;
            this.gbLoginKorisnika.Text = "Logovanje";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(40, 115);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(94, 29);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(123, 71);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(150, 22);
            this.txtSifra.TabIndex = 5;
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(123, 30);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(150, 22);
            this.txtIme.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sifra";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Korisnicko ime";
            // 
            // gbSaljiSvima
            // 
            this.gbSaljiSvima.Controls.Add(this.btnSaljiSvima);
            this.gbSaljiSvima.Controls.Add(this.rtbPorukaZaSve);
            this.gbSaljiSvima.Location = new System.Drawing.Point(425, 29);
            this.gbSaljiSvima.Name = "gbSaljiSvima";
            this.gbSaljiSvima.Size = new System.Drawing.Size(352, 168);
            this.gbSaljiSvima.TabIndex = 1;
            this.gbSaljiSvima.TabStop = false;
            this.gbSaljiSvima.Text = "Salnje svima";
            // 
            // btnSaljiSvima
            // 
            this.btnSaljiSvima.Location = new System.Drawing.Point(43, 127);
            this.btnSaljiSvima.Name = "btnSaljiSvima";
            this.btnSaljiSvima.Size = new System.Drawing.Size(150, 35);
            this.btnSaljiSvima.TabIndex = 1;
            this.btnSaljiSvima.Text = "Salji svima";
            this.btnSaljiSvima.UseVisualStyleBackColor = true;
            this.btnSaljiSvima.Click += new System.EventHandler(this.btnSaljiSvima_Click);
            // 
            // rtbPorukaZaSve
            // 
            this.rtbPorukaZaSve.Location = new System.Drawing.Point(6, 30);
            this.rtbPorukaZaSve.MaxLength = 200;
            this.rtbPorukaZaSve.Name = "rtbPorukaZaSve";
            this.rtbPorukaZaSve.Size = new System.Drawing.Size(327, 91);
            this.rtbPorukaZaSve.TabIndex = 0;
            this.rtbPorukaZaSve.Text = "";
            // 
            // gbSaljiOdredjenom
            // 
            this.gbSaljiOdredjenom.Controls.Add(this.cbKorisnici);
            this.gbSaljiOdredjenom.Controls.Add(this.btnSaljiKorisniku);
            this.gbSaljiOdredjenom.Controls.Add(this.rtbPorukaZaKorisnika);
            this.gbSaljiOdredjenom.Location = new System.Drawing.Point(40, 224);
            this.gbSaljiOdredjenom.Name = "gbSaljiOdredjenom";
            this.gbSaljiOdredjenom.Size = new System.Drawing.Size(661, 168);
            this.gbSaljiOdredjenom.TabIndex = 1;
            this.gbSaljiOdredjenom.TabStop = false;
            this.gbSaljiOdredjenom.Text = "Slanje odredjenom";
            // 
            // cbKorisnici
            // 
            this.cbKorisnici.FormattingEnabled = true;
            this.cbKorisnici.Location = new System.Drawing.Point(396, 30);
            this.cbKorisnici.Name = "cbKorisnici";
            this.cbKorisnici.Size = new System.Drawing.Size(121, 24);
            this.cbKorisnici.TabIndex = 4;
            // 
            // btnSaljiKorisniku
            // 
            this.btnSaljiKorisniku.Location = new System.Drawing.Point(50, 115);
            this.btnSaljiKorisniku.Name = "btnSaljiKorisniku";
            this.btnSaljiKorisniku.Size = new System.Drawing.Size(150, 35);
            this.btnSaljiKorisniku.TabIndex = 3;
            this.btnSaljiKorisniku.Text = "Salji korisniku";
            this.btnSaljiKorisniku.UseVisualStyleBackColor = true;
            this.btnSaljiKorisniku.Click += new System.EventHandler(this.btnSaljiKorisniku_Click);
            // 
            // rtbPorukaZaKorisnika
            // 
            this.rtbPorukaZaKorisnika.Location = new System.Drawing.Point(13, 18);
            this.rtbPorukaZaKorisnika.MaxLength = 200;
            this.rtbPorukaZaKorisnika.Name = "rtbPorukaZaKorisnika";
            this.rtbPorukaZaKorisnika.Size = new System.Drawing.Size(327, 91);
            this.rtbPorukaZaKorisnika.TabIndex = 2;
            this.rtbPorukaZaKorisnika.Text = "";
            // 
            // gbPoruke
            // 
            this.gbPoruke.Controls.Add(this.btnCitajPoruku);
            this.gbPoruke.Controls.Add(this.dgvOstale);
            this.gbPoruke.Controls.Add(this.dgvPoslednje3);
            this.gbPoruke.Location = new System.Drawing.Point(40, 429);
            this.gbPoruke.Name = "gbPoruke";
            this.gbPoruke.Size = new System.Drawing.Size(661, 408);
            this.gbPoruke.TabIndex = 2;
            this.gbPoruke.TabStop = false;
            this.gbPoruke.Text = "Poruke";
            // 
            // btnCitajPoruku
            // 
            this.btnCitajPoruku.Location = new System.Drawing.Point(57, 349);
            this.btnCitajPoruku.Name = "btnCitajPoruku";
            this.btnCitajPoruku.Size = new System.Drawing.Size(99, 28);
            this.btnCitajPoruku.TabIndex = 2;
            this.btnCitajPoruku.Text = "Citaj poruku";
            this.btnCitajPoruku.UseVisualStyleBackColor = true;
            this.btnCitajPoruku.Click += new System.EventHandler(this.btnCitajPoruku_Click);
            // 
            // dgvOstale
            // 
            this.dgvOstale.AllowUserToAddRows = false;
            this.dgvOstale.AllowUserToDeleteRows = false;
            this.dgvOstale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOstale.Location = new System.Drawing.Point(13, 185);
            this.dgvOstale.Name = "dgvOstale";
            this.dgvOstale.ReadOnly = true;
            this.dgvOstale.RowHeadersWidth = 51;
            this.dgvOstale.RowTemplate.Height = 24;
            this.dgvOstale.Size = new System.Drawing.Size(636, 129);
            this.dgvOstale.TabIndex = 1;
            // 
            // dgvPoslednje3
            // 
            this.dgvPoslednje3.AllowUserToAddRows = false;
            this.dgvPoslednje3.AllowUserToDeleteRows = false;
            this.dgvPoslednje3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoslednje3.Location = new System.Drawing.Point(13, 34);
            this.dgvPoslednje3.Name = "dgvPoslednje3";
            this.dgvPoslednje3.ReadOnly = true;
            this.dgvPoslednje3.RowHeadersWidth = 51;
            this.dgvPoslednje3.RowTemplate.Height = 24;
            this.dgvPoslednje3.Size = new System.Drawing.Size(636, 129);
            this.dgvPoslednje3.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 931);
            this.Controls.Add(this.gbPoruke);
            this.Controls.Add(this.gbSaljiOdredjenom);
            this.Controls.Add(this.gbSaljiSvima);
            this.Controls.Add(this.gbLoginKorisnika);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbLoginKorisnika.ResumeLayout(false);
            this.gbLoginKorisnika.PerformLayout();
            this.gbSaljiSvima.ResumeLayout(false);
            this.gbSaljiOdredjenom.ResumeLayout(false);
            this.gbPoruke.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOstale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoslednje3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLoginKorisnika;
        private System.Windows.Forms.GroupBox gbSaljiSvima;
        private System.Windows.Forms.GroupBox gbSaljiOdredjenom;
        private System.Windows.Forms.GroupBox gbPoruke;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSaljiSvima;
        private System.Windows.Forms.RichTextBox rtbPorukaZaSve;
        private System.Windows.Forms.ComboBox cbKorisnici;
        private System.Windows.Forms.Button btnSaljiKorisniku;
        private System.Windows.Forms.RichTextBox rtbPorukaZaKorisnika;
        private System.Windows.Forms.Button btnCitajPoruku;
        private System.Windows.Forms.DataGridView dgvOstale;
        private System.Windows.Forms.DataGridView dgvPoslednje3;
    }
}

