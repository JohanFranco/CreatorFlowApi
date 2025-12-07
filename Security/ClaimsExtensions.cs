using System.Security.Claims;

namespace CreatorFlowApi.Security
{
    public static class ClaimsExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var id = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(id))
                throw new InvalidOperationException("User id not found in token.");

            return int.Parse(id);
        }
    }
}
