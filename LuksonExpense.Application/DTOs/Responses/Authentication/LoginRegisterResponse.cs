
namespace LuksonExpense.Application.DTOs.Responses.Authentication
{
    public record class LoginRegisterResponse(string AccessToken, DateTime LoggedAt, DateTime ExpirationToken, Guid RefreshToken);
}
