using System;
using System.Security.Claims;

namespace TokenAuthentication.Infrastructure.Authentication
{
    public static class PrincipalExtensions
    {
        public static bool HasClaim(this ClaimsPrincipal principal, string type)
        {
            if (principal == null)
            {
                return false;
            }
            return !String.IsNullOrEmpty(principal.GetClaimValue(type));
        }

        public static string GetClaimValue(this ClaimsPrincipal principal, string type)
        {
            Claim claim = principal.FindFirst(type);

            return claim != null ? claim.Value : null;
        }
    }
}