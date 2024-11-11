using System;
using System.Text;


namespace First;

class Program
{
    static void Main(string[] args)
    {
        int [] sayilar = new int[]{2,4,6,7,8,3,1,0};

        string isim = "Gencay";
        string soyad = "yildiz";

        ArraySegment<int> segment1 = new ArraySegment<int>(sayilar); // sayiları referans eder direkt yeni bir array oluşturmadan

        ArraySegment<int> segment2 = new ArraySegment<int>(sayilar,2,5); // segöent2 aslında 2 ve 5 .indise olana kadar ki değerlerin arrayini gösteririr

        segment2[0] *= 10; // gerçek arrayde etkilenir o ona bakıyor çünkü

        ArraySegment<int> segment3 = segment1.Slice(0,3); //dilimlemeye yarıyor Slice fonksiyonu

        ArraySegment<int> segment4 = segment1.Slice(4,7);

        string text = "Merhaba Dünya";
        StringSegment segment5 = new StringSegment(text);
        StringSegment segment6 = new StringSegment(text,2,5);
        Console.WriteLine(segment6);

        StringBuilder builder = new StringBuilder();
        builder.Append(isim);
        builder.Append(" ");   // + operatörü gibi birleştirme yapar bu maliyeti azaltır yani böylece arka planda stringsegment kullanr
        builder.Append(soyad);
    }


}
