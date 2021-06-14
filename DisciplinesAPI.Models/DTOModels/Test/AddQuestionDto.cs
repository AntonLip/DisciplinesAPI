using DisciplinesAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisciplinesAPI.Models.DTOModels.Test
{
    public class AddQuestionDto : IEntityDto<Guid>

    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public Guid DisciplinesId { get; set; }
        public List<AddAnswerDto> Answers { get; set; }
       
    }
}
