using Microsoft.EntityFrameworkCore;
using Sprint3.Data;
using Sprint3.Models;

namespace Sprint3.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly RestauranteDbContext _context;
        public FuncionarioRepository(RestauranteDbContext context) => _context = context;

        public async Task<IEnumerable<Funcionario>> ListarTodos() =>
            await _context.Funcionarios.ToListAsync();

        public async Task<Funcionario?> BuscarPorId(int id) =>
            await _context.Funcionarios.FindAsync(id);

        public async Task Criar(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Funcionario funcionario)
        {
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Deletar(int id)
        {
            var funcionario = await BuscarPorId(id);
            if (funcionario == null) return false;
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}