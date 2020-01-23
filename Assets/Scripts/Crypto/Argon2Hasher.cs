using System.Text;
using Konscious.Security.Cryptography;

namespace Crypto
{
    public static class Argon2Hasher
    {
        public static byte[] HashPassword(string password, string username)
        {
            using (var argon2 = new Argon2id(
                Encoding.Default.GetBytes(password))
            {
                DegreeOfParallelism = 1,
                MemorySize = 1024 * 32,
                Iterations = 1
            })
            {
                argon2.Salt = Encoding.Default.GetBytes(username);
                argon2.KnownSecret = Encoding.Default.GetBytes("Funat");

                return argon2.GetBytes(32);
            }
        }

        /*public static string String(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
            return Convert.ToBase64String(bytes);
        }*/
    }
}
