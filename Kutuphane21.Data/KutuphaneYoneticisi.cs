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
        public void KitapEkle(string ad,int basimYili,string tarif,KitapTur tur,string yazar,int adet)
        {
            for (int i = 0; i < adet; i++)
            {
                Kitap kitap = new Kitap();
                kitap.Ad = ad;
                kitap.BasimYili = basimYili;
                kitap.Tarifi = tarif;
                kitap.Tur = tur;
                kitap.Yazar = yazar;
                Kitaplar.Add(kitap);
            }
        }
        public void KitapTeslimEt(Kitap kitap)
        {
            Kitaplar.Add(kitap);
        }
    }
}
