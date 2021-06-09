using DisciplinesAPI.Models.DBModels;
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
    public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(AppDbContext context)
            : base(context)
        {

        }

        public async Task AddFiles(Guid id, IFormFile body, string typeFile, CancellationToken cancellationToken = default)
        {
            var lesson = _dbSet.Where(c => c.Id == id).FirstOrDefault();
            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await body.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }
            if (lesson != null)
            {
                switch (typeFile)
                {
                    case "methodic":
                        lesson.MethodicMaterials = fileBytes;
                        break;
                    case "presentation":
                        lesson.Presentation = fileBytes;
                        break;
                    case "additional":
                        lesson.AdditionalMaterial = fileBytes;
                        break;
                    default:
                         throw new  ArgumentException();
                }
                _context.Entry(lesson).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}