using LuksonExpense.Application.DTOs.MappingDtos;
using LuksonExpense.Application.DTOs.Responses.Modules;
using LuksonExpense.Application.UseCases.V1.Modules.Commands.Add;
using LuksonExpense.Application.UseCases.V1.Modules.Queries.List;
using LuksonExpense.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LuksonExpenseAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ModulesController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("List")]
        public async Task<ActionResult<Response<ModuleListResponse>>> GetModules()
        {
            Response<ModuleListResponse> result = await _mediator.Send(new GetModuleListQuery());
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Response<ModuleDTO>>> AddModule(AddModuleCommand command)
        {
            Response<ModuleDTO> result = await _mediator.Send(command);
            return StatusCode((int)result.StatusCode, result.Content);
        }
    }
}
