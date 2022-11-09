using ExtensionsMethods;
using ROASApp.Domain;


//int x = 5;
//string y = "1234";
//var a = y.ToInt32();
//Console.ReadLine();

//object o = "fdd";  burda ToInt32 metodu gelmez.bunu için this.object yapmamız lazım
//o.ToInt32();

ROAS r = new ROAS();
r.reklamKanali = "Instagram";
r.reklamMaliyeti = 3500;

// bu metodu çağırınca bana reklam kanalını ismini ve reklam maliyetini versin
r.Brief();
Console.ReadLine();

