using AutoMapper;
using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.Test;
using DisciplinesAPI.Models.Interfaces.Repository;
using DisciplinesAPI.Models.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Services
{
    public class QuestionService : BaseService<Questions, QuestionsDto, AddQuestionDto, AddQuestionDto>, IQuestionsService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswersRepository _answerRepository;
        public QuestionService(IQuestionRepository questionsRepository, IAnswersRepository answerRepository,  IMapper mapper)
             : base(questionsRepository, mapper)
        {
            _questionRepository = questionsRepository;
            _answerRepository = answerRepository;
        }

        public override async Task<QuestionsDto> AddAsync(AddQuestionDto modelDto, CancellationToken cancellationToken = default)
        {
            if (modelDto is null)
                throw new ArgumentNullException();

            var model = _mapper.Map<Questions>(modelDto);
            var answers = model.Answers;
            model.Answers = null;
            await _questionRepository.AddAsync(model, cancellationToken);
            foreach(var a in answers)
            {
                await _answerRepository.AddAsync(a, cancellationToken);
            }
            model.Answers = answers;
            return _mapper.Map<QuestionsDto>(model);
        }
        public int CheckTest(List<QuestionsDto> model, CancellationToken canselationToken = default)
        {
            if (model is null)
                throw new ArgumentException();
            int rate = 0;
            foreach (var m in model)
            {
                rate += CheckQuestion(m);
            }
            return (int)(rate / model.Count);

        }

        public async Task<List<QuestionsDto>> GetTest(Guid disciplineId, int countQuestions, CancellationToken canselationToken = default)
        {
            if (disciplineId == Guid.Empty)
                throw new ArgumentNullException();

            var questionsCount = _questionRepository.GetWithInclude(q => q.DisciplinesId == disciplineId).Count;
            List<Questions> questions = new List<Questions>();
            if (questionsCount < countQuestions)
            {
                questions = _questionRepository.GetWithInclude(q => q.DisciplinesId == disciplineId, q => q.Answers);
            }
            else
            {
                var questionsAll = _questionRepository.GetWithInclude(q => q.DisciplinesId == disciplineId, q => q.Answers);
                Random rnd = new Random();
                for(int i = 0; i < countQuestions; i++) 
                {
                    int questionNumber = rnd.Next(1, questionsCount);
                    questions.Add(questionsAll[questionNumber]);
                }
            }

            return questions is null ? throw new ArgumentNullException() : _mapper.Map<List<QuestionsDto>>(questions);
        }


        private int CheckQuestion(QuestionsDto model, CancellationToken canselationToken = default)
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
