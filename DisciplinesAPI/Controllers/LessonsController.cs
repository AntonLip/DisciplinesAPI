using AutoMapper;
using DisciplinesAPI.Models.DTOModels;
using DisciplinesAPI.Models.DTOModels.Disciplines;
using DisciplinesAPI.Models.DTOModels.Lesson;
using DisciplinesAPI.Models.Interfaces;
using DisciplinesAPI.Models.Interfaces.Services;
using DisciplinesAPI.WebApi;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace DisciplinesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ExceptionFilter]
    [HttpModelResultFilter]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        [Route("discipline/{disciplineId:guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get all lesson", Type = typeof(ResultDto<List<LessonDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<LessonDto>>>> GetAllLessonInDiscipline(int count, int page, [FromRoute]Guid disciplineId)
        {
            return Ok(await _lessonService.GetAllLessonInDisciplines(page, count, disciplineId));
        }

        [HttpGet]
        [Route("{lessonId:guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get all lesson", Type = typeof(ResultDto<List<LessonDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<LessonDto>>>> GetLessonById( [FromRoute] Guid lessonId)
        {
            return Ok(await _lessonService.GetByIdAsync(lessonId));
        }
        [HttpDelete]
        [Route("{lessonId:guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get all lesson", Type = typeof(ResultDto<List<DisciplineDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<LessonDto>>>> DeleteLesson([FromRoute] Guid lessonId)
        {
            return Ok(await _lessonService.RemoveAsync(lessonId));
        }
        [HttpPut]
        [Route("{lessonId:guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get all lesson", Type = typeof(ResultDto<List<DisciplineDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<LessonDto>>>> UpdateLesson([FromRoute] Guid lessonId, [FromBody] UpdateLessonDto model)
        {
            return Ok(await _lessonService.UpdateAsync(lessonId, model));
        }
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get all lesson", Type = typeof(ResultDto<List<DisciplineDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<LessonDto>>>> AddLesson( [FromBody] AddLessonDto model)
        {
            return Ok(await _lessonService.AddAsync(model));
        }

    }
}
