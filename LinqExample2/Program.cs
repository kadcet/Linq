public class Program
{
    public static void Main()
    {
        var list = Urun.Urunler();

        #region WHERE
        // WHERE
        // geriye asıl dönüş tipi IEnumerable

        // fiyatı 1000 üstü olan ürünleri getir
        IEnumerable<Urun> sonuc1 = list.Where(u => u.fiyat > 1000);
        IEnumerable<Urun> sonuc2 = list.Where(Filtre);

        var sonucTest = list.Where(u => u.fiyat > 1000);

        //burdaki urun takma isim.Listenin içindeki her bir elemana urun ismini ver
        IEnumerable<Urun> sonuc3 = from urun in list
                                   where urun.fiyat > 1000
                                   select urun;


        IEnumerable<Urun> sonuc4 = from urun in list
                                   where urun.fiyat > 1000
                                   && urun.ad.StartsWith("L")
                                   select urun;

                                   #endregion


                                   #region SELECT
        // SELECT SEÇİMLER YAPMAK İÇİN  WHERE FİLTRELEME YAPMAK İÇİN

        //ürünlerin isim listesi
        var sonuc5 = list.Where(x=> x.fiyat>1000).ToList();

        var sonuc6 = from q in list
                     select q.ad;

        // IEnumerable değil liste olarak gelmesini istersek

        var sonuc7 = (from q in list
                      select q.ad).ToList();

        // ürünlerin isimlerini ve fiyatlarını seçmek istiyorum

        //var sonuc8 = from q in list
        //             select new
        //             {
        //                 Name = q.ad,
        //                 Price = q.fiyat
        //             };

        //foreach (var item in sonuc8)
        //{
        //    Console.WriteLine($"Ürün Adı : {item.Name} Fiyatı : {item.Price}");
        //}

        var sonuc8 = from q in list
                     select new Secilen
                     {
                         name = q.ad,
                         price = q.fiyat
                     };

        Yazdir(sonuc8.ToList());
        #endregion

        #region COUNT
        // Count yapmış olduğum seçimin sonucunda kaç eleman olduğunu bulabilirim

        // fiyatı 1000 den küçük olanların sayısı
        var result = list.Where(u => u.fiyat < 1000).Count();

        var result1 = (from q in list
                       where q.fiyat < 1000
                       select q).Count();
        #endregion

        #region ORDER BY ve ORDERBYDESCENDİNG

        // ürün fiyatına göre küçükten büyüğe
        // result2 ve result3 arasında fark yok. Aynısı
        var result2 = list.OrderBy(u => u.fiyat).ToList();

        var result3 = (from q in list
                       orderby q.fiyat
                       select q).ToList();

        // ürün fiyatına göre büyükten küçüğe
        var result4 = list.OrderByDescending(u => u.fiyat).ToList();
        var result5 = (from q in list
                       orderby q.fiyat descending
                       select q).ToList();

        // ürün adına göre sıralama
        var result6 = list.OrderBy(u => u.ad).ToList();
        var result7 = (from q in list
                       orderby q.ad
                       select q).ToList();

        var result8 = list.OrderByDescending(u => u.ad).ToList();
        var result9 = (from q in list
                       orderby q.ad descending
                       select q).ToList();

        // TAKE
        // var ex=list.Take(1);  // listedeki 1 tane ürünü aldık
        // En ucuz 3 ürün
        var result10 = list.OrderBy(u => u.fiyat).Take(3);
        var result11 = (from q in list
                        orderby q.fiyat
                        select q).Take(3);

        //SUM
        // Ürün kalemlerinin toplam fiyatı
        var result12 = list.Sum(u => u.fiyat);

        // Stoktaki toplam ürün fiyatı ( stok*ürün adedi)

        var result13 = list.Sum(u => (u.fiyat * u.stok));

        // MAX
        // En pahalı ürün
        var result14 = list.Max(u => u.fiyat);

        // stokta en çok olan ürün
        var result15 = list.Max(u => u.stok);

        //MİN
        //en ucuz ürün
        var result16 = list.Min(u => u.fiyat);
        // stokta en az olan ürün
        var result17 = list.Min(u => u.stok);

        //FİRST (ilk)
        // liste içinde verdiğim şarta uyan ilk elemanı getirir. Elemanı bulamazsa HATA MEYDANA GETİRİYO InvalidOperationException
        var result18 = list.First(u => u.fiyat == 75); // bu var getiri
        //var result19 = list.First(u => u.fiyat == 3750); // bu yok. Hata verir

        // FirstOrDefault (ilkini getir bulamazsan varsayılanı dön
        // fiyat double ise sıfır  class ise null vs vs
        var result20 = list.FirstOrDefault(u => u.fiyat == 75);
        var result21 = list.FirstOrDefault(u => u.fiyat == 3750);

        //Single
        var result22 = list.Single(u => u.stok == 78);
        //SingleOrDefault (
        var result23 = list.SingleOrDefault(u => u.stok == 78);

        //ANY

        // listenin içinde eleman varmı true yada false
        var result24 = list.Any(); 

        // listede fiyatı 1200 olan ürün var mı
        var result25 = list.Any(u => u.fiyat == 1200);

        #endregion
    }

    public static void Yazdir(List<Secilen> secilenler)
    {
        foreach (var item in secilenler)
        {
            Console.WriteLine($"Ürün Adı : {item.name} Fiyatı : {item.price}");
        }
    }




    public static bool Filtre(Urun u)
    {
        return u.fiyat > 1000;
    }
}

public class Secilen
{
    public string name;
    public double price;
}

public class Urun
{
    public int id;
    public string ad;
    public double fiyat;
    public int stok;

    public Urun(int id, string ad, double fiyat, int stok)
    {
        this.id = id;
        this.ad = ad;
        this.fiyat = fiyat;
        this.stok = stok;
    }

    public static List<Urun> Urunler()
    {
        return new List<Urun>
        {
            new Urun(1,"Monitör",1200,45),
            new Urun(2,"Klavye",180,25),
            new Urun(3,"Mouse",75,12),
            new Urun(4,"Laptop",2000,36),
            new Urun(5,"Masa",400,78),
            new Urun(6,"Sandalye",200,78)
        };
    }
}
