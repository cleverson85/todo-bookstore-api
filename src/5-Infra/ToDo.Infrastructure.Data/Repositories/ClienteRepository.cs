using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Infrastructure.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly Expression<Func<Cliente, object>>[] include = { c => c.Pessoa, c => c.Pessoa.Endereco, c => c.InstituicaoEnsino };
        protected readonly IInstituicaoEnsinoRepository _instituicaoEnsinoRepository;

        public ClienteRepository(IUnitOfWork unitOfWork, IInstituicaoEnsinoRepository instituicaoEnsinoRepository) : base(unitOfWork)
        {
            _instituicaoEnsinoRepository = instituicaoEnsinoRepository;
        }

        public async Task<Cliente> FindByCpf(string cpf)
        {
            var cliente = await GetByExpression(new PaginacaoParametroDto(), c => c.Cpf == cpf, c => c.OrderBy(e => e.Pessoa.Nome), include);
            return cliente.FirstOrDefault();
        }

        public async Task<IList<Cliente>> FindByDescription(string description)
        {
            var result = await GetByExpression(new PaginacaoParametroDto(),
               c => c.Pessoa.Nome.ToLower().Contains(description.ToLower()) || c.Cpf.Contains(description) ||
               c.Pessoa.Email != null && c.Pessoa.Email.ToLower().Contains(description.ToLower()), null, include);

            return result;
        }

        public async Task<Cliente> FindByEmail(string email)
        {
            var cliente = await GetByExpression(new PaginacaoParametroDto(),
               c => c.Pessoa.Email.ToLower().Contains(email.ToLower()), c => c.OrderBy(e => e.Pessoa.Nome), include);
            return cliente.FirstOrDefault();
        }

        public async Task<IList<Cliente>> FindByName(string name)
        {
            return await GetByExpression(new PaginacaoParametroDto(), c => c.Pessoa.Nome.ToLower().Contains(name.ToLower()), c => c.OrderBy(e => e.Pessoa.Nome), include);
        }

        public override async Task<Cliente> GetById(int id, params Expression<Func<Cliente, object>>[] includes)
        {
            return await base.GetById(id, include);
        }

        public override Task<IList<Cliente>> GetAll(PaginacaoParametroDto paginacaoParametro = null, params Expression<Func<Cliente, object>>[] includes)
        {
            return base.GetAll(paginacaoParametro, include);
        }

        public override async Task<Cliente> Save(Cliente entity)
        {
            entity.InstituicaoEnsino = await _instituicaoEnsinoRepository.GetById(entity.InstituicaoEnsino.Id);
            return await base.Save(entity);
        }
    }
}
