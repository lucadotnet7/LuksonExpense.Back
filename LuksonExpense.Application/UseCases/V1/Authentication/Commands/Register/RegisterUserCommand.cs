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
                User? existUser = await userRepository.GetUserByEmail(request.Request.Email);

                if (existUser != null)
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

                await userRepository.CreateUser(user);

                string token = authProvider.CreateToken(user);

                response.StatusCode = HttpStatusCode.Created;
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
