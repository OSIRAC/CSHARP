using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;


namespace DATA_INSERT_UPDATE_DELETE
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUDOPERATION context = new CRUDOPERATION();

            Student student = new Student()
            {
                Name = "OMER",
                No = 130
            };           
            /*
            context.Students.Add(student);
            context.SaveChanges();
            */
            //Student student1 = context.Students.FirstOrDefault(s => s.Id == 1);  // SELECT İLE GELEN VERİLERİ CHANGETRACER TAKİP EDER
            /*
            student1.Name = "EMİR";
            student1.No = 110;
            context.SaveChanges();
            */
            Student student2 = new Student()  // CONTEXT TEN GELMEYEN YAN CHANGE TRACERIN TAKİP ETMEDİĞİ VERİLERİ GÜNCELLERKEN İD VERMEK ZORUNDAYIZ
            {
                Id = 1,
                Name = "BEKİR",
                No = 130
            };
            //context.Students.Update(student2);
            //context.SaveChanges();
            //Student student3 = context.Students.FirstOrDefault(s => s.Id == 1);
            //context.Students.Remove(student3);
            //context.SaveChanges();
            /*
            Student student4 = new Student()  // CHANGE TRACERLA TAKİP EDİLMİYORSA DİREKT İD ÜZERİNDNE SİLERİZ
            {
                Id = 2,
            };
            */
            //context.Students.Remove(student4);
            //context.SaveChanges();
            /*
            Student student5 = new Student()  // CHANGE TRACERLA TAKİP EDİLMİYORSA DİREKT İD ÜZERİNDNE SİLERİZ
            {
                Id = 3,
            };
            context.Entry(student5).State = EntityState.Deleted;  // DURMUNU DEĞİŞTİRDİK ÖYLE SİLDİK
            context.SaveChanges();
            */
            var student6 = from students in context.Students  // QUERY SYNTAX YAPISIDIR
                           where students.Id == 1  // students BURDA CONEXT.STUDENTS IN İÇİNDEKİ NESNELERİ TEMSİL EDER
                           select students;  // SELECT İLE HEPSİNİ ÇEKEMK İSTEDİĞİMİZİ SÖYLÜYORUZ
        }
    }

    class CRUDOPERATION : DbContext
    {
        public DbSet<Student> Students { get; set; } // STUDENTS BURDA TABLOLARI TEMSİL EDER DERKEN ONA SORGU OLUŞTURMA ONU İŞLEME ANLAMINDA TEMSİLDEN BAHSEDİYORUZ YANİ STUDENTS TABLOYU TEMSİL EDİYOR BU TEMSİL ÜZERİNDEN BAK SORGU YAZABİLİRİSN DEMEK YANİ STUDENTS BURDA BELİRLİ SORGU İŞLEMLERİ YAPMAMIZI SAĞLAYAN BELLİ TABLODA İÇİNDE STUDENT CLASSI OLAN REFERANSTIR
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = localhost\\SQLEXPRESS; Database = CRUDOPERATION; Trusted_Connection = True;TrustServerCertificate=True;");
        }
    }
    // DBSET<T> NİN AMAÇI İÇERİSİNDE VERİ TUTMAK DEĞİL GENERİC OLAN VERİ TABANI TABLOSUYLA ETKİLEŞİM KURMAK İÇİN ESNEKLİK SAĞLAMAK BİLGİ VERMEK GİBİ DÜŞÜNÜLEBİLİR GENERİC KISMI
    // TABLOYU TEMSİL ETMEK DERKEN ÖRNEK CONTEXT.STUDENTS YAPTIK STUDENTS TABLOYU TEMSİL EDİYOR YANİ ONU İSTİYORUZ YANİ BİR QUERY NESNESİ OLUŞTURULUYOR ARKA PLANDA 
    class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int No { get; set; }
    }
}





