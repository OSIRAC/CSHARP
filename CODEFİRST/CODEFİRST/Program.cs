// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CODEFİRST
{
    class Program
    {  
        static void Main(string[] args)
        {
            ECommerceDbContext context = new();
            context.Database.Migrate();  // DATABASE PROPERTYSİ DATABASE İLE İLGİLİ ÇEŞİTLİ İŞLEMLER YAPMAMAIZI SAĞLAR CONNECTİON AÇMA KAPAMA VB.
             // MİGRATE() METHODU YENİ BİR MİGRATİON OLUŞTURMAZ SADECE OLUŞAN MİGRATİONLARI TEKER TEKER UYGULAR
            IQueryable<Customer> query = context.Customers;  //  SQL SORGULARINI HAZIRLAMAK İÇİN BİR YAPIDIR IQUERABLE I İMPLEMENTE ETTİĞİ İÇİN SORGU OLUŞTURABİLİR DEMEK YANİ BİR ARA BASMAKTIR TABLOYU TEMSİL EDER VE ÖN PLANA ÇIKAN ÖZELLİĞİ İMPLEMENTASYONLARLA O TEMSİL ÜZERİNDE SORGULAMALAR YAPMAKTIR
            string sqlquery = query.ToQueryString();
            Console.WriteLine(sqlquery);
            
            IQueryable<Customer> query1 = context.Customers.Where(c => c.Id ==1);  // WHERE BİR EXPRESSİON ALIR COMPİLER LAMBDAYI OTOTMATİK ÇEVİRİR
              // FUNC<CUSTOMER,BOOL> TÜRÜNDE TANIMLADIK BURDA C BİR CUSTOMER NESNESİDİR
            string sqlquery1 = query.ToQueryString();
            Console.WriteLine(sqlquery1);
            Customer customer = new()
            {
                FirstName = "Omer",   // ID SPECİFİCATİON AKTİF HALE GELİR VE O OTOMATİK ARTAR 
                LastName = "Islamoglu"
            };
            context.Customers.Add(customer); // VERİ TÜRÜ BELLİ OLRAK YOLLARAIZ BURDA
            //  context.add(customer) YAPARSAK OBJECT OLRAK ALIR TİP GÜVENKİ DEĞİL
            Console.WriteLine(context.Entry(customer).State); // CUSTOMERIN STATE İ ORTAYA ÇIKAR BU STATE E GÖRE SAVE CHANGES SQL OLUSTURUR
            context.SaveChanges(); // INSERT UPDATE DELETE İŞLEMLERİ İÇİN SQL SORGDUSU OLUŞTURUP GÖNDERİR BU METHOD
            // SAVECHANGES BİRDEN FAZLA VERİ EKLERKEN BİR KEZ KULLANMAYA DİKKAT ET
            Customer customer1 = new()
            {
                FirstName = "EMİR",
                LastName = "ISLAMOGLU"
            };
            context.Customers.AddRange(customer, customer1); // BİRDEN FAZLA VERİ EKLERKEN BÖYLE DE YAPABİLİRZ TEKER TEKER ADD DE DİYEBİLRİZ
            Console.WriteLine(customer.Id);  // SAVECHANGES DAN SONRA ÇAĞRILIR ÇÜNKÜ VERİ TABANINA SORGU GİTMİŞ OTOİNCREMENT İLE İD ATANMIŞ VE ARTMIŞTIR ÖNCE ÇAĞRILSA 0 OLUR EF CORE VERİ TABANINDAKİ İD Yİ ALIR VE BURAYA ATAR
        }
    }
public class ECommerceDbContext : DbContext
    {
        // DATABASEFİRST VEYA CODEFİRST DE BİZ TABLOLAR VERİ TABANI TEMSİL EDERİZ OLUŞTURDUKLARIMIZI YANSITIR EF CORE SONRA TEMSİL EDİCENKİ YANSISIN
        public DbSet<Product> Products { get; set; }  // DBSET<ENTİTİY> EF CORE UN ÖZEL BİR SINIFIDIR
         // PRODUCTS TABLOMUZUN ADIDIR DEĞİŞTİRİLEBİLİR ÇEŞİTLİ METHODLARLA AMA
        public DbSet<Customer> Customers { get; set; } // CUSTOMER BURDA BİLDİĞİMİZ ANLAMDA BİR NESNEYE REFERANS VERMEZ SADECE ARA BİR BASAMAKTIR MESELA ÇEŞİTLİ ŞEYLER İMPLEMENTE EDEREK TABLOYA KARŞI SORGULAR OLUŞTURMAMIZI SAĞLAR

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  // SQL CONNECTİONIMIZI VERDİK BURDA
        {
            optionsBuilder.UseSqlServer  ("Server=localhost\\SQLEXPRESS;Database=ECommerceDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }  // DATABASE İN ADI BURDA BELİRLENİR MİGRATİONDA TABLO ADIDIR KOLONLARIN PRİMARY Mİ FALAN ÖZELLİĞİ BELİRLENİR
    }      // ONCONFİGURİNG OTOMATİK CONTEXT NENSESİ OLUŞTURULUNCA TETİKLENİR
    public class Product
    {
        public int Id { get; set; }  // KOLONLARIMIZ VERİ TABANINDAKİ BUNLAR 
        // Id ID ProductId ProductID DEFAULT CONVENTİONDUR OTOTMATİK PRİMARY KEY OLUR ZORUNLUDUR TANIMLAMAK EF CORE İÇİN
        public string? Name { get; set; }  // BU SINIFIN NESNELERİ VERİLERİMİZDİR BİZİM

        public int Quantity { get; set; }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}