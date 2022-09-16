using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services;

namespace ConsoleApp1
{
    class Program
    {
        static MusteriServis _musteriServis = new MusteriServis();
        static Musteri kullanici = null;
        static void Main(string[] args)
        {
            //Urun urun1 = new Urun();
            //urun1.Id = 1;
            //urun1.Adi = "Monitör";
            //urun1.Boyut = "17";
            //urun1.Renk = "Siyah";
            //urun1.UrunKodu = "M001";
            //urun1.SonKullanimTarihi = new DateTime(2022, 09, 16);

            //Urun urun2 = new Urun();
            //urun2.Id = 2;
            //urun2.Adi = "Klavye";
            //urun2.Renk = "Gri";
            //urun2.UrunKodu = "K001";
            //urun2.SonKullanimTarihi = new DateTime(2022, 09, 16);


            //UrunServis urunServis = new UrunServis();
            //urunServis.UrunEkle(urun1);
            //urunServis.UrunEkle(urun2);

            //var urunListesi = urunServis.UrunListele();


            //Console.WriteLine("Ürünün Adı   -   Ürünün Kodu   -   Ürün Rengi   -   Açıklama   -   Son Kullanma Tarihi   -   Boyut   -   Beden");
            //foreach (var urun in urunListesi)
            //{
            //    Console.WriteLine($"{urun.Adi}   -   {urun.UrunKodu}   -   {urun.Renk}   -   {urun.Aciklama}   -   {urun.SonKullanimTarihi}   -   {urun.Boyut}   -   {urun.Beden}");
            //}

            //UrunServis _urunServis = new UrunServis();
            //Console.Write("Getirelecek Ürün Kodu: ");
            ////int id = Convert.ToInt32(Console.ReadLine());
            //var urun = _urunServis.UrunGetir(0, Console.ReadLine());
            //UrunYaz(urun);

            Giris();

            Console.ReadKey();


            //// ekrana ıdsini yazdırıp ürün getirme
            //Console.Write("Getirelecek Ürün Id: ");
            //var deger = Console.ReadLine();
            //var data = urunServis.UrunGetir(Convert.ToInt32(deger));
            //Console.WriteLine($"{data.Adi}-{data.Renk}-{data.UrunKodu}");


            //// ekrandan ürün ekleme

            //Urun urun3 = new Urun();
            //Console.WriteLine("Ürün Ekle");
            //Console.Write("Ürün Id: ");
            //urun3.Id = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Ürün Adı: ");
            //urun3.Adi = Console.ReadLine();
            //Console.Write("Ürün Rengi: ");
            //urun3.Renk = Console.ReadLine();
            //Console.Write("Ürün Kodu: ");
            //urun3.UrunKodu = Console.ReadLine();

            //urunServis.UrunEkle(urun3);

            //Console.WriteLine("Ürün Eklendi");

            //Console.WriteLine("Ürün Listesi");

            //foreach (var item in urunServis.UrunListele())
            //{
            //    Console.WriteLine(item.Adi);
            //}
            // Console.ReadKey();

        }

        static void Menu()
        {
            Console.WriteLine("Müşteri Kaydet  : 1");
            Console.WriteLine("Tüm Müşteriler  : 2");
            Console.WriteLine("Müşteri Bul     : 3");
            Console.WriteLine("Müşteri Güncelle: 4");

            string menu = Console.ReadLine();
            if (menu == "1")
            {
                MusteriKaydet();
            }
            else if (menu == "2")
            {
                Musteriler();
            }
            else if (menu == "3")
            {
                MusteriBul();
            }
            else if (menu == "4")
            {
                MusteriGuncelle();
            }

            Console.WriteLine("");
            Menu();
        }

        static void MusteriKaydet()
        {
            Musteri musteri = new Musteri();
            Console.Write("Müşteri Adı: ");
            musteri.Adi = Console.ReadLine();

            Console.Write("Kullanıcı Adı: ");
            musteri.KullaniciAdi = Console.ReadLine();

            Console.Write("email: ");
            musteri.Email = Console.ReadLine();

            Console.Write("Cinsiyet: ");
            musteri.Cinsiyet = Console.ReadLine() == "E" ? "Erkek" : "Kadın";

            musteri.SonGirisTarihi = null;


            _musteriServis.MusteriKaydetVeGuncelle(musteri);
            Console.WriteLine("Müşteri Kaydedildi");
        }

        static void Musteriler()
        {
            var data = _musteriServis.Musteriler();
            foreach (var item in data)
            {
                Console.WriteLine($"{item.Adi} - {item.KullaniciAdi} - {item.Cinsiyet}");
            }
        }

        static void MusteriBul()
        {
            Console.Write("Kullanıcı Adını Giriniz: ");
            var data = _musteriServis.MusteriGetir(Console.ReadLine());
            if (data == null)
            {
                Console.WriteLine("Kullanıcı Bulunamadı");
            }
            else
            {
                Console.WriteLine($"{data.KullaniciAdi}-{data.Adi}-{data.SonGirisTarihi}");
            }
        }

        static void MusteriGuncelle()
        {
            Console.Write("Müşteri Adı: ");
            kullanici.Adi = Console.ReadLine();

            Console.Write("Kullanıcı Adı: ");
            kullanici.KullaniciAdi = Console.ReadLine();

            Console.Write("email: ");
            kullanici.Email = Console.ReadLine();

            Console.Write("Cinsiyet: ");
            kullanici.Cinsiyet = Console.ReadLine() == "E" ? "Erkek" : "Kadın";

            kullanici.SonGirisTarihi = null;
            
            _musteriServis.MusteriKaydetVeGuncelle(kullanici);
            Console.WriteLine("Müşteri Güncellendi");
        }

        static void Giris()
        {
            Console.WriteLine("Kullanıcı Adı: ");
            string kullaniciAdi = Console.ReadLine();
            Console.Write("Şifre: ");
            string sifre = Console.ReadLine();

            kullanici = _musteriServis.Giris(kullaniciAdi, sifre);

            if (kullanici == null)
            {
                Console.WriteLine("Kullanıcı Adı ya da Şifre hatalı");
            }
            else
            {
                kullanici.SonGirisTarihi = DateTime.Now;
                _musteriServis.MusteriKaydetVeGuncelle(kullanici);
                Menu();
            }
           

        }
        // geri dönecek bir şey olmadığı için void yazılır
        static void UrunYaz(Urun urun)
        {
            Console.WriteLine($"{urun.Adi}   -   {urun.UrunKodu}   -   {urun.Renk}   -   {urun.Aciklama}   -   {urun.SonKullanimTarihi}   -   {urun.Boyut}   -   {urun.Beden}");
        }
    }
}
