using System.Collections.Generic;
using MicroservicesRebus.Estoque.Api.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroservicesRebus.Estoque.Api.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produtos");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nome).HasColumnName("nome").IsRequired().HasMaxLength(100);
            builder.Property(x => x.QuantidadeEstoque).HasColumnName("quantidadeEstoque").IsRequired();
            builder.Property(x => x.Valor).HasColumnName("valor").HasColumnType("decimal(15,2)").IsRequired();

            builder.Ignore(x => x.Erros);

            builder.HasData(PopularProdutos());
        }

        private IList<Produto> PopularProdutos()
        {
            return new List<Produto>
            {
                new Produto(1, "BMW X1", 100, 200000M),
                new Produto(2, "BMW 320", 100, 250000M),
                new Produto(3, "MERCEDES A200", 100, 290000M),
                new Produto(4, "LAND EVOQUE", 100, 350000M),
                new Produto(5, "FERRARI F40", 100, 1250000M)
            };
        }
    }
}