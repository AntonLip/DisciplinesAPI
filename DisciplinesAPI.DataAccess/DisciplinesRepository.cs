using DisciplinesAPI.Models;
using DisciplinesAPI.Models.Interfaces;

namespace DisciplinesAPI.DataAccess
{
    public class DisciplinesRepository : BaseRepository<Disciplines>, IDisciplinesRepository
    {
        public DisciplinesRepository(AppDbContext context)
            : base(context)
        {

        }
    }
}
