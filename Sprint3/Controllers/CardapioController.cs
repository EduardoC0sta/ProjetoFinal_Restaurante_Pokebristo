using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sprint3.DTOs;
using Sprint3.Services;

namespace Sprint3.Controllers
{
    [Authorize(Roles = "Gerente")] // Segurança JWT
    [Route("api/[controller]")]
    [ApiController]
    public class CardapioController : ControllerBase
    {
        private readonly CardapioService _service;
        public CardapioController(CardapioService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.Listar());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.Buscar(id);
            return item == null ? NotFound(new { msg = "Item não encontrado." }) : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CardapioDTO dto)
        {
            var novo = await _service.Criar(dto);
            return CreatedAtAction(nameof(GetById), new { id = novo.IdCardapio }, novo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CardapioDTO dto)
        {
            var item = await _service.Buscar(id);
            if (item == null) return NotFound(new { msg = "Item para atualização não encontrado." });

            await _service.Atualizar(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _service.Buscar(id);
            if (item == null) return NotFound(new { msg = "Item para exclusão não encontrado." });

            await _service.Deletar(id);
            return Ok(new { mensagem = "Prato removido com sucesso!" });
        }
    }
}