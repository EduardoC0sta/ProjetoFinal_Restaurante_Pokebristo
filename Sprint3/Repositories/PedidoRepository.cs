using Microsoft.EntityFrameworkCore;
using Sprint3.Data;
using Sprint3.Models;

namespace Sprint3.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly RestauranteDbContext _context;
        public PedidoRepository(RestauranteDbContext context) => _context = context;

        public async Task<IEnumerable<Pedido>> ListarTodos()
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Funcionario)
                .ToListAsync();
        }

        public async Task<Pedido?> BuscarPorId(int id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        public async Task CriarPedido(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync(); // Salvar no MySQL
        }

        public async Task<bool> DeletarPedido(int id)
        {
            var pedido = await BuscarPorId(id);
            if (pedido == null) return false;

            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}