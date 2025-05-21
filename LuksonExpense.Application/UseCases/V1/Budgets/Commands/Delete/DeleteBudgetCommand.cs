using LuksonExpense.Application.Abstractions.Authentication;
using LuksonExpense.Domain.Models;
using LuksonExpense.Infrastructure.Interfaces;
using MediatR;

namespace LuksonExpense.Application.UseCases.V1.Budgets.Commands.Delete
{
    public sealed class DeleteBudgetCommand : IRequest<Unit>
    {
        public Guid BudgetId { get; set; }
    }

    public sealed class DeleteBudgetCommandHandler(
        IBudgetRepository repository, AuthProvider authProvider) 
        : IRequestHandler<DeleteBudgetCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User loggedUser = await authProvider.GetCurrentUser();

                Budget? existBudget = await repository.GetById(request.BudgetId, loggedUser.Id);

                if (existBudget is null)
                    throw new ArgumentNullException("El presupuesto que intentas eliminar no existe.");

                await repository.Delete(existBudget);

                return new Unit();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
