using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.Test;
using System;
using System.Collections.Generic;
using System.Text;

namespace DisciplinesAPI.Models.Interfaces.Services
{
    public interface IQuestionsService : IService<Questions, QuestionsDto, AddQuestionDto, AddQuestionDto, Guid>
    {
    }
}
