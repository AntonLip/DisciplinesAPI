using DisciplinesAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisciplinesAPI.Models.DTOModels.Test
{
    public class QuestionsDto : IEntityDto<Guid>

    {
        public Guid Id { get ; set ; }
         public string Name { get ; set ; }
        public List<AnswerDto> Answers { get; set; }

        public int Count { get => Answers.Count;  }

       
    }
}
