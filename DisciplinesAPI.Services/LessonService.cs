using AutoMapper;
using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.Lesson;
using DisciplinesAPI.Models.Interfaces.Repository;
using DisciplinesAPI.Models.Interfaces.Services;
using System;
using System.Collections.Generic;
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

        public  IEnumerable<LessonDto> GetAllLessonInDisciplinesAsync(int page, int count, Guid id, CancellationToken cancellationToken = default)
        {

            if (count <= 0)
                count = 5;
            if (id == Guid.Empty)
                throw new ArgumentNullException();
            var result = _lessonRepository.GetWithInclude(l => l.Disciplines.Id == id, l => l.Disciplines, l => l.LessonType);

            if (result is null)
                throw new ArgumentException();

            return _mapper.Map<List<LessonDto>>(result);
        }

    }
}
