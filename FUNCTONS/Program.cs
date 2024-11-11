using System;
using System.Collections;


namespace First;

class Program
{
    public static void x(int a,int b,string c)
    {

    }
    public static void y(in int a,int b,string c)
    {
        // a=23; gibi değer atanamaz artık readonly yapar yani dışarıdan gelen değeri değiştirmez in keywordu

    }

    public static ref int GetNumber(int index,int [] numbers)
    {
        return ref numbers[index]; // Referansı döndürür
    }

    static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        x(4,6,"yes");
        x(b:5,c:"ahmet",a:6);  //sırasını istedğimiz gibi böyle yazabilriz 

        // Fonksiyonları öncede çağırabilirsin o farketmez
        m(3);
        //topla() METHOD overloading için fonksiyon adları aynı olcak Farkı parametre sayııs veya parametre türüyle atarsın
        
        int a = 5;
        ModifyValue(ref a);  // a'nın referansı metoda geçirilir.
        Console.WriteLine(a);

        int value = GetNumber(2,numbers); // Bu, numbers[2] olan 3'ün bir kopyasını alır
        value = 42; // value değişir, fakat numbers[2] değişmez

        // Referans üzerinden doğrudan değişiklik yapıyoruz
        ref int refToNumber = ref GetNumber(2,numbers); // Bu, numbers[2]'nin referansını tutar
        refToNumber = 42; // Bu, numbers[2]'yi doğrudan değiştirir
        // return ref olsa bile compiler onu o adresin değerini kpyalar tekrar ref gerekir


    }

    public static int topla(int a,int b)
    {

        return a + b;
    }

    public static double topla(int a,double b)
    {

        return a + b;
    }


    public static int m(int a)
    {
        int b = 0;
        n(a,b); // böylelikle bu şekilde vermek zorund akalırsın

        static void n(int a,int b)  // static yaparsak locali dışarıdakilere erişemez fonksiyonun içindekilerine yani maliyet düşer
        {
            Console.WriteLine("merhaba");  // Local functiondur iç içe functondur erişim belirleyicisi kullanılmaz çünkü zaten sınıfın bir elemanı değil fonksiyonun ana fonksiyonla aynı isimde olması yanlıştır
        }
        return 0;
    }
    // ref keywordu değer tiplilerde referans gibi çalışmamızı sağlar

    static void  ModifyValue(ref int x)  // direktmen adres değerini değiştir 100 se 200 yap değişken gibi düşünme adres tutar falan diye biliyorum mantıksız ama böyle anladyabildim
    {    // normalde adresler değişkeen atanır ama burda paldür küldür değere değer atıyıruz
        x = 10;  // x, a'nın referansını tutar, bu yüzden a'nın değeri 10 olur.
    }



    

}
