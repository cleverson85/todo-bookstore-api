using System.Threading.Tasks;
using ToDo.Domain.Enum;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface IClienteBloqueioRepository : IBaseRepository<ClienteBloqueio>
    {
        Task<ClienteBloqueio> GetByClienteIdeSituacao(PaginacaoParametroDto paginacaoParametro, int clienteId, SituacaoCliente situacaoCliente);
    }
}
