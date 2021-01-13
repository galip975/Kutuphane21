using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane21.Data
{
    public class KutuphaneYoneticisi
    {
        public List<Kitap> Kitaplar { get; set; } = new List<Kitap>();
        public void KitapEkle(string ad,int adet,int basimYili,string tarif,KitapTur tur,string yazar)
        {
            Kitap kitap = new Kitap();
            kitap.Ad = ad;
            kitap.Adet = adet;
            kitap.BasimYili = basimYili;
            kitap.Tarifi = tarif;
            kitap.Tur = tur;
            kitap.Yazar = yazar;
            Kitaplar.Add(kitap);
        }
    }
}
