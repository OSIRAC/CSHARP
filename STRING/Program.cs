using System;

namespace First;

class Program
{
    static void Main(string[] args)
    {
        int yas = 5;
        char [] yas1 = new char[] {'a','b'};
        Console.WriteLine(yas);   // lengthe kadar gider \0 a kadar değil
        // char [] yas = new char[] {"ab"}; böyle birşey olmaz 
        string elma = "ayva"; // arka planda char dizisine çevrilir ama ikisi farklı özellikleri vardır
        Console.WriteLine(elma[0]);  // referans türü olup tanımlanmış tek keyworddur
        Console.WriteLine($"Yasim : {yas} ");  // String formatlandırma
        Console.WriteLine("Ben \"buradayim");  //   \ karakteri özel anlam ifade eden şeyleri yazmamızı sağlar

    }
}
