using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Models.Interfaces.Services
{
    public interface IService<TModel, TModelDto, TModelAddDto, TModelUpdateDto, TId>
        where TModel : IEntity<TId>
        where TModelDto : IEntityDto<TId>
        where TModelAddDto : IEntityDto<TId>
        where TModelUpdateDto : IEntityDto<TId>
    {
        Task<TModelDto> AddAsync(TModelAddDto obj, CancellationToken cancellationToken = default);
        Task<IEnumerable<TModelDto>> GetAllAsync(int page, int count, CancellationToken cancellationToken = default);
        Task<TModelDto> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
        Task<TModelDto> UpdateAsync(TId id , TModelUpdateDto obj, CancellationToken cancellationToken = default);

        Task<TModelDto> RemoveAsync(TId id, CancellationToken cancellationToken = default);
    }
}
