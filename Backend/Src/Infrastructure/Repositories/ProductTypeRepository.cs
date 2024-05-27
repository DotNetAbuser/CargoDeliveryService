namespace Infrastructure.Repositories;

public class ProductTypeRepository(
    ApplicationDbContext dbContext)
    : IProductTypeRepository
{
    public async Task<IEnumerable<ProductTypeEntity>> GetAllAsync()
    {
        return await dbContext.ProductTypes
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<ProductTypeEntity?> GetByIdAsync(int id)
    {
        return await dbContext.ProductTypes
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreateAsync(ProductTypeEntity entity)
    {
        await dbContext.ProductTypes.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(ProductTypeEntity entity)
    {
        dbContext.ProductTypes.Update(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(ProductTypeEntity entity)
    {
        dbContext.ProductTypes.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsExistByNameAsync(string name)
    {
        return await dbContext.ProductTypes
            .AsNoTracking()
            .AnyAsync(x => x.Name == name);
    }
}