using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesRebus.Pedido.Api.Data
{
    public class PedidoRepository : IPedidoRepository, IDisposable
    {
        readonly PedidoContext _context;

        public PedidoRepository(PedidoContext context)
        {
            _context = context;
        }

        public void Alterar(Model.Pedido pedido)
        {
            _context.Update(pedido);
            Gravar();
        }

        public void Incluir(Model.Pedido pedido)
        {
            _context.Add(pedido);
            Gravar();
        }

        public IEnumerable<Model.Pedido> ListarTodos()
        {
            return _context.Pedidos.Include(x => x.Itens);
        }

        public Model.Pedido ObterPorId(int numeroPedido)
        {
            return _context.Pedidos.FirstOrDefault(x => x.Numero == numeroPedido);
        }

        private void Gravar()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

    public interface IPedidoRepository
    {
        void Incluir(Model.Pedido pedido);
        void Alterar(Model.Pedido pedido);
        Model.Pedido ObterPorId(int numeroPedido);
        IEnumerable<Model.Pedido> ListarTodos();
    }
}