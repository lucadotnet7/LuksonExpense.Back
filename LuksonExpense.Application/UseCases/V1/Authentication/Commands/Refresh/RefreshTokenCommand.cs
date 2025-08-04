using System.Net;
using AutoMapper;
using LuksonExpense.Application.Abstractions.Authentication;
using LuksonExpense.Application.DTOs.Requests.Users;
using LuksonExpense.Application.DTOs.Responses.Authentication;
using LuksonExpense.Domain.Models;
using LuksonExpense.Domain.Shared;
using LuksonExpense.Infrastructure.Interfaces;
using MediatR;

namespace LuksonExpense.Application.UseCases.V1.Authentication.Commands.Refresh
{
    public sealed class RefreshTokenCommand : IRequest<Response<LoginRegisterResponse>>
    {
        public RefreshTokenRequest Request { get; set; }
    }

    public sealed class RefreshTokenCommandHandler(
        IMapper mapper, IUserRepository userRepository,
        AuthProvider authProvider, PwdHasher passwordHasher)
        : IRequestHandler<RefreshTokenCommand, Response<LoginRegisterResponse>>
    {
        public async Task<Response<LoginRegisterResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<LoginRegisterResponse>();

            try
            {
                User? user = await userRepository.GetUserByEmail(request.Request.Email);

                if (user == null)
                {
                    response.StatusCode = HttpStatusCode.Unauthorized;
                    response.Error = new ErrorResponse
                    {
                        ErrorMessages = new List<string> { "Correo electrónico incorrecto." }
                    };

                    return response;
                }

                if (user.AccessToken != request.Request.AccessToken || user.RefreshToken != request.Request.RefreshToken)
                {
                    response.StatusCode = HttpStatusCode.Unauthorized;
                    response.Error = new ErrorResponse
                    {
                        ErrorMessages = new List<string> { "Ha ocurrido un error intentando actualizar el accessToken." }
                    };

                    return response;
                }

                (string accessToken, DateTime expirationToken) = authProvider.CreateToken(user);
                user.AccessToken = accessToken;
                user.ExpirationToken = expirationToken;
                user.RefreshToken = Guid.NewGuid();

                await userRepository.UpdateUser(user);

                response.StatusCode = HttpStatusCode.OK;
                response.Content = new LoginRegisterResponse(accessToken, DateTime.UtcNow, expirationToken, user.RefreshToken);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
