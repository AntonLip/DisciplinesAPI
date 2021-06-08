using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Models.Interfaces
{
    public interface IRepository<TModel, TId>
        where TModel : IEntity<TId>
    {
        Task AddAsync(TModel obj, CancellationToken cancellationToken = default);
        Task<IEnumerable<TModel>> GetAllAsync(int page, int count, CancellationToken cancellationToken = default);
        Task<TModel> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
        Task UpdateAsync( TModel obj, CancellationToken cancellationToken = default);

        public int GetCount();
        TModel GetFirst(Func<TModel, bool> predicate);
        IEnumerable<TModel> GetWithInclude(params Expression<Func<TModel, object>>[] includeProperties);
        Task RemoveAsync(TModel model, CancellationToken cancellationToken = default);
        IEnumerable<TModel> GetWithInclude(Func<TModel, bool> predicate,
            params Expression<Func<TModel, object>>[] includeProperties);

    }
}
