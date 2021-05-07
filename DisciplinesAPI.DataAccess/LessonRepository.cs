using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.Interfaces;

namespace DisciplinesAPI.DataAccess
{
    public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(AppDbContext context) 
            : base(context)
        {

        }
    }
}
