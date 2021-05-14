using DisciplinesAPI.Models.DTOModels.LessonType;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Models.Interfaces.Services
{
    public interface ILessonTypeService
    {
        Task<LessonTypeDto> AddAsync(AddLessonTypeDto obj, CancellationToken cancellationToken = default);
        Task<IEnumerable<LessonTypeDto>> GetAllAsync(int page, int count, CancellationToken cancellationToken = default);
        Task<LessonTypeDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<LessonTypeDto> UpdateAsync(LessonTypeDto obj, CancellationToken cancellationToken = default);

        Task<LessonTypeDto> Remove(Guid id, CancellationToken cancellationToken = default);
    }
}
