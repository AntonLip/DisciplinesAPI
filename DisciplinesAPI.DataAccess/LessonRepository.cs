using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public IEnumerable<Lesson> GetAllLessonInDisciplines(Guid disciplinesId, int page, int count, CancellationToken cancellationToken)
        {
            var result = _dbSet.Where(l => l.Disciplines.Id == disciplinesId)
                                .Include(l => l.LessonType)
                                .Skip(page * count).Take(count).ToList();
            return result;
        }

    }
}
