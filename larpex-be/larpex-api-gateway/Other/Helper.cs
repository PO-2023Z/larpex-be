using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace larpex_api_gateway.Other;


public static class Helper
{
    public static string GetTokenData(HttpContext context)
    {
        string token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = tokenHandler.ReadJwtToken(token);
        var claims = tokenDescriptor.Claims.ToList();

        var emailClaim = claims.First(claim => claim.Type.Equals(ClaimTypes.Email));
        var email = emailClaim.Value;

        return email;
    }
}