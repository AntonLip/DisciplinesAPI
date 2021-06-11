using AutoMapper;
using DisciplinesAPI.Models.Interfaces;
using DisciplinesAPI.Models.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


//вопрос про как сделать так чтобы модели дто были разные на адейт эдд и ремув и т.д


namespace DisciplinesAPI.Services
{
    public abstract class BaseService<TModel, TModelDto, TModelAddDto, TModelUpdateDto> : IService<TModel, TModelDto, TModelAddDto, TModelUpdateDto, Guid>
        where TModelDto :  class, IEntityDto<Guid>
        where TModel : class, IEntity<Guid>
        where TModelAddDto : IEntityDto<Guid>
        where TModelUpdateDto : IEntityDto<Guid>
    {
        protected readonly IRepository<TModel, Guid> _repository;
        protected readonly IMapper _mapper;
        public BaseService(IRepository<TModel, Guid> repository,
                            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TModelDto> AddAsync(TModelAddDto modelDto, CancellationToken cancellationToken = default)
        {
            if (modelDto is null)
                throw new ArgumentNullException();

            var model = _mapper.Map<TModel>(modelDto);
            await _repository.AddAsync(model, cancellationToken);
            return _mapper.Map<TModelDto>(model);
        }

        public virtual async Task<IEnumerable<TModelDto>> GetAllAsync(int page, int count, CancellationToken cancellationToken = default)
        {
            if (count <= 0)
                count = 5;

            var listModelDto = await _repository.GetAllAsync(page, count, cancellationToken);

            return listModelDto is null ? throw new ArgumentException() : _mapper.Map<List<TModelDto>>(listModelDto);
        }

        public int GetCountEntity()
        {
            return _repository.GetCount();
        }

        public virtual async Task<TModelUpdateDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();

            var modelDto = await _repository.GetByIdAsync(id, cancellationToken);

            return modelDto is null ? throw new ArgumentException() : _mapper.Map<TModelUpdateDto>(modelDto);
        }

        public virtual async Task<TModelDto> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();

            var model = await _repository.GetByIdAsync(id, cancellationToken);

            if (model is null)
                throw new ArgumentException();


           model.IsDeleted = true;
           await _repository.UpdateAsync(model, cancellationToken);

            return _mapper.Map<TModelDto>(model);
        }

        public virtual async Task<TModelDto> UpdateAsync(Guid id, TModelUpdateDto modelDto, CancellationToken cancellationToken = default)
        {
            if (id != modelDto.Id)
                throw new ArgumentNullException();

            var model = _mapper.Map<TModel>(modelDto);

            await _repository.UpdateAsync(model, cancellationToken);

            return _mapper.Map<TModelDto>(model);
        }
    }
}
