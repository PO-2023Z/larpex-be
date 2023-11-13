using larpex_auth;
using Microsoft.AspNetCore.Mvc;

namespace larpex_api_gateway.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{

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