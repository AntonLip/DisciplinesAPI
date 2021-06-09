using AutoMapper;
using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.Lesson;
using DisciplinesAPI.Models.Interfaces.Repository;
using DisciplinesAPI.Models.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Services
{
    public class LessonService : BaseService<Lesson, LessonDto, AddLessonDto, UpdateLessonDto>, ILessonService

    {
        private readonly ILessonRepository _lessonRepository;
        public LessonService(ILessonRepository lessonRepository, IMapper mapper)
            : base(lessonRepository, mapper)
        {
            
            _lessonRepository = lessonRepository;
        }

        public Task AddFiles(Guid id, IFormFile body, string typeFile, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();
            if(body is null)
                throw new ArgumentNullException();

            return _lessonRepository.AddFiles(id, body, typeFile, cancellationToken);
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
