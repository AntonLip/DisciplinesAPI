using AutoMapper;
using DisciplinesAPI.Models;
using DisciplinesAPI.Models.DTOModels.Disciplines;
using DisciplinesAPI.Models.Interfaces.Repository;
using DisciplinesAPI.Models.Interfaces.Services;


namespace DisciplinesAPI.Services
{
    public class DisciplinesService : BaseService<Disciplines, DisciplineDto, AddDisciplineDto, UpdateDisciplineDto>, IDisciplinesService
    {        
        public DisciplinesService(IDisciplinesRepository disciplinesRepository,  IMapper mapper)
           : base(disciplinesRepository, mapper)
        {
            
        }       

    }
}
