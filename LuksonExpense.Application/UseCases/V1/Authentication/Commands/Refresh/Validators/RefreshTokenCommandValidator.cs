using FluentValidation;

namespace LuksonExpense.Application.UseCases.V1.Authentication.Commands.Refresh.Validators
{
    public sealed class RefreshTokenCommandValidator : AbstractValidator<RefreshTokenCommand>
    {
        public RefreshTokenCommandValidator()
        {
            RuleFor(x => x.Request)
                .NotNull()
                .NotEmpty()
                .WithMessage("El request no puede ser nulo o vacío.");

            RuleFor(x => x.Request.AccessToken)
                .NotEmpty()
                .NotNull()
                .WithMessage("Debe enviar el accessToken del usuario.");

            RuleFor(x => x.Request.RefreshToken)
                .NotEmpty()
                .NotNull()
                .WithMessage("Debe enviar el refreshToken del usuario.");

            RuleFor(x => x.Request.Email)
                .EmailAddress()
                .WithMessage("El formato de correo electrónico no es correcto.")
                .NotNull()
                .NotEmpty()
                .WithMessage("Debe enviar el email del usuario.");
        }
    }
}
