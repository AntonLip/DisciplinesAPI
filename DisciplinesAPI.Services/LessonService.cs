using AutoMapper;
using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.Lesson;
using DisciplinesAPI.Models.Interfaces;
using DisciplinesAPI.Models.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Services
{
    public class LessonService : ILessonService

    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public LessonService(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }
        public async Task<LessonDto> AddAsync(AddLessonDto model, CancellationToken cancellationToken = default)
        {
            if (model is null)
                throw new ArgumentNullException();

            var newLesson = _mapper.Map<Lesson>(model);

            await _lessonRepository.AddAsync(newLesson);

            return _mapper.Map<LessonDto>(newLesson);
        }

        public async Task<IEnumerable<LessonDto>> GetAllAsync(int page, int count, CancellationToken cancellationToken = default)
        {
            if (count <= 0)
                count = 5;
            var result = await _lessonRepository.GetAllAsync(page, count);

            return result is null ? throw new ArgumentException() : _mapper.Map<List<LessonDto>>(result);
        }

        public async Task<IEnumerable<LessonDto>> GetAllLessonInDisciplines(int page, int count, Guid id, CancellationToken cancellationToken = default)
        {
            if (count <= 0)
                count = 5;
            if (id == Guid.Empty)
                throw new ArgumentNullException();
            var result =  _lessonRepository.Get(l => l.Disciplines.Id == id);
            if (result is null)
                throw new ArgumentException();

            return _mapper.Map<List<LessonDto>>(result);
        }

        public async Task<LessonDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();
            var result = await _lessonRepository.GetByIdAsync(id);

            return result is null ? throw new ArgumentException() : _mapper.Map<LessonDto>(result);
        }

        public async Task<LessonDto> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();
            var result = await _lessonRepository.GetByIdAsync(id);

            if (result is null)
                throw new ArgumentException();

            _lessonRepository.RemoveAsync(result);

            return _mapper.Map<LessonDto>(result);
        }

        public async Task<LessonDto> UpdateAsync(Guid id, UpdateLessonDto model, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();


            if (model is null)
                throw new ArgumentException();

            if (id != model.Id)
                throw new ArgumentException();

            var updateLesson = _mapper.Map<Lesson>(model);

            await _lessonRepository.UpdateAsync(updateLesson);

            return _mapper.Map<LessonDto>(updateLesson);
        }
    }
}
