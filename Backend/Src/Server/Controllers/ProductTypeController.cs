namespace Server.Controllers;

[ApiController]
[Route("api/delivery/product-type")]
public class ProductTypeController(
    IProductTypeService productTypeService)
    : ControllerBase
{
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = await productTypeService.GetAllAsync();
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var response = await productTypeService.GetByIdAsync(id);
        return Ok(response);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync(CreateProductTypeRequest request)
    {
        return Ok(await productTypeService.CreateAsync(request));
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateProductTypeRequest request)
    {
        return Ok(await productTypeService.UpdateAsync(id, request));
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        return Ok(await productTypeService.DeleteAsync(id));
    }
}