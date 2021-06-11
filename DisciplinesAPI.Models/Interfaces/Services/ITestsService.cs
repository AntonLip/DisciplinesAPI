using DisciplinesAPI.Models.DTOModels.Test;

using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Models.Interfaces.Services
{
    public interface ITestsService
    {
        Task<int> CheckTet(TestDto model, CancellationToken canselationToken = default);
        Task<TestDto> GetTet(CancellationToken canselationToken = default);
    }
}
