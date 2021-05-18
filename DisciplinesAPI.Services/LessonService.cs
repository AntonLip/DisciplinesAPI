using AutoMapper;
using DisciplinesAPI.Models;
using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.Lesson;
using DisciplinesAPI.Models.Interfaces;
using DisciplinesAPI.Models.Interfaces.Repository;
using DisciplinesAPI.Models.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Services
{
    public class LessonService : BaseService<Lesson, LessonDto, AddLessonDto, UpdateLessonDto>, ILessonService

    {
        private readonly ILessonTypeRepository _lessonTypeRepository;
        private readonly IDisciplinesRepository _disciplinesRepository;
        private readonly ILessonRepository _lessonRepository;
        public LessonService(ILessonRepository lessonRepository, IMapper mapper,
               ILessonTypeRepository lessonTypeRepository, IDisciplinesRepository disciplinesRepository)
            : base(lessonRepository, mapper)
        {
            _disciplinesRepository = disciplinesRepository;
            _lessonTypeRepository = lessonTypeRepository;
            _lessonRepository = lessonRepository;
        }

        public override async Task<LessonDto> AddAsync(AddLessonDto modelDto, CancellationToken cancellationToken = default)
        {
            if (modelDto is null)
                throw new ArgumentNullException();

            if (modelDto.DisciplineId == Guid.Empty || modelDto.LessonTypeId == Guid.Empty)
                throw new ArgumentNullException();

            var lessonType = await _lessonTypeRepository.GetByIdAsync(modelDto.LessonTypeId);
            var disciplines = await _disciplinesRepository.GetByIdAsync(modelDto.DisciplineId);

            if (lessonType is null || disciplines is null)
                throw new ArgumentNullException();

            var model = _mapper.Map<Lesson>(modelDto);
            model.LessonType = lessonType;
            model.Disciplines = disciplines;

            await _repository.AddAsync(model, cancellationToken);
            return _mapper.Map<LessonDto>(model);
        }

        public  IEnumerable<LessonDto> GetAllLessonInDisciplinesAsync(int page, int count, Guid id, CancellationToken cancellationToken = default)
        {

            if (count <= 0)
                count = 5;
            if (id == Guid.Empty)
                throw new ArgumentNullException();
            var result = _lessonRepository.GetWithInclude(l => l.Disciplines.Id == id, l => l.Disciplines, l => l.LessonType);

            return _mapper.Map<List<LessonDto>>(result);
        }
    }
}
