using DisciplinesAPI.Models.DBModels;
using System;

namespace DisciplinesAPI.Models.Interfaces.Repository
{
    public interface ILessonRepository :IRepository<Lesson,Guid>
    {
    }
}
