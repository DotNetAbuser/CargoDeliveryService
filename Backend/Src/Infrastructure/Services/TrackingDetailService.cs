namespace Infrastructure.Services;

public class TrackingDetailService(
    ITrackingDetailRepository trackingDetailRepository)
    : ITrackingDetailService
{
    public async Task<Result<IEnumerable<TrackingDetailResponse>>> GetTrackingDetailsOrderIdAsync(Guid id)
    {
        var trackingDetailsEnitities = await trackingDetailRepository
            .GetTrackingDetailsByOrderIdAsync(id);
        var trackingDetailsResponse = trackingDetailsEnitities.Select(trackingDetailEntity =>
            new TrackingDetailResponse(
            Id: trackingDetailEntity.Id,
            OrderId: trackingDetailEntity.OrderId,
            Location: trackingDetailEntity.Location,
            Created: trackingDetailEntity.Created)).ToList();
        return Result<IEnumerable<TrackingDetailResponse>>
            .Success(trackingDetailsResponse,"История перемещения груза успешно получена.");
    }

    public async Task<Result> CreateAsync(CreateTrackingDetailRequest request)
    {
        var trackingDetailEntity = new TrackingDetailEntity {
            OrderId = request.OrderId,
            Location = request.Location
        };
        await trackingDetailRepository.CreateAsync(trackingDetailEntity);
        return Result<string>.Success("В историю успешно добавлена новая локация.");
    }
}