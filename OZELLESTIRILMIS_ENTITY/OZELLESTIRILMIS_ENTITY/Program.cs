using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("KISILER")]
class CALISAN
{
    public int Id { get; set; }

    [ForeignKey(nameof(DEPARTMAN))]
    public int DEPARTMANId { get; set; }

    [MaxLength(100)]
    [Required]  // BU PROPU NOT NULL YAPAR
    public string? Name { get; set; }
    [NotMapped]
    public int LAYLAYLOM { get; set; }

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
        modelBuilder.Entity<CALISAN>().ToTable("KISILER");   // TABLONUN ADINI BOYLEDE DEĞİSTİREBİLRİZ AMA BURANIN BORUSU ÖTER DATA ANNOTAYTIONA GÖRE    }

        modelBuilder.Entity<CALISAN>().Ignore(x => x.LAYLAYLOM); // BOYLEDE GORMEZDEN GELEBİLİRİZ

        modelBuilder.Entity<CALISAN>()
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasDefaultValue(50); // DEFAULT VALUE YU SADECE FLUENT API DE YAPABİLİRİZ      
    }
}

