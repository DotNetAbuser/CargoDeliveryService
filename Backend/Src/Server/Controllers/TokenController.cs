namespace Server.Controllers;

[ApiController]
[Route("api/identity/token")]
public class TokenController(
    ITokenService tokenService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SignInAsync(SignInRequest request)
    {
        var response = await tokenService.SignInAsync(request);
        return Ok(response);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequest request)
    {
        var response = await tokenService.RefreshTokenAsync(request);
        return Ok(response);
    }
}

