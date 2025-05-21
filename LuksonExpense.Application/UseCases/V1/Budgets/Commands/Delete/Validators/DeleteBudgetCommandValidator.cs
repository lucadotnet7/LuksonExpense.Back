using FluentValidation;

namespace LuksonExpense.Application.UseCases.V1.Budgets.Commands.Delete.Validators
{
    public sealed class DeleteBudgetCommandValidator : AbstractValidator<DeleteBudgetCommand>
    {
        public DeleteBudgetCommandValidator()
        {
            RuleFor(x => x.BudgetId)
                .NotNull()
                .NotEmpty()
                .WithMessage("Debe indicar el id del presupuesto que intenta eliminar.");
        }
    }
}
