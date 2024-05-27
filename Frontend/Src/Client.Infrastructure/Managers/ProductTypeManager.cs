namespace Client.Infrastructure.Managers;

public interface IProductTypeManager
{
    Task<IResult<IEnumerable<ProductTypeResponse>>> GetAllAsync();
    Task<IResult<ProductTypeResponse>> GetByIdAsync(int id);
    Task<IResult> CreateAsync(CreateProductTypeRequest request);
    Task<IResult> UpdateAsync(int id, UpdateProductTypeRequest request);
    Task<IResult> DeleteAsync(int id);
}

public class ProductTypeManager(
    IHttpClientFactory factory)
    : IProductTypeManager
{
    public async Task<IResult<IEnumerable<ProductTypeResponse>>> GetAllAsync()
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(ProductTypeRoutes.GetAll);
        return await response.ToResultAsync<IEnumerable<ProductTypeResponse>>();
    }

    public async Task<IResult<ProductTypeResponse>> GetByIdAsync(int id)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(ProductTypeRoutes.GetById(id));
        return await response.ToResultAsync<ProductTypeResponse>();
    }

    public async Task<IResult> CreateAsync(CreateProductTypeRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PostAsJsonAsync(ProductTypeRoutes.Create, request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> UpdateAsync(int id, UpdateProductTypeRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PutAsJsonAsync(ProductTypeRoutes.Update(id), request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> DeleteAsync(int id)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .DeleteAsync(ProductTypeRoutes.Delete(id));
        return await response.ToResultAsync();
    }
}