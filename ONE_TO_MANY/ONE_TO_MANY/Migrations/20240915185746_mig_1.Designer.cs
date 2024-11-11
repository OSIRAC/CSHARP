﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ONE_TO_ONE;

#nullable disable

namespace ONE_TO_MANY.Migrations
{
    [DbContext(typeof(WORLDDBCONTEXT))]
    [Migration("20240915185746_mig_1")]
    partial class mig_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ONE_TO_ONE.CALISAN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DEPARTMANId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DEPARTMANId");

                    b.ToTable("CALISANLAR");
                });

            modelBuilder.Entity("ONE_TO_ONE.DEPARTMAN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DEPARTMANLAR");
                });

            modelBuilder.Entity("ONE_TO_ONE.CALISAN", b =>
                {
                    b.HasOne("ONE_TO_ONE.DEPARTMAN", "DEPARTMAN")
                        .WithMany("CALISANLAR")
                        .HasForeignKey("DEPARTMANId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DEPARTMAN");
                });

            modelBuilder.Entity("ONE_TO_ONE.DEPARTMAN", b =>
                {
                    b.Navigation("CALISANLAR");
                });
#pragma warning restore 612, 618
        }
    }
}