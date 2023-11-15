using System.Security.Claims;
using System.Security.Principal;

namespace ClaimSubmissionApi.Services
{
    public static class ExtensionHelper
    {
        public static string GetUserId(this IIdentity identity)
        {
            return identity.GetClaimValue(ClaimTypes.NameIdentifier);
        }
        public static string GetClaimValue(this IIdentity identity, string claimType)
        {
            return ((ClaimsIdentity)identity)?.Claims?.FirstOrDefault((Claim c) => c.Type == claimType)?.Value;
        }
    }
}
