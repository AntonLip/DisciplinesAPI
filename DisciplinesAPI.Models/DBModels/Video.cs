using DisciplinesAPI.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace DisciplinesAPI.Models.DBModels
{
    public class Video : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
        public VideoCourses VideoCourses { get; set; }
    }
}
