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
                // Como o cliente faz o pedido sozinho pelo site, definimos um funcionário padrão (ex: ID 1 - Claudia)
                IdFuncionario = dto.IdFuncionario == 0 ? 1 : dto.IdFuncionario,
                StatusPedido = dto.StatusPedido ?? "Pendente",
                DataPedido = DateTime.Now,

                // Mapeamento dos itens do carrinho para o modelo do banco de dados
                Itens = dto.Itens.Select(i => new ItemPedido
                {
                    IdCardapio = i.IdCardapio,
                    Quantidade = i.Quantidade
                }).ToList()
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