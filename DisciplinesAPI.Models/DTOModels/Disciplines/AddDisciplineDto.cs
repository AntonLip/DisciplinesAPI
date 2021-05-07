using System;

namespace DisciplinesAPI.Models.DTOModels.Disciplines
{
    public class AddDisciplineDto
    {      
        public string ShortName { get; set; }
   
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
    }
}
