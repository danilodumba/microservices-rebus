using Microsoft.EntityFrameworkCore;
using MicroservicesRebus.Pedido.Api.Model;

namespace MicroservicesRebus.Pedido.Api.Data
{
    public class PedidoContext: DbContext
    {
        public PedidoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Model.Pedido> Pedidos {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new PedidoItensMap());
        }
    }
}