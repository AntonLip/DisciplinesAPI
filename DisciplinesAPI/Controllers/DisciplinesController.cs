﻿using DisciplinesAPI.Models.DTOModels;
using DisciplinesAPI.Models.DTOModels.Disciplines;
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
    public class DisciplinesController : ControllerBase
    {
        private readonly IDisciplinesService _disciplinesService;


        public DisciplinesController(IDisciplinesService disciplinesService)
        {
            _disciplinesService = disciplinesService;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get all disciplines", Type = typeof(ResultDto<List<DisciplineDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<DisciplineDto>>>> GetAllDisciplines(int count, int page)
        {
            return Ok(await _disciplinesService.GetAllAsync(page, count));
        }

        [HttpGet]
        [Route("{disciplinesId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get discipline by id", Type = typeof(ResultDto<List<DisciplineDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<DisciplineDto>>>> GetDisciplineById([FromRoute]Guid disciplinesId)
        {
            return Ok(await _disciplinesService.GetByIdAsync(disciplinesId));
        }

        [HttpDelete]
        [Route("{disciplinesId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get discipline by id", Type = typeof(ResultDto<List<DisciplineDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<DisciplineDto>>>> RemoveDiscipline([FromRoute] Guid disciplinesId)
        {
            return Ok(await _disciplinesService.RemoveAsync(disciplinesId));
        }

        [HttpPut]
        [Route("{disciplinesId:Guid}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get discipline by id", Type = typeof(ResultDto<List<DisciplineDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<DisciplineDto>>>> UpdateDiscipline([FromRoute] Guid disciplinesId,[FromBody] UpdateDisciplineDto model)
        {           
            return Ok(await _disciplinesService.UpdateAsync(disciplinesId, model));
        }
        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Get discipline by id", Type = typeof(ResultDto<List<DisciplineDto>>))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<ResultDto<IEnumerable<DisciplineDto>>>> AddDiscipline([FromBody] AddDisciplineDto model)
        {
            
            return Ok(await _disciplinesService.AddAsync(model));
        }
    }
}
