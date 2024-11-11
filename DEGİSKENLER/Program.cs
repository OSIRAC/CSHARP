using System;

namespace First;

class Program
{
    static void Main(string[] args)
    {   // Structlar value typeder referans type değildir class gibi struclar farklı structlardan kalıtım almazlar inteferacelerden alabilirler ama

        Console.WriteLine(typeof(int));  // Int32 ile int aynı şeydir Int32 bir structır o yüzden int numeb=32 number. yaparız 
        Console.WriteLine(typeof(Int32));
        int @static = 3; // Anlamlı keywordler değişken adlandırıken kullanılmaz ama @ işaretiyle kullanılabilir
        double elma = 3.14;
        float armut = 3.14f;  // Default olarak Double tanımlanır o yüzden float için f ile belitcez double için geek yoktur
        const double pi = 3.14;  // Değeri sabittir değişmez
        (int a,int b) kayisi = (3,5); //Value olarak atamak tuplela bir Struct gibidir ama değildir kendine hastır
        
        Console.WriteLine(kayisi.a);
        var tuple = new Tuple<int, string>(1, "Hello"); //Reference olararak atamak Tuple bir sınıftır
        Console.WriteLine(elma);
        Console.WriteLine(armut);

        bool x = default(bool);  // boolun defaultu yani False döner
        bool y = default; // bu da olur
        // Struclar başlangıç değerle başlatılırsa new lenir ama int ler vb. 0 ile başladığındna struct ya new lenmez gerek yoktur
        // Run time da ramde yer ayrılır ve değer atanır
        // Value typeler stackde tutulur yığın referanslar heap de

        object a = 5; // object bütün türlerin atasıdır her şeyi alabilir referans türüdür. atanan tür kutulanır referansı değişkene atanır yani a referansı tutar int in nesneye sarararak object gibi davranması sağlanır
        //Boxing işlemi yaptık object bir türü sarmalar kendi türüyle
        int m = (int)a; // Cast operatörü unboxing yapar biz a yı object haliyle toplayamayız onun için kendi türünü çıkarması için cast ederiz

        var sayi = 15; //var bir keyworddur compiler karar verir manuel girmeyiz biz bir veri türü değildir

        dynamic esya = 14; // dynamic key wordu  run timeda belli olur var dan farkı budur ve runtime da türünüde değiştirebilirisn normalde var da olmaz çünkü atadın başka bir türde değer atayamazsın ona
        // Uzaktan gelen verilerde kullanılır beklemeli yani 
        string eksi ="armut"; // string keywordu system.String taklit eder ve classdır newlenebilir ama gereksizdir

        string e = "123";
        short a1 = short.Parse(e); //Parse string ifadeleri dönüştürür;
        double a2 = Convert.ToDouble(e);  // Stringi bir seye dönüştürürz. 

        int a3 = 34;
        float a4 = a3; //Bilinçsiz dönüşümdür yani compiler dönüştürür sayılar arasında;

        int a5 = 34;
        short a6 = (short)a5;  //bilinçli dönüşümler manuel yapılır Cast operatörüyle
        Console.WriteLine(a6);

        checked
        {
            int s = 500;
            byte b =(byte)s;  // Checked bloğu bilinçli dönüşümlerde bizi uyarır run time da
        }
        Console.WriteLine(e + a3); // a3 tam sayı olmasına rağmen objecte döünüşür ve sonuç string döner string toplamışsın gibi olur

        bool medeniHal = true
        string mesaj = medeniHal == true ? "ne güzel" : "ne kötü "; //ternary opöratörüdür

        int yas = 25;
        string sonuc = yas < 25 ? "a" : (yas == 25 ? "b" : "c");  //fazla koşulda böyle kullanılır

        object r = true;
        Console.WriteLine(r is bool); // is key wordu boxing işlemine tutulmuş bir şeyin özündeki türü öğrenir bool geri döner

        string t = "esya";
        Console.WriteLine(t is null); // Null mı diye bakar

        object r1 = true;
        Console.WriteLine(r1 as string);  // Cast operatörü gibidir unboxing yapar ama tür dönüşümü hatalı ise null dödürür bu yüzden referans türler veya nullable larla kullanılır 

        int? r2 = null; // deger türler null olmaz referans olur mama ? nullable işaretididr 

        string adres = null;
        string yeni = adres ?? "bilmem"; // null olma durumunda şunu yap demek ??  değer döndürü bu
        adres ??= "hadi";   // dödürdüğünü atarda
    } 
}
       