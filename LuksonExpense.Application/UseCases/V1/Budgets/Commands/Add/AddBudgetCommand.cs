using AutoMapper;
using LuksonExpense.Application.Abstractions.Authentication;
using LuksonExpense.Application.DTOs.MappingDtos.Budgets;
using LuksonExpense.Application.DTOs.Requests.Budgets;
using LuksonExpense.Domain.Models;
using LuksonExpense.Domain.Shared;
using LuksonExpense.Infrastructure.Interfaces;
using MediatR;
using System.Net;

namespace LuksonExpense.Application.UseCases.V1.Budgets.Commands.Add
{
    public sealed class AddBudgetCommand : IRequest<Response<BudgetDTO>>
    {
        public AddBudgetRequest Request { get; set; }
    }

    public sealed class AddBudgetCommandHandler(
        IMapper mapper, IBudgetRepository repository,
        AuthProvider authProvider) 
        : IRequestHandler<AddBudgetCommand, Response<BudgetDTO>>
    {
        public async Task<Response<BudgetDTO>> Handle(AddBudgetCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<BudgetDTO>();

            try
            {
                User loggedUser = await authProvider.GetCurrentUser();
                Budget newBudget = mapper.Map<Budget>(request.Request);
                newBudget.UserId = loggedUser.Id;
                newBudget.User = loggedUser;

                newBudget = await repository.Add(newBudget);

                response.StatusCode = HttpStatusCode.Created;
                response.Content = mapper.Map<BudgetDTO>(newBudget);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
