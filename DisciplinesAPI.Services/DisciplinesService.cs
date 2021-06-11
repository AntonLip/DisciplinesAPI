using AutoMapper;
using DisciplinesAPI.Models;
using DisciplinesAPI.Models.DTOModels;
using DisciplinesAPI.Models.DTOModels.Disciplines;
using DisciplinesAPI.Models.Interfaces.Repository;
using DisciplinesAPI.Models.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Services
{
    public class DisciplinesService : BaseService<Disciplines, DisciplineDto, AddDisciplineDto, UpdateDisciplineDto>, IDisciplinesService
    {
        private readonly IDisciplinesRepository _disciplinesRepository;
        public DisciplinesService(IDisciplinesRepository disciplinesRepository,  IMapper mapper)
           : base(disciplinesRepository, mapper)
        {
            _disciplinesRepository = disciplinesRepository;
        }
        public Task AddFiles(Guid id, IFormFile body, string typeFile, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();
            if (body is null)
                throw new ArgumentNullException();

            return _disciplinesRepository.AddFiles(id, body, typeFile, cancellationToken);
        }
        public async Task<FileDto> GetFiles(Guid id, string typeFile, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();

            var discipline =await _disciplinesRepository.GetByIdAsync(id, cancellationToken);

            if (discipline is null)
                throw new ArgumentNullException();

            FileDto fileDto = new FileDto();
            fileDto.FileType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

            switch (typeFile)
            {
                case "plan":
                    fileDto.FileBytes = discipline.Plan;                    
                    fileDto.FileName = string.Format("Учебная программа по {0}.docx", discipline.ShortName);
                    break;
                case "gpid":
                    fileDto.FileBytes = discipline.GPID;
                    fileDto.FileName = string.Format("ГПИД по {0}.pptx", discipline.ShortName);
                    break;
                default:
                    throw new ArgumentException();
            }
            return fileDto;
        }
    
}
}
