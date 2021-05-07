using DisciplinesAPI.Models.DTOModels.Lesson;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Models.Interfaces.Services
{
    public interface ILessonRepository
    {
        Task<LessonDto> AddAsync(AddLessonDto obj, CancellationToken cancellationToken = default);
        Task<IEnumerable<LessonDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<LessonDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<LessonDto> UpdateAsync(UpdateLessonDto model, CancellationToken cancellationToken = default);
        LessonDto RemoveAsync(LessonDto model, CancellationToken cancellationToken = default);
    }
}
