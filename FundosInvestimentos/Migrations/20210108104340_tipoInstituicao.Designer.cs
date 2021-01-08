﻿// <auto-generated />
using System;
using FundosInvestimentos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FundosInvestimentos.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20210108104340_tipoInstituicao")]
    partial class tipoInstituicao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("FundosInvestimentos.Models.Fundo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CNPJ")
                        .HasColumnType("text");

                    b.Property<string>("CodigoAnbima")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("InstituicaoId")
                        .HasColumnType("uuid");

                    b.Property<string>("RazaoSocialAdministrador")
                        .HasColumnType("text");

                    b.Property<string>("RazaoSocialDistribuidor")
                        .HasColumnType("text");

                    b.Property<string>("RazaoSocialGestor")
                        .HasColumnType("text");

                    b.Property<double>("Saldo")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("InstituicaoId");

                    b.ToTable("Fundos");
                });

            modelBuilder.Entity("FundosInvestimentos.Models.FundoDistribuido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CNPJ")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("FundoDistribuido");
                });

            modelBuilder.Entity("FundosInvestimentos.Models.FundoFundosDistribuidos", b =>
                {
                    b.Property<Guid>("FundoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FundoDistribuidoId")
                        .HasColumnType("uuid");

                    b.HasKey("FundoId", "FundoDistribuidoId");

                    b.HasIndex("FundoDistribuidoId");

                    b.ToTable("FundoFundosDistribuidos");
                });

            modelBuilder.Entity("FundosInvestimentos.Models.Instituicao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AnoCriacao")
                        .HasColumnType("text");

                    b.Property<string>("CNPJ")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("text");

                    b.Property<Guid>("TipoInstituicaoId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("TipoInstituicaoId");

                    b.ToTable("Instituicao");
                });

            modelBuilder.Entity("FundosInvestimentos.Models.TipoInstituicao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Tipo")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("TipoInstituicao");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d525c7b9-1aab-4fb0-83df-b73bc35e689d"),
                            CreatedAt = new DateTime(2021, 1, 8, 10, 43, 39, 784, DateTimeKind.Utc).AddTicks(4638),
                            Tipo = "Administrador",
                            UpdatedAt = new DateTime(2021, 1, 8, 10, 43, 39, 784, DateTimeKind.Utc).AddTicks(4638)
                        },
                        new
                        {
                            Id = new Guid("30f7d1fc-cd61-4dcf-95d3-924c0067adf9"),
                            CreatedAt = new DateTime(2021, 1, 8, 10, 43, 39, 784, DateTimeKind.Utc).AddTicks(6751),
                            Tipo = "Gestor",
                            UpdatedAt = new DateTime(2021, 1, 8, 10, 43, 39, 784, DateTimeKind.Utc).AddTicks(6751)
                        },
                        new
                        {
                            Id = new Guid("872470d4-b566-465a-a1fc-783a3fbb65f3"),
                            CreatedAt = new DateTime(2021, 1, 8, 10, 43, 39, 784, DateTimeKind.Utc).AddTicks(6775),
                            Tipo = "Distribuidor",
                            UpdatedAt = new DateTime(2021, 1, 8, 10, 43, 39, 784, DateTimeKind.Utc).AddTicks(6775)
                        });
                });

            modelBuilder.Entity("FundosInvestimentos.Models.Fundo", b =>
                {
                    b.HasOne("FundosInvestimentos.Models.Instituicao", "Instituicao")
                        .WithMany("Fundos")
                        .HasForeignKey("InstituicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Instituicao");
                });

            modelBuilder.Entity("FundosInvestimentos.Models.FundoFundosDistribuidos", b =>
                {
                    b.HasOne("FundosInvestimentos.Models.FundoDistribuido", "FundoDistribuido")
                        .WithMany("FundoFundosDistribuidos")
                        .HasForeignKey("FundoDistribuidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FundosInvestimentos.Models.Fundo", "Fundo")
                        .WithMany("FundoFundosDistribuidos")
                        .HasForeignKey("FundoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fundo");

                    b.Navigation("FundoDistribuido");
                });

            modelBuilder.Entity("FundosInvestimentos.Models.Instituicao", b =>
                {
                    b.HasOne("FundosInvestimentos.Models.TipoInstituicao", "TipoInstituicao")
                        .WithMany("Instituicao")
                        .HasForeignKey("TipoInstituicaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoInstituicao");
                });

            modelBuilder.Entity("FundosInvestimentos.Models.Fundo", b =>
                {
                    b.Navigation("FundoFundosDistribuidos");
                });

            modelBuilder.Entity("FundosInvestimentos.Models.FundoDistribuido", b =>
                {
                    b.Navigation("FundoFundosDistribuidos");
                });

            modelBuilder.Entity("FundosInvestimentos.Models.Instituicao", b =>
                {
                    b.Navigation("Fundos");
                });

            modelBuilder.Entity("FundosInvestimentos.Models.TipoInstituicao", b =>
                {
                    b.Navigation("Instituicao");
                });
#pragma warning restore 612, 618
        }
    }
}