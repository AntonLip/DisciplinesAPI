using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.LessonType;
using System;

namespace DisciplinesAPI.Models.Interfaces.Services
{
    public interface ILessonTypeService : IService<LessonType, LessonTypeDto, LessonTypeDto, LessonTypeDto, Guid>
    {
        
    }
}
