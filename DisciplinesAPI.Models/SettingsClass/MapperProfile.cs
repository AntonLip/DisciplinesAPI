using AutoMapper;
using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.Disciplines;
using DisciplinesAPI.Models.DTOModels.Lesson;
using DisciplinesAPI.Models.DTOModels.LessonType;
using DisciplinesAPI.Models.DTOModels.Test;
using System;
using System.Collections.Generic;

namespace DisciplinesAPI.Models
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
                .ForMember(dest => dest.LessonType,
                    opt =>
                    {
                        opt.MapFrom<LessonTypeResolver>();
                    })
                .ForMember(dest => dest.Disciplines,
                    opt =>
                    {
                        opt.MapFrom<DisciplinesResolver>();
                    })
                .AfterMap((src, dest) => 
                    { 
                        dest.Id = Guid.NewGuid();
                    });
            CreateMap<Lesson, LessonDto>()
                .ForMember(dto => dto.LessonType, conf => conf.MapFrom(ol => ol.LessonType.Name));
            CreateMap<UpdateLessonDto, Lesson>().ReverseMap();
            CreateMap<Lesson, LessonDto>()
            .ForMember(dto => dto.LessonType, conf => conf.MapFrom(ol => ol.LessonType.Name));

            CreateMap<Questions, QuestionsDto>();
            CreateMap<AddQuestionDto, Questions>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                    foreach(var a in dest.Answers)
                    {
                        a.Questions = dest;
                    }
                });
            CreateMap<Answers, AnswerDto>().ReverseMap();
            CreateMap<AddAnswerDto,Answers >()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                });
            
        }
    }
}
