using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDo.Domain.Pesquisa;
using ToDo.Domain.Interfaces.Repositories;
using ToDo.Domain.Interfaces.Services;
using ToDo.Domain.Models;

namespace ToDo.Infrastructure.Services
{
    public class BaseService<Entity> : IBaseService<Entity> where Entity : BaseEntity
    {
        protected readonly IBaseRepository<Entity> _repository;

        public BaseService(IBaseRepository<Entity> repository)
        {
            _repository = repository;
        }

        public async Task<Entity> Save(Entity entity)
        {
           return await _repository.Save(entity);
        }

        public async Task Save(IList<Entity> entities)
        {
            await _repository.SaveList(entities);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public virtual async Task<IList<Entity>> GetAll(PaginacaoParametroDto paginacaoParametro = null)
        {
            return await _repository.GetAll(paginacaoParametro);
        }

        public async Task<int> Count()
        {
            return await _repository.Count();
        }

        public virtual async Task<Entity> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public virtual async Task<IList<Entity>> GetByExpression(PaginacaoParametroDto paginacaoParametro, 
            Expression<Func<Entity, bool>> filter = null, Func<IQueryable<Entity>, IOrderedQueryable<Entity>> orderBy = null, params Expression<Func<Entity, object>>[] includes)
        {
            return await _repository.GetByExpression(paginacaoParametro, filter, orderBy, includes);
        }

        public async Task<Entity> Find(Entity entity)
        {
            return await _repository.Find(entity);
        }
    }
}
