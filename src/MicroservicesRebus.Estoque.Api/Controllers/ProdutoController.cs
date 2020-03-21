using MicroservicesRebus.Estoque.Api.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesRebus.Estoque.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController: ControllerBase
    {
        readonly IProdutoRepository _produtoRepository;
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(_produtoRepository.ListarTodos());
        }
    }
}