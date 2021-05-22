using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.Interfaces.Repository;


namespace DisciplinesAPI.DataAccess
{
    public class QuestionsRepository : BaseRepository<Questions>, IQuestionRepository
    {
        public QuestionsRepository(AppDbContext context)
            : base(context)
        {

        }
    }
}
