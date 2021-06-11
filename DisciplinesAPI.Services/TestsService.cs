using DisciplinesAPI.Models.DTOModels.Test;
using DisciplinesAPI.Models.Interfaces.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Services
{
    public class TestsService : ITestsService
    {
        public Task<int> CheckTet(TestDto model, CancellationToken canselationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<TestDto> GetTet(CancellationToken canselationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
