using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDo.Domain.Pesquisa;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IBaseService<Entity> where Entity : BaseEntity
    {
        Task<Entity> Save(Entity entity);
        Task Save(IList<Entity> entities);
        Task Delete(int id);
        Task<IList<Entity>> GetAll(PaginacaoParametroDto paginacaoParametro = null);
        Task<Entity> GetById(int id);
        Task<IList<Entity>> GetByExpression(PaginacaoParametroDto paginacaoParametro, Expression<Func<Entity, bool>> filter = null, Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null, 
            params Expression<Func<Entity, object>>[] includes);
        Task<Entity> Find(Entity entity);
        Task<int> Count();
        Task<IList<Entity>> FindByDescription(string description, PaginacaoParametroDto paginacaoParametro);
    }
}
