using System.Net;
using AutoMapper;
using LuksonExpense.Application.Abstractions.Authentication;
using LuksonExpense.Application.DTOs.MappingDtos.Budgets;
using LuksonExpense.Domain.Models;
using LuksonExpense.Domain.Shared;
using LuksonExpense.Infrastructure.Interfaces;
using MediatR;

namespace LuksonExpense.Application.UseCases.V1.Budgets.Queries.GetList
{
    public sealed class GetBudgetListQuery : IRequest<Response<IEnumerable<BudgetDTO>>>
    {
    }

    public sealed class GetBudgetListQueryHandler(
        IMapper mapper, IBudgetRepository repository,
        AuthProvider authProvider) 
        : IRequestHandler<GetBudgetListQuery, Response<IEnumerable<BudgetDTO>>>
    {
        public async Task<Response<IEnumerable<BudgetDTO>>> Handle(GetBudgetListQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<IEnumerable<BudgetDTO>>();
            try
            {
                User loggedUser = await authProvider.GetCurrentUser();
                IEnumerable<Budget> budgets = await repository.GetList(loggedUser.Id);

                response.StatusCode = HttpStatusCode.OK;
                response.Content = mapper.Map<IEnumerable<BudgetDTO>>(budgets);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
