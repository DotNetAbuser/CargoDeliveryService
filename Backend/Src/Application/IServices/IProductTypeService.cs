namespace Application.IServices;

public interface IProductTypeService
{
    Task<Result<IEnumerable<ProductTypeResponse>>> GetAllAsync();
    Task<Result<ProductTypeResponse>> GetByIdAsync(int id);
    Task<Result> CreateAsync(CreateProductTypeRequest request);
    Task<Result> UpdateAsync(int id, UpdateProductTypeRequest request);
    Task<Result> DeleteAsync(int id);
}