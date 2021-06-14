using DisciplinesAPI.Models.DTOModels;
using DisciplinesAPI.Models.DTOModels.Test;
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
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsService _questionService;
        public QuestionsController(IQuestionsService questionService)
        {
            _questionService = questionService;            
        }
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get all Question", Type = typeof(ResultDto<List<QuestionsDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<QuestionsDto>>>> GetAll(int count, int page)
        {
            return Ok(await _questionService.GetAllAsync(page, count));
        }

        [HttpGet]
        [Route("Test/{disciplineId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get test", Type = typeof(ResultDto<List<QuestionsDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<List<QuestionsDto>>>> GetTest(Guid disciplineId, int countQuestions)
        {
            return Ok(await _questionService.GetTest(disciplineId, countQuestions));
        }

        [HttpGet]
        [Route("{questionId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get Question by id", Type = typeof(ResultDto<List<QuestionsDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<QuestionsDto>>>> GetById([FromRoute] Guid questionId)
        {
            return Ok(await _questionService.GetByIdAsync(questionId));
        }
        
        [HttpDelete]
        [Route("{questionId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Delete question by id", Type = typeof(ResultDto<List<QuestionsDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<QuestionsDto>>>> RemoveQuestion([FromRoute] Guid questionId)
        {
            return Ok(await _questionService.RemoveAsync(questionId));
        }

        [HttpPut]
        [Route("{questionId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "update question", Type = typeof(ResultDto<List<QuestionsDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<QuestionsDto>>>> UpdateQuestion([FromRoute] Guid questionId, [FromBody] AddQuestionDto model)
        {
            return Ok(await _questionService.UpdateAsync(questionId, model));
        }
        
        
        
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Add Question ", Type = typeof(ResultDto<QuestionsDto>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<QuestionsDto>>> AddQuestion([FromBody] AddQuestionDto model)
        {

            return Ok(await _questionService.AddAsync(model));
        }
        [HttpPost]
        [Route("CheckTest")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Add Question ", Type = typeof(ResultDto<int>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<int>>> CheckTest([FromBody] List<QuestionsDto> model)
        {
            return Ok( _questionService.CheckTest(model));
        }

    }
}
