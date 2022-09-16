using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Models;

namespace Services
{
    public class MusteriServis
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
        public void MusteriKaydet(Musteri musteri)
        {
            connection.Insert<Musteri>(musteri);
        }

        public List<Musteri> Musteriler()
        {
            return connection.GetAll<Musteri>().ToList();
        }

        public void MusteriGuncelle(Musteri musteri)
        {
            var data = connection.Get<Musteri>(musteri.Id);
            data.KullaniciAdi = musteri.KullaniciAdi;
            data.Adi = musteri.Adi;
            data.Soyadi = musteri.Soyadi;
            data.Email = musteri.Email;
            data.Cinsiyet = musteri.Cinsiyet;
            data.Sifre = musteri.Sifre;
            data.SonGirisTarihi = musteri.SonGirisTarihi;
            data.Adres = musteri.Adres;

            connection.Update<Musteri>(data);
        }

        public void MusteriKaydetVeGuncelle(Musteri musteri)
        {
            if (musteri.Id == 0)
            {
                connection.Insert<Musteri>(musteri);
            }
            else
            {
                var data = connection.Get<Musteri>(musteri.Id);
                data.KullaniciAdi = musteri.KullaniciAdi;
                data.Adi = musteri.Adi;
                data.Soyadi = musteri.Soyadi;
                data.Email = musteri.Email;
                data.Cinsiyet = musteri.Cinsiyet;
                data.Sifre = musteri.Sifre;
                data.SonGirisTarihi = musteri.SonGirisTarihi;
                data.Adres = musteri.Adres;

                connection.Update<Musteri>(data);
            }
        }

        public Musteri MusteriGetir(string kullaniciAdi)
        {
            // Get ıd ye göre getirir
            // kullanıcı adına göre getirmek için ise
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@prmKullaniciAdi", kullaniciAdi);
            return connection.Query<Musteri>("select * from Musteri where kullaniciAdi=@prmKullaniciAdi", parameters).FirstOrDefault();
        }
        public Musteri Giris(string kullaniciAdi,string sifre)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@prmKullaniciAdi", kullaniciAdi);
            parameters.Add("@prmSifre", sifre);

           return connection.Query<Musteri>("select * from Musteri where kullaniciAdi=@prmKullaniciAdi And sifre=@prmSifre", parameters).FirstOrDefault();
        }
    }
}
