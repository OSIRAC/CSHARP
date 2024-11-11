using System;

namespace First;

class Program
{
    static void Main(string[] args)
    { 
        int  numara = 3;

        switch(numara)     // caselerde eşitlik durumlarına göre aksiyon alınır switchin içine neye eşitlik bakıcaksa o girilir
        {
            case 1 when (5==5):  // when ile şart ekleriz 1 e eşitliğin yanında
                Console.WriteLine("Adim bu");
                break;

            case 2:
                Console.WriteLine("Ad bu degil");
                break;

            case 3:
                goto case 2;
            default:
                Console.WriteLine("Bisey Yaz");
                break;
        }
    

    int i=10;
    string isim = i switch  // değer atamalı kullanımı bu şekildedir kısaltma durumudur
    {
        5 => "hilmi",
        10 => "ayse"
    };

    object obj = 42;

    switch (obj)   // int n e dönüştürme tamamlanırsa yani eşitlik tamamsa yapar kopyalar değerini ona 
    {
        case int n when n > 40:
            Console.WriteLine($"The number {n} is greater than 40");
            break;
        case string s:
            Console.WriteLine($"The string is: {s}");
            break;
        default:
            Console.WriteLine("The type is unknown");
            break;
    }

    }
}