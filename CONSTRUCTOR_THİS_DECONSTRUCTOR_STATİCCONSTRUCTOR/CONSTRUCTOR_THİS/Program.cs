using System;

namespace CONSTRUCTOR_THİS_DECONSTRUCTOR_STATİCCONSTRUCTOR
{
    class Program
    {
        static void Main(string[] args)
        { 
            new MyClass();  // NESNE ÜRETİLİRKEN TETİKLENEN METODDUR KONFİGÜRASYON YAPMAMIZI SAĞLAR 

            MyClass myClass = new MyClass(13,14);

            MyClass myClass1 = myClass.RETURNTHİS(35);

            Console.WriteLine(myClass1.Para);

            myClass = null;

            myClass1 = null;

            {
                MyClass myClass2 = new MyClass(123); // Bu nesne sadece bu blok içinde kullanılabilir ANA MAİNDE ERİŞİLMEZ 
            }

            GC.Collect();   // GARBAGE COLLECTORUN TETİKLENMESİ İÇİN BİZİM O NESNEYE BİR DAHA ULAŞAMAMIZ OLMAMIZ LAZIM MAİNİN İÇİNDE GARBAGE TETİKLENMEDEN ÖNCE
      
            Console.ReadLine();
        }
    }
    class MyClass
    {
        public int Para { get; set; }    
        public MyClass()    // PUBLİC OLCAKKİ DIŞARIDAN NESNE ÜRETİRKEN TETİKLENSİN
        {
            Console.WriteLine("Merhaba Dünya");
        }
        // İLK ÖNCE THİS() CONSTRUCTORU TETİKLENİR SONRA KENDİSİ
        public MyClass(int a) : this()  // OVERLOAD YAPABİLİRİZ 
        {
            Console.WriteLine($"A nın değeri : {a}");
        }     
        public MyClass(int a,int b) : this(a)  // THİS İÇERİSİNE YA SABİT BİR DEĞER ATAYABİLİRİSN YA DA YANDAKİ FONKSİYONUN PARAMETRESİNİ VEREBİLİRSİN BİR FİELD IN DEĞERİNİ VEREMEZSİN
        {
            Console.WriteLine($"A nın değeri : {a} B nin degeri : {b}");
        }
        /*
        MyClass()  // PRİVATE OLUNCA DIŞARIDAN NESNE ÜRETİLMEZ YANİ
        {
            Console.WriteLine("Merhaba Dünya");
        }

        void NESNEURET()
        {
            new MyClass();
        }
        */

        public MyClass RETURNTHİS(int para)  // THİS ANAHTAR KELİMESİ METHODLAR PROPERTYLER YANİ NESNENİN TEMSİLİNİN OLDUĞU YERDE KULLANILABİLİR MESELA BİR METHODA NESNE ÜZERİNDNE ERİŞİRİZ O YÜZDEN KULLANILIR SALT OLARAK SINIFIN İÇİNDE OLMAZ AMA
        {
            this.Para = para; // 'this', şu anda çalışmakta olan 'MyClass' nesnesini temsil ediyor
            return this; // Mevcut nesne temsilcisi geri döndürülüyor REFERANS DEĞER OLAN
        }
        ~MyClass()  // NESNE İMHA EDİLİRKEN TETİKLENEN FONKSİYONDUR NESNEYİ GARBAGE COLLECTOR İMHA EDER
        {
            Console.WriteLine("NESNE İMHA EDİLİYOR"); 
        }

        static MyClass()
        {
            Console.WriteLine("İLK MESAJ");  // STATİK CONSTRUCTOR İLGİLİ SINIFTAN ÜRETİLEN İLK NESNEDE TETİKLENEN CONSTRUCTORDUR SONRAKİ O SINIFTAN ÜRETİMLERDE TETİKLENMEZ
            //  İLK ÜRETİMDE STATİK ONDAN SONRA NORMAL CONSTRACTOR TETİKLENİR
            // AYRICA SINIFTA OLAN HERHANGİ BİR STATİC YAPILANMA TETİKLENİRSEDE TETİKLENİR AMA BİR SINIFTA STATİC CONSTRUCTOR SADECE BİR KEZ TETİKLENİR UNUTMA !!!
            // HAFIZADA YER AYRILDIKTAN SONRA NORMAL CONSTRUCTOR TETİKLENİR ÇÜNKÜ KONFÜGİRE EDİCEK
        }
    }
}
