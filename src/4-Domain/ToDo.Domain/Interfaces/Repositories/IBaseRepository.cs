using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDo.Domain.Pesquisa;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<Entity> where Entity : BaseEntity
    {
        Task<Entity> Save(Entity entity);
        Task SaveList(IList<Entity> entities);
        Task Update(Entity entity);
        Task Delete(int id);
        Task<IList<Entity>> GetAll(PaginacaoParametroDto paginacaoParametro, params Expression<Func<Entity, object>>[] includes);
        Task<IList<Entity>> GetAll(params Expression<Func<Entity, object>>[] includes);
        Task<Entity> GetById(int id, params Expression<Func<Entity, object>>[] includes);
        Task<IList<Entity>> GetByExpression(PaginacaoParametroDto paginacaoParametro, Expression<Func<Entity, bool>> filter = null, Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null, 
            params Expression<Func<Entity, object>>[] includes);
        Task<Entity> Find(Entity entity);
        Task<int> Count();
    }
}


