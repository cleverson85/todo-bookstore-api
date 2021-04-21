using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Data.Repositories
{
    public class GeneroRepository : BaseRepository<Genero>, IGeneroRepository
    {
        public GeneroRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }
    }
}