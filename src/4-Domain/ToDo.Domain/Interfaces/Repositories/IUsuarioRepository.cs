using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> FindUser(Usuario usuario, PaginacaoParametroDto paginacaoParametroDto);
        Task<Usuario> FindById(int id);
    }
}
