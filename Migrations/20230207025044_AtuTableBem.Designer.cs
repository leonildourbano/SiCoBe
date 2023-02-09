﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoSisConBens.Data;

#nullable disable

namespace ProjetoSisConBens.Migrations
{
    [DbContext(typeof(ProjetoSisConBensContext))]
    [Migration("20230207025044_AtuTableBem")]
    partial class AtuTableBem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjetoSisConBens.Models.Bem", b =>
                {
                    b.Property<int>("BemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BemId"), 1L, 1);

                    b.Property<DateTime>("BemDataaquisicao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BemDatastatus")
                        .HasColumnType("datetime2");

                    b.Property<string>("BemDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BemImagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BemStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("BemValoraquisicao")
                        .HasColumnType("float");

                    b.Property<int>("InventarioId")
                        .HasColumnType("int");

                    b.Property<int>("UnidadeId")
                        .HasColumnType("int");

                    b.HasKey("BemId");

                    b.HasIndex("InventarioId");

                    b.HasIndex("UnidadeId");

                    b.ToTable("Bem");
                });

            modelBuilder.Entity("ProjetoSisConBens.Models.Cargo", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CargoId"), 1L, 1);

                    b.Property<string>("CargoDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CargoInstrucao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CargoId");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("ProjetoSisConBens.Models.Cidade", b =>
                {
                    b.Property<int>("CidadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CidadeId"), 1L, 1);

                    b.Property<string>("CidadeNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CidadeUf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.HasKey("CidadeId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("ProjetoSisConBens.Models.Colaborador", b =>
                {
                    b.Property<int>("ColaboradorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ColaboradorId"), 1L, 1);

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<string>("ColaboradorCpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColaboradorNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColaboradorRegistrofuncional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ColaboradorRg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnidadeId")
                        .HasColumnType("int");

                    b.HasKey("ColaboradorId");

                    b.HasIndex("CargoId");

                    b.HasIndex("UnidadeId");

                    b.ToTable("Colaborador");
                });

            modelBuilder.Entity("ProjetoSisConBens.Models.Inventario", b =>
                {
                    b.Property<int>("InventarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventarioId"), 1L, 1);

                    b.Property<DateTime>("InventarioDatainicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("InventarioDatatermino")
                        .HasColumnType("datetime2");

                    b.Property<string>("InventarioDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InventarioMemoria")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InventarioId");

                    b.ToTable("Inventario");
                });

            modelBuilder.Entity("ProjetoSisConBens.Models.Unidade", b =>
                {
                    b.Property<int>("UnidadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UnidadeId"), 1L, 1);

                    b.Property<int>("CidadeId")
                        .HasColumnType("int");

                    b.Property<string>("UnidadeAtividades")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnidadeBairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnidadeCep")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnidadeEndereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnidadeIdentificacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UnidadeId");

                    b.HasIndex("CidadeId");

                    b.ToTable("Unidade");
                });

            modelBuilder.Entity("ProjetoSisConBens.Models.Bem", b =>
                {
                    b.HasOne("ProjetoSisConBens.Models.Inventario", "Inventario")
                        .WithMany("Bem")
                        .HasForeignKey("InventarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoSisConBens.Models.Unidade", "Unidade")
                        .WithMany("Bem")
                        .HasForeignKey("UnidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventario");

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("ProjetoSisConBens.Models.Colaborador", b =>
                {
                    b.HasOne("ProjetoSisConBens.Models.Cargo", "Cargo")
                        .WithMany("Colaborador")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoSisConBens.Models.Unidade", "Unidade")
                        .WithMany("Colaborador")
                        .HasForeignKey("UnidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("ProjetoSisConBens.Models.Unidade", b =>
                {
                    b.HasOne("ProjetoSisConBens.Models.Cidade", "Cidade")
                        .WithMany("Unidade")
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("ProjetoSisConBens.Models.Cargo", b =>
                {
                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("ProjetoSisConBens.Models.Cidade", b =>
                {
                    b.Navigation("Unidade");
                });

            modelBuilder.Entity("ProjetoSisConBens.Models.Inventario", b =>
                {
                    b.Navigation("Bem");
                });

            modelBuilder.Entity("ProjetoSisConBens.Models.Unidade", b =>
                {
                    b.Navigation("Bem");

                    b.Navigation("Colaborador");
                });
#pragma warning restore 612, 618
        }
    }
}
