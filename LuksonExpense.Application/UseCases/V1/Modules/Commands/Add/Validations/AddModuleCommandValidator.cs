using FluentValidation;

namespace LuksonExpense.Application.UseCases.V1.Modules.Commands.Add.Validations
{
    public sealed class AddModuleCommandValidator : AbstractValidator<AddModuleCommand>
    {
        public AddModuleCommandValidator()
        {
            RuleFor(x => x.Request.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("El nombre del módulo es obligatorio.");

            RuleFor(x => x.Request.IconName)
                .NotEmpty()
                .NotNull()
                .WithMessage("El nombre del icono del módulo es obligatorio.");

            RuleFor(x => x.Request.Route)
                .NotEmpty()
                .NotNull()
                .WithMessage("La ruta del módulo es obligatoria.");
        }
    }
}
