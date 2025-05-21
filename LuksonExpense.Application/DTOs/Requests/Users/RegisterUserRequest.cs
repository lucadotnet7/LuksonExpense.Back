namespace LuksonExpense.Application.DTOs.Requests.Users
{
    public record class RegisterUserRequest(
        string Firstname,
        string Lastname,
        string Email,
        string Password);
}
