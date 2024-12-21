// Alışveriş Listesini Hazırla
// Listedeki Ürünlerin Fiyatlarını Belirle
// Kullanıcıya Alışveriş Listelerini Söyle
// Kullanıcının Seçtiği Alışveriş Listesinde ki Fiyatları Söyle
// Kullanıcının Seçtiği Ürünlerden Ne Kadar Almak İstediğini Sor
// Kullanıcıdan Gelen Verileri Bir Yerde Depola
// Bu Verileri Son Olarak "Aldığı Ürün", "Aldığı Ürünün Adeti", "Aldığı Ürünlerin Toplam Fiyatı" Şeklinde Kullanıcıya Sun


using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, string[]> kategoriler = new Dictionary<string, string[]>
        {
            { "Kahvaltılık", new string[] { "Ekmek", "Peynir", "Zeytin", "Çikolata", "Süt", "Yumurta", "Margarin" } },
            { "MeyveSebze", new string[] { "Limon", "Armut", "Elma", "Üzüm", "Mandalina", "Soğan", "Patates", "Domates", "Salatalık", "Havuç", "Biber", "Patlıcan" } },
            { "Atıştırmalıkİçecek", new string[] { "Cips", "Gofret", "Bisküvi", "Kek", "Kraker", "Sakız", "Su", "Kola", "Meyve Suyu", "Kahve", "Çay", "Ayran" } },
            { "TemelGıda", new string[] { "Makarna", "Bakliyat", "Un", "Şeker", "Baharat", "Salça", "Çorba", "Turşu", "Konserve", "Sıvı Yağ" } },
            { "Temizlik", new string[] { "Çamaşır", "Bulaşık", "Mutfak", "Temizlik", "Sabun", "Peçete" } }
        };

        Dictionary<string, int[]> fiyatlar = new Dictionary<string, int[]>
        {
            { "Kahvaltılık", new int[] { 10, 15, 5, 10, 15, 20, 5 } },
            { "MeyveSebze", new int[] { 5, 10, 15, 15, 10, 5, 10, 15, 15, 5, 10, 15 } },
            { "Atıştırmalıkİçecek", new int[] { 40, 15, 20, 5, 10, 5, 10, 25, 15, 20, 15, 10 } },
            { "TemelGıda", new int[] { 10, 15, 25, 20, 10, 15, 10, 10, 15, 30 } },
            { "Temizlik", new int[] { 25, 15, 20, 15, 10, 20 } }
        };

        List<string> alinanUrunler = new List<string>();
        List<int> alinanAdetler = new List<int>();
        int toplamFiyat = 0;

        bool devamEtmek = true;

        while (devamEtmek)
        {
            Console.WriteLine("Hangi kategoriden ürün seçmek istersiniz?");
            foreach (var kategori in kategoriler.Keys)
            {
                Console.WriteLine($"- {kategori}");
            }

            string secilenKategori = Console.ReadLine();

            if (kategoriler.ContainsKey(secilenKategori))
            {
                Console.WriteLine($"{secilenKategori} kategorisindeki ürünler:");

                string[] urunler = kategoriler[secilenKategori];
                int[] urunFiyatlari = fiyatlar[secilenKategori];

                for (int i = 0; i < urunler.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {urunler[i]} - {urunFiyatlari[i]} TL");
                }

                Console.WriteLine("Almak istediğiniz ürün numarasını seçin:");
                int urunSecimi = Convert.ToInt32(Console.ReadLine()) - 1;

                if (urunSecimi >= 0 && urunSecimi < urunler.Length)
                {
                    Console.WriteLine($"Kaç adet {urunler[urunSecimi]} almak istersiniz?");
                    int adet = Convert.ToInt32(Console.ReadLine());

                    alinanUrunler.Add(urunler[urunSecimi]);
                    alinanAdetler.Add(adet);

                    toplamFiyat += urunFiyatlari[urunSecimi] * adet;

                    Console.WriteLine("Başka bir ürün almak ister misiniz? (Evet/Hayır)");
                    string devamMi = Console.ReadLine().ToLower();

                    if (devamMi != "evet")
                    {
                        devamEtmek = false;
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz ürün seçimi.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz kategori seçimi.");
            }
        }

        Console.WriteLine("Aldığınız ürünler:");
        for (int i = 0; i < alinanUrunler.Count; i++)
        {
            Console.WriteLine($"{alinanUrunler[i]} - {alinanAdetler[i]} adet");
        }
        Console.WriteLine($"Toplam fiyat: {toplamFiyat} TL");
    }
}
