using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.Interfaces.Repository;

namespace DisciplinesAPI.DataAccess
{
    public class LessonTypeRepository : BaseRepository<LessonType>, ILessonTypeRepository
    {
        public LessonTypeRepository(AppDbContext context)
           : base(context)
        {

        }
    }
}
