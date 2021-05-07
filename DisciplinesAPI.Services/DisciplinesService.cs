using AutoMapper;
using DisciplinesAPI.Models;
using DisciplinesAPI.Models.DTOModels.Disciplines;
using DisciplinesAPI.Models.Interfaces;
using DisciplinesAPI.Models.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Services
{
    public class DisciplinesService : IDisciplinesService
    {
        private readonly IDisciplinesRepository _disciplinesRepository;
        private readonly IMapper _mapper;
        public DisciplinesService(IDisciplinesRepository disciplinesRepository,
            IMapper mapper)
        {
            _disciplinesRepository = disciplinesRepository;
            _mapper = mapper;
        }

        public async Task<DisciplineDto> AddAsync(AddDisciplineDto model, CancellationToken cancellationToken = default)
        {
            if (model is null)
                throw new ArgumentNullException();

            var newDiscipline = _mapper.Map<Disciplines>(model);
            await _disciplinesRepository.AddAsync(newDiscipline);
            return _mapper.Map<DisciplineDto>(newDiscipline);
        }

        public async Task<IEnumerable<DisciplineDto>> GetAllAsync(int page, int count, CancellationToken cancellationToken = default)
        {
            var disciplines = await _disciplinesRepository.GetAllAsync(page, count);

            return disciplines is null ? throw new ArgumentException() : _mapper.Map<List<DisciplineDto>>(disciplines);
        }

        public async Task<DisciplineDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var disciplines = await _disciplinesRepository.GetByIdAsync(id);

            return disciplines is null ? throw new ArgumentException() : _mapper.Map<DisciplineDto>(disciplines);
        }

        public async Task<DisciplineDto> UpdateAsync(UpdateDisciplineDto model, CancellationToken cancellationToken = default)
        {
            if (model is null)
                throw new ArgumentNullException();

            var updateDiscipline = _mapper.Map<Disciplines>(model);
            await _disciplinesRepository.UpdateAsync(updateDiscipline);
            return _mapper.Map<DisciplineDto>(updateDiscipline);
        }

        public async Task<DisciplineDto> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();

            var delDescipline = await _disciplinesRepository.GetByIdAsync(id);
            
            if (delDescipline is null)
                throw new ArgumentNullException();

            _disciplinesRepository.RemoveAsync(delDescipline);

            return _mapper.Map<DisciplineDto>(delDescipline);
        }

    }
}
