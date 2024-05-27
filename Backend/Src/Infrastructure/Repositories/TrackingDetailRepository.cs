namespace Infrastructure.Repositories;

public class TrackingDetailRepository(
    ApplicationDbContext dbContext)
    : ITrackingDetailRepository
{
    public async Task<IEnumerable<TrackingDetailEntity>> GetTrackingDetailsByOrderIdAsync(Guid id)
    {
        return await dbContext.TrackingDetails
            .AsNoTracking()
            .Where(x => x.OrderId == id)
            .ToListAsync();
    }

    public async Task CreateAsync(TrackingDetailEntity entity)
    {
        await dbContext.TrackingDetails.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }
}