using Sprint3.Models;

namespace Sprint3.Repositories
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> ListarTodos();
        Task Adicionar(Funcionario funcionario);
    }
}