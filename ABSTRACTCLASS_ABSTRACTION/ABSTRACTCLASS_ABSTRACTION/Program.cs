using System;

namespace ABSTRACTCLASS_ABSTRACTION
{
    class Program    // ABSTARCTION SADECE SEÇTİĞİMİZ MALZEMELERİN ÖNÜMÜZE GELMESİDİR GEREKSİZ AYRINTILARI GİZLEMEK YANİ. AYNI ZMANDA İMZA BIRAKMAKTIR YANİ SOYUTLAYARAK NASIL YAPILCAĞINI KULLANICIYA BIRAKMAKTIR
    {
        static void Main(string[] args) 
        {
            // MEMELİ memeli = new MEMELİ();  BU OLMAZ ÇÜNKÜ NEW MEMELİ() YAPMIŞSIN
            OMER omer = new OMER(1);

            MEMELİ memeli = omer;

            memeli.UREME();
            memeli.NEFES_AL();
        }
    }
    abstract class MEMELİ  // ABSTRACT CLASSLAR NESNE ÜRETİLMEYEN DOĞRUDAN CLASSLARDIR SOYUT CLASSDIR NESNE YOK YANİ GRUPLAMA İÇİN KULLANILIR GENELDE AMA İÇİNDE CLASS OLDUĞUNDNA DOLAYI TAM METHODLARDA BARINABİLRİ
    {
        public int Dogurdugu_Yavru { get; set; }

        public abstract void YEMEK();  // PEKİ BU DAVRANIŞLARI NEDEN ZORLARIZ GARANTİ ETMEK İÇİN MESMELA BİR CLASS UÇMA ÖZELLİKLERİ BARINDIRSIN İSTİYOSAN NORMAL BİR CLASS DAN TÜRETMEZSİN ÇÜNKÜ O KODLARI BİR DAHA OVERRİDE ETMEK GEREKCEK VE O CLASS DA BOŞUNA YER KAPLAMIŞ OLCAK BURDA İMPLEMENTASYON YANİ KENDİNE GÖRE ÇEKİ DÜZEN VERMEYİ ZORLUYORUZ BİZ NORMAL BİR CLASS DAN TÜRETİNCE ONU DÜZELTMEDEN DE UYGULAYABİLİR BUNU İSTEMİYOZ

        public abstract void UREME();   // ABSTRACT İLE İŞARETLENMELİ İMZALAR  MEMELİ memeli = new OMER() YAPILDIĞINDNA İMZAYA KARŞILIK GELEN OVERRİDE DURUMU TETİKLENİR

        public void NEFES_AL()
        {
            Console.WriteLine("NEFES ALİR");
        }
    }

    abstract class İNSAN : MEMELİ
    {
        public abstract int IQ { get; set; }

        public int İrade_Katsayisi { get; set; }

        public İNSAN(int a)   // ABSTARCT CLASSLARDAN KALITIM GEREĞİ NESNE OLUSTURULUR AMA DOGRUDAN NEWLENEMEZ
        {
            Console.WriteLine($"{a} İNSAN OLUSTURULDU");
        }
    }
    class OMER : İNSAN 
    {
        public OMER(int b) : base(b)
        {
            Console.WriteLine("OMER OLUSTU");
        }
        public string  Hobiler { get; set; }

        public string Meslek { get; set; }
        public override int IQ { get; set;}

        public override void UREME()   // İMZALARI NORMAL CLASSLAR UYGULAMAK ZORUNDADIR
        {
            Console.WriteLine("OMER URER");
        }
        public override void YEMEK()
        {
            Console.WriteLine("OMER YER");
        }
    }
}
