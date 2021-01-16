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
    public partial class BagisForm : Form
    {
        KullaniciYoneticisi ky;
        KutuphaneYoneticisi kutuphaney;
        public BagisForm(KullaniciYoneticisi kullaniciYoneticisi, KutuphaneYoneticisi kutuphaneYoneticisi)
        {
            ky = kullaniciYoneticisi;
            kutuphaney = kutuphaneYoneticisi;
            InitializeComponent();
            cboTur.Items.Add(KitapTur.BilimKurgu);
            cboTur.Items.Add(KitapTur.Biyografi);
            cboTur.Items.Add(KitapTur.Edebiyat);
            cboTur.Items.Add(KitapTur.Korku);
            cboTur.Items.Add(KitapTur.Polisiye);
            cboTur.Items.Add(KitapTur.Tarih);
            cboTur.Items.Add(KitapTur.Mitoloji);
            cboTur.SelectedIndex = 0;
        }

        private void btnBagisYap_Click(object sender, EventArgs e)
        {
            string kitapAd = txtKitapAd.Text;
            int adet = (int)nudKitapAdet.Value;
            int basimYili = (int)nudBasimYili.Value;
            string tarif = txtKitapTarif.Text;
            KitapTur tur = (KitapTur)cboTur.SelectedItem;
            string yazar = txtKitapYazar.Text;
            kutuphaney.KitapEkle(kitapAd,basimYili, tarif, tur, yazar,adet);
            Close();
        }
    }
}
