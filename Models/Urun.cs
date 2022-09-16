using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string UrunKodu { get; set; }
        public string Aciklama { get; set; }
        public string Beden { get; set; }
        public DateTime SonKullanimTarihi { get; set; }
        public string Boyut { get; set; }
        public string Renk { get; set; }
    }
}
