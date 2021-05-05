using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IClienteService : IBaseService<Cliente>
    {
        Task<IList<Cliente>> FindByName(string name);
        Task<Cliente> FindByCpf(string cpf);
        Task<Cliente> FindByEmail(string email);
        Task<IList<Cliente>> FindByDescription(string description);
    }
}
