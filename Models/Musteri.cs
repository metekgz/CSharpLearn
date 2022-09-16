using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Models
{
    [Table("Musteri")]
    public class Musteri
    {
        [Key]
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public string Cinsiyet { get; set; }
        public DateTime? SonGirisTarihi { get; set; }
        public string Adres { get; set; }
    }
}
