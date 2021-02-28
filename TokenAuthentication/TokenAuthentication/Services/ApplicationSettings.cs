namespace TokenAuthentication.Services
{
    public class ApplicationSettings : IApplicationSettings
    {
        public string NancyBasePath
        {
            get { return "/api"; }
        }

        public string TokenEndpointBasePath
        {
            get { return "/token"; }
        }

        public int SaltSize
        {
            get { return 13; }
        }
    }
}