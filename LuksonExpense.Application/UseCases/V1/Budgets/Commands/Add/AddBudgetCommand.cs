using AutoMapper;
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

    public sealed class AddBudgetCommandHandler(IMapper mapper, IBudgetRepository repository) : IRequestHandler<AddBudgetCommand, Response<BudgetDTO>>
    {
        public async Task<Response<BudgetDTO>> Handle(AddBudgetCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<BudgetDTO>();

            try
            {
                Budget createdBudget = await repository.Add(mapper.Map<Budget>(request.Request));

                response.StatusCode = HttpStatusCode.Created;
                response.Content = mapper.Map<BudgetDTO>(createdBudget);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
