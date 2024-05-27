namespace Server.Controllers;

[ApiController]
[Route("api/delivery/tracking-detail")]
public class TrackingDetailController(
    ITrackingDetailService trackingDetailService)
    : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTrackingDetailsByOrderIdAsync(Guid id)
    {
        var response = await trackingDetailService.GetTrackingDetailsOrderIdAsync(id);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateTrackingDetailRequest request)
    {
        return Ok(await trackingDetailService.CreateAsync(request));
    }
    
}