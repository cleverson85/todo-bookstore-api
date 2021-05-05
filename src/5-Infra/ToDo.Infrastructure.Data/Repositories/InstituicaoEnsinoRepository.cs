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
    public class InstituicaoEnsinoRepository : BaseRepository<InstituicaoEnsino>, IInstituicaoEnsinoRepository
    {
        private readonly Expression<Func<InstituicaoEnsino, object>>[] include = { c => c.Pessoa, c => c.Pessoa.Endereco };

        public InstituicaoEnsinoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public async Task<IList<InstituicaoEnsino>> FindInstituicaoByName(string name)
        {
            return await GetByExpression(new PaginacaoParametroDto(), c => c.Pessoa.Nome.ToLower().Contains(name.ToLower()), null, include);
        }

        public async Task<InstituicaoEnsino> FindInstituicaoEnsinoByCnpj(string cnpj)
        {
            var instituicao = await GetByExpression(new PaginacaoParametroDto(), c => c.Cnpj == cnpj, null, include);
            return instituicao.FirstOrDefault();
        }

        public async Task<IList<InstituicaoEnsino>> FindByDescription(string description)
        {
            var instituicao = await GetByExpression(new PaginacaoParametroDto(), c => c.Cnpj.Contains(description) || c.Pessoa.Nome.ToLower().Contains(description.ToLower()), null, include);
            return instituicao;
        }

        public override async Task<InstituicaoEnsino> GetById(int id, params Expression<Func<InstituicaoEnsino, object>>[] includes)
        {
            return await base.GetById(id, include);
        }

        public override async Task<IList<InstituicaoEnsino>> GetAll(PaginacaoParametroDto paginacaoParametro = null, params Expression<Func<InstituicaoEnsino, object>>[] includes)
        {
            return await base.GetAll(new PaginacaoParametroDto(), include);
        }
    }
}
