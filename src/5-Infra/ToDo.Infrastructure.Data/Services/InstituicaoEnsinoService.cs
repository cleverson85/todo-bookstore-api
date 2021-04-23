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
    public class InstituicaoEnsinoService : BaseService<InstituicaoEnsino>, IInstituicaoEnsinoService
    {
        private readonly IInstituicaoEnsinoRepository _instituicaoEnsinoRepository;
        private readonly Expression<Func<InstituicaoEnsino, object>>[] include = { c => c.Pessoa, c => c.Pessoa.Endereco };

        public InstituicaoEnsinoService(IInstituicaoEnsinoRepository instituicaoEnsinoRepository) : base(instituicaoEnsinoRepository)
        {
            _instituicaoEnsinoRepository = instituicaoEnsinoRepository;
        }

        public async Task<IList<InstituicaoEnsino>> FindInstituicaoByName(string name)
        {
            return await _instituicaoEnsinoRepository.
                GetByExpression(new PaginacaoParametroDto(), c => c.Pessoa.Nome.Contains(name, StringComparison.InvariantCultureIgnoreCase), null, include);
        }

        public async Task<InstituicaoEnsino> FindInstituicaoEnsinoByCnpj(string cnpj)
        {
            var instituicao = await _instituicaoEnsinoRepository.GetByExpression(new PaginacaoParametroDto(), c => c.Cnpj == cnpj, null, include);
            return instituicao.FirstOrDefault();
        }

        public override async Task<IList<InstituicaoEnsino>> FindByDescription(string description, PaginacaoParametroDto paginacaoParametro)
        {
            var instituicao = await _instituicaoEnsinoRepository.GetByExpression(new PaginacaoParametroDto(), 
                c => c.Cnpj.Contains(description) || c.Pessoa.Nome.Contains(description), null, include);
            return instituicao;
        }

        public override async Task<IList<InstituicaoEnsino>> GetAll(params Expression<Func<InstituicaoEnsino, object>>[] includes)
        {
            return await base.GetAll(include);
        }

        public override async Task<InstituicaoEnsino> GetById(int id, params Expression<Func<InstituicaoEnsino, object>>[] includes)
        {
            return await base.GetById(id, include);
        }
    }
}
