using DisciplinesAPI.Models.DTOModels;
using DisciplinesAPI.Models.DTOModels.Disciplines;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Models.Interfaces.Services
{
    public interface IDisciplinesService : IService<Disciplines, DisciplineDto, AddDisciplineDto, UpdateDisciplineDto, Guid>
    {
        Task AddFiles(Guid id, IFormFile body, string typeFile, CancellationToken cancellationToken = default);
        Task<FileDto> GetFiles(Guid id, string typeFile, CancellationToken cancellationToken = default);
    }
}
