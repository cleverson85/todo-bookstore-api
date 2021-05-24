using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Infrastructure.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository) : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> FindByCpf(string cpf)
        {
            return await _clienteRepository.FindByCpf(cpf);
        }

        public async Task<Cliente> FindByEmail(string email, PaginacaoParametroDto paginacaoParametro)
        {
            return await _clienteRepository.FindByEmail(email, paginacaoParametro);
        }

        public async Task<IList<Cliente>> FindByName(string name, PaginacaoParametroDto paginacaoParametro)
        {
            return await _clienteRepository.FindByName(name, paginacaoParametro);
        }

        public override async Task<IList<Cliente>> FindByDescription(string description, PaginacaoParametroDto paginacaoParametro)
        {
            var result = await _clienteRepository.FindByDescription(description, paginacaoParametro);
            return result;
        }

        public override async Task<Cliente> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public override async Task<IList<Cliente>> GetAll(PaginacaoParametroDto paginacaoParametro)
        {
            return await base.GetAll(paginacaoParametro);
        }
    }
}
