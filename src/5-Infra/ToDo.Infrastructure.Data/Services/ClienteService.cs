using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;

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

        public async Task<Cliente> FindByEmail(string email)
        {
            return await _clienteRepository.FindByEmail(email);
        }

        public async Task<IList<Cliente>> FindByName(string name)
        {
            return await _clienteRepository.FindByName(name);
        }

        public async Task<IList<Cliente>> FindByDescription(string description)
        {
            var result = await _clienteRepository.FindByDescription(description);
            return result;
        }

        public override async Task<Cliente> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public override async Task<IList<Cliente>> GetAll()
        {
            return await base.GetAll();
        }
    }
}
