using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Models;
using ToDo.Domain.Pesquisa;

namespace ToDo.Infrastructure.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly Expression<Func<Usuario, object>>[] include = { c => c.Pessoa };

        public UsuarioRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        public async Task<Usuario> FindById(int id)
        {
            return await GetById(id, include);
        }

        public async Task<Usuario> FindUser(Usuario usuario, PaginacaoParametroDto paginacaoParametroDto)
        {
            var user = await GetByExpression(paginacaoParametroDto, c => c.Pessoa.Email == usuario.Pessoa.Email, null, include);
            return user.FirstOrDefault();
        }
    }
}
