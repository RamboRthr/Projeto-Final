using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly MyContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        protected GenericRepository(MyContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public virtual async Task<T> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public virtual async Task<T> GetById(int id)
        {
            return await Query().SingleOrDefaultAsync(entity => entity.Id == id);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await Query().ToListAsync();
        }

        public async Task Delete(int id)
        {
            var result = await GetById(id);

            _dbSet.Remove(result);
        }

        public async Task Save() => await _dbContext.SaveChangesAsync();
        protected IQueryable<T> Query() => _dbSet.AsNoTracking().Where(entity => !entity.Deleted);
    }
}
