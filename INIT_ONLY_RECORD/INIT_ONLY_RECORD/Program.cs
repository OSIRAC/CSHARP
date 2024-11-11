using System;

namespace INIT_ONLY_RECORD
{

    class Program
    {
        static void Main(string[] args) 
        {
            MyClass myClass = new MyClass();

            myClass.Yas = 22;

            new MyClass().Yas = 21; // DOT NESNE ÜZERİNDNE KULLANILIR AMA NEWLE DİREKT TANIMLARSAM BAŞKA BİR YERDE BİR DAHA ONU KULLANAMAZSIN

            Console.WriteLine(myClass.Yas);  // BURDA 21 YAZAR ÇÜNKÜ NEW MYCLASSS().YAS REFERANSA ATANMADI ERİŞEMEYİZ ONA O GARBAGE COLLECTORA GİDER

            MyClass myClass2 = new MyClass
            {
                Yas = 21,       // OBJECT İNİTİLAZER PROPLARIN DEFAULT DEĞERİ BÖYLE OLARAK KALKAR AMA
                Numara = 310,   // SADECE FİELDLARA DEĞER ATANIR FONKSİYONLAR GELMEZ
            };
            // READONLY PROPLARA DEĞERLER YA PROP İNTİLAZER LA YA DA CONSTRUCTOR İLE ATANIR OBJECT İNİTİLAZERLA OLMAZ OLMASINI İSTİYORSAN İNİT YAPCAN

            MyClass myClass3 = new MyClass
            {
                Yıl = 2002,  // İNİT OLDUĞUNDAN READONLYE OBJECT İNİTİLAZER İLE DEĞER ATANABİLİR
                Para = 10    
            };

            MyClass myClass4 = new MyClass
            {
                Yıl = myClass3.Yıl,   // YARIN BİRGÜN BİR TANE DEĞERİNİ DEĞİŞTİRMEK İSTESEN İNİT OLDUĞUNDAN BÖYLE YAPARSIN
                Para = 90
            };

            MyClass myClass5 = myClass4.With(100);  // RECORDLARDAKİ ÖZELLİK OLMASA BÖYLE YAPARDIK FONKSİYONLA

            MyRecord myRecord = new MyRecord
            {
                Name = "OMER",
                Tc = 23
            };

            MyRecord myRecord1 = new MyRecord
            {
                Name = "OMER",
                Tc = 23
            };
            Console.WriteLine(myRecord.Equals(myRecord1));  // BUT TRUE DÖNECEKTİR ÇÜNKÜ RECORDLARDA DEĞER ÖN PLANDADIR ÇÜNKÜ DEĞERLER DEĞİŞMİYOR Kİ NESNE ÖN PLANDA OLSA DEĞİŞKENLİK DURUMU OLUR

            MyRecord myRecord2 = myRecord1 with { Tc = 30 };  // BURADA RECORDUN BİR ÖZELLİĞİNİ KULLANDIK NAME YUKARIDAN ALINDI DEĞİŞMEDİ TC DEĞŞTİ YENİ BİR NESNE OLUŞTURULDU SONRA TEKRARDAN              
        }
    }
    class MyClass
    {
        private readonly int para = 123;  // BÖYLE DE DİREKT ATAMA YAPABİLRİZ

        public int Para
        {
            get
            { 
                return para; 
            }
            init     // OBJECT İNİTİLAZERLA ATAYABİLİRİZ BÖYLE READONLY FİELDLARA
            {
                para = value;
            }
        }
        public int Yas { get; set; }

        public int Numara { get; set; }

        public int Yıl { get; init; }  // İNİT GET OLMADAN KULLANILAMAZ  private readonly int yıl; OLUŞTURUR ARKA PLANDA

        public MyClass With(int para)  // READONLY LER YA PROP İNTİLAZERLA YA DA CONSTRUCTORLA DEĞİŞİR HERHANGİ BİR FONKSİYONLA DEĞİŞMEZ 
        {
            return new MyClass // BURADA Kİ PARA REDONLY NİN Kİ DEĞİL O DEĞİŞMEZ YENİ OLUŞAN SINIFINKİ DEĞİŞİYOR
            {
                Yıl = this.Yıl,
                Para = para
            };
        }
    }
    record MyRecord  // RECORDLAR EĞER TÜM FİELDLARIMIZ İNİTSE ORTAYA ATILMIŞTIR BİR CLASS TIR ÖZÜNDE
    {
        public string Name { get; init; }

        public int Tc { get; init; }

    }
}
