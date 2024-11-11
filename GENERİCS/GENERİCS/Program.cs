using System.Collections;
using System;

namespace GENERİCS
{
    class Program
    {
        static void Main(string[] args) 
        {
            int x,y;
            ArrayList list1 = new ArrayList();
            list1.Add(15);
            list1.Add("Merhaba");

            x = (int)list1[0];   // ARRAYLİSTLERDE VERİLER OBJECT OLARAK ALINIR OKUNURKEN CAST GEREKİR
            // ARRAYLİSTLER ARRAYLERİN BİR ADIM EVRİMLEŞMİŞ HALİDİR
        
            List<int> list2 = new List<int>();
            list2.Add(10);
            y = list2[0];   // İŞTE LİSTLERDE GENERİC BU YÜZDEN GELİMİŞTİR LİST DİYEREK DOĞRUDAN TANIMLAMA YAPMAK MÜMKÜN DEĞİL GENERİC OLMAK ZORUNDADIR

            VERİTABANİ<int> veri = new VERİTABANİ<int>();

            CLASSWİTHBASE<DERİVEDCLASS> class1 = new CLASSWİTHBASE<DERİVEDCLASS>();
            
            class1.CallBaseMethod(new DERİVEDCLASS());

            GENERİCFUNCTİON<int>(3); // TÜRÜNÜ BÖYLEDE BELİRTEBİLİRM


        }

        public static void GENERİCFUNCTİON<T>(T item)  // GENERİC FUNCTİONLAR BÖYLE TANIMLANABİLİR
        {
            Console.WriteLine(item);
        }
    }

    class VERİTABANİ<T> // GENERİC CLASSLARIN ORTAYA ÇIKMA SEBEBİ TÜR ESNEKLİĞİ SAĞLAMAKTIR YARIN BİR GÜN TÜRÜM STRİNG OLUNCA SINIFIMI KLONLİCAZ ÇÜNKÜ ?
    {
        private T veri;

        public void SAKLA(T veri)
        {
            this.veri = veri;
        }

        public T Al()
        {
            return veri;
        }
    }

    class BASECLASS
    {
        public void BaseMethod()
        {
            Console.WriteLine("Base method.");
        }
    }

    class DERİVEDCLASS : BASECLASS
    {
        public void DerivedMethod()
        {
            Console.WriteLine("Derived method.");
        }
    }


    class CLASSWİTHBASE<T> where T : BASECLASS  // TBURADA BASECLASS DAN TÜREMİŞ BİR SINIF OLMA ZORUNLULUĞU VARDIR
    {
        public void CallBaseMethod(T obj)
        {
            obj.BaseMethod(); // T'nin BaseClass'tan türemiş olduğunu garanti eder.
        }
    }

    class JUSTCLASS<T> where T : class  // T BURADA CLASS OLMA ZORUNLULUĞU VARDIR
    {


    }

    class NEWABLW<T> where T : new() // T BURDA NEWLENEBİLİR DEMEK DEFAULT OLRAK NEWLENMEZ AMA 
    {
        public T nesne { get; set; }  // EKSTRA KOŞUL EKLEMEK İSTİYORSAK WHERE T : ABC , DFG ŞEKLİNDE YAZABİLİRZ

        public void NEW()
        {
            nesne = new T();  // PARAMETRESİZ OLARAK NEWLENEBİLİR DİYORUZ
        }
    }

   

}