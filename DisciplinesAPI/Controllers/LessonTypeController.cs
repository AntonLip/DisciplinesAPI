using DisciplinesAPI.Models.DTOModels;
using DisciplinesAPI.Models.DTOModels.Disciplines;
using DisciplinesAPI.Models.DTOModels.LessonType;
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
    [Route("api/[controller]/")]
    [ApiController]

    [ExceptionFilter]
    [HttpModelResultFilter]
    public class LessonTypeController : ControllerBase
    {
        private readonly ILessonTypeService _lessonTypeService;
        public LessonTypeController(ILessonTypeService lessonTypeService)
        {
            _lessonTypeService = lessonTypeService;
        }
        

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get all lesson type", Type = typeof(ResultDto<List<LessonTypeDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<DisciplineDto>>>> GetAllLessonTypes(int count, int page)
        {
            return Ok(await _lessonTypeService.GetAllAsync(page, count));
        }
        [HttpGet]
        [Route("{lessonTypeId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get lesson type by id", Type = typeof(ResultDto<List<LessonTypeDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<DisciplineDto>>>> GetLessonTypesById([FromRoute]Guid lessonTypeId)
        {
            return Ok(await _lessonTypeService.GetByIdAsync(lessonTypeId));
        }
        [HttpDelete]
        [Route("{lessonTypeId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Remove lesson type", Type = typeof(ResultDto<List<LessonTypeDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<DisciplineDto>>>> RemoveLessonTypes([FromRoute] Guid lessonTypeId)
        {
            return Ok (await _lessonTypeService.RemoveAsync(lessonTypeId));
        }

        [HttpPut]
        [Route("{lessonTypeId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Remove lesson type", Type = typeof(ResultDto<List<LessonTypeDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<DisciplineDto>>>> UpdateLessonTypes([FromRoute] Guid lessonTypeId, [FromBody] LessonTypeDto model)
        {

            return Ok(await _lessonTypeService.UpdateAsync(lessonTypeId, model));
        }
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Remove lesson type", Type = typeof(ResultDto<List<LessonTypeDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<DisciplineDto>>>> AddLessonTypes(LessonTypeDto model)
        {
            return Ok(await _lessonTypeService.AddAsync(model));
        }
    }
}
