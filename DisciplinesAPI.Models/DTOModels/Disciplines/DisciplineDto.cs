using DisciplinesAPI.Models.Interfaces;
using System;

namespace DisciplinesAPI.Models.DTOModels.Disciplines
{
    public class DisciplineDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }       
        public string Name { get; set; }     
        public string FullName { get; set; }
        public int CountHours { get; set; }      
        public DateTime DateOfPlan { get; set; }
    }
}
