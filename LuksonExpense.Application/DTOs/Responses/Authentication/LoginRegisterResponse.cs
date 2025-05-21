
namespace LuksonExpense.Application.DTOs.Responses.Authentication
{
    public record class LoginRegisterResponse(string Token, DateTime LoggedAt);
}
