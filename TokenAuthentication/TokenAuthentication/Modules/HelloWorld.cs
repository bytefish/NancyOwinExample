using Nancy;
using TokenAuthentication.Infrastructure.Authentication;
using TokenAuthentication.Infrastructure.Nancy;

namespace TokenAuthentication.Modules
{
    public class HelloWorldModule : SecureModule
    {
        public HelloWorldModule()
        {
            Get["/admin"] = _ =>
            {
                if (!this.Principal.HasClaim(SampleClaimTypes.Admin))
                {
                    return HttpStatusCode.Forbidden;
                }

                return "Hello Admin!";
            };

            Get["/"] = _ =>
            {
                if (!IsAuthenticated)
                {
                    return HttpStatusCode.Forbidden;
                }

                return "Hello User!";
            };   
        }
    }
}
