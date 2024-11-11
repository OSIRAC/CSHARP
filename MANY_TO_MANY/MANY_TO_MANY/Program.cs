using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONE_TO_ONE
{

    class Program
    {
        static void Main(string[] args)  // DEAFULT CONVENTİONDA OTOMATİK CROSS TABLE OLULUR SANA GEREK YOKTUR DİĞER YÖNTEMLERDE OLUŞTUEMK ZORUNDASINDIR
        {
            // COMPOSİT KEY TANIMLAMAK İSTİYORSAN FLUENT API YE GİTMEK ZORUNDASINDIR İKİ TANESİ AYNI ANDA PRİMARY KEY OLURSA COMPOSİT OLUR O 
            WORLDDBCONTEXT context = new WORLDDBCONTEXT();
            /*
            YAZAR yazar = new YAZAR();
            yazar.YazarAdi = "YASAR";  // BURADA YENİ BİR NESNE OLUŞTURUYORUZ KENDİ TABLOSU ÜSTÜNDE 
            yazar.KİTAPLAR.Add(new() { KİTAPId = 1 });  // BURADA AYNI NESNE ÜSÜTNDEN GELDİĞİNDEN BU FOREİGN KEYLE EŞLEŞTİRİYORUZ
            yazar.KİTAPLAR.Add(new() { KİTAP = new KİTAP() { KitapAdi = "B KİTAP" } }); // BURADA KİTAPLARA GEÇİP YENİ BİR KİTAP OLUŞTURUYORUZ 1 İD İLE YİNE BUNUDA EŞLEŞTİRİYORUZ AYNI NENSE ÜZERİNDEN
            context.Add(yazar);
            context.SaveChanges();

            YAZAR yazar1 = new YAZAR()
            {
                YazarAdi = "YASAR",
                KİTAPLAR = new HashSet<KİTAPYAZAR>()  // YUKARIDAKİYLE BU AYNIDIR BİRİ İÇERİDEKİNİ KULLANIR ÖBÜRÜ BİR DAHA YARATIR
                {
                    new(){KİTAPId = 1},
                    new(){KİTAP = new(){KitapAdi = "KONAK"}}
                }
            };
            */
            /*
            YAZAR yazar = new YAZAR()
            {
                YazarAdi = "KEMAL"
            };
            context.YAZARLAR.Add(yazar);
            context.SaveChanges();
            */
            YAZAR? yazar = new YAZAR();
            yazar  = context.YAZARLAR.FirstOrDefault(c => c.Id == 2);
            yazar.KİTAPLAR.Add(new() { KİTAPId = 2 , YAZARId = yazar.Id}); // YAZAR.ID GEREK YOKTUR ÇÜNKÜ YAZAR ÜSTÜNDNE GELİNDİĞİNDEN DOLAYI OTOMATİK ATANIR NAVİGATİON ÜZERİNDEN SIÇTAYIP DOLDURURUZ
            context.AddRange(yazar.KİTAPLAR);
            context.SaveChanges();
        }
    }

    class KİTAP
    {
        public KİTAP()
        {
            YAZARLAR = new HashSet<KİTAPYAZAR>();
        }
        public int Id { get; set; }     

        public string? KitapAdi { get; set; }

        public ICollection<KİTAPYAZAR> YAZARLAR { get; set; }
    }

    class KİTAPYAZAR
    {
        [ForeignKey(nameof(KİTAP))]
        public int KİTAPId {  get; set; }

        [ForeignKey(nameof(YAZAR))]
        public int YAZARId { get; set; }

        public KİTAP KİTAP { get; set; }

        public YAZAR YAZAR { get; set; }

    }

    class YAZAR
    {
        public YAZAR()
        {
            KİTAPLAR = new HashSet<KİTAPYAZAR>();
        }

        public int Id { get; set; }

        public string? YazarAdi { get; set; }

        public ICollection<KİTAPYAZAR> KİTAPLAR { get; set; }
    }
    class WORLDDBCONTEXT : DbContext
    {
        public DbSet<KİTAP> KİTAPLAR { get; set; }  // CROSS TABLE DBSET OLRAK TANIMLAMANA GEREK YOKTUR

        public DbSet<YAZAR> YAZARLAR { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = MANYTOMANY; Trusted_Connection = True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  // MIGRATION OLUŞTURULMADAN HEMEN ÖNCE ARAYA GİRER VE UYGULATIR
        {
            modelBuilder.Entity<KİTAPYAZAR>()
                .HasKey(ky => new { ky.KİTAPId, ky.YAZARId }); // COMPOSİT KEY TANIMLİCAKSAK ANONİM SINIF OLRAK BÖYLE BELİRTİRİZ

            modelBuilder.Entity<KİTAPYAZAR>() // FLUENT API İLE FOREIGN KEY ATANCAKSA İLİŞKİLERDE BELİRTİLMELİDİR
                .HasOne(ky => ky.KİTAP)
                .WithMany(k => k.YAZARLAR)
                .HasForeignKey(k => k.KİTAPId);

            modelBuilder.Entity<KİTAPYAZAR>()
                .HasOne(ky => ky.YAZAR)
                .WithMany(k => k.KİTAPLAR)
                .HasForeignKey(k => k.YAZARId);
        }
    }
}
    