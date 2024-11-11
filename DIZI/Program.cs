using System;

namespace First;

class Program
{
    static void Main(string[] args)
    {
        int [] yaslar = new int[3];  // 1. tanımlama yolu 

        Array yaslar4 = new int[3]; // zaten Array sınıfndan türeme tüm diziler // Burada Indexer kullanılmaz!!
        yaslar4.SetValue(30,0); // bu şekilde tanımlanır [] bununla değil
        object value = yaslar4.GetValue(0);

        int [] yaslar1 = {30,1,45,24};  // bu şekilde olur int yaslar1[3]; BU OLMAZ !!

        int [] yaslar2 = new int[] {1,45,89,42};

        var yaslar3 = new int[] {1,46,89,42};
        
        char [] harf = new char[3] {'a','e','4'}; // char dizisi oluşturduk böyle C deki strind değildir

        string [] kelime = {"esya","armut"}; // string dizisi oluşturduk böylecede

        string sayi = new string(harf); // string constructoru char diziis alır string yapar string alamz ama

        Console.WriteLine(sayi);
        Console.WriteLine(new string(harf)); // stringe dönüştürür adresini döner onu yazarız orayada
        
        int[] numbers = { 10, 20, 30, 40, 50 };

        // İlk üç elemanı almak için:
        int[] firstThree = numbers[0..3]; // geriye alt bir dizi döner new e gerek yoktur

        Index indis = ^3;  // bir structır ındex'i türleştirmişler ^sagdan direkt sayıyla ama 3 birim
        Console.WriteLine(numbers[indis]);                   

        int [,] sayilar = new int[3,4];   // 2 boyutlu dizi tanımlama
        sayilar[1,2] = 5;

        int [,] sayilar1 = {
            {3,5,7},
            {4,8,9},
            {1,2,0}
        };

        int [][] sayilar2 = new int  [3][]; // integer dizisi alan bir dizi bu Düzensiz diziler diye de geçer bu
        sayilar2[0] = new int[3] {1,2,3};
        sayilar2[1] = new int[3] {4,5,6};
        sayilar2[2] = new int[3] {7,8,9};

        Console.WriteLine(sayilar2[0][0]); 

    }
}
