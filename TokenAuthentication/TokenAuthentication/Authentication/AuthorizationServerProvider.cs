using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using TokenAuthentication.Model;
using TokenAuthentication.Services;

namespace TokenAuthentication.Infrastructure.Authentication
{
    /// <summary>
    /// Implements an <see cref="OAuthAuthorizationServerProvider"/> using a custom authentication backend.
    /// </summary>
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private readonly IAuthenticationService authService;

        public SimpleAuthorizationServerProvider(IAuthenticationService authService)
        {
            this.authService = authService;
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

            return base.ValidateClientAuthentication(context);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        { 
            if (!CredentialsAvailable(context))
            {
                context.SetError("invalid_grant", "User or password is missing.");

                return base.GrantResourceOwnerCredentials(context);
            }

            Credentials credentials = GetCredentials(context);

            UserIdentity userIdentity;
            if (authService.TryAuthentifcate(credentials, out userIdentity))
            {
                var oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);

                oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, userIdentity.Name));

                // Add Claims from DB:
                foreach (var claim in userIdentity.Claims)
                {
                    oAuthIdentity.AddClaim(new Claim(claim.Type, claim.Value));
                }

                context.Validated(oAuthIdentity);

                return base.GrantResourceOwnerCredentials(context);
            }
            else
            {
                context.SetError("invalid_grant", "Invalid credentials.");
                return base.GrantResourceOwnerCredentials(context);
            }
        }

        private bool CredentialsAvailable(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (string.IsNullOrWhiteSpace(context.UserName))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(context.Password))
            {
                return false;
            }
            return true;
        }

        private Credentials GetCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return new Credentials()
            {
                UserName = context.UserName,
                Password = context.Password
            };
        }
    }
}