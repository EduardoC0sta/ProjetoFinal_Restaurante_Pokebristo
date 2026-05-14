using Sprint3.DTOs;
using Sprint3.Models;
using Sprint3.Repositories;

namespace Sprint3.Services
{
    public class CardapioService
    {
        private readonly ICardapioRepository _repository;
        public CardapioService(ICardapioRepository repository) => _repository = repository;

        public async Task<IEnumerable<Cardapio>> Listar() => await _repository.ListarTodos();

        public async Task<Cardapio?> Buscar(int id) => await _repository.BuscarPorId(id);

        public async Task<Cardapio> Criar(CardapioDTO dto)
        {
            var novoPrato = new Cardapio
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco
            };
            await _repository.Adicionar(novoPrato);
            return novoPrato;
        }

        public async Task Atualizar(int id, CardapioDTO dto)
        {
            var prato = await _repository.BuscarPorId(id);
            if (prato != null)
            {
                prato.Nome = dto.Nome;
                prato.Descricao = dto.Descricao;
                prato.Preco = dto.Preco;
                await _repository.Atualizar(prato);
            }
        }

        public async Task Deletar(int id) => await _repository.Deletar(id);
    }
}