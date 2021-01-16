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
    public partial class Form1 : Form
    {
        KullaniciYoneticisi ky = new KullaniciYoneticisi();
        public Form1()
        {
            InitializeComponent();
            string json = File.ReadAllText("veriKullanici.json");
            ky = JsonConvert.DeserializeObject<KullaniciYoneticisi>(json);
        }

        private void llblKayitOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KayitOlForm frm = new KayitOlForm(ky);
            frm.ShowDialog();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Kullanici girisYapan = ky.BeniBul(txtKullaniciAdi.Text, txtKullaniciParola.Text);
            if (girisYapan == null)
            {
                MessageBox.Show("Kullanici Bulunamadı");
            }
            else
            {
                KutuphaneForm frm = new KutuphaneForm(ky, girisYapan);
                frm.ShowDialog();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string json = JsonConvert.SerializeObject(ky);
            File.WriteAllText("veriKullanici.json", json);
        }
    }
}
