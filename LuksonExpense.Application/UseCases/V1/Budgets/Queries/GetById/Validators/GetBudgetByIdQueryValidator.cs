using FluentValidation;

namespace LuksonExpense.Application.UseCases.V1.Budgets.Queries.GetById.Validators
{
    public sealed class GetBudgetByIdQueryValidator : AbstractValidator<GetBudgetByIdQuery>
    {
        public GetBudgetByIdQueryValidator()
        {
            RuleFor(x => x.BudgetId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Debe indicar un id para el presupuesto.");
        }
    }
}
