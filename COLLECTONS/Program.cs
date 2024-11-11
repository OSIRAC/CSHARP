using System;
using System.Collections;


namespace First;

class Program
{
    static void Main(string[] args)
    {
        int toplam = 0;
        // Arraylistler arraylerin hatalarını kapatmak için ortaya çıkmıştır ilk koleksiyondur diğer koleksiyonlar bunun hatalarını örtmek için evrimleşmiştir
        ArrayList _yaslar = new ArrayList();
        _yaslar.Add(35);
        Console.WriteLine(_yaslar[0]);

        toplam += (int)_yaslar[0];  // Arraylist object olarak veri alır bu yüzden unboxing yapmalıyız 
        // Genericler bunu çözmek için geliştirilmiştir 

    }



}
