using System;
using System.Diagnostics;

namespace INTERFACE
{

    class Program
    {
        static void Main(string[] args) 
        {
            IRIDEABLE ride = new BİKE();

            ride.RIDE(); // SADECE IRIDEABLELA İLGİLİ METHODLAR GÖZÜKÜR BÖYLELİKLE İSTEDİĞİMİZ ÖNÜMÜZDE OLUR SADECE 

            BİKE bike = new BİKE();
            bike.GO();   // BURADA IVEHICLE DAKİ ÇALIŞIR

            IVEHICLE vehıcle = new BİKE();
            vehıcle.OZELMETHOD();  // DEFAULT İMPLEMENTİON DA İNTERFACE ÜZERİNDEN ÇAĞIRMAK ZORUNDASINDIR
                         
            ride.GO();   // BUNU DERSEK IRIDEABLE DAKİ TETİKLENİR  İMPLİCİT OLANI TETİKLEMEK İSTİYORSAK İNTERFACE REFERANSI İLE TANIMLAMAK ZORUNDASIN

            PAZAR pazar = new PAZAR();

            pazar.AL(new CAR());  // BÖYLECE SADECE HANGİ SINIFI GŞRERSEK ONA ÖZELLEŞMİŞ METHODU ALIRIZ
            pazar.AL(new BİKE());
        }
    }

    interface IVEHICLE       // INTERFACELER İN ANTLASMA VEYA BİR YETENEK ÖZELLİK KAZANDIRMASI ÖN PLANA ÇIKAR ÇÜNKÜ BUNLARI KESİNLİKLE UYGULAMAK YANİ KENDİSİNE ÖZEL DEĞŞTİRMEK ZORUNDADIR
    {
        void GO();
        void STOP();

        void OZELMETHOD()  // DEFAULT ÖZELLİK GELMİŞTİR İNTERFACELERİN İÇİNE GÖVDELİ METHOD TANIMLANABİLİR ALTTAKİLER ZORUNDA DEĞİLDİR BUNU UYGULAMAK
        {
            Console.WriteLine("BU OZEL METHODDUR");
        }
    }

    interface IRIDEABLE
    {
        void GO();
        void RIDE();
    }

    interface IFLYABEL
    {
        void SOAR();
    }

    class CAR : IVEHICLE,ISLEMLER
    {
        public string Model { get; set; }

        public int Yas { get; set; }

        public void AL()
        {
            Console.WriteLine("ARABA ALDIK");
        }

        public void GO()
        {
            Console.WriteLine("ARABA GİDER");
        }

        public void SAT()
        {
            Console.WriteLine("ARABA SATTIK");
        }

        public void STOP()
        {
            Console.WriteLine("ARABA DURUR");
        }
    }   // ALT TARAFTA CLASS TAN DA TÜRETMEK İSTİYORSAK İLK CLASS ADI YAZILIR

    class BİKE : IVEHICLE, IRIDEABLE, ISLEMLER  // BİRDEN FAZLA INTERFACE UYGULANABİLİR AYRICA BÖYLECE TÜM ÖZELLİKLER BİR CLASSA TOPLANMAZ İNTERFACELERE DAĞITILIR
    {
        public string Model { get; set; }

        public int Yas { get; set; }

        public  void AL()   // UYGULANAN METHODLAR HER ZAMAN PUBLİC OLMALIDIR  OVERRİDE KEYWORDÜNE GEREK YOKTUR ABSTRACT CLASSLARDAKİ GİBİ
        {
            Console.WriteLine("BİSİKLET ALDIK");
        }

        public void RIDE()
        {
            Console.WriteLine("BİSİKLET SURULUR");
        }

        public void SAT()
        {
            Console.WriteLine("BİSİKLET SATTIK");
        }

        public void OZELMETHOD() // DEFAULT İMPLEMENTİON OVERRİDE YAZILMADAN NORMAL BİR ŞEKİLDE EZİLEBİLİR 
        {
            Console.WriteLine("BU OZEL METHODDUR(EZDİK)");
        }

        public void STOP()
        {
            Console.WriteLine("BİSİKLET DURUR");
        }

        void IRIDEABLE.GO()   // İKİ İNTERFACEDE DE AYNI FONKSİYON VARSA INTERFACE ÜZERİNDNE PRİVATE ŞEKLİND EUYGULANIR HANGİSİNİ KULLANMAK İSTİYORSAK
        {
            Console.WriteLine("BİSİKLET GİDER(IRIDABLE)");
        }

        public void GO()
        {
            Console.WriteLine("BİSİKLET GİDER(NORMAL)");
        }
    }

    interface ISLEMLER   // INTERFACE INTERFACEDEN TÜREYEBİLİR
    {
        void AL();

        void SAT();

    }

    class PAZAR  // BURADAKİ AMAÇ ISLEMLER islem = NEW BİKE() YAPARSAK BİKE A ÖZELLEŞTİRMİŞ OLANI ÇAĞIRTMAKTIR UYGULATMAKTIR YANİ KENDİSİNE GÖRE ÖZELLEŞTİRİLMİŞ FONKSİYONU GETİRMEKTİR
    {
        public void AL(ISLEMLER islem)
        {
            islem.AL();
        }

        public void SAT(ISLEMLER islem)
        {
            islem.SAT();
        }

    }

}

