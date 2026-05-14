using Microsoft.AspNetCore.Mvc;
using Sprint3.Repositories;

namespace Sprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _repository;
        public PedidoController(IPedidoRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pedidos = await _repository.ListarTodos();
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Erro interno no servidor!", detalhe = ex.InnerException?.Message ?? ex.Message });
            }
        }
    }
}