using System;

namespace DisciplinesAPI.Models.DTOModels.Lesson
{
    public class AddLessonDto
    {
        public string Name { get; set; }
        public string SectionName { get; set; }
        public string ThemeName { get; set; }
        public int CountHours { get; set; }
        public int CurrentNumberOflessonsType { get; set; }
        public Guid LessonTypeId { get; set; }
        public Guid DisciplineId { get; set; }
    }
}
