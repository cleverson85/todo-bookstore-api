using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        Task<IList<Cliente>> FindByName(string name, PaginacaoParametroDto paginacaoParametro);
        Task<Cliente> FindByCpf(string cpf);
        Task<Cliente> FindByEmail(string email, PaginacaoParametroDto paginacaoParametro);
        Task<IList<Cliente>> FindByDescription(string description, PaginacaoParametroDto paginacaoParametro);
    }
}
