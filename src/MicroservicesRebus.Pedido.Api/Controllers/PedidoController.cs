using System.Threading.Tasks;
using MicroservicesRebus.Core;
using MicroservicesRebus.Pedido.Api.Data;
using MicroservicesRebus.Pedido.Api.Events;
using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;

namespace MicroservicesRebus.Pedido.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController: ControllerBase
    {
        readonly IPedidoRepository _pedidoRepository;
        readonly IBus _bus;
        public PedidoController(IPedidoRepository pedidoRepository, IBus bus)
        {
            _pedidoRepository = pedidoRepository;
            _bus = bus;
        }

        [HttpPost("")]
        public async Task<IActionResult> Incluir(Model.Pedido pedido)
        {
            _pedidoRepository.Incluir(pedido);

            var evento = new RemoverEstoqueEvent(pedido.Numero);

            foreach (var item in pedido.Itens)
            {
                evento.Itens.Add(new RemoverEstoqueItem(item.ProdutoID, item.Quantidade));
            }

            await _bus.Publish(evento);

            return Ok("Pedido incluido");
        }

        [HttpGet("")]
        public IActionResult ListarTodos()
        {
            return Ok(_pedidoRepository.ListarTodos());
        }
    }
}