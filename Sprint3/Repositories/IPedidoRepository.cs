using Sprint3.Models;

namespace Sprint3.Repositories
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> ListarTodos();
        Task<Pedido?> BuscarPorId(int id);
        Task CriarPedido(Pedido pedido);
        Task AtualizarPedido(Pedido pedido);
        Task<bool> DeletarPedido(int id);
    }
}