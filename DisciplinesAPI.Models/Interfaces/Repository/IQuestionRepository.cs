using DisciplinesAPI.Models.DBModels;
using System;
using System.Threading.Tasks;

namespace DisciplinesAPI.Models.Interfaces.Repository
{
    public interface IQuestionRepository : IRepository<Questions, Guid>
    {
        
    }
}
