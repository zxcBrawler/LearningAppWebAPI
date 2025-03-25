using System.Security.Cryptography;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;

namespace LearningAppWebAPI.Domain.Repository
{
    public class AuthorizationRepository(AppDbContext context)
    {

        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 24;
        public const int PBKDF2_ITERATIONS = 1000;

        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;

        protected readonly AppDbContext _context = context;

        public async Task<bool> Authorize(string username, string password)
        {
            var optUser = await _context.User.FindAsync(username);

            if (optUser == null)
            {
                return false;
            }

            return ValidatePassword(password, optUser.Password_Hash);
        }

        public async Task<User> Register(string username, string password)
        {

            User? user = await _context.User.FindAsync(username);
            if (user == null)
            {
                user = new User
                {

                    // add all other params
                    // Email = email    
                    Username = username,
                    Password_Hash = CreateHash(password)
                };
            }
            await _context.User.AddAsync(user);
            return user;
        }

        public static string CreateHash(string password)
        {
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);


            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

        public static bool ValidatePassword(string password, string correctHash)
        {

            char[] delimiter = { ':' };
            string[] split = correctHash.Split(delimiter);
            int iterations = int.Parse(split[ITERATION_INDEX]);
            byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
            byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

            byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }
    }
}
