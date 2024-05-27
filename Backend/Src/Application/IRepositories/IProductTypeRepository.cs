namespace Application.IRepositories;

public interface IProductTypeRepository
{
    Task<IEnumerable<ProductTypeEntity>> GetAllAsync();
    Task<ProductTypeEntity?> GetByIdAsync(int id);
    
    Task CreateAsync(ProductTypeEntity entity);
    Task UpdateAsync(ProductTypeEntity entity);
    Task DeleteAsync(ProductTypeEntity entity);
    
    Task<bool> IsExistByNameAsync(string name);

}