using System.Security.Cryptography;
using LearningAppWebAPI.Data;
using LearningAppWebAPI.Models;

namespace LearningAppWebAPI.Domain.Repository
{
    /// <summary>
    /// The authorization repository class
    /// </summary>
    public class AuthorizationRepository(AppDbContext context)
    {

        /// <summary>
        /// The salt byte size
        /// </summary>
        public const int SALT_BYTE_SIZE = 24;
        /// <summary>
        /// The hash byte size
        /// </summary>
        public const int HASH_BYTE_SIZE = 24;
        /// <summary>
        /// The pbkdf2 iterations
        /// </summary>
        public const int PBKDF2_ITERATIONS = 1000;

        /// <summary>
        /// The iteration index
        /// </summary>
        public const int ITERATION_INDEX = 0;
        /// <summary>
        /// The salt index
        /// </summary>
        public const int SALT_INDEX = 1;
        /// <summary>
        /// The pbkdf2 index
        /// </summary>
        public const int PBKDF2_INDEX = 2;

        /// <summary>
        /// The context
        /// </summary>
        protected readonly AppDbContext _context = context;

        /// <summary>
        /// Authorizes the username
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <returns>A task containing the bool</returns>
        public async Task<bool> Authorize(string username, string password)
        {
            var optUser = await _context.User.FindAsync(username);

            if (optUser == null)
            {
                return false;
            }

            return ValidatePassword(password, optUser.PasswordHash);
        }

        /// <summary>
        /// Registers the username
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <returns>The user</returns>
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
                    PasswordHash = CreateHash(password)
                };
            }
            await _context.User.AddAsync(user);
            return user;
        }

        /// <summary>
        /// Creates the hash using the specified password
        /// </summary>
        /// <param name="password">The password</param>
        /// <returns>The string</returns>
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

        /// <summary>
        /// Pbkdfs the 2 using the specified password
        /// </summary>
        /// <param name="password">The password</param>
        /// <param name="salt">The salt</param>
        /// <param name="iterations">The iterations</param>
        /// <param name="outputBytes">The output bytes</param>
        /// <returns>The byte array</returns>
        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }

        /// <summary>
        /// Validates the password using the specified password
        /// </summary>
        /// <param name="password">The password</param>
        /// <param name="correctHash">The correct hash</param>
        /// <returns>The bool</returns>
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

        /// <summary>
        /// Slows the equals using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The bool</returns>
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }
    }
}
