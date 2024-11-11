using System;
using System.Collections;

namespace EXTENSIONFUNCTION_LINQ
{
    class Program
    {
        static void Main(string[] args) 
        {
            IEnumerable<int> sayilar = new List<int> { 1, 2, 3, 4, 5 };
            // LINQ SORGULARI IENUMERABLE<T> YE EXTENSION METHOD OLARAK EXTEND EDİLMİŞTİR GENERİC ÇÜNKÜ TÜRÜ BİLMEMİZ LAZIM LAMBDANIN İÇİNDEKİNİN       
            var sonuc = sayilar.Where(x => x > 3); // WHERE METHODU İÇİN IENURABLE<T> TÜRÜNDEN BİR NESNE LAZIM BU NESNEYİ ÜRETMEK İÇİN DE KOLEKSİYON ÇÜNKÜ KOLEKSİYONLAR BUNU İMPLEMENTE ETTİĞİ İÇİN ONLARI KULLANARAK NESNE OLUŞTURABİLİRİZ WHERE BURDA WhereEnumerableIterator<T> DÖNER BU DA IENURABLE<T> TÜRÜNDENDİR YANİ BUNUN TÜRÜNDNE DÖNMİŞ OLUR VE  WhereEnumerableIterator<T> İÇERİSİNDE GETENUMATOR() FONKSİYONU BARINDIRIR İMPLEMENTE ETTİĞİ İÇİN IENURABLE<T> Yİ FOREACH BU FONKSİYON YARIDIMIYLA 

            List<int> list = new List<int> { 1, 2, 3, 4};
            // WHERE EXTENSION FUNCTION OLDUĞUNDNA this IEnumerable<TSource> source OLARAK YAZILMIŞTIR BURDA SOURCE DA list OLMAKTADIR
            var sonuc1 = list.Where(x => x > 2)
                             .Select(x => x * 2)  // HER BRİRNİ SEÇ İKİ İLE ÇARP DEMEK
                             .OrderBy(x => x)     // HER BİRİNİ KENDİ NORMAL DEĞERİYLE SIRALA DEMEK
                             .ToList();

            // LİST SINIFI IENUMERABLE I İMPLEMENTE ETTİĞİ İÇİN KENDİSİ ÜZERİNDEN DE ERİŞEBİLRİZ WHERE LINQ SORGUSUNA

            List<int> sayilarListesi = sonuc1.ToList();  // LİST E DÖNÜŞTÜRMEYE SAĞLAR BÖYLECE LİST İN EK FONKSİYONLARINI KULLANABİLİRİZ

            foreach (int sayi in sonuc)   
            {
                Console.WriteLine(sayi); 
            }
            // LINQ SORGULARI LAZY EVAULATION YAPAR YANİ İŞLEMİN GERÇEKTEN İHİTYAÇ DUYULDUĞUND AYAPILMASI DEMEKTİR YANİ FOREACH YA DA TOLİST() METHODU GİBİ İÇEİRİNDE DÖNEN İFADELERDE FİLTRELEME GERÇEKLEŞTİRİLİR
            string s1 = "elma";
            s1.GOSTER("HADİ");

            MyIExtensıon myIExtensıon = new MyClass();

            myIExtensıon.YAZ();

            MyClass myClass = new MyClass(); 
            
            myClass.YAZ();
        }   
    }
    interface MyIExtensıon
    {
        public void OKU();
    }
    class MyClass : MyIExtensıon
    {
        public void OKU()
        {
            Console.WriteLine("OKUDUM INTERFACE");
        }
    }
    static class MyExtensıon
    {
       public static void GOSTER(this string str,string yas)  // EXTENSION METHODLAR STATİC CLASS İÇİNDE TANIMLANIR DOĞRUDAN PROGRAM ULAŞSIN DİYE STATİC CLASS İÇİNDEKİ HER METHOD DA STATİC OLMAK ZORUNDADIR THİS HANGİ ÖN TANIMLI SINFA METHOD EKLİCEKSEK ONU GÖSTERİR STR DEHANGİ ÖRNEK ÜSTÜNDEN ÇAĞIDIYSAK ONU GÖSTERİRİ STR BURDA S1 İ TEMSİL EDER İKİNİC PARAMETRE METHODUN İLK PARAMETRESİDİR YANİ GOSTER ÇAĞRILDIĞINDAKİ
        {
            Console.WriteLine(str);
            Console.WriteLine(yas);
        }     
        public static void YAZ(this MyIExtensıon myIExtensıon) // BURADA SANKİ MYIEXTENSION İNTERFACİNE YAZ ADLI METHODUN İMZASINI GEÇMİŞ OLDUK myIExtensıon BURADA BU INTERFACEDEN OLUŞANI TEMSİL EDER
        {
            Console.WriteLine("INTERFACE E YAZDIM");
            myIExtensıon.OKU();
        }
    }
}