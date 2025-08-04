using System.Net;
using AutoMapper;
using LuksonExpense.Application.Abstractions.Authentication;
using LuksonExpense.Application.DTOs.MappingDtos;
using LuksonExpense.Domain.Models;
using LuksonExpense.Domain.Shared;
using LuksonExpense.Infrastructure.Interfaces;
using MediatR;

namespace LuksonExpense.Application.UseCases.V1.Budgets.Queries.GetById
{
    public sealed class GetBudgetByIdQuery : IRequest<Response<BudgetDTO>>
    {
        public Guid BudgetId { get; set; }
    }

    public sealed class GetBudgetByIdQueryHandler(
        IMapper mapper, IBudgetRepository repository,
        AuthProvider authProvider)
        : IRequestHandler<GetBudgetByIdQuery, Response<BudgetDTO>>
    {
        public async Task<Response<BudgetDTO>> Handle(GetBudgetByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new Response<BudgetDTO>();
            try
            {
                User loggedUser = await authProvider.GetCurrentUser();

                Budget? budget = await repository.GetById(request.BudgetId, loggedUser.Id);

                if (budget is null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Error = new ErrorResponse
                    {
                        ErrorMessages = new List<string> { $"No se encuentra ningún presupuesto con id {request.BudgetId}" }
                    };

                    return response;
                }

                response.StatusCode = HttpStatusCode.OK;
                response.Content = mapper.Map<BudgetDTO>(budget);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
