using System.Runtime.CompilerServices;
using System;
using Microsoft.EntityFrameworkCore;
using MicroservicesRebus.Estoque.Api.Model;
using MicroservicesRebus.Estoque.Api.Data.Mappings;

namespace MicroservicesRebus.Estoque.Api.Data
{
    public class EstoqueContext: DbContext
    {
        public EstoqueContext(DbContextOptions<EstoqueContext> options) : base(options)
        {
            
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}