using Microsoft.AspNetCore.Mvc;
using Sprint3.DTOs;
using Sprint3.Models;
using Sprint3.Repositories; // Recomenda-se criar um ClienteService para padronizar

namespace Sprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repository;
        public ClientesController(IClienteRepository repository) => _repository = repository;

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _repository.ListarTodos());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDTO dto)
        {
            var cliente = new Cliente { Cpf = dto.Cpf, Nome = dto.Nome };
            await _repository.Adicionar(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.IdCliente }, cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sucesso = await _repository.Deletar(id);
            if (!sucesso) return NotFound(new { msg = "Cliente não encontrado." });
            return Ok(new { msg = "Cliente removido!" });
        }
    }
}