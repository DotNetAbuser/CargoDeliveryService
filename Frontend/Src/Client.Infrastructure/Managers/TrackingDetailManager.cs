namespace Client.Infrastructure.Managers;

public interface ITrackingDetailManager
{
    Task<IResult<IEnumerable<TrackingDetailResponse>>> GetTrackingDetailsOrderIdAsync(Guid id);
    Task<IResult> CreateAsync(CreateTrackingDetailRequest request);
}

public class TrackingDetailManager(
    IHttpClientFactory factory)
    : ITrackingDetailManager
{
    public async Task<IResult<IEnumerable<TrackingDetailResponse>>> GetTrackingDetailsOrderIdAsync(Guid id)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(TrackingDetailRoutes.GetTrackingDetailsByOrderId(id));
        return await response.ToResultAsync<IEnumerable<TrackingDetailResponse>>();
    }

    public async Task<IResult> CreateAsync(CreateTrackingDetailRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PostAsJsonAsync(TrackingDetailRoutes.Create, request);
        return await response.ToResultAsync();
    }
}