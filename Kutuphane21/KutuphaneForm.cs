using Kutuphane21.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            string json = File.ReadAllText("veriKutuphane.json");
            kutuphaney = JsonConvert.DeserializeObject<KutuphaneYoneticisi>(json);
            TurEkleme();
            DataGuncelle();
        }

        private void TurEkleme()
        {
            cboTur.Items.Add("Hepsi");
            cboTur.Items.Add(KitapTur.BilimKurgu);
            cboTur.Items.Add(KitapTur.Biyografi);
            cboTur.Items.Add(KitapTur.Edebiyat);
            cboTur.Items.Add(KitapTur.Korku);
            cboTur.Items.Add(KitapTur.Polisiye);
            cboTur.Items.Add(KitapTur.Tarih);
            cboTur.Items.Add(KitapTur.Mitoloji);
        }

        private void DataGuncelle()
        {
            dgvKitaplar.DataSource = null;
            dgvKitaplar.DataSource = kutuphaney.Kitaplar;
            dgvKitaplar.Columns[0].Visible = false;
            dgvKitaplar.Columns[6].Visible = false;
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
            if (cboTur.SelectedIndex == 0)
            {
                DataGuncelle();
            }
            else
            {
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
        }

        private void tsmiHesabim_Click(object sender, EventArgs e)
        {
            HesabimForm frm = new HesabimForm(kutuphaney, ky, kullanici);
            frm.ShowDialog();
            DataGuncelle();
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
                arananKitap.AlinmaTarihi = DateTime.Now;
                kullanici.OduncAlinanKitaplar.Add(arananKitap);
                DataGuncelle();
                foreach (var item in kutuphaney.Kitaplar)
                {
                    if (item.ID == arananKitap.ID)
                    {
                        kutuphaney.Kitaplar.Remove(item);
                        DataGuncelle();
                        return;
                    }
                }
            }
        }

        private void tsmiBagisYap_Click(object sender, EventArgs e)
        {
            BagisForm frm = new BagisForm(ky, kutuphaney);
            frm.ShowDialog();
            DataGuncelle();
        }

        private void tsmiCikisYap_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void KutuphaneForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string json = JsonConvert.SerializeObject(kutuphaney);
            File.WriteAllText("veriKutuphane.json", json);
        }
    }
}
