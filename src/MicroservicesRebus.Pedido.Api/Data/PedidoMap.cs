using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroservicesRebus.Pedido.Api.Data
{
    public class PedidoMap : IEntityTypeConfiguration<Model.Pedido>
    {
        public void Configure(EntityTypeBuilder<Model.Pedido> builder)
        {
            builder.ToTable("pedidos");
            builder.HasKey(x => x.Numero);

            builder.Property(x => x.Numero).IsRequired().HasColumnName("numero");
            builder.Property(x => x.NomeCliente).HasColumnName("nome_cliente").HasMaxLength(100).IsRequired();
            builder.Property(x => x.Data).HasColumnName("data").IsRequired();
            builder.Property(x => x.Status).IsRequired().HasColumnName("status").HasColumnType("smallint");
            builder.Property(x => x.MotivoCancelamento).HasColumnName("motivo_cancelamento").HasMaxLength(255);

            builder.HasMany(x => x.Itens).WithOne().HasForeignKey(x => x.NumeroPedido);
        }
    }
}