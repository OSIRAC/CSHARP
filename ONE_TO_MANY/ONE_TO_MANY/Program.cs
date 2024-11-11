using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONE_TO_ONE
{

    class Program
    {
        static void Main(string[] args)
        {
            WORLDDBCONTEXT context = new WORLDDBCONTEXT();
            /*
            DEPARTMAN departman = new DEPARTMAN() { Name = "BİLGİSAYAR" };
            departman.CALISANLAR.Add(new CALISAN { Name = "ÖMER" });  // BURADA BİLGİSAYAR EKLEDİK DİĞERLERİNİNDE BİLGİSAYAR OLARAK EŞLEŞTİRDİK
            departman.CALISANLAR.Add(new CALISAN { Name = "EMİR" });
            departman.CALISANLAR.Add(new CALISAN { Name = "MUSTAFA" });

            context.DEPARTMANLAR.Add(departman);
            context.SaveChanges();
            */
            /*
            DEPARTMAN? departman = new DEPARTMAN();
            departman = context.DEPARTMANLAR.FirstOrDefault(c => c.Id == 3);

            departman.CALISANLAR.Add(new() { DEPARTMANId = departman.Id, Name = "KESKİN" });
            /*
            {
                DEPARTMANId = 3,  // VERİLERİ BÖYLE EKLERİZ BÖYLECE KADİR KİŞİSİDE 3 ID Lİ DEPARTMAN ATANMIŞ OLDU
                // YENİ DEPENDENT ENTTİYLER EKLEMİŞ OLDUK BÖYLECE VERİLER VARSA BÖYLE EKLENİR YENİLER
                Name = "KADİR"
            };
            */
            /*
            context.AddRange(departman.CALISANLAR);
            context.SaveChanges();
            */
            /*
            DEPARTMAN departman = new DEPARTMAN()
            {
                Name = "KONTROL OTOTMASYON"
            };
            context.DEPARTMANLAR.Add(departman);
            context.SaveChanges(); 
             */
            DEPARTMAN departman =new DEPARTMAN();

            departman = context.DEPARTMANLAR.FirstOrDefault(c => c.Id == 4);
            departman.CALISANLAR.Add(new() { DEPARTMANId = departman.Id ,Name ="FIRTINA"});
            departman.CALISANLAR.Add(new() { DEPARTMANId = departman.Id, Name = "KASIRGA" });
            context.AddRange(departman.CALISANLAR);
            context.SaveChanges();
        }
    }

    class CALISAN
    {
        public int Id { get; set; }

        [ForeignKey(nameof(DEPARTMAN))]
        public int DEPARTMANId { get; set; }

        public string? Name { get; set; }

        public DEPARTMAN DEPARTMAN { get; set; }
    }
    class DEPARTMAN
    {
        public DEPARTMAN()
        {
            CALISANLAR = new HashSet<CALISAN>();
        }

        public int Id { get; set; }

        public string? Name { get; set; }

        public ICollection<CALISAN> CALISANLAR { get; set; }  // ICOLLECTİON COLECTİONLARA ÇEŞİTLİ ADD REMOVE METHODLARI KAZANDIRIR
    }
    class WORLDDBCONTEXT : DbContext
    {
        public DbSet<CALISAN> CALISANLAR { get; set; }

        public DbSet<DEPARTMAN> DEPARTMANLAR { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = ONETOMANY; Trusted_Connection = True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CALISAN>()
                .HasOne(a => a.DEPARTMAN)
                .WithMany(d => d.CALISANLAR)
                .HasForeignKey(a => a.DEPARTMANId);  // FOREİGN KEY OTOMATİK OLUŞTURULUR TANIMLAMANA GEREK YOKTUR AMA TANIMLAYABİLİRSİNDE
        }
    }

}
