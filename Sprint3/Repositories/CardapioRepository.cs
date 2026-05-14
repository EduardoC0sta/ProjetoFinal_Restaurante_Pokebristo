using Microsoft.EntityFrameworkCore;
using Sprint3.Data;
using Sprint3.Models;

namespace Sprint3.Repositories
{
    public class CardapioRepository : ICardapioRepository
    {
        private readonly RestauranteDbContext _context;
        public CardapioRepository(RestauranteDbContext context) => _context = context;

        public async Task<IEnumerable<Cardapio>> ListarTodos() => await _context.Cardapios.ToListAsync();

        public async Task<Cardapio?> BuscarPorId(int id) => await _context.Cardapios.FindAsync(id);

        public async Task Adicionar(Cardapio cardapio)
        {
            _context.Cardapios.Add(cardapio);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Cardapio cardapio)
        {
            _context.Entry(cardapio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(int id)
        {
            var item = await BuscarPorId(id);
            if (item != null)
            {
                _context.Cardapios.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}