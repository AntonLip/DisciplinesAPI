using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DisciplinesAPI.Models
{
    public class Disciplines : IEntity<Guid>
    {
        private byte[] plan;

        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string ShortName { get; set; }
        [Required]

        public string FullName { get; set; }

        public int CountHours { get; set; }
        public int CountHoursGZ { get; set; }
        public int CountHoursPZ { get; set; }
        public int CountHoursLeck { get; set; }
        public int CountHoursSEM { get; set; }
        public int CountHoursLR { get; set; }
        public int CountHoursMZ { get; set; }
        public int CountHoursTest { get; set; }
        public int CountHoursСontrolWork { get; set; }
        public int CountHoursSWZ { get; set; }

        public bool IsExam { get; set; }
        public DateTime DateOfPlan { get; set; }
        public int CountNorm { get; set; }
        public int Semester { get; set; }
#nullable enable
        public byte[]? Plan { get => plan; set => plan = value; }
#nullable enable
        public byte[]? GPID { get; set; }
#nullable enable

        public List<Questions>? Questions { get; set; }
        public List<Lesson>? lessons { get; set; }
    }
}
