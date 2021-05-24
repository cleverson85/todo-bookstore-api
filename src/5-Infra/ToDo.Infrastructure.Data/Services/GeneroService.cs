using System.Collections.Generic;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;
using ToDo.Infrastructure.Services;

namespace ToDo.Infrastructure.Data.Services
{
    public class GeneroService : BaseService<Genero>, IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;

        public GeneroService(IGeneroRepository generoRepository) : base(generoRepository)
        {
            _generoRepository = generoRepository;
        }

        public override Task<IList<Genero>> FindByDescription(string description, PaginacaoParametroDto paginacaoParametro)
        {
            throw new System.NotImplementedException();
        }
    }
}
