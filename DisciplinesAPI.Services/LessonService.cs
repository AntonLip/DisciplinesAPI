using AutoMapper;
using DisciplinesAPI.Models.DBModels;
using DisciplinesAPI.Models.DTOModels;
using DisciplinesAPI.Models.DTOModels.Lesson;
using DisciplinesAPI.Models.Interfaces.Repository;
using DisciplinesAPI.Models.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DisciplinesAPI.Services
{
    public class LessonService : BaseService<Lesson, LessonDto, AddLessonDto, UpdateLessonDto>, ILessonService

    {
        private readonly ILessonRepository _lessonRepository;
        public LessonService(ILessonRepository lessonRepository, IMapper mapper)
            : base(lessonRepository, mapper)
        {            
            _lessonRepository = lessonRepository;
        }

        public Task AddFiles(Guid id, IFormFile body, string typeFile, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();
            if(body is null)
                throw new ArgumentNullException();

            return _lessonRepository.AddFiles(id, body, typeFile, cancellationToken);
   }

        public  IEnumerable<LessonDto> GetAllLessonInDisciplinesAsync(int page, int count, Guid id, CancellationToken cancellationToken = default)
        {

            if (count <= 0)
                count = 5;
            if (id == Guid.Empty)
                throw new ArgumentNullException();
            var result = _lessonRepository.GetWithInclude(l => l.Disciplines.Id == id, l => l.Disciplines, l => l.LessonType);

            if (result is null)
                throw new ArgumentException();

            return _mapper.Map<List<LessonDto>>(result);
        }

        public async Task<FileDto> GetFiles(Guid id, string typeFile, CancellationToken cancellationToken = default)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();

            var lesson =  _lessonRepository.GetWithInclude(l => l.Id == id, l => l.LessonType).Find(l => l.Id == id);         

            if (lesson is null)
                throw new ArgumentNullException();

            FileDto fileDto = new FileDto();
            
            
            switch (typeFile)
            {
                case "methodic":
                    fileDto.FileBytes = lesson.MethodicMaterials;
                    fileDto.FileType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    fileDto.FileName = string.Format("{0} {1}.docx", lesson.LessonType.Name, lesson.CurrentNumberOflessonsType);
                    break;
                case "presentation":
                    fileDto.FileBytes = lesson.Presentation;
                    fileDto.FileType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                    fileDto.FileName = string.Format("{0} {1}.pptx", lesson.LessonType, lesson.CurrentNumberOflessonsType);
                    break;
                case "additional":
                    fileDto.FileBytes = lesson.AdditionalMaterial;
                    fileDto.FileType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    fileDto.FileName = string.Format("{0} {1}.docx", lesson.LessonType, lesson.CurrentNumberOflessonsType);
                    break;
                default:
                    throw new ArgumentException();
            }
            return fileDto;
        }
    }
}
