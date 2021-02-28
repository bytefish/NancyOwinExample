using System;
using System.Text;

namespace TokenAuthentication.Services
{
    public static class CryptoServiceExtensions
    {
        public static void CreateHash(this ICryptoService cryptoService, string data, out string hash, out string salt)
        {
            byte[] hashBytes;
            byte[] saltBytes;
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            cryptoService.CreateHash(dataBytes, out hashBytes, out saltBytes);

            hash = Convert.ToBase64String(hashBytes);
            salt = Convert.ToBase64String(saltBytes);
        }

        public static string ComputeHash(this ICryptoService cryptoService, string data, string salt)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] saltBytes = Convert.FromBase64String(salt);

            byte[] hashBytes = cryptoService.ComputeHash(dataBytes, saltBytes);

            return Convert.ToBase64String(hashBytes);
        }
    }
}