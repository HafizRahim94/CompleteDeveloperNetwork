using etiqatest.Application.Common.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace etiqatest.Infrastructure.Helper
{
    public class PasswordHasher : IPasswordHasher
    {
        public static void HashPassword(string password, ref string hashedPassword, ref string saltString)
        {
            // Generate a 128-bit salt using a cryptographically strong random sequence of nonzero values.
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            // Derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            saltString = Convert.ToBase64String(salt);
        }

        public static bool VerifyPassword(string password, string hashedPassword, byte[] salt)
        {
            // Derive the subkey using the same parameters
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            // Check if the hashed passwords are the same
            return hashed == hashedPassword;
        }

        public bool VerifyPassword(string password, string hashedPassword, string saltString)
        {
            return VerifyPassword(password, hashedPassword, Convert.FromBase64String(saltString));
        }
    }
}
