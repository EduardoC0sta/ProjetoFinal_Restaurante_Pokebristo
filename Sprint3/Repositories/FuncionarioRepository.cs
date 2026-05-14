using Microsoft.EntityFrameworkCore;
using Sprint3.Data;
using Sprint3.Models;

namespace Sprint3.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly RestauranteDbContext _context;
        public FuncionarioRepository(RestauranteDbContext context) => _context = context;

        public async Task<IEnumerable<Funcionario>> ListarTodos() => await _context.Funcionarios.ToListAsync();

        public async Task Adicionar(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();
        }
    }
}