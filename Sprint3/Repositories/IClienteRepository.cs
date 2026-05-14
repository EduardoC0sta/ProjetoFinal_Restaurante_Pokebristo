using Sprint3.Models;

namespace Sprint3.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ListarTodos();
        Task<Cliente?> BuscarPorId(int id);
        Task Adicionar(Cliente cliente);
        Task<bool> Deletar(int id);
    }
}