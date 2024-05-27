namespace Server.Controllers;

[ApiController]
[Route("api/delivery/order")]
public class OrderController(
    IOrderService orderService)
    : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await orderService.GetAllAsync();
        return Ok(response);
    }

    [HttpGet("free-orders")]
    [Authorize]
    public async Task<IActionResult> GetFreeOrdersAsync()
    {
        var response = await orderService.GetFreeOrdersAsync();
        return Ok(response);
    }

    [HttpGet("creator/{id:guid}")]
    [Authorize]
    public async Task<IActionResult> GetAllByCreatorIdAsync(Guid id)
    {
        var response = await orderService.GetAllByCreatorIdAsync(id);
        return Ok(response);
    }
    
    [HttpGet("driver/{id:guid}")]
    [Authorize]
    public async Task<IActionResult> GetAllByDriverIdAsync(Guid id)
    {
        var response = await orderService.GetAllByDriverIdAsync(id);
        return Ok(response);
    }
    
    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var response = await orderService.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateAsync(CreateOrderRequest request)
    {
        return Ok(await orderService.CreateAsync(request));
    }

    [HttpPut("{id:guid}/take-order")]
    [Authorize(Roles = "Driver")]
    public async Task<IActionResult> TakeOrderAsync(Guid id, TakeOrderRequest request)
    {
        return Ok(await orderService.TakeOrderAsync(id, request));
    }
    
    [HttpPut("{id:guid}/change-payment-status")]
    [Authorize(Roles = "Driver")]
    public async Task<IActionResult> ChangePaymentStatusAsync(Guid id, ChangePaymentStatusRequest request)
    {
        return Ok(await orderService.ChangePaymentStatusAsync(id, request));
    }
}