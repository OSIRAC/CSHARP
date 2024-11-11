using System;


namespace ALGORİTMACALISMASI1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5]; // 1.Yöntem
            int[] array2 = new int[] {1,2, 3}; // 2. Yöntem
            int[] array3 = {1,2,3}; // 3. Yöntem
            var array4 = new int[] {1,2,3};  // var array4 = { 1, 2, 3 };  BU OLMAZ ÇÜNKÜ ARRAYIN İÇİNE BAKAR AMA VAR BİLGİ VERMEZ KAFASI KARISIR
            Array array1 = new int[] { 1, 2, 3 }; //   Array array1 = { 1, 2, 3 }; BOLE DE OLMAZ BELLİ DEĞİL ÇÜNKÜ

            double ortalama;
            double arraytoplam = 0;

            Console.WriteLine("LUTFEN VIZE NOTLARINIZI GIRINIZ");

            for (int i = 0; i < array.Length ; i++)
            {
                Console.WriteLine($"{i + 1}. VIZE :");
                array[i] = int.Parse(Console.ReadLine());
                arraytoplam += array[i];
            }

            ortalama = arraytoplam / array.Length;
            Console.WriteLine($"NOT ORTALAMAN : {ortalama}");
            // AYRIYATEN KULLANICIDAN DA DİZİNİN BOYUTUNU ALABİLİRİSN C DEN FARKLI OLARAK

            // ARRAYLER ÜZERİNDE İŞLEM YAPMAK İÇİN ÇOĞU METHODLAR STATİCTANIMLANMIŞTIR ÇÜNKÜSTATİC OLMASA SIRALAMA METHODU STRİNFG ARRAYİ İÇİNDE ÇAĞRILABİLİRDİ BU SAÇMA OLURDU.STATİC METHODLAR KALITIMLA GEÇMEZ O YÜZDEN

            Array.Sort( array );
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("\t");
                Console.Write(array[i]);
            }

            int[,] sayi = new int[2,2]; // 2 boyutlu dizi tanımlama

            int[,] sayi1 =   // Böylede tanımlanabilri
            {
                {1,2,3},
                {5,6,8}
            };
            int satirsayisi = sayi1.GetLength(0); // 1.Boyutunu yani satırı döndürür.
            int sutunsayisi = sayi1.GetLength(1);
            Console.WriteLine($"Satır sayisi : {satirsayisi}");

            int [][] sayi2 = new int[3][]; // integer dizisi alan bir dizi bu Düzensiz diziler diye de geçer bu

            sayi2[0] = new int[3] { 1, 2, 3 };
            sayi2[1] = new int[3] { 4, 5, 6 };
            sayi2[2] = new int[3] { 7, 8, 9 };

        }
    }
}
