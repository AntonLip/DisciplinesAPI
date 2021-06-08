using DisciplinesAPI.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisciplinesAPI.Models.DBModels
{
    public class Lesson : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
       
        public string SectionName { get; set; }
        [Required]

        public string ThemeName { get; set; }
        public int CountHours { get; set; }
        public int CurrentNumberOflessonsType { get; set; }
#nullable enable
        public byte[]? MethodicMaterials { get; set; }
#nullable enable
        public byte[]? AdditionalMaterial { get; set; }
#nullable enable
        public byte[]? Presentation { get; set; }
        //Link to videos
        //Link to literature
        [ForeignKey("LessonType")]
        public Guid LessonTypeId { get; set; }
        public LessonType LessonType { get; set; }
        
        public Disciplines Disciplines { get; set; }
    }
}
