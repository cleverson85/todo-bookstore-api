using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private readonly Expression<Func<Cliente, object>>[] include = { c => c.InstituicaoEnsino, c => c.Pessoa, c => c.Pessoa.Endereco };

        public ClienteService(IClienteRepository clienteRepository) : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> FindByCpf(string cpf)
        {
            var cliente = await _clienteRepository.GetByExpression(new PaginacaoParametroDto(), c => c.Cpf == cpf, c => c.OrderBy(e => e.Pessoa.Nome), include);
            return cliente.FirstOrDefault();
        }

        public async Task<Cliente> FindByEmail(string email)
        {
            var cliente = await _clienteRepository.GetByExpression(new PaginacaoParametroDto(), c => c.Pessoa.Email == email, c => c.OrderBy(e => e.Pessoa.Nome), include);
            return cliente.FirstOrDefault();
        }

        public async Task<Cliente> FindById(int id)
        {
            return await _clienteRepository.GetById(id, include);
        }

        public async Task<IList<Cliente>> FindByName(string name, PaginacaoParametroDto paginacaoParametroDto)
        {
            return await GetByExpression(paginacaoParametroDto, c => c.Pessoa.Nome.Contains(name), c => c.OrderBy(e => e.Pessoa.Nome), include);
        }
    }
}
