using Microsoft.EntityFrameworkCore;
using Sprint3.Data;
using Sprint3.Models;

namespace Sprint3.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly RestauranteDbContext _context;
        public ClienteRepository(RestauranteDbContext context) => _context = context;

        public async Task<IEnumerable<Cliente>> ListarTodos() => await _context.Clientes.ToListAsync();

        public async Task<Cliente?> BuscarPorId(int id) => await _context.Clientes.FindAsync(id);

        public async Task Adicionar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Deletar(int id)
        {
            var cliente = await BuscarPorId(id);
            if (cliente == null) return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}