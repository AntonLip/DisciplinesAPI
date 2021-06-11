using AutoMapper;
using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.Test;
using DisciplinesAPI.Models.Interfaces.Repository;
using DisciplinesAPI.Models.Interfaces.Services;
using System;
using System.Threading;

namespace DisciplinesAPI.Services
{
    public class QuestionService : BaseService<Questions, QuestionsDto, AddQuestionDto, AddQuestionDto>, IQuestionsService
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionService(IQuestionRepository questionsRepository,  IMapper mapper)
             : base(questionsRepository, mapper)
        {
            _questionRepository = questionsRepository;
        }
        public int CheckQuestion(QuestionsDto model, CancellationToken canselationToken = default)
        {
            if (model is null)
                throw new ArgumentNullException();
            var question = _questionRepository.GetWithInclude(q => q.Id == model.Id, q => q.Answers).Find(q => q.IsDeleted == false);
            if (question is null)
                throw new ArgumentException();
            int trueAnswerCount = question.Answers.FindAll(a => a.IsTrue).Count;
            int cntTrutAnswered = 0;
            foreach (var a in question.Answers)
            {
                var ansDto = model.Answers.Find(ans => ans.Id == a.Id);
                if (a.IsTrue == true && ansDto.IsChoosen == true)
                    cntTrutAnswered++;
            }
            if (trueAnswerCount == cntTrutAnswered)
                return question.Difficulty;

            return 0;
        }
    }
}
