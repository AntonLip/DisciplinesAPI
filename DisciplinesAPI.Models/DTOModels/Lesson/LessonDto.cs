using System;

namespace DisciplinesAPI.Models.DTOModels.Lesson
{
    public class LessonDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SectionName { get; set; }
        public string ThemeName { get; set; }
        public int CountHours { get; set; }
        public int CurrentNumberOflessonsType { get; set; }
        public string LessonType { get; set; }
    }
}
