using System;
using System.Collections.Generic;
using FundosInvestimentos.Models;
using Microsoft.EntityFrameworkCore;

namespace FundosInvestimentos.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<TipoInstituicao> TipoInstituicao { get; set; }
        public DbSet<Fundo> Fundos { get; set; }
        public DbSet<FundoDistribuido> FundoDistribuido { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<FundoFundosDistribuidos> FundoFundosDistribuidos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FundoFundosDistribuidos>()
                .HasKey(FD => new { FD.FundoId, FD.FundoDistribuidoId });

            // Dados inseridos automaticamente ao subir o banco
            builder.Entity<TipoInstituicao>()
                .HasData(
                    new List<TipoInstituicao>()
                    {
                        new TipoInstituicao(Guid.NewGuid(),"Administrador", DateTime.UtcNow),
                        new TipoInstituicao(Guid.NewGuid(),"Gestor", DateTime.UtcNow),
                        new TipoInstituicao(Guid.NewGuid(),"Distribuidor", DateTime.UtcNow),
                    }
                );
        }

    }
}