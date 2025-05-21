using LuksonExpense.Application.DTOs.MappingDtos.Budgets;
using LuksonExpense.Application.UseCases.V1.Budgets.Commands.Add;
using LuksonExpense.Application.UseCases.V1.Budgets.Commands.Delete;
using LuksonExpense.Application.UseCases.V1.Budgets.Commands.Edit;
using LuksonExpense.Application.UseCases.V1.Budgets.Queries.GetById;
using LuksonExpense.Application.UseCases.V1.Budgets.Queries.GetList;
using LuksonExpense.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LuksonExpenseAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BudgetController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetById")]
        public async Task<ActionResult<Response<BudgetDTO>>> GetById(Guid budgetId)
        {
            Response<BudgetDTO> result = await mediator.Send(new GetBudgetByIdQuery { BudgetId = budgetId });
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpGet("List")]
        public async Task<ActionResult<Response<IEnumerable<BudgetDTO>>>> GetList()
        {
            Response<IEnumerable<BudgetDTO>> result = await mediator.Send(new GetBudgetListQuery());
            return StatusCode((int)result.StatusCode, result.Content);
        }

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

        [HttpDelete("Delete")]
        public async Task<ActionResult<Unit>> DeleteBudget(Guid budgetId)
            => await mediator.Send(new DeleteBudgetCommand { BudgetId = budgetId });
    }
}
