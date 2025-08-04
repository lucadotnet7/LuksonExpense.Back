using System.Net;
using AutoMapper;
using LuksonExpense.Application.Abstractions.Authentication;
using LuksonExpense.Application.DTOs.Requests.Users;
using LuksonExpense.Application.DTOs.Responses.Authentication;
using LuksonExpense.Domain.Models;
using LuksonExpense.Domain.Shared;
using LuksonExpense.Infrastructure.Interfaces;
using MediatR;

namespace LuksonExpense.Application.UseCases.V1.Authentication.Commands.Register
{
    public sealed class RegisterUserCommand : IRequest<Response<LoginRegisterResponse>>
    {
        public RegisterUserRequest Request { get; set; }
    }

    public sealed class RegisterUserCommandHandler(
        IMapper mapper, IUserRepository userRepository, 
        AuthProvider authProvider, PwdHasher passwordHasher) 
        : IRequestHandler<RegisterUserCommand, Response<LoginRegisterResponse>>
    {
        public async Task<Response<LoginRegisterResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<LoginRegisterResponse>();

            try
            {
                if (await EmailAlreadyExists(request.Request.Email))
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Error = new ErrorResponse
                    {
                        ErrorMessages = new List<string> { $"El correo electrónico {request.Request.Email} ya se encuentra en uso." }
                    };

                    return response;
                }

                User user = mapper.Map<User>(request.Request);
                user.Password = passwordHasher.HashPassword(request.Request.Password);

                (string accessToken, DateTime expirationToken) = authProvider.CreateToken(user);

                user.AccessToken = accessToken;
                user.ExpirationToken = expirationToken;

                await userRepository.CreateUser(user);

                response.StatusCode = HttpStatusCode.Created;
                response.Content = new LoginRegisterResponse(accessToken, DateTime.UtcNow, expirationToken, user.RefreshToken);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<bool> EmailAlreadyExists(string email) 
        {
            User? existUser = await userRepository.GetUserByEmail(email);

            if (existUser != null)
                return true;

            return false;
        }
    }
}
