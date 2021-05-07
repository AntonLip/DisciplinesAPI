using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DisciplinesAPI.Models.DBModels
{
    public class LessonType
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public List<Lesson> lessons { get; set; }
    }
}
