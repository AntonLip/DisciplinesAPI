using AutoMapper;
using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.Lesson;
using DisciplinesAPI.Models.DTOModels.LessonType;
using DisciplinesAPI.Models.Interfaces.Repository;
using DisciplinesAPI.Models.Interfaces.Services;

namespace DisciplinesAPI.Services
{
    public class LessonTypeService : BaseService<LessonType, LessonTypeDto, LessonTypeDto, LessonTypeDto> , ILessonTypeService
    {
        public LessonTypeService(ILessonTypeRepository lessonTypeRepository, IMapper mapper)
            : base(lessonTypeRepository, mapper)
        {

        }
    }
}
