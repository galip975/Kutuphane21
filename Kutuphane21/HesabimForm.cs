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
            DataGuncelle();
        }

        private void DataGuncelle()
        {
            dgvOduncAlinanKitaplar.DataSource = null;
            dgvOduncAlinanKitaplar.DataSource = kullanici.OduncAlinanKitaplar;
            dgvOduncAlinanKitaplar.Columns[0].Visible = false;
        }

        private void dgvOduncAlinanKitaplar_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOduncAlinanKitaplar.SelectedRows.Count > 0)
            {
                DataGridViewRow satir = dgvOduncAlinanKitaplar.SelectedRows[0];
                DateTime alinmaTarihi = (DateTime)satir.Cells[6].Value;
                DateTime teslimTarihi = alinmaTarihi.AddDays(15);
                dtpTeslimTarihi.Value = teslimTarihi;
            }
        }

        private void btnKitapTeslimEt_Click(object sender, EventArgs e)
        {
            if (dgvOduncAlinanKitaplar.SelectedRows.Count > 0)
            {
                DataGridViewRow satir = dgvOduncAlinanKitaplar.SelectedRows[0];
                kutuphaney.KitapTeslimEt((Kitap)satir.DataBoundItem);
                kullanici.OduncAlinanKitaplar.Remove((Kitap)satir.DataBoundItem);
                DataGuncelle();
            }
        }
    }
}
