using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IClienteService : IBaseService<Cliente>
    {
        Task<Cliente> FindById(int id);
        Task<IList<Cliente>> FindByName(string name, PaginacaoParametroDto paginacaoParametroDto);
        Task<Cliente> FindByCpf(string cpf);
        Task<Cliente> FindByEmail(string email);
    }
}
