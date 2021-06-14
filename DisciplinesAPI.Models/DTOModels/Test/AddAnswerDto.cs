using System;
using System.Collections.Generic;
using System.Text;

namespace DisciplinesAPI.Models.DTOModels.Test
{
    public class AddAnswerDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public bool IsTrue { get; set; }
    }
}
