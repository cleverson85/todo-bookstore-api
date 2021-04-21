using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface IEmprestimoRepository : IBaseRepository<Emprestimo>
    {
        Task<int> SaveEmprestimo(Emprestimo entity);
    }
}
