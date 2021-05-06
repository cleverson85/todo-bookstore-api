using System.Collections.Generic;
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

        public InstituicaoEnsinoService(IInstituicaoEnsinoRepository instituicaoEnsinoRepository) : base(instituicaoEnsinoRepository)
        {
            _instituicaoEnsinoRepository = instituicaoEnsinoRepository;
        }

        public async Task<IList<InstituicaoEnsino>> FindInstituicaoByName(string name)
        {
            return await _instituicaoEnsinoRepository.FindInstituicaoByName(name);
        }

        public async Task<InstituicaoEnsino> FindInstituicaoEnsinoByCnpj(string cnpj)
        {
            return await _instituicaoEnsinoRepository.FindInstituicaoEnsinoByCnpj(cnpj);
        }

        public override async Task<InstituicaoEnsino> GetById(int id)
        {
            return await _instituicaoEnsinoRepository.GetById(id);
        }

        public override async Task<IList<InstituicaoEnsino>> GetAll(PaginacaoParametroDto paginacaoParametro)
        {
            return await base.GetAll(paginacaoParametro);
        }

        public async Task<IList<InstituicaoEnsino>> FindByDescription(string description)
        {
            return await _instituicaoEnsinoRepository.FindByDescription(description);            
        }
    }
}
