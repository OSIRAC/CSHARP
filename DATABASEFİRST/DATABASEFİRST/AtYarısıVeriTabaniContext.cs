using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DATABASEFİRST;

public partial class AtYarısıVeriTabaniContext : DbContext
{
    public AtYarısıVeriTabaniContext()
    {
    }

    public AtYarısıVeriTabaniContext(DbContextOptions<AtYarısıVeriTabaniContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAtOyunTablosu> TblAtOyunTablosus { get; set; }

    public virtual DbSet<TblAtYarısı> TblAtYarısıs { get; set; }

    public virtual DbSet<TblOyuncular> TblOyunculars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=AtYarısıVeriTabani;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAtOyunTablosu>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_AtOyunTablosu");

            entity.Property(e => e.OyuncuAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<TblAtYarısı>(entity =>
        {
            entity.HasKey(e => e.KullaniciAd);

            entity.ToTable("Tbl_AtYarısı");

            entity.Property(e => e.KullaniciAd)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sifre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblOyuncular>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tbl_Oyuncular");

            entity.Property(e => e.ArkadasAdi).HasMaxLength(50);
            entity.Property(e => e.KullaniciAd).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
