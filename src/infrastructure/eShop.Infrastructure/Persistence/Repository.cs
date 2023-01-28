using eShop.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Persistence
{
    internal abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : EntityBase<TId>
        where TId : struct
    {
        
        static protected readonly List<TEntity> _entities = new List<TEntity>();

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Create(TEntity entity)
        {
            _entities.Add(entity);
        }

        public Task CreateAndCommitAsync(TEntity entity)
        {
            return Task.Run(()=>_entities.Add(entity));
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public Task DeleteAndCommitAsync(TEntity entity)
        {
            return Task.Run(()=>_entities.Remove(entity));
        }

        public Task<IEnumerable<TEntity>> GetAllFromIdListAsync(IEnumerable<TId> ids)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetAsync(TId id)
        {
            return Task.Run(()=> _entities.SingleOrDefault(p => p.Id.Equals(id)));
        }

        public Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression = null!)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAndCommitAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
