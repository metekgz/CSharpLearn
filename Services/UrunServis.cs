using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Dapper;

namespace Services
{
    public class UrunServis
    {

        // güvenlik açığı oluşmaması için parametre tanımlanmalı ve içine yazılmalı


        // sql bağlantısı oluşturma
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        // databaseden getirmek için connection kullanıyoruz
        // listi bir dizi olarak düşünebiliriz birden fazla değeri içerisinde tutar
        static List<Urun> Urunler = new List<Urun>();
        public void UrunEkle(Urun urun)
        {
            // dışarıdan gelen ürünler kısmı
            DynamicParameters param = new DynamicParameters();
            param.Add("@Adi", urun.Adi);
            param.Add("@UrunKodu", urun.UrunKodu);
            param.Add("@Beden", urun.Beden);
            param.Add("@SonKullanimTarihi", urun.SonKullanimTarihi);
            param.Add("@Aciklama", urun.Aciklama);
            param.Add("@Boyut", urun.Boyut);
            param.Add("@Renk", urun.Renk);
            connection.Execute("INSERT INTO Urun (Adi,UrunKodu,Beden,SonKullanimTarihi,Aciklama,Boyut,Renk) Values (@Adi,@UrunKodu,@Beden,@SonKullanimTarihi,@Aciklama,@Boyut,@Renk)", param);


            // Urunler.Add(urun);
        }

        public List<Urun> UrunListele()
        {
            var data = connection.Query<Urun>("Select * from urun").ToList();
            return data;

            // return Urunler;
        }

        // ürün içerisinde ıd olanı bana getir
        // FirstOfFefault bir tane geltir bulamıyorsan defaultu getir
        public Urun UrunGetir(int Id, string urunKodu = "")
        {
            Urun data = null;
            if (urunKodu != "")
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@prmUrunKodu", urunKodu);
                // "'" yapılmasının nedeni tabloda UrunKodu= 'K001' şeklinde olduğu için tırnak ekleriz
                data = connection.Query<Urun>("select * from urun where UrunKodu=@prmUrunKodu", param).FirstOrDefault();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@prmId", Id);
                data = connection.Query<Urun>("select * from urun where  Id=@prmId", param).FirstOrDefault();
            }

            return data;

            // return Urunler.Where(x => x.Id == Id).FirstOrDefault();
        }

        // ürünler içerisindeki rengi getir 
        // ToList olanların hepsini getir
        public List<Urun> Filtre(string renk)
        {
            return Urunler.Where(x => x.Renk == renk).ToList();

        }
    }
}
