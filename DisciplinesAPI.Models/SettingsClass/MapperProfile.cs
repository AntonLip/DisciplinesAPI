using AutoMapper;
using DisciplinesAPI.Models;
using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.Disciplines;
using DisciplinesAPI.Models.DTOModels.Lesson;
using DisciplinesAPI.Models.DTOModels.LessonType;
using System;

namespace TimetibleMicroservices.Models
{
    class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<LessonTypeDto, LessonType>().ReverseMap();
            CreateMap<AddLessonTypeDto, LessonType>().AfterMap((src,dest) => { dest.Id = Guid.NewGuid(); });

            CreateMap<AddDisciplineDto, Disciplines>().AfterMap((src,dest) => { dest.Id = Guid.NewGuid(); });
            CreateMap<UpdateDisciplineDto, Disciplines>().ReverseMap(); 
            CreateMap<Disciplines, DisciplineDto>().AfterMap((src, dest) => { dest.Name = src.ShortName; });

            CreateMap<AddLessonDto, Lesson>().AfterMap((src, dest) => { dest.Id = Guid.NewGuid(); });
            CreateMap<UpdateLessonDto, Lesson>().ReverseMap();
        }
    }
}
