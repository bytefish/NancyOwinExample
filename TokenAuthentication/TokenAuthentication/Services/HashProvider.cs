using System.Security.Cryptography;

namespace TokenAuthentication.Services
{
    public class HashProvider : IHashProvider
    {
        public byte[] ComputeHash(byte[] data)
        {
            using (var sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(data);
                
            }
        }
    }
}
