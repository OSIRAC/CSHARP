
using System;
using System.ComponentModel.Design;

namespace TEK_YONLU_LINKED_LIST
{
    class Program
    {
        static void Main(string[] args)
        {
            FONKSİYONLAR fonk = new FONKSİYONLAR();
            int sayi,indis;
            int secim = MENU();
            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        Console.Write("SAYI : ");
                        sayi = int.Parse(Console.ReadLine());
                        fonk.BASA_EKLE(sayi);
                        break;
                    case 2:
                        Console.Write("SAYI : ");
                        sayi = int.Parse(Console.ReadLine());
                        fonk.SONA_EKLE(sayi);
                        break;

                    case 3:
                        Console.Write("İNDİS : ");
                        indis = int.Parse(Console.ReadLine());
                        Console.Write("SAYI : ");
                        sayi = int.Parse(Console.ReadLine());
                        fonk.ARAYA_EKLE(indis,sayi);
                        break;

                    case 4:
                        Console.Write("İNDİS : ");
                        indis = int.Parse(Console.ReadLine());
                        fonk.ARADAN_SİL(indis);
                        break;
                    case 5:
                        fonk.BASTAN_SİL();
                        break;

                    case 6:
                        fonk.SONDAN_SİL();
                        break;
                    case 0:
                        break;

                    default:
                        Console.WriteLine("HATALI SEÇİM");
                        break;

                }

                Console.Clear();
                fonk.YAZDİR();
                secim = MENU();
            }
        }

            public static int MENU()
            {
                int secim;
                Console.WriteLine("\n1-BASA EKLE");
                Console.WriteLine("2-SONA EKLE");
                Console.WriteLine("3-ARAYA EKLE");
                Console.WriteLine("4-ARADAN SİL");
                Console.WriteLine("5-BASTAN SİL");
                Console.WriteLine("6-SONDAN SİL");
                Console.WriteLine("0-PROGRAMI KAPAT");
                Console.Write("SEÇİMİNİZ");
                secim = int.Parse(Console.ReadLine());
                return secim;
            }

        }
    }


