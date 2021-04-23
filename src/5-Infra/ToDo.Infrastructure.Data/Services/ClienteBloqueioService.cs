using System.Threading.Tasks;
using ToDo.Domain.Enum;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Infrastructure.Services
{
    public class ClienteBloqueioService : BaseService<ClienteBloqueio>, IClienteBloqueioService
    {
        private readonly IClienteService _clienteService;
        private readonly IClienteBloqueioRepository _clienteBloqueioRepository;

        public ClienteBloqueioService(IClienteBloqueioRepository clienteBloqueioRepository, IClienteService clienteService) : base(clienteBloqueioRepository)
        {
            _clienteBloqueioRepository = clienteBloqueioRepository;
            _clienteService = clienteService;
        }

        public async Task<Cliente> BloquearCliente(int clienteId)
        {
            var cliente = await _clienteService.GetById(clienteId);
            var clienteBloqueio = await _clienteBloqueioRepository.GetByClienteIdeSituacao(new PaginacaoParametroDto(), clienteId, SituacaoCliente.Ativo);

            if (clienteBloqueio == null)
            {
                clienteBloqueio = new ClienteBloqueio(cliente);
            }
            
            clienteBloqueio.Bloquear();
            await _clienteBloqueioRepository.Save(clienteBloqueio);

            cliente.Situacao = SituacaoCliente.Bloqueado;
            await _clienteService.Save(cliente);

            return cliente;
        }

        public async Task<Cliente> DesbloquearCliente(int clienteId)
        {
            var cliente = await _clienteService.GetById(clienteId);
            var clienteBloqueio = await _clienteBloqueioRepository.GetByClienteIdeSituacao(new PaginacaoParametroDto(), clienteId, SituacaoCliente.Bloqueado);

            clienteBloqueio.DesBloquear();
            await _clienteBloqueioRepository.Save(clienteBloqueio);

            cliente.Situacao = SituacaoCliente.Ativo;
            await _clienteService.Save(cliente);

            return cliente;
        }
    }
}
