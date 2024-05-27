namespace Server.Controllers;

[ApiController]
[Route("api/identity/user")]
public class UserController(
    IUserService userService)
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await userService.GetAllAsync();
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var response = await userService.GetByIdAsync(id);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAsync(SignUpRequest request)
    {
        return Ok(await userService.CreateAsync(request));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(await userService.DeleteAsync(id));
    }
}