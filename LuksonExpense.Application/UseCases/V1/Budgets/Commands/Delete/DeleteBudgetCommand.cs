using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LuksonExpense.Domain.Models;
using LuksonExpense.Domain.Shared;
using LuksonExpense.Infrastructure.Interfaces;
using MediatR;

namespace LuksonExpense.Application.UseCases.V1.Budgets.Commands.Delete
{
    public sealed class DeleteBudgetCommand : IRequest<Unit>
    {
        public Guid BudgetId { get; set; }
    }

    public sealed class DeleteBudgetCommandHandler(IBudgetRepository repository) 
        : IRequestHandler<DeleteBudgetCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteBudgetCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Budget? existBudget = await repository.GetById(request.BudgetId);

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
