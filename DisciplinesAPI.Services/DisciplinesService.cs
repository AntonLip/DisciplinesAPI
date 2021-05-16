using AutoMapper;
using DisciplinesAPI.Models;
using DisciplinesAPI.Models.DTOModels.Disciplines;
using DisciplinesAPI.Models.Interfaces;
using DisciplinesAPI.Models.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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
