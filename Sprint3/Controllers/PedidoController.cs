using Microsoft.AspNetCore.Mvc;
using Sprint3.DTOs;
using Sprint3.Services;
using Sprint3.Repositories;

namespace Sprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService _service;
        private readonly IPedidoRepository _repository;

        public PedidoController(PedidoService service, IPedidoRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        // GET: api/Pedido (Listar todos)
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _repository.ListarTodos());

        // POST: api/Pedido (ADICIONADO! Criar novo pedido com itens)
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PedidoDTO dto)
        {
            try
            {
                await _service.CriarNovoPedido(dto);
                return Ok(new { mensagem = "Pedido criado com sucesso no PokéBistro!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = "Não foi possível criar o pedido.", detalhe = ex.Message });
            }
        }

        // PUT: api/Pedido/{id} (Editar status ou vínculos do pedido)
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PedidoDTO dto)
        {
            try
            {
                await _service.AtualizarPedidoExistente(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = "Erro ao atualizar pedido", detalhe = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletado = await _repository.DeletarPedido(id);
            return deletado ? NoContent() : NotFound("Pedido não encontrado.");
        }
    }
}