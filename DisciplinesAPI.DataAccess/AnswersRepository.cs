using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.Interfaces.Repository;

namespace DisciplinesAPI.DataAccess
{
    public  class AnswersRepository : BaseRepository<Answers>, IAnswersRepository
    {
        public AnswersRepository(AppDbContext context)
            : base(context)
        {

        }
    }
}
