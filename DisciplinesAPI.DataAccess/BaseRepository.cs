using DisciplinesAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.DataAccess
{
    public class BaseRepository<TModel> : IRepository<TModel, Guid>
        where TModel : class, IEntity<Guid>
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<TModel> _dbSet;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TModel>();
        }
        public async Task AddAsync(TModel model, CancellationToken cancellationToken = default)
        {
            _dbSet.Add(model);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<TModel> Get(Func<TModel, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(int page, int count, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().Skip(page * count).Take(count).ToListAsync();
        }

        public async Task<TModel> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(id);
        }

        public void RemoveAsync(TModel model, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(model);
        }

        public async Task UpdateAsync(TModel model, CancellationToken cancellationToken = default)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public IEnumerable<TModel> GetWithInclude(params Expression<Func<TModel, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<TModel> GetWithInclude(Func<TModel, bool> predicate,
            params Expression<Func<TModel, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        private IQueryable<TModel> Include(params Expression<Func<TModel, object>>[] includeProperties)
        {
            IQueryable<TModel> query = _dbSet.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}