using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane21.Data
{
    public class KullaniciYoneticisi
    {
        public List<Kullanici> Kullanicilar { get; set; } = new List<Kullanici>();
        public void KayitOl(string username,string ad,string parola)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.KullaniciAdi = username;
            kullanici.Name = ad;
            kullanici.Parola = parola;
            Kullanicilar.Add(kullanici);
            
        }
        public Kullanici BeniBul(string userName, string password)
        {
            return Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == userName && x.Parola == password);
        }
    }
}
