using FluentValidation;

namespace LuksonExpense.Application.UseCases.V1.Authentication.Queries.Login.Validators
{
    public sealed class UserLoginQueryValidator : AbstractValidator<UserLoginQuery>
    {
        public UserLoginQueryValidator()
        {
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
