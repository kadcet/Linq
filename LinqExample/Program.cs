// Linq Extension metodlarla çalışıyor. İçerde bi tip var. Linq o tiplere yapışıyor
// Linq IEnumarable uygulayan bütün objeleri sorgulayabilir anlamına geliyor.
// mesela List
List<string> liste = new List<string>
{
    "Ahmet","Ayşe","Ali","Mehmet","Mustafa","Süleyman"
};

// isim A harfi ile başlıyorsa seç dedik StartsWith geriye IEnumerable boolean dönüyor
// Select ise içine aldığı fonksiyonun parametre olarak bir string almasını ve geriye bir boolen dönmesini istiyor
// dönüş hep boolen yani true yada false

var sonuc1 = liste.Select(isim => isim.StartsWith("A"));// kaç tane a varsa bluen bluen dönecek
var sonuc2 = liste.Where(isim => isim.StartsWith("A")).ToList();// sonucu listeye çevirmek için tostring yaptık


foreach (var item in sonuc2)
{
    Console.WriteLine(item);
}

Console.ReadLine();

#region Uzun Yol
var sonuc3 = liste.Where(Filtre).ToList();

bool Filtre(string str)
{
    // 3. Yol
    return str.StartsWith("A");

    // 2. Yol
    //if (str.StartsWith("A"))
    //    return true;
    //else return false;

    // 1. YOl
    //if (str.StartsWith("A"))
    //{
    //    return true;
    //}
    //else
    //{
    //    return false;
    //}
} 
#endregion
