using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace ONE_TO_ONE
{

    class Program
    {
        static void Main(string[] args)
        {
            WORLDDBCONTEXT context = new WORLDDBCONTEXT();
            /*
            COUNTRY country = new COUNTRY();
            country.Name = "GERMANY";   // AMERİCA YA KARŞILIK WHASHINGTONU EŞLEŞTŞRYOR 1 DEĞERİNİ ATIYOR
            
            country.CAPİTAL = new CAPİTAL()
            {
                Name = "WASHINGTON"
            };          
            context.COUNTRIES.Add(country);
            context.SaveChanges();
            */
            
            COUNTRY? country1 = context.COUNTRIES.FirstOrDefault(c => c.Id == 3);  
            /*
            COUNTRY   // VERİLER BU ŞEKİL GELİR CAPİTLDAKİ ATANMADIYSA
            {
                Id = 2,
                Name = "Turkey",
                 CAPİTAL = null
            };
            */
            country1.CAPİTAL = new CAPİTAL()
            {
                COUNTRYId = country1.Id,  // BURADA 3 ID DİYEREK YUKARIDAKİ 3 Ü KASTEDİYORUZ GİRİLEN
                Name = "İSTANBUL"                          
            };         
            context.CAPİTALS.Add(country1.CAPİTAL);
            context.SaveChanges();
        }
    }

    class COUNTRY
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public CAPİTAL CAPİTAL { get; set; }
    }
    class CAPİTAL
    {
        // DATA ANNOTATİONDA FOREİGN KEY PROP GEREKMEZ ÇÜNKÜ ARTIK BAĞIMSIZ TÜR NE ANLAŞILIR
        [Key,ForeignKey(nameof(COUNTRY))]  // NAMEOF İÇİNE DEĞİŞKEN ALIR STRİNG OLRAK DÖNDÜRÜR BURDA NAVİGATİON PROPU YANİ EF CORE BAKAR BU FOREİGN KEY COUNTRY TÜRÜNDE O SINIFA REFERANS EDER YANİ BİR ŞEY DOLDURDUĞUMUZDA TABLOYA ÖTEKİNDEN DEĞERE BAKAR DEMEK
        public int COUNTRYId { get; set; }  // BAGIMLI TABLO KENDİ BASINA ANLAMI OLMAYAN TABLODUR BAŞKENT KENDİ BAŞINA ANLAMI YOK ŞEHİR VARSA BAŞKENT OLUR

        public string? Name { get; set; }

        // public int COUNTRYId { get; set; }  // CONVENTİON DA EFCORE HANGİ TARAF BAĞIMLI TARAF ANLAYAMAZ O YÜZDEN YENİ BİR PROP EKLERİZ FOREİGN KEY NAVİGATİON PROP + Id FORMULU VARDIR

        public COUNTRY COUNTRY { get; set; }  // NAVİGATİON PROP        
    }
    class WORLDDBCONTEXT : DbContext
    {
        public DbSet<COUNTRY> COUNTRIES { get; set; }

        public DbSet<CAPİTAL> CAPİTALS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = ONETOONE; Trusted_Connection = True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<COUNTRY>()
                .HasKey(c => c.Id);
            // FLUENT API METHODU BUDA
            modelBuilder.Entity<COUNTRY>()  // EF CORE NAVİGATİON PROPLARLA İLİŞKİLERİ ÇÖZEBİLİR PRMİARY YA D AFOREİGN KEY TANIMLAMASI VERİ TABANI DÜZEYİNDE BELLİ EDER BU YÜZDEN NAVİGATİON PROP KULLANILIR
                .HasOne(c => c.CAPİTAL) // COUNTRY CAPİTALE SAHİPMİŞ
                .WithOne(c => c.COUNTRY) // NAVİGATİON PROP ÜZERİNDNE BURAYA ATLAR CAPİTALDE COUNTRYE SAHİPMİŞ
                .HasForeignKey<CAPİTAL>(c => c.COUNTRYId);  // FOREİGN KEY TANIMLADIK AMA PRİMARY KEY ÖZELLİĞİ EZİLDİ EZİLMEMESİ İÇİN KEY OLARAK ONU DA TANIMLIYORUZ
        }
    }

}
