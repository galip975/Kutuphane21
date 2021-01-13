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
    public partial class HesabimForm : Form
    {
        KullaniciYoneticisi ky;
        KutuphaneYoneticisi kutuphaney;
        Kullanici kullanici;
        public HesabimForm(KutuphaneYoneticisi kutuphaneYoneticisi, KullaniciYoneticisi kullaniciYoneticisi,
            Kullanici girisYapan)
        {
            ky = kullaniciYoneticisi;
            kutuphaney = kutuphaneYoneticisi;
            kullanici = girisYapan;
            InitializeComponent();
            lblAd.Text = kullanici.Name;
            lblID.Text = kullanici.ID;
            lblKullaniciAdi.Text = kullanici.KullaniciAdi;
            lblParola.Text = kullanici.Parola;
            foreach (var item in kullanici.OduncAlinanKitaplar)
            {
                dgvOduncAlinanKitaplar.Rows.Add(item.Key.Ad,item.Value);
            }
        }
    }
}
