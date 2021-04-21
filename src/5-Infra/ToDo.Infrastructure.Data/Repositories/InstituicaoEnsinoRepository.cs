using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Data.Repositories
{
    public class InstituicaoEnsinoRepository : BaseRepository<InstituicaoEnsino>, IInstituicaoEnsinoRepository
    {
        public InstituicaoEnsinoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }
    }
}
