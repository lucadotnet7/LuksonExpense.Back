using LuksonExpense.Application.DTOs.MappingDtos;
using LuksonExpense.Application.UseCases.V1.Budgets.Commands.Add;
using LuksonExpense.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LuksonExpenseAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class BudgetController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Add")]
        public async Task<ActionResult<Response<BudgetDTO>>> AddBudget(AddBudgetCommand request)
        {
            Response<BudgetDTO> result = await mediator.Send(request);
            return StatusCode((int)result.StatusCode, result.Content);
        }
    }
}
