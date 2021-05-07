using DisciplinesAPI.Models.DBModels;
using System;

namespace DisciplinesAPI.Models.Interfaces
{
    public interface ILessonRepository : IRepository<Lesson, Guid>
    {

    }
}
