using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface IInstituicaoEnsinoRepository : IBaseRepository<InstituicaoEnsino>
    {
        Task<IList<InstituicaoEnsino>> FindInstituicaoByName(string name);
        Task<InstituicaoEnsino> FindInstituicaoEnsinoByCnpj(string cnpj);
        Task<IList<InstituicaoEnsino>> FindByDescription(string description);
    }
}
