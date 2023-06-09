﻿// <auto-generated />
using System;
using CajaTrujillo.Seguros.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CajaTrujillo.Seguros.Repository.Migrations
{
    [DbContext(typeof(CajaTrujilloDbContext))]
    [Migration("20230513041323_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CajaTrujillo.Seguros.Entity.Afiliacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("FechaAfiliacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaVigencia")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroPoliza")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SeguroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("SeguroId");

                    b.ToTable("Afiliaciones");
                });

            modelBuilder.Entity("CajaTrujillo.Seguros.Entity.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("CajaTrujillo.Seguros.Entity.Pago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AfiliacionId")
                        .HasColumnType("int");

                    b.Property<int>("Anio")
                        .HasColumnType("int");

                    b.Property<int>("Mes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AfiliacionId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("CajaTrujillo.Seguros.Entity.Seguro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cobertura")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Compania")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EdadMaxima")
                        .HasColumnType("int");

                    b.Property<decimal>("FactorImpuesto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ImporteMensual")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Moneda")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("MontoPrima")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PorcentajeComision")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TipoSeguro")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Seguros");
                });

            modelBuilder.Entity("CajaTrujillo.Seguros.Entity.Afiliacion", b =>
                {
                    b.HasOne("CajaTrujillo.Seguros.Entity.Cliente", "Cliente")
                        .WithMany("Afiliaciones")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CajaTrujillo.Seguros.Entity.Seguro", "Seguro")
                        .WithMany("Afiliaciones")
                        .HasForeignKey("SeguroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Seguro");
                });

            modelBuilder.Entity("CajaTrujillo.Seguros.Entity.Pago", b =>
                {
                    b.HasOne("CajaTrujillo.Seguros.Entity.Afiliacion", "Afiliacion")
                        .WithMany("Pagos")
                        .HasForeignKey("AfiliacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Afiliacion");
                });

            modelBuilder.Entity("CajaTrujillo.Seguros.Entity.Afiliacion", b =>
                {
                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("CajaTrujillo.Seguros.Entity.Cliente", b =>
                {
                    b.Navigation("Afiliaciones");
                });

            modelBuilder.Entity("CajaTrujillo.Seguros.Entity.Seguro", b =>
                {
                    b.Navigation("Afiliaciones");
                });
#pragma warning restore 612, 618
        }
    }
}
