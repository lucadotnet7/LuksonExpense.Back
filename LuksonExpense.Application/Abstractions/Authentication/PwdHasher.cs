using Microsoft.AspNetCore.Identity;

namespace LuksonExpense.Application.Abstractions.Authentication
{
    public sealed class PwdHasher(PasswordHasher<object> hasher)
    {
        public string HashPassword(string password)
        {
            return hasher.HashPassword(null!, password);
        }

        public bool Verify(string password, string hashedPassword)
        {
            var result = hasher.VerifyHashedPassword(null!, hashedPassword, password);
            return result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded;
        }
    }
}
