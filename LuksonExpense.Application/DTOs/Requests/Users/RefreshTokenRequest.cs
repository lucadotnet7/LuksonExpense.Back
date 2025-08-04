namespace LuksonExpense.Application.DTOs.Requests.Users
{
    public record class RefreshTokenRequest(string AccessToken, Guid RefreshToken, string Email);
}
