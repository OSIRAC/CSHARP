using System;

namespace First;

class Program
{
    static void Main(string[] args)
    {
        // keywordler programlamanın atomik parçaısıdr önceden tanımlıdır sonradan ortaya çıkmaz using,class,void vb.
        // operatörler bir işlemi yapan keywordlardir, keywordler işlem yapmak zorunda değildir daha geniştir anlamı
        while (true)
        {
            // konsepli keyworddür 
        }
        int x = 5; // konseplidir yine belli bir konsept var
        break; // konseptsizdir pat diye kullanılır.   bulunduğu yeri sonlandırır.
        continue; // Döngülerde kullanılır altında kalanları atlattırır;
        for (int i = 0; i < 10; i++)
        {
            if (i % 2 != 0)
            {
                continue;  //sadece çiftleri yazar
            }
            Console.WriteLine("merhaba")
            // return fonksiyonu sonlandırır direkt yani Maindeyse kod main sonlanır break döngüyü sonlandırır.

            int i = 1;
            x : 
            Console.WriteLine("merhaba");
            if(i <= 100)
                goto x;   // goto böyle kullanılır x: li duruma yönlendirir
        }
    } 


}
