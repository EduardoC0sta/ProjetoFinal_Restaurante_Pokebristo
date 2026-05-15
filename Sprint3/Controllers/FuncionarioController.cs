using Microsoft.AspNetCore.Mvc;
using Sprint3.DTOs;
using Sprint3.Services;
using Sprint3.Repositories;

namespace Sprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioService _service;
        private readonly IFuncionarioRepository _repository;

        public FuncionarioController(FuncionarioService service, IFuncionarioRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _repository.ListarTodos());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FuncionarioDTO dto)
        {
            try
            {
                await _service.CriarFuncionario(dto);
                return Ok(new { mensagem = "Funcionário contratado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletado = await _repository.Deletar(id);
            return deletado ? NoContent() : NotFound("Funcionário não encontrado.");
        }
    }
}