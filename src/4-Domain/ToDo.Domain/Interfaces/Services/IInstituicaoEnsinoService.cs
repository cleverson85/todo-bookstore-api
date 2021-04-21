using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IInstituicaoEnsinoService : IBaseService<InstituicaoEnsino>
    {
        Task<IList<InstituicaoEnsino>> FindInstituicaoByName(string name);
        Task<InstituicaoEnsino> FindInstituicaoEnsinoByCnpj(string cnpj);
    }
}
