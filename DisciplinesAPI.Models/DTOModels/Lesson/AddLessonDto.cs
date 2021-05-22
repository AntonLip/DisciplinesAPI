using DisciplinesAPI.Models.Interfaces;
using System;

namespace DisciplinesAPI.Models.DTOModels.Lesson
{
    public class AddLessonDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SectionName { get; set; }
        public string ThemeName { get; set; }
        public int CountHours { get; set; }
        public int CurrentNumberOflessonsType { get; set; }
        public string LessonType { get; set; }
        public Guid DisciplineId { get; set; }
    }
}
