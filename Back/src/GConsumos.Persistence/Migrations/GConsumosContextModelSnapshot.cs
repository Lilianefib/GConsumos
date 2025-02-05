﻿// <auto-generated />
using System;
using GConsumos.Persistence.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GConsumos.Persistence.Migrations
{
    [DbContext(typeof(GConsumosContext))]
    partial class GConsumosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("GConsumos.Domain.Consumo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Competencia")
                        .HasColumnType("TEXT");

                    b.Property<int>("MedidorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalConsumo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MedidorId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Consumos");
                });

            modelBuilder.Entity("GConsumos.Domain.Medicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataMedicao")
                        .HasColumnType("TEXT");

                    b.Property<int>("MedidorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("leitura")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Medicoes");
                });

            modelBuilder.Entity("GConsumos.Domain.Medidor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Localizacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Unidade")
                        .HasColumnType("TEXT");

                    b.Property<string>("numeroMedidor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Medidores");
                });

            modelBuilder.Entity("GConsumos.Domain.Morador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Endereco")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Unidade")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Moradores");
                });

            modelBuilder.Entity("GConsumos.Domain.MoradorMedidor", b =>
                {
                    b.Property<int>("MoradorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MedidorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MoradorId", "MedidorId");

                    b.HasIndex("MedidorId");

                    b.ToTable("MoradoresMedidores");
                });

            modelBuilder.Entity("GConsumos.Domain.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("TEXT");

                    b.Property<string>("Unidade")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("GConsumos.Domain.Consumo", b =>
                {
                    b.HasOne("GConsumos.Domain.Medidor", "Medidor")
                        .WithMany()
                        .HasForeignKey("MedidorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GConsumos.Domain.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medidor");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("GConsumos.Domain.MoradorMedidor", b =>
                {
                    b.HasOne("GConsumos.Domain.Medidor", "Medidor")
                        .WithMany()
                        .HasForeignKey("MedidorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GConsumos.Domain.Morador", "Morador")
                        .WithMany("MoradorMedidor")
                        .HasForeignKey("MoradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medidor");

                    b.Navigation("Morador");
                });

            modelBuilder.Entity("GConsumos.Domain.Morador", b =>
                {
                    b.Navigation("MoradorMedidor");
                });
#pragma warning restore 612, 618
        }
    }
}
