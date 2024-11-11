using System;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace USINGBLOCK_ANONYMOUSTYPE
{
    class Program  // USİNG ÇEŞİTLİ NAMESPACELERİ EKLEMEMİZE OLANAK SAĞLAR 
    {

        public delegate void MyDelegate(int x);  // delegate ANAHTAR KELİMESİ TYPEDEF GİBİDİR BUNU BİR TÜR YAPAR NASIL Kİ BİZ  typedef int (*ptrtopla)(int, int);  PTRTOPLA BİR TÜR OLDU ARTIK İNT DÖNEN İNT,İNT PARAMETRESİ ALAN BİR FONKSİYON İŞARETÇİSİ TÜRÜ OLDU O ŞEKİL
        public delegate int MyDelegate2(int x);
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("elma.txt"))  // USİNG BLOĞU IDİSPOSİBLE DAN TÜREYEN SINIFLARDA KULLANILIR BLOCK BİİTNCE OTOMATİK ÇAĞRILIR DİPOSE KAYNAKLARI SERBEST BIRAKMAK DEMEKTİR
            {


            }
            using StreamWriter writer1 = new StreamWriter("elma.txt");   // YENİ ÖZELLİKLE BU ŞEKİLDE DE KULLANILABİLİR USİNG İFADESİNİN BULUNDUĞU BLOCK BİİTNCE OTOMATİK ÇAĞRILIR YANİ BİR NEVİ NESNEYE ERİŞİM KESİLİNCE DİYE DÜŞÜNEBİLİRİZ
            var person = new  // ANONİM CLASSLAR VAR İLE OLUŞTURLUR ÇÜNKÜ BİR CLASS TAN OLUŞMAZ YANİ ANONİM
            {                 
                Name = "Ahmet", // ANONİM SINIFLARIN ÖZELLİKLERİ OLUŞTURULURKEN BELİRLENİR VE READONLYDİRLER YANİ SET YAPILMAZ
                Age = 30
            };

            MyDelegate delege = new MyDelegate(PrintNumber);

            delege = PrintNumber;  // PRİNTNUMBER CHAR DİZİSİ GİBİ ADRESİ TUTTAR KENDİSİDE FONKSİYONUN BAŞINDADIR DİREKTMEN DELEGATE ATANABİLİR

            delege += PrintSquare;

            delege(4);  // FONKSİYONUN ADRESİNİ ATADIK NASIL ÇAĞIRIYORSAK FONKSİYONLARDAKİ GİBİ ÇAĞIRIRIZ

            MyDelegate2 delege2 = x => x * x * x;

            Console.WriteLine(delege2(5));

            Action action = () => Console.WriteLine("MERHABA DÜNYA");  // ACTİON DELEGATE HAZIRDIR İÇİNE PARAMETRE ALABİLİR FAKAT GERİYE DÖNÜŞ DEĞERİ VOİD OLMAK ZORUNDADIR

            Action <string> message = message => Console.WriteLine(message);  // GENERİC FONKSİYON TUTAN BİR PREDİCATE TANIMLADIK BUNLAR HAZIRDIR GÖMÜLÜ OLARAK GELİR

            message("HADİ");

            Predicate<int> isEven = number => number % 2 == 0;  // PREDİCATE YALNICA BİR PARAMETRE ALAN VE GERİYE BOOL DÖDÜREN BİR DELEGATEDİR

            isEven(4);

            Func<int, int, int> add = (a, b) => a + b;  // FUNC GERİYE DÖNÜŞ DEĞERİ OLAN METHODLARI TEMSİL EDER SON PARAMETRE GERİYE DÖNÜŞ DEĞERİDİR

            Console.WriteLine(add(3, 4));
        }
        void PRINTANONYMOUS(dynamic obj)  // VAR KEYWORDU KULLANILMAZ ÇÜNKÜ FONKSİYON ÇAĞRIMLARINDA FONKSİYONUN İÇİYLE FONKSİYON ARASI UYUMA BAKILIR YANİ FONKSİYON PARAMETRELERİ TAM OLAMLIDIR
            // DYNAMİC KULLANILIRÇÜNKÜFONKSİYON DERLEMESİNDE DEĞİL ÇALIŞMA ZAMANININI KAPSADIĞINDNA DYNAMİC O UYUŞMAZLIĞA BAKILMAZ BİLE
        {
            Console.WriteLine(obj.Name); // OBJ. DEDİĞİMZDE ÇIKMAZ ÇÜNKÜ DYNAMİCLE ALDIĞIMIZDAN DERLEME ZAMANINDA ETKİSİNİ GÖSTERMEZ
        }   // KOD YAZIM ANI YARI DERLEME ZAMANIDIR KODUN EKSİKLİKLERİNİ DERLEYİCİ BİZE BİLGİ VERİR AMA TAM BİR DERLEME DEĞİLDİR ELBET

        public static void PrintNumber(int x)
        {
            Console.WriteLine(x);
        }

        public static void PrintSquare(int x)
        {
            Console.WriteLine($"Square: {x * x}");
        }
    }
}
