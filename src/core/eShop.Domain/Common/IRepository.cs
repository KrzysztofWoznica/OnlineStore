﻿
using System.Linq.Expressions;


namespace eShop.Domain.Common
{
    public interface IRepository<TEntity, TId>
        where TEntity : EntityBase<TId>
        where TId : struct
    {             
        Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> expression = null!);
        Task<IEnumerable<TEntity>> GetAllFromIdListAsync(IEnumerable<TId> ids);
        Task<TEntity?> GetAsync(TId id);

        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);      

        Task CreateAndCommitAsync(TEntity entity);
        Task UpdateAndCommitAsync(TEntity entity);
        Task DeleteAndCommitAsync(TEntity entity);

        Task CommitAsync();

       

    }
}