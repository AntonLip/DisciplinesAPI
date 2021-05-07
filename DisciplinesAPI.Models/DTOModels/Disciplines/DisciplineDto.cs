using System;
using System.Collections.Generic;
using System.Text;

namespace DisciplinesAPI.Models.DTOModels.Disciplines
{
    public class DisciplineDto
    {
        public Guid Id { get; set; }       
        public string Name { get; set; }     
        public string FullName { get; set; }
        public int CountHours { get; set; }      
        public DateTime DateOfPlan { get; set; }
    }
}
