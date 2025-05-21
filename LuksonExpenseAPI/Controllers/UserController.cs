using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LuksonExpenseAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController(IMediator mediator) : ControllerBase
    {
    }
}
