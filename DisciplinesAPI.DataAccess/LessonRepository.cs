using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.Interfaces.Repository;

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