namespace TokenAuthentication.Services
{
    public interface IHashProvider
    {
        byte[] ComputeHash(byte[] data);
    }
}
