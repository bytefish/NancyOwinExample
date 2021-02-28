namespace TokenAuthentication.Services
{
    /// <summary>
    /// Cryptographic functions for creating and computing hashes.
    /// </summary>
    public interface ICryptoService
    {
        /// <summary>
        /// Creates a hash from given data.
        /// </summary>
        /// <param name="data">The data to be hashed</param>
        /// <param name="hash">Computed Hash</param>
        /// <param name="salt">Salt used for the Hash</param>
        void CreateHash(byte[] data, out byte[] hash, out byte[] salt);

        /// <summary>
        /// Computes a Hash from given data and salt.
        /// </summary>
        /// <param name="data">Data to be hashed</param>
        /// <param name="salt">Salt used for the hash</param>
        /// <returns></returns>
        byte[] ComputeHash(byte[] data, byte[] salt);
    }
}
