namespace Application.IRepositories;

public interface ITrackingDetailRepository
{
    Task<IEnumerable<TrackingDetailEntity>> GetTrackingDetailsByOrderIdAsync(Guid id);
    Task CreateAsync(TrackingDetailEntity entity);
}