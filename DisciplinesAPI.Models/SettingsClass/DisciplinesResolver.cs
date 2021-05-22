using AutoMapper;
using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels.Lesson;
using DisciplinesAPI.Models.Interfaces.Repository;
using System;

namespace DisciplinesAPI.Models
{
    internal class DisciplinesResolver : IValueResolver<AddLessonDto, Lesson, Disciplines>
    {
        private readonly IDisciplinesRepository _disciplinesRepository;

        public DisciplinesResolver(IDisciplinesRepository disciplinesRepository)
        {
            _disciplinesRepository = disciplinesRepository;
        }
        Disciplines IValueResolver<AddLessonDto, Lesson, Disciplines>.Resolve(AddLessonDto source, Lesson destination, Disciplines destMember, ResolutionContext context)
        {
            try
            {
                var disciplines = _disciplinesRepository.GetByIdAsync(source.DisciplineId).Result;
                return disciplines;
            }
            catch 
            {
                return new Disciplines(); ;
            }
        }
    }
}