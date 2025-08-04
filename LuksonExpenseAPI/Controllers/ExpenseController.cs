using LuksonExpense.Domain.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LuksonExpenseAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ExpenseController : ControllerBase
    {
        //[HttpPost("Create")]
        //public async Task<ActionResult<Response<>>> CreateExpense(Guid budgetId)
        //{
        //    return Ok();
        //}
    }
}
