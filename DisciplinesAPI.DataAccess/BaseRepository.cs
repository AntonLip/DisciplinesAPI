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
        protected readonly AppDbContext _context;
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

        public TModel GetFirst(Func<TModel, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).FirstOrDefault();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(int page, int count, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().Where(l => l.IsDeleted == false).OrderBy(l=>l.Id).Skip(page * count).Take(count).ToListAsync();
        }

        public async Task<TModel> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.Where(l => l.IsDeleted == false).FirstAsync(l=>l.Id==id) ;
        }

        public async Task RemoveAsync(TModel model, CancellationToken cancellationToken = default)
        {
            _context.Entry(model).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
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
        public int GetCount()
        {
            return _dbSet.Count();
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
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty).Where(l=>l.IsDeleted == false));
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}