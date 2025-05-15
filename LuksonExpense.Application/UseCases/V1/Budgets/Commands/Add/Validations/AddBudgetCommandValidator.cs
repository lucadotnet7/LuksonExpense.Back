using FluentValidation;

namespace LuksonExpense.Application.UseCases.V1.Budgets.Commands.Add.Validations
{
    public sealed class AddBudgetCommandValidator : AbstractValidator<AddBudgetCommand>
    {
        public AddBudgetCommandValidator()
        {
            RuleFor(x => x.Request)
                .NotNull()
                .WithMessage("El presupuesto no puede ser nulo.");

            RuleFor(x => x.Request.BudgetName)
                .NotEmpty()
                .WithMessage("Debe ingresar un nombre para el presupuesto.")
                .MinimumLength(5)
                .WithMessage("El nombre del presupuesto debe tener al menos 5 caracteres.")
                .MaximumLength(80)
                .WithMessage("El nombre del presupuesto no puede exceder los 80 caracteres.");

            RuleFor(x => x.Request.BudgetFrom)
                .NotEmpty()
                .NotNull()
                .WithMessage("El presupuesto debe tener una fecha de inicio.");

            RuleFor(x => x.Request.BudgetTo)
                .NotEmpty()
                .NotNull()
                .WithMessage("El presupuesto debe tener una fecha de fin.");

            RuleFor(x => x.Request.Amount)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("El monto del presupuesto debe ser mayor a 0.");
        }
    }
}
