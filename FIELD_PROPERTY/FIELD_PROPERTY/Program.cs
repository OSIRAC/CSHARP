using System;
using System.Security;

namespace FIELD_PROPERTY
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            Property prop = new Property();
            prop.Yas = 15;
            Console.WriteLine(prop.Ulke);

        }

    }

    class MyClass  // CLASSLAR GENELDE NAMESPACE İÇERİSİNDE TANIMLANIR %99
    {
        int a = 22;   // VERİ DEPOLAYAN TUTAN CLASS MEMBERLARI FİELDDIR

        public void MyFunction()  // FONKSİYONLAR VERİ TUTMAZ FİELD DEĞİLDİR AMA MEMBERDIR
        {
            Console.WriteLine("Merhaba Dünya");
        }

        class MyClass1  // NESTED CLASSLAR BİR FİELD DEĞİLDİR BİR MEMEBER DEĞİLDİR OUTER CLASSIN
        {
            
        }

    }

    class Property
    {
        int yas;
        int tc;
        /// <summary>
        /// BU BİR PROPERTYDİR
        /// </summary>
        public int Yas  // FULL PROPERTY DİR  HANGİSİNİ ENCAPSULATİON YAPICAKSAK ONUN İSMİ BÜYÜK OLUR
        {               // ENCAPSULATİON İÇİN C# ÖZEL GELİŞTİRİLMİŞ ÖZELLİKTİR PROPERTY
            get         // DÖNÜŞ DEĞERİ ENCAPSULATİON YAPACAĞIN DEĞERİN TÜRÜ OLMALIDIR
            {           // PUBLİC OLMALI Kİ DIŞARIDAN ERİŞELİM
                return yas;  // OKUMA İŞLEMİ OLURSA BU TETİKLENİR ATAMADA DİĞERİ
            }
            set 
            { 
                yas = value;  // 15 DEĞERİ VALUE İLE TUTULUR YAS A ATANIR
            }
        }

        public int Tc { get => tc ; set => tc = value; }  // BU FULL PROPERTY DİR  LAMBDA İLE DE KISALTABİLİRSİN FULL PROPERTY GET SET İŞLEMLERİNİ YUKARIDAKİ GİBİ ARKA PLANDA YAPAR

        public string Name { get; set; }  // ARKA PLANDA FİELD OLUŞTURULUR name DİYE SENİN OLUŞTURMANA GEREK YOK HERHANGİ BİR KONTROL YAPMAK İSTEMİYORSAM BU KULLANILIR PROP İLE OLUŞTURMADIR
        public int Numara { get; set; } = 310; // NESNE AYAĞI KALKAR KALKMAZ DA ATAYABİLİRİSİN PROPERTYE

        public string Okul { get; } = "YİLDİZ"; // PORPERTYLER READONLY OLABİLİR AMA WRİTEONLY OLAMAZ ATAMAYI NASIL YAPCAZ ? İLK ATAMA ÖZELLİĞİYLE O ZAMAN 

        public string Ulke => "TURKEY";  // YUKARIDAKİ GİBİ READONLY BİR PROP VARSA VE İLK ATAMASI VARSA EXPRESSİON BUDDY PROPERTY ŞEKLİNDE KULLANILABİLİR
    }
}
