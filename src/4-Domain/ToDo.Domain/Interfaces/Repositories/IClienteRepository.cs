using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<IList<Cliente>> FindByName(string name);
        Task<Cliente> FindByCpf(string cpf);
        Task<Cliente> FindByEmail(string email);
        Task<IList<Cliente>> FindByDescription(string description);
    }
}
