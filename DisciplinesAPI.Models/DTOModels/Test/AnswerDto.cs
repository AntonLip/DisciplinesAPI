using DisciplinesAPI.Models.Interfaces;
using System;

namespace DisciplinesAPI.Models.DTOModels.Test
{
    public class AnswerDto : IEntityDto<Guid>
    {
        public Guid Id { get ; set ; }
        public string Name { get ; set ; }
        public bool IsChoosen{ get; set; }
    }
}
