using eShop.Application.Common.Persistence.Repositories;
using eShop.Domain.Common;
using eShop.Infrastructure.Persistence.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Persistence.Repositories
{
    internal abstract class EFRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : EntityBase<TId>
        where TId : struct
    {
        protected ApplicationDbContext Context { get; }


        protected EFRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        protected virtual DbSet<TEntity> GetSet()
            => Context.Set<TEntity>();
     
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null!) =>
            await Context.Set<TEntity>()
            .AsNoTracking()
            .ToListAsync();

        public virtual async Task<IEnumerable<TEntity>> GetAllFromIdListAsync(IEnumerable<TId> ids) =>
            await Context.Set<TEntity>()
            .AsNoTracking()
            .Where(t => ids.Contains(t.Id))
            .ToListAsync();

        public virtual async Task<TEntity?> GetAsync(TId id) =>
            await Context.Set<TEntity>()
            .AsNoTracking()
            .SingleOrDefaultAsync(t => id.Equals(t.Id));

        public virtual void Create(TEntity entity) =>
            Context.Add(entity);

        public virtual void Update(TEntity entity) =>
            Context.Update(entity);

        public virtual void Delete(TEntity entity) =>
            Context.Remove(entity);

        public async Task CreateAndCommitAsync(TEntity entity)
        {
            Create(entity);
            await CommitAsync();
        }

        public async Task UpdateAndCommitAsync(TEntity entity)
        {
            Update(entity);
            await CommitAsync();
        }

        public async Task DeleteAndCommitAsync(TEntity entity)
        {
            Delete(entity);
            await CommitAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await Context.SaveChangesAsync();
            }
            catch (SqlException ex)
            {

            }
        }
    }
}
