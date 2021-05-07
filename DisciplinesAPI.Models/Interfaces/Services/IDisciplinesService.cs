using DisciplinesAPI.Models.DTOModels.Disciplines;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Models.Interfaces.Services
{
    public interface IDisciplinesService
    {
        Task<DisciplineDto> AddAsync(AddDisciplineDto obj, CancellationToken cancellationToken = default);
        Task<IEnumerable<DisciplineDto>> GetAllAsync(int page, int count, CancellationToken cancellationToken = default);
        Task<DisciplineDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<DisciplineDto> UpdateAsync(UpdateDisciplineDto model, CancellationToken cancellationToken = default);
        Task<DisciplineDto> RemoveAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
