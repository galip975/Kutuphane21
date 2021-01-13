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
    public partial class KutuphaneForm : Form
    {
        KullaniciYoneticisi ky;
        KutuphaneYoneticisi kutuphaney = new KutuphaneYoneticisi();
        Kullanici kullanici;
        public KutuphaneForm(KullaniciYoneticisi kullaniciYoneticisi, Kullanici girisYapan)
        {
            ky = kullaniciYoneticisi;
            kullanici = girisYapan;
            InitializeComponent();
            cboTur.Items.Add("Hepsi");
            cboTur.Items.Add(KitapTur.BilimKurgu);
            cboTur.Items.Add(KitapTur.Biyografi);
            cboTur.Items.Add(KitapTur.Edebiyat);
            cboTur.Items.Add(KitapTur.Korku);
            cboTur.Items.Add(KitapTur.Polisiye);
            cboTur.Items.Add(KitapTur.Tarih);
            cboTur.Items.Add(KitapTur.Mitoloji);
            cboTur.SelectedIndex = 0;
            OrnekKitaplar();
            dgvKitaplar.DataSource = kutuphaney.Kitaplar;
        }
        private void OrnekKitaplar()
        {
            kutuphaney.KitapEkle("Ben Kirke", 1, 2019, "mitolojik bir kitap. 2 günde bitirdim.", KitapTur.Mitoloji, "Madeline Miller");
            kutuphaney.KitapEkle("Hayvan Çiftliği", 10, 1946, "harika bir kitap", KitapTur.BilimKurgu, "George Orwell");
            kutuphaney.KitapEkle("Mitoloji Sözlüğü", 1, 2019, "Mitoloji sözlüğüdür.", KitapTur.Mitoloji, "Azra Erhat");
        }
        private void txtKitapArama_TextChanged(object sender, EventArgs e)
        {
            List<Kitap> arananKitaplar = new List<Kitap>();
            foreach (Kitap kitap in kutuphaney.Kitaplar)
            {
                if (kitap.Ad.Contains(txtKitapArama.Text))
                {
                    arananKitaplar.Add(kitap);
                }
            }
            dgvKitaplar.DataSource = arananKitaplar;
        }
        private void cboTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            //KitapTur tur = (KitapTur)cboTur.SelectedItem;
            List<Kitap> arananKitaplar = new List<Kitap>();
            foreach (Kitap kitap in kutuphaney.Kitaplar)
            {
                if (kitap.Tur == (KitapTur)cboTur.SelectedItem)
                {
                    arananKitaplar.Add(kitap);
                }
            }
            dgvKitaplar.DataSource = arananKitaplar;
        }

        private void tsmiHesabim_Click(object sender, EventArgs e)
        {
            HesabimForm frm = new HesabimForm(kutuphaney, ky, kullanici);
            frm.ShowDialog();
        }

        private void dgvKitaplar_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var position = dgvKitaplar.HitTest(e.X, e.Y).RowIndex;
                if (position >= 0)
                {
                    contextMenuStrip1.Show(dgvKitaplar, new Point(e.X, e.Y));
                }
            }
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow satir = dgvKitaplar.SelectedRows[0];
            Kitap kitap = (Kitap)satir.DataBoundItem;
            Kitap arananKitap = kutuphaney.Kitaplar.FirstOrDefault(x => x.ID == kitap.ID);
            if (arananKitap != null)
            {
                kullanici.OduncAlinanKitaplar.Add(arananKitap, DateTime.Now);
                kutuphaney.Kitaplar.FirstOrDefault(x => x.ID == arananKitap.ID).Adet -= 1;
                dgvKitaplar.DataSource = null;
                dgvKitaplar.DataSource = kutuphaney.Kitaplar;
            }
        }

        private void tsmiBagisYap_Click(object sender, EventArgs e)
        {
            BagisForm frm = new BagisForm(ky,kutuphaney);
            frm.ShowDialog();
            dgvKitaplar.DataSource = null;
            dgvKitaplar.DataSource = kutuphaney.Kitaplar;
        }

        private void tsmiCikisYap_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
