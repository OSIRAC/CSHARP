using System;

namespace SPECİALEXCEPCİON_SEALED_PARTİAL
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            int y = 0;
            try
            {
                //int m = x / y;  // SİSTEM KENDİSİ HATA FIRLATIR ONU YAKALARSIN            
                if(y==0)
                {
                    throw new MyException("HATA BULDUM"); // BURADA KENDİN HATA ATARSIN CATCH YAKALAR AMA SİSTEMİN ATTIĞINI KENDİ SINIFIN YAKALAYABİLİR Mİ ONU BULAMADIM
                    // THROW KOD BLOĞUNU DURDURUR CATCH BLOĞUNU TETİKLER HATAYI CATCHE FIRLATIR
                }             
            }
            catch (Exception e)
            {
            Console.WriteLine(e.Message);
            }
            /*   
            catch  TRY DENER HATA VARSA CATCH TETİKLENİR O YAPILIR PROGRAM BÖYLECE PATLAMAZ AYNI ZAMNDA İSTERSEN HATAYIDA TUTABİLİRSİN
            {
                Console.WriteLine("merhabab");
            }
            */
            C c = new C();
            c.YAZ();

            Person person = new Person();
            person.COZ();
        }
    }
    class MyException : Exception  // EXCEPTİONDAN TÜREMELİDİR
    {
        public MyException(string mesaj) : base(mesaj)   // YUKARIDAKİ CONSTRUCTOR İLE MESSAGE PROPU DOLDURULMALIDIR
        {
           
        }
    }
     class A   // SEALED KEY WORDUYLE İŞARETLERİZ SINIFI AMA VİRTUAL ÖZELLİKLER BULUNAMAZ BÖYLECE ÇÜNKÜ ALT SINIFLARDAN OVERRİDE EDİLEMEZ DE ONDAN
    {
        public virtual void YAZ()
        {
            Console.WriteLine("MERHABA A");
        }       
    }
    class B : A// : A SEALED KEY WORDU KALITIM VERMEYİ ENGELLER BAŞKA BİR CLASSA AMA KALITIM ALABİLİR 
    {
        public sealed override void YAZ()  // SEALED İLE İŞARETLERSEK OVERRİDE TEKRAR EDİLEMEZ ALT SINIFLARDAN DEMEK
        {
            Console.WriteLine("MERHABA B");
        }
    }
    class C : B
    {
       
    }

    partial class Person  // PARTİAL YAPILAR YAPIYI BÖLMEYE YARAR AYNI NAMESPACE ALTIND AOLMALIDIRLAR AYNI İSİMDE OLACAK VE İKİSİDE PARTİAL İLE İŞARETLENECEK
    {
        public void OKU()
        {
            Console.WriteLine("OKUDUM");
        }
    }

    partial class Person   // AYNI PERSON person = new Person() person. İLE İKİ FONKSİYONADA ERİŞEBİLRİM ÇÜNKÜ AYNI CLASSLAR BİR NEVİ
    {
        public void COZ()
        {
            Console.WriteLine("COZDUM");
        }
    }
}
