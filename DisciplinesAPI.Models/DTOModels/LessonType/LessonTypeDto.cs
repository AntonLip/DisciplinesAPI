using DisciplinesAPI.Models.Interfaces;
using System;

namespace DisciplinesAPI.Models.DTOModels.LessonType
{   
    public class LessonTypeDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

}
