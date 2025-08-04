using System.Net;
using LuksonExpense.Application.DTOs.Responses.Authentication;
using LuksonExpense.Application.UseCases.V1.Authentication.Commands.Refresh;
using LuksonExpense.Application.UseCases.V1.Authentication.Commands.Register;
using LuksonExpense.Application.UseCases.V1.Authentication.Queries.Login;
using LuksonExpense.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LuksonExpenseAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController(IMediator mediator) : ControllerBase
    {

        [HttpPost("Register")]
        public async Task<ActionResult<Response<LoginRegisterResponse>>> Register(RegisterUserCommand request)
        {
            Response<LoginRegisterResponse> result = await mediator.Send(request);
            if (result.StatusCode != HttpStatusCode.Created)
                return StatusCode((int)result.StatusCode, result.Error);
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<Response<LoginRegisterResponse>>> Login(UserLoginQuery request)
        {
            Response<LoginRegisterResponse> result = await mediator.Send(request);
            if (result.StatusCode != HttpStatusCode.OK)
                return StatusCode((int)result.StatusCode, result.Error);
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpPost("Refresh")]
        public async Task<ActionResult<Response<LoginRegisterResponse>>> RefreshToken(RefreshTokenCommand request)
        {
            Response<LoginRegisterResponse> result = await mediator.Send(request);
            if (result.StatusCode != HttpStatusCode.OK)
                return StatusCode((int)result.StatusCode, result.Error);
            return StatusCode((int)result.StatusCode, result.Content);
        }
    }
}
