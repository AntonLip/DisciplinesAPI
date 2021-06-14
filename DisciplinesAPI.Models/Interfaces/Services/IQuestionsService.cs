using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.Test;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Models.Interfaces.Services
{
    public interface IQuestionsService : IService<Questions, QuestionsDto, AddQuestionDto, AddQuestionDto, Guid>
    {
        
        int CheckTest(List<QuestionsDto> model, CancellationToken canselationToken = default);
        Task<List<QuestionsDto>> GetTest(Guid disciplineId, int countQuestions, CancellationToken canselationToken = default);
    }
}