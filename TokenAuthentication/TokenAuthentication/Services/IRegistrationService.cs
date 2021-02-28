using TokenAuthentication.Requests;

namespace TokenAuthentication.Services
{
    public interface IRegistrationService
    {
        void Register(RegisterUserRequest register);
    }
}