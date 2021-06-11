using DisciplinesAPI.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DisciplinesAPI.Models.DBModels
{
    public class Answers : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public bool IsTrue { get; set; }
        [ForeignKey("Questions")]
        public Guid QuestionsId { get; set; }
        public Questions Questions { get; set; }
    }
}
