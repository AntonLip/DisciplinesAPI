using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.Lesson;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Models.Interfaces.Services
{
    public interface ILessonService : IService<Lesson, LessonDto, AddLessonDto, UpdateLessonDto, Guid>
    {
        IEnumerable<LessonDto> GetAllLessonInDisciplinesAsync(int page, int count, Guid id, CancellationToken cancellationToken = default);
        
    }
}
