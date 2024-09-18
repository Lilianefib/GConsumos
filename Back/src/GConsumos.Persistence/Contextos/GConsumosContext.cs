using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GConsumos.Domain;
using Microsoft.EntityFrameworkCore;

namespace GConsumos.Persistence.Contextos
{
    public class GConsumosContext: DbContext
    {
        public GConsumosContext(DbContextOptions<GConsumosContext> options) : base(options) { }
        public DbSet<Consumo> Consumos { get; set; }
        public DbSet<Medicao> Medicoes { get; set; }
        public DbSet<Medidor> Medidores { get; set; }
        public DbSet<Morador> Moradores { get; set; }
        public DbSet<MoradorMedidor> MoradoresMedidores { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<MoradorMedidor>()
                 .HasKey(MM => new {MM.MoradorId, MM.MedidorId});
        }
    }
}