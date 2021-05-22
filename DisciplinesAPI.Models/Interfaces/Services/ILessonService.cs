using DisciplinesAPI.Models.DTOModels.Lesson;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Models.Interfaces.Services
{
    public interface ILessonService
    {
        Task<LessonDto> AddAsync( AddLessonDto obj, CancellationToken cancellationToken = default);
        Task<IEnumerable<LessonDto>> GetAllLessonInDisciplines(int page, int count, Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<LessonDto>> GetAllAsync(int page, int count, CancellationToken cancellationToken = default);
        Task<LessonDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<LessonDto> UpdateAsync(Guid id, UpdateLessonDto model, CancellationToken cancellationToken = default);
        Task<LessonDto> RemoveAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
