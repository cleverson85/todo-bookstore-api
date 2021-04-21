using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IClienteBloqueioService : IBaseService<ClienteBloqueio>
    {
        Task<Cliente> BloquearCliente(int clienteId);
        Task<Cliente> DesbloquearCliente(int clienteId);
    }
}
