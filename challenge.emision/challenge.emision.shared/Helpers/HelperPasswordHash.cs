using System.Security.Cryptography;
using System.Text;

namespace challenge.emision.shared.Helpers
{
    public static class HelperPasswordHash
    {
        public static bool ValidatePasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var hashComputed = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < hashComputed.Length; i++)
                {
                    if (hashComputed[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
