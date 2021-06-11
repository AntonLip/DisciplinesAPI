using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.Test;
using System;
using System.Threading;

namespace DisciplinesAPI.Models.Interfaces.Services
{
    public interface IQuestionsService : IService<Questions, QuestionsDto, AddQuestionDto, AddQuestionDto, Guid>
    {
        int CheckQuestion(QuestionsDto model, CancellationToken canselationToken = default);        
    }
}