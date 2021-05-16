using DisciplinesAPI.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Models.Interfaces
{
    public interface ILessonRepository : IRepository<Lesson, Guid>
    {
        IEnumerable<Lesson> GetAllLessonInDisciplines(Guid disciplinesId, int page, int count, CancellationToken cancellationToken);
    }
}
