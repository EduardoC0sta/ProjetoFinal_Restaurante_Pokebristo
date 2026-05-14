using Sprint3.Models;

namespace Sprint3.Repositories
{
    public interface ICardapioRepository
    {
        Task<IEnumerable<Cardapio>> ListarTodos();
        Task<Cardapio?> BuscarPorId(int id);
        Task Adicionar(Cardapio cardapio);
        Task Atualizar(Cardapio cardapio);
        Task Deletar(int id);
    }
}