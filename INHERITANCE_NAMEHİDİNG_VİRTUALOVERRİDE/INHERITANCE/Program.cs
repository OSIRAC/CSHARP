using System;
using System.Runtime.CompilerServices;

namespace INHERITANCE_NAMEHİDİNG_VİRTUALOVERRİDE
{

    class Program
    {
        static void Main(string[] args)
        {
            Yazilimci yazilimci = new Yazilimci(4);
            yazilimci.Adi = "Ömer";

            Personel personel = new Personel(6);
            personel.CALİS();

            Yazilimci yazilimci1 = new Yazilimci(6);
            Console.WriteLine(yazilimci1.Adi); // BU NULL DÖNER ÇÜNKÜ BİZ DİĞER NESNE DE ATADIK ONU

            yazilimci.OKU();
            Omer kisi = new Omer(7);
            kisi.CALİS();
            Console.WriteLine(kisi.SoyAdi);
        }

    }
    class Personel    // KALITIMLA BİZ ALT SINIFTAN ÜST SINIFA ERİŞİRİZ COMPİLER BASE İLE ERİŞMEZ AYNI ŞEKİLDE THİS İLE DE BİR KEZ TANIMLANIR HER ELEMAN SADECE YUKARIYA ERİŞİRİZ
    {
        public Personel(int a)  // İLK KALITIM ALINAN SINIFLAR OLUŞUR YANİ O CONSTRUCTORLAR TETİKLENİR
        {
            Console.WriteLine(a);
        }
        public string Adi { get; set; }
       
        public string SoyAdi { get; set; }

        public bool MedeniHal { get; set; }

        public void OKU()
        {
            Console.WriteLine("HADİ OKUYALIM");
        }

        public virtual void CALİS()
        {
            Console.WriteLine("PERSONEL CALISTI");
        }
    }
    class Yazilimci : Personel   // HER SINIF OBJECT TEN TÜRER
    {
        public string YazilimDili { get; set; }

        public new int OKU()   // NAME HİDİNG DURUMU OLUR TÜREMİŞ CLASS TERCİH EDİLİR BASE CLASSA GÖRE NEW İLE HATA VERMESİ ENGELLENİR SADECE KULLANIM ŞART DEĞİLDİR
        {
            Console.WriteLine("HADİ OKUYALIM MI ?"); // NAME HİDİNG DE İMZASI AYNI OLMASI YETERLİDİR
            base.OKU(); // BÖYLE DURUMLARDA KULLANILIR ÇÜNKÜ KULLANILMAZSA YAZİLİMCİNİN Kİ TETİKLENİR
            return 0;
        }

        public Yazilimci(int a) : base(a)
        {
           
        }

        public override void CALİS()   // OVERRİDE DA İMZA VE GERİYE DÖNÜŞ ÖNEMLİDİR OVERRİDE OLMASI İÇİN VİRTUAL İLE İŞARETLENMELİDİR  
        {
           Console.WriteLine("BEN CALİSMİCAM");  // OVERRİDE DA ÜSTTEKİ METHOD İPTAL EDİLİP BU KULLANILIR NAME HİİDNG DE İKİ FARKLI METHOD VARDIR AMA
            base.CALİS();  // YA DA BÖYLE KULLANILIR KARMAŞIKLIĞI ÖNLEMEK İÇİN KISACASI HANGİSİNİ BELLİ ŞEKİLDE SEÇMEK İÇİN

        }// OVERRİDE İŞLEMİ İÇİN POLİMORFİZM ŞART DEĞİLDİR AMA GERÇEK FARK ORDA DAHA İYİ ORTAYA ÇIKAR

    }
    class Omer : Yazilimci
    {
        public Omer(int a) : base(a)   // OVERRİDE OLDUĞUNDNA ARTIK BU GEÇERLİ OLUR O DİĞERİ KALITIMSAL OLRAK İPTAL EDİLMİŞTİR ÇÜNKÜ 
        {
            base.SoyAdi = "islamoğlu";  // NORMAL ŞEKİLDE KİŞİ.SOYADİ DEYİP ATASANDA ZATEN BASE E ERİŞİP YAPIYOR AYNI ŞEYLER  YANİ BU DUMLARDA GEREKSİZDİR
        }
    }
}
