using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane21.Data
{
    public class Kullanici
    {
        public Kullanici()
        {
            ID = Guid.NewGuid().ToString();
        }
        public string ID { get; }
        public string Name { get; set; }
        public List<Kitap> OduncAlinanKitaplar { get; set; } = new List<Kitap>();
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
    }
}
