using System.Security.Cryptography;

namespace TokenAuthentication.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly IApplicationSettings settings;
        private readonly IHashProvider hashProvider;

        public CryptoService(IApplicationSettings settings, IHashProvider hashProvider)
        {
            this.settings = settings;
            this.hashProvider = hashProvider;
        }

        public void CreateHash(byte[] data, out byte[] hash, out byte[] salt)
        {
            salt = CreateSalt();
            hash = ComputeHash(data, salt);
        }

        public byte[] ComputeHash(byte[] data, byte[] salt)
        {
            byte[] saltedData = Concatenate(data, salt);
            byte[] hashBytes = hashProvider.ComputeHash(saltedData);

            return hashBytes;
        }

        private byte[] CreateSalt()
        {
            byte[] randomBytes = new byte[settings.SaltSize];
            using (var randomGenerator = new RNGCryptoServiceProvider())
            {
                randomGenerator.GetBytes(randomBytes);
                return randomBytes;
            }
        }

        private byte[] Concatenate(byte[] a, byte[] b)
        {
            byte[] result = new byte[a.Length + b.Length];

            System.Buffer.BlockCopy(a, 0, result, 0, a.Length);
            System.Buffer.BlockCopy(b, 0, result, a.Length, b.Length);

            return result;
        }
    }
}