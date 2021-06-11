using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Models.Interfaces.Repository
{
    public  interface IDisciplinesRepository : IRepository<Disciplines,Guid>
    {
        Task AddFiles(Guid id, IFormFile body, string typeFile, CancellationToken cancellationToken = default);
    }
}
