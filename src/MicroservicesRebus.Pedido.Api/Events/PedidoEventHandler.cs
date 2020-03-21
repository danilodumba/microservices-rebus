using System.Threading.Tasks;
using MicroservicesRebus.Core;
using MicroservicesRebus.Core.Events;
using MicroservicesRebus.Pedido.Api.Data;
using Rebus.Handlers;

namespace MicroservicesRebus.Pedido.Api.Events
{
    public class PedidoEventHandler : 
        IHandleMessages<EstoqueFinalizadoEvent>,
        IHandleMessages<EstoqueInconsistenteEvent>
    {
        readonly IPedidoRepository _pedidoRepository;

        public PedidoEventHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public Task Handle(EstoqueFinalizadoEvent message)
        {
            var pedido = _pedidoRepository.ObterPorId(message.NumeroPedido);
            pedido.Finalizar();
            _pedidoRepository.Alterar(pedido);

            return Task.CompletedTask;
        }

        public Task Handle(EstoqueInconsistenteEvent message)
        {
            var pedido = _pedidoRepository.ObterPorId(message.NumeroPedido);
            pedido.Cancelar(message.MotivoCancelamento);
            _pedidoRepository.Alterar(pedido);

            return Task.CompletedTask;
        }
    }
}