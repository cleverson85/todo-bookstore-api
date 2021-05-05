using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IInstituicaoEnsinoService : IBaseService<InstituicaoEnsino>
    {
        Task<IList<InstituicaoEnsino>> FindInstituicaoByName(string name);
        Task<InstituicaoEnsino> FindInstituicaoEnsinoByCnpj(string cnpj);
        Task<IList<InstituicaoEnsino>> FindByDescription(string description);
    }
}
