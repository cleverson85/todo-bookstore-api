using System.Linq;
using System.Threading.Tasks;
using ToDo.Domain.Enum;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Infrastructure.Data.Repositories
{
    public class ClienteBloqueioRepository : BaseRepository<ClienteBloqueio>, IClienteBloqueioRepository
    {
        public ClienteBloqueioRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public async Task<ClienteBloqueio> GetByClienteIdeSituacao(PaginacaoParametroDto paginacaoParametro, int clienteId, SituacaoCliente situacaoCliente)
        {
            var clieteBloqueio = await GetByExpression(paginacaoParametro, c => c.Cliente.Id == clienteId && c.Situacao == situacaoCliente);
            return clieteBloqueio.FirstOrDefault();
        }
    }
}
