using AutoMapper;
using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.Lesson;
using DisciplinesAPI.Models.Interfaces.Repository;

namespace DisciplinesAPI.Models
{
    internal class LessonTypeResolver : IValueResolver<AddLessonDto, Lesson, LessonType>
    {
        private readonly ILessonTypeRepository _lessonTypeRepository;

        public LessonTypeResolver(ILessonTypeRepository lessonTypeRepository)
        {
            _lessonTypeRepository = lessonTypeRepository;
        }
        public LessonType Resolve(AddLessonDto source, Lesson destination, LessonType destMember, ResolutionContext context)
        {
            try
            {
                
                var lessonType =  _lessonTypeRepository.GetFirst(l=> l.Name == source.LessonType);
                destination.LessonTypeId = lessonType.Id;
                return null;
            }
            catch
            {
                return new LessonType();
            }
        }
    }
}