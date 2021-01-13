using Kutuphane21.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane21
{
    public partial class KayitOlForm : Form
    {
        KullaniciYoneticisi ky;

        public KayitOlForm(KullaniciYoneticisi kullaniciYoneticisi)
        {
            InitializeComponent();
            ky = kullaniciYoneticisi;
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            if (txtParola.Text != txtParolaTekrar.Text)
            {
                MessageBox.Show("Parola Hatalı Girdiniz!");
                return;
            }
            ky.KayitOl(txtKullaniciAd.Text, txtAd.Text, txtParola.Text);
            MessageBox.Show("Kayıt İşlemi Başarıyla Gerçekleştirilmiştir.");
            Close();
        }
    }
}
