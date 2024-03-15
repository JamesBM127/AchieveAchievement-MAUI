using AchieveAchievementLibrary.Entity;
using JBMSecurePassword;
using System.Text;
using System.Text.RegularExpressions;

namespace AchieveAchievementLibrary.EntitySettings
{
    public static class AccountSettings
    {
        public static bool IsValid(this Account account)
        {
            StringBuilder errors = new StringBuilder();
            errors.Append("[B00001] Invalid properties");
            byte i = 0;

            if (string.IsNullOrWhiteSpace(account.Login) || account.Login.Length > 20)
                errors.Append($" [{++i}]Login");

            if (string.IsNullOrWhiteSpace(account.Salt))
                errors.Append($" [{++i}]Password");

            if (string.IsNullOrWhiteSpace(account.HashedPassword))
                errors.Append($" [{++i}]Password");

            if(string.IsNullOrWhiteSpace(account.Email) || !IsValidEmail(account.Email))
                errors.Append($" [{++i}]Email");

            if (account.PlayerId == Guid.Empty)
                errors.Append($" [{++i}]Player");

            if (i != 0)
                throw new ArgumentException(errors.ToString());
            else
                return true;
        }

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(email, pattern);
        }

        public static (string, string) GetSaltAndHashPassword(string inputPassword)
        {
            string salt = PasswordManager.GenerateSalt();
            string hashedPassword = PasswordManager.HashPassword(inputPassword, salt);

            return (salt, hashedPassword);
        }

        public static bool AuthLogin(string inputPassword, string salt, string hash)
        {
            return PasswordManager.AuthenticatePassword(inputPassword, salt, hash);
        }
    }
}
