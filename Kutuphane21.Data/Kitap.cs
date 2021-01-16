using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane21.Data
{
    public class Kitap
    {
        public Kitap()
        {
            ID = Guid.NewGuid().ToString();
        }
        public string ID { get;}
        public string Ad { get; set; }
        public string Yazar { get; set; }
        public KitapTur Tur { get; set; }
        public string Tarifi { get; set; }
        public int BasimYili { get; set; }
        public DateTime? AlinmaTarihi { get; set; }
    }
}
