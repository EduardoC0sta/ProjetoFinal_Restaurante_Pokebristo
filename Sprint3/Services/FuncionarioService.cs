using Sprint3.Models;
using Sprint3.Repositories;
using Sprint3.DTOs;

namespace Sprint3.Services
{
    public class FuncionarioService
    {
        private readonly IFuncionarioRepository _repository;
        public FuncionarioService(IFuncionarioRepository repository) => _repository = repository;

        public async Task CriarFuncionario(FuncionarioDTO dto)
        {
            // Regra de negócio simples
            if (dto.Salario < 0) throw new Exception("O salário não pode ser negativo.");

            var funcionario = new Funcionario
            {
                Nome = dto.Nome,
                Cargo = dto.Cargo,
                Salario = dto.Salario,
                Status = dto.Status
            };

            await _repository.Criar(funcionario);
        }
    }
}