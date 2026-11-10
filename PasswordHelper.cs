using System.Security.Cryptography;

namespace torresJasmine_Inventory_Management_System
{
    internal static class PasswordHelper
    {
        private const string FormatVersion = "PBKDF2-SHA256";
        private const int IterationCount = 100_000;
        private const int SaltSize = 16;
        private const int HashSize = 32;

        public static string HashPassword(string password)
        {
            ArgumentNullException.ThrowIfNull(password);

            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                IterationCount,
                HashAlgorithmName.SHA256,
                HashSize);

            return string.Join(
                '$',
                FormatVersion,
                IterationCount,
                Convert.ToBase64String(salt),
                Convert.ToBase64String(hash));
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            if (password is null || string.IsNullOrWhiteSpace(storedHash))
            {
                return false;
            }

            string[] parts = storedHash.Split('$');
            if (parts.Length != 4 || parts[0] != FormatVersion ||
                !int.TryParse(parts[1], out int iterations) ||
                iterations < 10_000 || iterations > 1_000_000)
            {
                return false;
            }

            try
            {
                byte[] salt = Convert.FromBase64String(parts[2]);
                byte[] expectedHash = Convert.FromBase64String(parts[3]);
                if (salt.Length != SaltSize || expectedHash.Length != HashSize)
                {
                    return false;
                }

                byte[] actualHash = Rfc2898DeriveBytes.Pbkdf2(
                    password,
                    salt,
                    iterations,
                    HashAlgorithmName.SHA256,
                    HashSize);

                return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
