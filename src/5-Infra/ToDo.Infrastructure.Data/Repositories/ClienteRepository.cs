using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Models;
using ToDo.Infrastructure.Data.Contexts;

namespace ToDo.Infrastructure.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }
    }
}
