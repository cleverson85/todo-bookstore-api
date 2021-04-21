using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Models;
using ToDo.Infrastructure.Data.Contexts;
using ToDo.Infrastructure.Data.Repositories;

namespace ToDo.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public DbContext GetContext()
        {
            return _context;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        public IBaseRepository<Entity> GetRepository<Entity>() where Entity : BaseEntity
        {
            return new BaseRepository<Entity>(this);
        }

        public IEmprestimoRepository GetEmprestimoRepository()
        {
            return new EmprestimoRepository(this);
        }
    }
}
