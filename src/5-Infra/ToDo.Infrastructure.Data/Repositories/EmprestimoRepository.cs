using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Data.Repositories
{
    public class EmprestimoRepository : BaseRepository<Emprestimo>, IEmprestimoRepository
    {
        private readonly Expression<Func<Emprestimo, object>>[] include = { c => c.Cliente, c => c.LivrosEmprestimo, c => c.Cliente.Pessoa, c => c.Cliente.InstituicaoEnsino };

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

        public override Task<Emprestimo> GetById(int id, params Expression<Func<Emprestimo, object>>[] includes)
        {
            return base.GetById(id, include);
        }
    }
}
