using Biblioteka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerskiDeo
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Administartor administartor = new Administartor
            {
                Email = txtEmail.Text,
                Sifra = txtSifra.Text
            };
            administartor = Kontroler.Instanca.UlogujAdmina(administartor);
            if(administartor != null)
            {
                MessageBox.Show($"Dobrodosli {administartor.Ime} {administartor.Prezime}");
                DialogResult = DialogResult.OK;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSifra_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
