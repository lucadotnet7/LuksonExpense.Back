using LuksonExpense.Application.DTOs.MappingDtos.Budgets;
using LuksonExpense.Application.UseCases.V1.Budgets.Commands.Add;
using LuksonExpense.Application.UseCases.V1.Budgets.Commands.Edit;
using LuksonExpense.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LuksonExpenseAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BudgetController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Add")]
        public async Task<ActionResult<Response<BudgetDTO>>> AddBudget(AddBudgetCommand request)
        {
            Response<BudgetDTO> result = await mediator.Send(request);
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<Response<BudgetDTO>>> UpdateBudget(EditBudgetCommand request)
        {
            Response<BudgetDTO> result = await mediator.Send(request);
            return StatusCode((int)result.StatusCode, result.Content);
        }
    }
}
