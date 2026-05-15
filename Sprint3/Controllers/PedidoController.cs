using Microsoft.AspNetCore.Mvc;
using Sprint3.Models;
using Sprint3.Repositories;

namespace Sprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _repository;
        public PedidoController(IPedidoRepository repository) => _repository = repository;

        // GET: api/Pedido
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
                return StatusCode(500, new { erro = "Erro ao listar!", detalhe = ex.Message });
            }
        }

        // POST: api/Pedido
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pedido pedido)
        {
            try
            {
                // Garante que a data seja a do momento da criação se vier vazia
                if (pedido.DataPedido == default) pedido.DataPedido = DateTime.Now;

                await _repository.CriarPedido(pedido);
                return CreatedAtAction(nameof(Get), new { id = pedido.IdPedido }, pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = "Não foi possível criar o pedido.", detalhe = ex.Message });
            }
        }

        // DELETE: api/Pedido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletado = await _repository.DeletarPedido(id);
                if (!deletado) return NotFound(new { mensagem = "Pedido não encontrado no PokéBistro!" });

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Erro ao deletar!", detalhe = ex.Message });
            }
        }
    }
}