using System.Net;
using AutoMapper;
using LuksonExpense.Application.Abstractions.Authentication;
using LuksonExpense.Application.DTOs.MappingDtos;
using LuksonExpense.Application.DTOs.Requests.Budgets;
using LuksonExpense.Domain.Models;
using LuksonExpense.Domain.Shared;
using LuksonExpense.Infrastructure.Interfaces;
using MediatR;

namespace LuksonExpense.Application.UseCases.V1.Budgets.Commands.Edit
{
    public sealed class EditBudgetCommand : IRequest<Response<BudgetDTO>>
    {
        public AddBudgetRequest Request { get; set; }
        public Guid BudgetId { get; set; }
    }

    public sealed class EditBudgetCommandHandler(
        IMapper mapper, IBudgetRepository repository,
        AuthProvider authProvider) 
        : IRequestHandler<EditBudgetCommand, Response<BudgetDTO>>
    {
        public async Task<Response<BudgetDTO>> Handle(EditBudgetCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<BudgetDTO>();

            try
            {
                User loggedUser = await authProvider.GetCurrentUser();

                Budget? existedBudget = await repository.GetById(request.BudgetId, loggedUser.Id);

                if (existedBudget is null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Error = new ErrorResponse
                    {
                        ErrorMessages = new List<string> { $"No existe un presupuesto con id: {request.BudgetId}" }
                    };
                }
                mapper.Map(request.Request, existedBudget);
                
                Budget updatedBudget = await repository.Update(existedBudget!);

                response.StatusCode = HttpStatusCode.OK;
                response.Content = mapper.Map<BudgetDTO>(updatedBudget);

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
