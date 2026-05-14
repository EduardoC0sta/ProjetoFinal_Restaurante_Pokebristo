using Sprint3.Models;

namespace Sprint3.Repositories
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> ListarTodos();
        Task CriarPedido(Pedido pedido);
    }
}