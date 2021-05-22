using DisciplinesAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisciplinesAPI.Models.DBModels
{
   
    public class LessonType : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
