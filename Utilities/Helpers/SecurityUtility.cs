using System.Text;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;

namespace Utilities.Helpers
{
    public static class SecurityUtility
    {
        private const int DefaultSaltSize = 16;
        private const int DefaultMemorySize = 65536;
        private const int DefaultDegreeOfParallelism = 8;
        private const int DefaultIterations = 4;
        private const int DefaultHashSize = 32;

        public static string CreateHash(string password, byte[] salt)
        {
            using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = DefaultDegreeOfParallelism;
            argon2.MemorySize = DefaultMemorySize;
            argon2.Iterations = DefaultIterations;
            byte[] hash = argon2.GetBytes(DefaultHashSize);


            string saltText = Convert.ToBase64String(salt);
            string hashText = Convert.ToBase64String(hash);
            string saltedHash = saltText + ":" + hashText;

            return saltedHash;
        }

        public static byte[] GenerateSalt()
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] salt = new byte[DefaultSaltSize];
            rng.GetBytes(salt);
            return salt;
        }

        public static bool VerifyPassword(string password, string saltText, string hashText)
        {
            byte[] salt = Convert.FromBase64String(saltText);
            byte[] hash = Convert.FromBase64String(hashText);

            using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = DefaultDegreeOfParallelism;
            argon2.MemorySize = DefaultMemorySize;
            argon2.Iterations = DefaultIterations;
            byte[] novoHash = argon2.GetBytes(DefaultHashSize);

            bool senhasCorrespondem = CompararBytes(hash, novoHash);

            if (senhasCorrespondem)
                return true;

            return false;
        }

        static bool CompararBytes(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
                return false;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }
    }
}
