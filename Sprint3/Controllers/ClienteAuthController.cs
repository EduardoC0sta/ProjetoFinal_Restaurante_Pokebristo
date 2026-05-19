using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sprint3.Data;
using Sprint3.DTOs;
using Sprint3.Models;

namespace Sprint3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteAuthController : ControllerBase
    {
        private readonly RestauranteDbContext _context;
        public ClienteAuthController(RestauranteDbContext context) => _context = context;

        [HttpPost("identificar")]
        public async Task<IActionResult> Identificar([FromBody] ClienteAuthDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Cpf)) return BadRequest("CPF é obrigatório.");

            // Verifica se o cliente já existe no banco do PokéBistro
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf == dto.Cpf);

            if (cliente == null)
            {
                if (string.IsNullOrWhiteSpace(dto.Nome)) return BadRequest("Nome é obrigatório para novos clientes.");

                // Cadastra o cliente novo na hora
                cliente = new Cliente { Nome = dto.Nome, Cpf = dto.Cpf };
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
            }

            // Retorna os dados do cliente para o front-end salvar na sessão
            return Ok(new { idCliente = cliente.IdCliente, nome = cliente.Nome });
        }
    }
}