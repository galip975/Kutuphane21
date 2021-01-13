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
        public Dictionary<Kitap, DateTime> OduncAlinanKitaplar { get; set; } = new Dictionary<Kitap, DateTime>();
        public string KullaniciAdi { get; set; }
        public string Parola { get; set; }
    }
}
