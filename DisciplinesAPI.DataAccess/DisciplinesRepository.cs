
using DisciplinesAPI.Models;
using DisciplinesAPI.Models.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.DataAccess
{
    public class DisciplinesRepository : BaseRepository<Disciplines>, IDisciplinesRepository
    {
        public DisciplinesRepository(AppDbContext context)
            : base(context)
        {
            
        }
        public async Task AddFiles(Guid id, IFormFile body, string typeFile, CancellationToken cancellationToken = default)
        {
            var discipline = _dbSet.Where(c => c.Id == id).FirstOrDefault();
            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await body.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }
            if (discipline != null)
            {
                switch (typeFile)
                {
                    case "gpid":
                        discipline.GPID = fileBytes;
                        break;
                    case "plan":
                        discipline.Plan = fileBytes;
                        discipline.DateOfPlan = DateTime.Now;
                        break;
                    default:
                        throw new ArgumentException();
                }
                _context.Entry(discipline).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}