using System.Linq;
using System.Threading.Tasks;
using MicroservicesRebus.Core;
using MicroservicesRebus.Estoque.Api.Data.Repository;
using Rebus.Handlers;
using Rebus.Bus;
using MicroservicesRebus.Core.Events;

namespace MicroservicesRebus.Estoque.Api.Events
{
    public class RemoverEstoqueEventHandler : IHandleMessages<RemoverEstoqueEvent>
    {
        readonly IProdutoRepository _produtoRepository;
        readonly IBus _bus;

        public RemoverEstoqueEventHandler(IProdutoRepository produtoRepository, IBus bus)
        {
            _produtoRepository = produtoRepository;
            _bus = bus;
        }

        public Task Handle(RemoverEstoqueEvent message)
        {
            //busca a lista de produtos que deve baixar o estoque.
            foreach(var item in message.Itens)
            {
                var produto = _produtoRepository.ObterPorId(item.ProdutoID);

                //Caso o produto nao foi encontrado lanco um evento para o pedido de inconformidade.
                if (produto == null)
                {
                    _bus.Publish(new EstoqueInconsistenteEvent(message.NumeroPedido, "Produto nao encontrato para o id informado."));
                    return Task.CompletedTask;
                }

                produto.DiminuirQuantidadeEstoque(item.Quantidade);

                //Vefico se o estoque ficou correto.
                if (!produto.EhValido())
                {
                    _bus.Publish(new EstoqueInconsistenteEvent(message.NumeroPedido, string.Join("| ", produto.Erros)));
                    return Task.CompletedTask;
                }

                _produtoRepository.Alterar(produto);
            }

            //Grava a baixa do estoque.
            _produtoRepository.Gravar();

            _bus.Publish(new EstoqueFinalizadoEvent(message.NumeroPedido));

            return Task.CompletedTask;
        }
    }
}