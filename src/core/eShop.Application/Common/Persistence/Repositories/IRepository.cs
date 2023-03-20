using eShop.Domain.Common;
using System.Linq.Expressions;


namespace eShop.Application.Common.Persistence.Repositories
{
    public interface IRepository<TEntity, TId>
        where TEntity : EntityBase<TId>
        where TId : struct
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null!);
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
