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
            

            CreateMap<AddDisciplineDto, Disciplines>()
                .AfterMap((src,dest) =>
                {
                    dest.Id = Guid.NewGuid();
                    dest.ShortName = src.Name;
                });
            CreateMap<UpdateDisciplineDto, Disciplines>()
                .AfterMap((src, dest) =>
                {                   
                    dest.ShortName = src.Name;
                }).ReverseMap(); 
            CreateMap<Disciplines, DisciplineDto>()
                .AfterMap((src, dest) =>
                {
                    dest.Name = src.ShortName;
                });

            CreateMap<AddLessonDto, Lesson>()
                .AfterMap((src, dest) => 
                { 
                    dest.Id = Guid.NewGuid();
                });
            CreateMap<Lesson, LessonDto>()
                .ForMember(dto => dto.LessonType, conf => conf.MapFrom(ol => ol.LessonType.Name));
            CreateMap<UpdateLessonDto, Lesson>().ReverseMap();
            CreateMap<Lesson, LessonDto>()
            .ForMember(dto => dto.LessonType, conf => conf.MapFrom(ol => ol.LessonType.name));
        }
    }
}
