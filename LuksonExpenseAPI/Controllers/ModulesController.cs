using LuksonExpense.Application.DTOs.Modules;
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
        public async Task<Response<ModuleListResponse>> GetModules()
            => await _mediator.Send(new GetModuleListQuery());

        [HttpPost("Add")]
        public async Task<Response<ModuleDTO>> AddModule(AddModuleCommand command)
            => await _mediator.Send(command);
    }
}
