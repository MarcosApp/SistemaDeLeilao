﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaDeLeilao.Data;

namespace SistemaDeLeilao.Migrations
{
    [DbContext(typeof(BancoContent))]
    partial class BancoContentModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmbarcadoresModelTransportadorModel", b =>
                {
                    b.Property<int>("EmbarcadoresId")
                        .HasColumnType("int");

                    b.Property<int>("TransportadorId")
                        .HasColumnType("int");

                    b.HasKey("EmbarcadoresId", "TransportadorId");

                    b.HasIndex("TransportadorId");

                    b.ToTable("EmbarcadoresModelTransportadorModel");
                });

            modelBuilder.Entity("SistemaDeLeilao.Models.EmbarcadoresModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Embarcadores");
                });

            modelBuilder.Entity("SistemaDeLeilao.Models.FuncionarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmbarcadoresId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmbarcadoresId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("SistemaDeLeilao.Models.LanceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OfertaId")
                        .HasColumnType("int");

                    b.Property<double?>("Preco")
                        .HasColumnType("float");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TransportadorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfertaId");

                    b.HasIndex("TransportadorId");

                    b.ToTable("Lance");
                });

            modelBuilder.Entity("SistemaDeLeilao.Models.OfertaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmbarcadoresId")
                        .HasColumnType("int");

                    b.Property<string>("EnderecoColeta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnderecoEntrega")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<string>("NomeOferta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmbarcadoresId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Oferta");
                });

            modelBuilder.Entity("SistemaDeLeilao.Models.TransportadorModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Local")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Transportadores");
                });

            modelBuilder.Entity("SistemaDeLeilao.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataCadastro = new DateTime(2022, 7, 24, 22, 47, 50, 946, DateTimeKind.Local).AddTicks(4866),
                            Email = "admin@yahoo.com",
                            Login = "admin",
                            Perfil = 1,
                            Senha = "97fcc7c4f1df18696b23ef9a44efc36482e9e51a"
                        });
                });

            modelBuilder.Entity("EmbarcadoresModelTransportadorModel", b =>
                {
                    b.HasOne("SistemaDeLeilao.Models.EmbarcadoresModel", null)
                        .WithMany()
                        .HasForeignKey("EmbarcadoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaDeLeilao.Models.TransportadorModel", null)
                        .WithMany()
                        .HasForeignKey("TransportadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SistemaDeLeilao.Models.EmbarcadoresModel", b =>
                {
                    b.HasOne("SistemaDeLeilao.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaDeLeilao.Models.FuncionarioModel", b =>
                {
                    b.HasOne("SistemaDeLeilao.Models.EmbarcadoresModel", "Embarcadores")
                        .WithMany()
                        .HasForeignKey("EmbarcadoresId");

                    b.HasOne("SistemaDeLeilao.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Embarcadores");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaDeLeilao.Models.LanceModel", b =>
                {
                    b.HasOne("SistemaDeLeilao.Models.OfertaModel", "Oferta")
                        .WithMany()
                        .HasForeignKey("OfertaId");

                    b.HasOne("SistemaDeLeilao.Models.TransportadorModel", "Transportador")
                        .WithMany()
                        .HasForeignKey("TransportadorId");

                    b.Navigation("Oferta");

                    b.Navigation("Transportador");
                });

            modelBuilder.Entity("SistemaDeLeilao.Models.OfertaModel", b =>
                {
                    b.HasOne("SistemaDeLeilao.Models.EmbarcadoresModel", "Embarcadores")
                        .WithMany()
                        .HasForeignKey("EmbarcadoresId");

                    b.HasOne("SistemaDeLeilao.Models.FuncionarioModel", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId");

                    b.Navigation("Embarcadores");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("SistemaDeLeilao.Models.TransportadorModel", b =>
                {
                    b.HasOne("SistemaDeLeilao.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
