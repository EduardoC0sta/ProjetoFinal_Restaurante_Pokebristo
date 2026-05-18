using Sprint3.Models;
using Sprint3.Repositories;
using Sprint3.DTOs;

namespace Sprint3.Services
{
    public class PedidoService
    {
        private readonly IPedidoRepository _repository;
        public PedidoService(IPedidoRepository repository) => _repository = repository;

        public async Task CriarNovoPedido(PedidoDTO dto)
        {
            var pedido = new Pedido
            {
                IdCliente = dto.IdCliente,
                IdFuncionario = dto.IdFuncionario,
                StatusPedido = dto.StatusPedido ?? "Pendente",
                DataPedido = DateTime.Now
            };
            await _repository.CriarPedido(pedido);
        }

        public async Task AtualizarPedidoExistente(int id, PedidoDTO dto)
        {
            var pedidoBanco = await _repository.BuscarPorId(id);
            if (pedidoBanco == null) throw new Exception("Pedido não encontrado no PokéBistro!");

            pedidoBanco.IdCliente = dto.IdCliente;
            pedidoBanco.IdFuncionario = dto.IdFuncionario;
            pedidoBanco.StatusPedido = dto.StatusPedido ?? "Pendente";

            await _repository.AtualizarPedido(pedidoBanco);
        }
    }
}