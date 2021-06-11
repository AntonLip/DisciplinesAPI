using DisciplinesAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisciplinesAPI.Models.DBModels
{
    public class Questions : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("Disciplines")]
        public Guid DisciplinesId { get; set; }
        public Disciplines Disciplines { get; set; }
        public List<Answers> Answers{ get; set; }

    }
}
