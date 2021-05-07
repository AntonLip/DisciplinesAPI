using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DisciplinesAPI.Models.DBModels
{
    public class Lesson
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public string sectionName { get; set; }
        public string themeName { get; set; }
        public int countHours { get; set; }
        public int currentNumberOflessonsType { get; set; }
#nullable enable
        public byte[]? MethodicMaterials { get; set; }
#nullable enable
        public byte[]? AdditionalMaterial { get; set; }
#nullable enable
        public byte[]? Presentation { get; set; }
        //Link to videos
        //Link to literature
        public LessonType? LessonType { get; set; }
        
        public Disciplines? Disciplines { get; set; }
    }
}
