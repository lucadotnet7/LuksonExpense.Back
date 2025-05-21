using System.Net;
using LuksonExpense.Application.Abstractions.Authentication;
using LuksonExpense.Application.DTOs.Requests.Users;
using LuksonExpense.Application.DTOs.Responses.Authentication;
using LuksonExpense.Domain.Models;
using LuksonExpense.Domain.Shared;
using LuksonExpense.Infrastructure.Interfaces;
using MediatR;

namespace LuksonExpense.Application.UseCases.V1.Authentication.Queries.Login
{
    public sealed class UserLoginQuery : IRequest<Response<LoginRegisterResponse>>
    {
        public LoginUserRequest Request { get; set; }
    }

    public sealed class UserLoginQueryHandler(
        AuthProvider authProvider, IUserRepository userRepository,
        PwdHasher passwordHasher) 
        : IRequestHandler<UserLoginQuery, Response<LoginRegisterResponse>>
    {
        public async Task<Response<LoginRegisterResponse>> Handle(UserLoginQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<LoginRegisterResponse>();
            try
            {
                User? user = await userRepository.GetUserByEmail(request.Request.Email);

                //TODO: Por default estan todos los users active, debo implementar la validación por email.
                if (user == null || !user.IsActive)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Error = new ErrorResponse
                    {
                        ErrorMessages = new List<string> { $"El usuario con email: {request.Request.Email} no existe o no fue verificado." }
                    };

                    return response;
                }

                bool verified = passwordHasher.Verify(request.Request.Password, user.Password);

                if (!verified)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Error = new ErrorResponse
                    {
                        ErrorMessages = new List<string> { $"Ha ocurrido un error intentando loguear al usuario. Verifique sus datos e intente nuevamente." }
                    };

                    return response;
                }

                string token = authProvider.CreateToken(user);

                response.StatusCode = HttpStatusCode.OK;
                response.Content = new LoginRegisterResponse(token, DateTime.UtcNow);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
