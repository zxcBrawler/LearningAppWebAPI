using System.Security.Cryptography;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;

namespace LearningAppWebAPI.Domain.Repository
{
    public class AuthorizationRepository(AppDbContext context)
    {
        private const int SALT_BYTE_SIZE = 24;
        private const int HASH_BYTE_SIZE = 24;
        private const int PBKDF2_ITERATIONS = 1000;
        private const int ITERATION_INDEX = 0;
        private const int SALT_INDEX = 1;
        private const int PBKDF2_INDEX = 2;

        public async Task<bool> Authorize(string username, string password)
        {
            var optUser = await context.User.FindAsync(username);

            return optUser != null && ValidatePassword(password, optUser.PasswordHash);
        }
        public async Task<User> Register(string username, string password)
        {

            User? user = await context.User.FindAsync(username) ?? new User
            {
                // add all other params
                // Email = email    
                Username = username,
                PasswordHash = CreateHash(password)
            };
            await context.User.AddAsync(user);
            return user;
        }

        private static string CreateHash(string password)
        {
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            var salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);
            var hash = Pbkdf2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }

        private static byte[] Pbkdf2(string password, byte[] salt, int iterations, int outputBytes)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

        private static bool ValidatePassword(string password, string correctHash)
        {

            char[] delimiter = { ':' };
            var split = correctHash.Split(delimiter);
            var iterations = int.Parse(split[ITERATION_INDEX]);
            var salt = Convert.FromBase64String(split[SALT_INDEX]);
            var hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

            var testHash = Pbkdf2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (var i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }
    }
}
