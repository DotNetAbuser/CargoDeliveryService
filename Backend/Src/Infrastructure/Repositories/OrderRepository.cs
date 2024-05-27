namespace Infrastructure.Repositories;

public class OrderRepository(
    ApplicationDbContext dbContext)
    : IOrderRepository
{
    public async Task<IEnumerable<OrderEntity>> GetAllWithIncludesAsync()
    {
        return await dbContext.Orders
            .AsNoTracking()
            .Include(x => x.Creator)
            .Include(x => x.Driver)
            .Include(x => x.ProductType)
            .Include(x => x.TrackingDetails)
            .OrderByDescending(x => x.Created)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderEntity>> GetFreeOrdersWithIncludesAsync()
    {
        return await dbContext.Orders
            .AsNoTracking()
            .Include(x => x.Creator)
            .Include(x => x.Driver)
            .Include(x => x.ProductType)
            .Include(x => x.TrackingDetails)
            .Where(x => x.DriverId == null)
            .OrderByDescending(x => x.Created)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderEntity>> GetAllByCreatorIdWithIncludesAsync(Guid id)
    {
        return await dbContext.Orders
            .AsNoTracking()
            .Include(x => x.Creator)
            .Include(x => x.Driver)
            .Include(x => x.ProductType)
            .Include(x => x.TrackingDetails)
            .Where(x => x.CreatorId == id)
            .OrderByDescending(x => x.Created)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderEntity>> GetAllByDriverIdWithIncludesAsync(Guid id)
    {
        return await dbContext.Orders
            .AsNoTracking()
            .Include(x => x.Creator)
            .Include(x => x.Driver)
            .Include(x => x.ProductType)
            .Include(x => x.TrackingDetails)
            .Where(x => x.DriverId == id)
            .OrderByDescending(x => x.Created)
            .ToListAsync();
    }

    public async Task<OrderEntity?> GetByIdAsync(Guid id)
    {
        return await dbContext.Orders
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<OrderEntity?> GetByIdWithIncludesAsync(Guid id)
    {
        return await dbContext.Orders
            .AsNoTracking()
            .Include(x => x.Creator)
            .Include(x => x.Driver)
            .Include(x => x.ProductType)
            .Include(x => x.TrackingDetails)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(OrderEntity entity)
    {
        dbContext.Orders.Update(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task CreateAsync(OrderEntity entity)
    {
        await dbContext.Orders.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }
}