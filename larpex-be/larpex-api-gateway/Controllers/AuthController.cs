using larpex_auth;
using Microsoft.AspNetCore.Mvc;

namespace larpex_api_gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    public AuthController(IConfiguration configuration)
    {

        string? key = configuration.GetValue<string>("JWT:Key");
        string? issuer = configuration.GetValue<string>("JWT:Issuer");
        int expirationTime = configuration.GetValue<int>("JWT:ExpirationTimeInMinutes");
        if (String.IsNullOrWhiteSpace(key) || String.IsNullOrWhiteSpace(issuer))
        {
            throw new Exception("Exception while creating auth controller!");
        }

        TokenGenerator.KeyString = key;
        TokenGenerator.ExpirationTime = expirationTime;
        TokenGenerator.IssuerName = issuer;
    }
    
    
    [HttpGet]
    public IActionResult GenerateToken(string email)
    {
        string result;
        
        try
        {
            result = TokenGenerator.GenerateToken(email);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

        return Ok(result);
    }
    
    
}