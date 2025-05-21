using FluentValidation;

namespace LuksonExpense.Application.UseCases.V1.Authentication.Commands.Register.Validators
{
    public sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Request)
                .NotNull()
                .NotEmpty()
                .WithMessage("El request no puede ser nulo o vacío.");

            RuleFor(x => x.Request.Firstname)
                .NotEmpty()
                .NotNull()
                .WithMessage("Debe indicar un nombre para el usuario.");

            RuleFor(x => x.Request.Lastname)
                .NotEmpty()
                .NotNull()
                .WithMessage("Debe indicar un apellido para el usuario.");

            RuleFor(x => x.Request.Email)
                .EmailAddress()
                .WithMessage("El formato de correo electrónico no es correcto.")
                .NotNull()
                .NotEmpty()
                .WithMessage("Debe indicar un email para el usuario.");

            RuleFor(x => x.Request.Password)
                .MinimumLength(8)
                .WithMessage("La contraseña debe contener como mínimo 8 caracteres")
                .MaximumLength(40)
                .WithMessage("La contraseña no puede contener más de 40 caracteres.")
                .NotNull()
                .NotEmpty()
                .WithMessage("Debe indicar una contrseña para el usuario");
        }
    }
}
