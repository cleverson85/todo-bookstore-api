using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IUsuarioService : IBaseService<Usuario>
    {
        Task<Usuario> Register(Usuario usuario);
        Task<Usuario> Authenticate(Usuario usuario);
        Task<Usuario> FindUser(Usuario usuario);
        Task<Usuario> FindById(int id);
        //Task<IList<Usuario>> FindByDescription(string description, PaginacaoParametroDto paginacaoParametro);
    }
}
