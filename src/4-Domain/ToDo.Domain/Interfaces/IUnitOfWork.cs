using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> Commit();
        void Rollback();
        DbContext GetContext();
    }
}