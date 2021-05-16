using DisciplinesAPI.Models.DTOModels.Disciplines;
using System;

namespace DisciplinesAPI.Models.Interfaces.Services
{
    public interface IDisciplinesService : IService<Disciplines, DisciplineDto, AddDisciplineDto, UpdateDisciplineDto, Guid>
    {
       
    }
}
