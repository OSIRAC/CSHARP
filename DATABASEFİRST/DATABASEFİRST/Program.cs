using Microsoft.EntityFrameworkCore;
using System;

namespace DATABASEFİRST
{

    class Program
    {
        static void Main(string[] args)
        {
            /*
            Scaffold - DbContext 'Server=localhost\SQLEXPRESS;Database=AtYarısıVeriTabani;Trusted_Connection=True;TrustServerCertificate=True;' Microsoft.EntityFrameworkCore.SqlServer
            */

            // Scaffold-DbContext 'Connection String' SQL PROVİDER  komut budur DATABASEFİRST YAKLAŞIMDINDA

            // SCAFFOLD İNŞAA ETMEK DEMEK VERİ TABANINI İNŞAA ET Scaffold - DbContext DBCONTEXT SINIFI İNŞAA ET DEMEK ŞU CONNECTION STRİNGİNE UYGUN ŞEKİLDE PEKİ HANGİ VERİ TABANININ CONNECTİON STRİNGİ BU SQL PROVİDER İLE DE ONU ANLAR DBCONTEXT OLUŞUR VE MEMEBERLARA ÖZGÜ SINIFLARDA AMA İLK TETİKLEME DBCONTEXT OLUŞMAYLA OLUR

            // SQL PROVİDER : SQL AÇMA KAPAMA İŞLEMLERİ SQL SORGUSUNA ÇEVİRME İŞLEMLERİ GİBİ ŞEYLERİ SAĞLAR
            // EF CORE TOOL : ÇEŞİTLİ MİGRATİON KOMUTLARINI İÇEREN ARAÇTIR TEMELDE
            // EF CORE DESİGN : MİGRATİON YAPILIRKEN ARKA PLANDAKİ BİLEŞENLERİ SAĞLAR EN TEMELDE
        }
    }
}
