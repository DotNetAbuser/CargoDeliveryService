namespace Application.IServices;

public interface ITrackingDetailService
{
    Task<Result<IEnumerable<TrackingDetailResponse>>> GetTrackingDetailsOrderIdAsync(Guid id);
    Task<Result> CreateAsync(CreateTrackingDetailRequest request);
}