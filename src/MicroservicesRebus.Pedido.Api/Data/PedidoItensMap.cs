using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroservicesRebus.Pedido.Api.Data
{
    public class PedidoItensMap : IEntityTypeConfiguration<Model.ItemPedido>
    {
        public void Configure(EntityTypeBuilder<Model.ItemPedido> builder)
        {
            builder.ToTable("pedidos_itens");
            builder.HasKey(x => new { x.NumeroPedido, x.ProdutoID }); //Chave composta

            builder.Property(x => x.NumeroPedido).IsRequired().HasColumnName("numero_pedido");
            builder.Property(x => x.ProdutoID).IsRequired().HasColumnName("produto_id");
            builder.Property(x => x.NomeProduto).HasColumnName("nome_produto").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Quantidade).HasColumnName("quantidade").IsRequired();
            builder.Property(x => x.ValorUnitario).IsRequired().HasColumnName("valor_unitario").HasColumnType("decimal(15,2)");
        }
    }
}