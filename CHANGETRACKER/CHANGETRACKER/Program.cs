using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;


namespace CHANGETRACKER
{
    class Program
    {
        static void Main(string[] args) 
        {
            CHANGETRACKER context = new CHANGETRACKER();
            var home = context.homes.ToList();  // TRACK ETTİRİYORUZ BURADA
            var entries = context.ChangeTracker.Entries().ToList();// ENTRY NİN ÇOĞUL HALİDİR
            // FOREACH FONKSİYONU LİST LERDE BULUNAN BİR MEHODDUR E BURDA BU LİSTEDEKİ HER BİR ÖGEYİ TEMSİL EDER
            entries.ForEach(e =>
            {
                if(e.State == EntityState.Unchanged)
                {
                    // ddjdjdjdj
                }
                else if(e.State == EntityState.Added)
                {
                    // fhhfhfhf
                }
            });                                       
            // BU METHOD TÜM TAKİ EDİLEN ENTİTY NESNELERİNİN DURUMLARINI VE BİLGİLERİNİ GERİYE DÖNER
            // ENTRİES METHODUNDADA DETECTCHANGE TETİKELNİR EN GÜNCEL HALİNİ GETİRMEK İÇİN
            //var home1 = context.homes.FirstOrDefault(s => s.Id == 1);
            //home1.price = 350;
            //home1.colour = "purple";
            context.ChangeTracker.DetectChanges(); // DETECTCHANGE METHODU TEKRAR GÖZDEN GEÇİRMEYİ SAĞLAR CHANGETRACKER ANBEAN BİLGİLENDİRİLİR AAM BU METHOD HADİ TEKRAR GÖZ AT DEMEK
            context.SaveChanges(false); // OTOMATİK DETECTCHANGE İ ÇAĞIRIR EMİN OLMAK İÇİN
            // FALSE PARAMETRESİ DAHA SONRA CHANGETRACKER IN O NENSELERİ TAKİPTEN BIRAKMAYACAĞINI SÖYLEMİŞ OLURUZ
            context.ChangeTracker.AcceptAllChanges();// BURADA ELLE TAKİPİ BIRAKTIRDIK

            // DETACHED CHANGETRACKER IN TAKİP ETMEDİĞİ ANLAMINA GELİR
            // UNCHANGED VERİ TABANINDAN SORGULANDIĞINDA ÜZERİRNDE HERHANGİ BİR DEĞİŞİKLİK YAPAMDIĞIMIZI SÖYLER

            var home2 = context.homes.AsNoTracking().ToList();
            foreach (var item in home2)  // ŞİMDİ BURDA AMAÇ EKRANA BASMAK OLDUĞUNDNA CHANGETRACKERLA TAKİBE GEREK YOK TUR SORGU OLUŞTURULMADAN ÖNCE ASNOTRACKİNG METHODUNU ÇAĞIRIYORUZ SAVECHANGE YAPSAK ETKİ ETMEZ ÇÜNKÜ TRACK EDİLENLER YOLLANIR
            {
                Console.WriteLine(item.colour);
            }
            // context.homes.AsNoTrackingWithIdentityResolution BU METHOD DAHA ÇOK İLİŞKİSEL TABLOLARDA KULLANILIR ATIYORUM BİR KİŞİN BİRDEN FAZLA ROLÜ OLSUN DİYELİM ASNOTRACKİNG YAPARSAK BİRDEN FAZLA NESNE OLUŞTURUP ATAR AMA BU METHOD HEM ASNO YAPAR HEMDE CHANGETRACKERIN YAPTIĞI GİBİ NESNELERİ YİNELEMEZ
        }
    }

    class CHANGETRACKER : DbContext
    {
        public DbSet<Home> homes {  get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CHANGETRACKER;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
    class Home
    {
        public int Id { get; set; }
        public  string? colour { get; set; }
        public int price { get; set; }
    }
}
