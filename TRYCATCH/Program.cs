using System;

namespace First;

class Program
{
    static void Main(string[] args)
    {

        try
        {
            int s1 = 10;
            int s2 = 0;
            int a = s1/s2;

            int.Parse("selam");
        }
        catch (DivideByZeroException Ex) when (3==3)// Catchlerden biir tetiklenir
        {
            Console.WriteLine(Ex.Message);
        }
        catch(FormatException ex2)
        {
            Console.WriteLine(ex2.Message);
        }
        catch(Exception ex3)   // Exception sınıfı ile hatayı tutarız Gözden kaçanlar olcağı için en alta atarız çünkü en üst sınıf
        {
            Console.WriteLine(ex3.Message);
        }
        finally
        {
            Console.WriteLine("Hertürlü çalisir");  // her türlü çalışır bu kod
        }

    }
}