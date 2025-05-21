using System.Net;
using LuksonExpense.Application.DTOs.MappingDtos.Modules;
using LuksonExpense.Application.DTOs.Responses.Modules;
using LuksonExpense.Application.UseCases.V1.Modules.Commands.Add;
using LuksonExpense.Application.UseCases.V1.Modules.Queries.List;
using LuksonExpense.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LuksonExpenseAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ModulesController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("List")]
        public async Task<ActionResult<Response<ModuleListResponse>>> GetModules()
        {
            Response<ModuleListResponse> result = await _mediator.Send(new GetModuleListQuery());
            if (result.StatusCode != HttpStatusCode.OK)
                return StatusCode((int)result.StatusCode, result.Error);
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Response<ModuleDTO>>> AddModule(AddModuleCommand command)
        {
            Response<ModuleDTO> result = await _mediator.Send(command);
            if (result.StatusCode != HttpStatusCode.Created)
                return StatusCode((int)result.StatusCode, result.Error);
            return StatusCode((int)result.StatusCode, result.Content);
        }
    }
}
