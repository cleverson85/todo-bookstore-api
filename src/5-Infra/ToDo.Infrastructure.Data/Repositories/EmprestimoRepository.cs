using System.Threading.Tasks;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Data.Repositories
{
    public class EmprestimoRepository : BaseRepository<Emprestimo>, IEmprestimoRepository
    {
        public EmprestimoRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public async Task<int> SaveEmprestimo(Emprestimo entity)
        {
            if (entity.Id == 0)
            {
                _dbSet.Attach(entity);
            }
            else
            {
                _dbSet.Update(entity);
            }

            return await Task.FromResult(1);
        }
    }
}
