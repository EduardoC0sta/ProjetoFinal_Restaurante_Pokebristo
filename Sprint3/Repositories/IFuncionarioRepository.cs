using Sprint3.Models;

namespace Sprint3.Repositories
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> ListarTodos();
        Task<Funcionario?> BuscarPorId(int id);
        Task Criar(Funcionario funcionario);
        Task Atualizar(Funcionario funcionario);
        Task<bool> Deletar(int id);
    }
}