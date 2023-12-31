﻿using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace larpex_auth;

public static class TokenGenerator
{
    public static int ExpirationTime;
    public static string? KeyString;
    public static string? IssuerName;
    
    public static string GenerateToken(string email)
    {
        if (String.IsNullOrWhiteSpace(KeyString) || String.IsNullOrWhiteSpace(IssuerName))
        {
            throw new Exception("Key or Issuer is invalid");
        }
        
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

    public static string GetEmail(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
    
        try
        {
            var tokenS = tokenHandler.ReadToken(token) as JwtSecurityToken;

            // Retrieve the email claim
            var emailClaim = tokenS?.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Email);
            return emailClaim?.Value;
        }
        catch (Exception)
        {
            // Token decoding failed
            return null;
        }
    }
}