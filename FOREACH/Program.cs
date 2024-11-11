using System;
using System.Collections;


namespace First;

class Program
{
    static void Main(string[] args)
    {
        // Döngüler belli bir kombinasyon ile çalışan belli bir şartı karşılayan yapılardır
        // iterasyon ama sonrakini elde etme mantığı vardır veri kümelerinde çalışırsın

        ArrayList list = new ArrayList(){123,34,25,67,49};

        foreach (object item in list)  // ne kabul ediyorsa onunla karşılanmalııdr
        {
            Console.WriteLine(item);
        }
    }
}

