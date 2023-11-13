using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace larpex_auth;

public static class TokenGenerator
{
    public static int ExpirationTime = 60; //TODO: Read expiration time from json file
    public static string KeyString = "fsaifhi234uhf2qf23r4234fdsfd232f23f2edsfae3"; //TODO: Read key from json file
    public static readonly string IssuerName = "LarpexApp";
    
    public static string GenerateToken(string email)
    {
        var key = Encoding.UTF8.GetBytes(KeyString);
        var skey = new SymmetricSecurityKey(key);
        var signedCredential = new SigningCredentials(skey, SecurityAlgorithms.HmacSha256Signature);

        var uClaims = new ClaimsIdentity(new[]
        {
            new Claim(JwtRegisteredClaimNames.Email, email)
        });
        var expires = DateTime.UtcNow.AddMinutes(ExpirationTime); 

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = uClaims,
            Expires = expires,
            Issuer = IssuerName,
            SigningCredentials = signedCredential,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenJwt = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(tokenJwt);
        return token;
    }
}