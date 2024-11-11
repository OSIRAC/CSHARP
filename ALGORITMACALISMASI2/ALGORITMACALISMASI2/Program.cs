using Microsoft.Extensions.Primitives;
using System;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ALGORITMACALISMASI2
{

    class Progrma
    {

        static void Main(string[] args)
        {
            char[] array = new char[] { 'a', 'b', 'c' };
            char[] array1 = { 'a', 'b', 'c' }; // AŞŞAĞIDAKİ YUKARIDAKİ GİBİ İŞTE NEW SİZ OTOMATİK OLUŞTURULUR

            char[] charArray = { 'H', 'e', 'l', 'l', 'o' };

            string ifade = "abc";  // Char dizisinin bir birleşimidir. Stringler kendine özgüdür arka planda char dizisi gibi işlem görürü ama string sınıfından türediğinden farklı methodları vardır

            string str = new string(charArray); // Karakterler arka planda birleştirilir


            // STRİNGLER DEĞİŞEMEZLER YANİ ÜZERİNDE İŞLEM YAPARSAN ESKİSİNE BİŞEY OLAMZ AMA ARRAYLER DEĞİŞEBİLİR
            string original = "hello";
            string modified = original + "world";  // original sabit kalır değşmez bu koşulda

            Console.WriteLine("BİR METİN GİRİNİZ");

            string metin = Console.ReadLine();

            int i = 0;

            while (metin[i] == ' ')
            {
                i ++;
            }
            string subtext = metin.Substring(i);

            string[] words = subtext.Split(' ');

            Console.WriteLine($"KELİME SAYISI :{ words.Length}");

            string text = "MerhabaNasilsiniz";
            text = "Mehabaiyiyim";  // STRİNGDE REFERANSI DEĞİŞTİRİRSİN ARTIK İYİYİMİ GÖSTERİYOR AMA DEĞİŞMEZ DERKEN İÇERİĞİ DEĞİŞMEZ DEMEK KARAKTERLERİ FALAN

            StringSegment segment = new StringSegment(text,2,6);
            // YENİ BİR STRİNG OLUŞTURMAZ SADECE POİNTER GİBİ TEMSİL EDER SUBSTRİNG DE OLUŞTURURDU
            // SEGMENT DE SADECE PARÇALARA AYIRIRIRZ YİNE STRİNGİ DEĞİŞTİREMEYİZ

            string isim = "gencay";
            string soyadi = "yildiz";
            StringBuilder builder = new StringBuilder();
            builder.Append(isim);
            builder.Append(soyadi);  
            Console.WriteLine(builder.ToString());  // STRİNG BİRLEŞTİRME (+) OPERATÖRÜYLE ÇOK ZAHMETLİDİR BÖYLE SEGMENT KULLANIR ARKA PLANDA AZ MALİYETLİDİR

            // ----------------- STRİNGİN İÇERİĞİNİ DEĞİŞTİRME ---------------------//

            string elma = "Elma";
            char[] karakter = elma.ToCharArray();
            karakter[0] = 'a';
            elma = new string(karakter);
            Console.WriteLine(karakter);  //STRİNGLER DEĞİŞMEZ OLDUĞUNDNA ARRAYE DÖNÜŞTÜRÜRÜZ O DEĞİŞEBİLİR SONUÇTA

        }
    }
}

