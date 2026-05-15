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
            // 1. Transformamos o DTO no Model Pedido
            var pedido = new Pedido
            {
                IdCliente = dto.IdCliente,
                IdFuncionario = dto.IdFuncionario,
                StatusPedido = dto.StatusPedido ?? "Pendente",
                DataPedido = DateTime.Now,
                // 2. Transformamos a lista de Itens do DTO para Itens do Model
                Itens = dto.Itens.Select(i => new ItemPedido
                {
                    IdCardapio = i.IdCardapio,
                    Quantidade = i.Quantidade
                }).ToList()
            };

            await _repository.CriarPedido(pedido);
        }
    }
}