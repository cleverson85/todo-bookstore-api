using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces;
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
            return await _instituicaoEnsinoRepository.GetByExpression(new PaginacaoParametroDto(), c => c.Pessoa.Nome == name, null, include);
        }

        public async Task<InstituicaoEnsino> FindInstituicaoEnsinoByCnpj(string cnpj)
        {
            var instituicao = await _instituicaoEnsinoRepository.GetByExpression(new PaginacaoParametroDto(), c => c.Cnpj == cnpj, null, include);
            return await Task.FromResult(instituicao.FirstOrDefault());
        }
    }
}
