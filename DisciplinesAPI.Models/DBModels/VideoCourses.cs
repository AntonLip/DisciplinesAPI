using DisciplinesAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DisciplinesAPI.Models.DBModels
{
    public class VideoCourses : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Info { get; set; }

        public bool IsDeleted { get; set; }

        public List<Video> Video { get; set; }
    }
}
