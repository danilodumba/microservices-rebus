using System;
using System.Collections.Generic;
using System.Linq;
using MicroservicesRebus.Estoque.Api.Model;

namespace MicroservicesRebus.Estoque.Api.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository, IDisposable
    {
        private readonly EstoqueContext _context;

        public ProdutoRepository(EstoqueContext context)
        {
            _context = context;
        }

        public void Alterar(Produto produto)
        {
            _context.Update(produto);
        }

        public void Incluir(Produto produto)
        {
            _context.Add(produto);
        }

        public IEnumerable<Produto> ListarTodos()
        {
            return _context.Produtos;
        }
        public Produto ObterPorId(int id)
        {
            return _context.Produtos.FirstOrDefault(x => x.Id == id);
        }

        public void Gravar()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

    public interface IProdutoRepository
    {
        void Incluir(Produto produto);
        void Alterar(Produto produto);
        Produto ObterPorId(int id);
        IEnumerable<Produto> ListarTodos();
        void Gravar();
    }
}