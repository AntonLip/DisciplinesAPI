using AutoMapper;
using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.LessonType;
using DisciplinesAPI.Models.Interfaces.Repository;
using DisciplinesAPI.Models.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Services
{
    public class LessonTypeService : ILessonTypeService
    {
        private readonly IMapper _mapper;

        private readonly ILessonTypeRepository _lessonTypeRepository;

        public LessonTypeService(ILessonTypeRepository lessonTypeRepository, IMapper mapper)
        {
            _lessonTypeRepository = lessonTypeRepository;
            _mapper = mapper;
        }

        public async Task<LessonTypeDto> AddAsync(AddLessonTypeDto model, CancellationToken cancellationToken = default)
        {
            if (model is null)
                throw new ArgumentNullException();

            var newLessonType = _mapper.Map<LessonType>(model);

            await _lessonTypeRepository.AddAsync(newLessonType);

            return _mapper.Map<LessonTypeDto>(newLessonType);
        }

        public async Task<IEnumerable<LessonTypeDto>> GetAllAsync(int page, int count, CancellationToken cancellationToken = default)
        {
            if (count == 0)
            {
                count = 5;
            }
            var result = await _lessonTypeRepository.GetAllAsync(page, count);

            return result is null ? throw new ArgumentNullException() : _mapper.Map<List<LessonTypeDto>>(result);
        }

        public async Task<LessonTypeDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();
            
            var result = await _lessonTypeRepository.GetByIdAsync(id);

            return result is null ? throw new ArgumentNullException() : _mapper.Map<LessonTypeDto>(result);
        }

        public async Task<LessonTypeDto> Remove(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();
            var delLessonType = await _lessonTypeRepository.GetByIdAsync(id);
            if (delLessonType is null)
                throw new ArgumentException();

             _lessonTypeRepository.RemoveAsync(delLessonType);

            return _mapper.Map<LessonTypeDto>(delLessonType);
        }

        public async Task<LessonTypeDto> UpdateAsync(LessonTypeDto model, CancellationToken cancellationToken = default)
        {
            if (model is null)
                throw new ArgumentNullException();

            await _lessonTypeRepository.UpdateAsync(_mapper.Map<LessonType>(model));
            return model;
        }
    }
}
