namespace Client.Infrastructure.Routes;

public static class TrackingDetailRoutes
{
    private const string BaseUrl = "api/delivery/tracking-detail";
    
    public static string GetTrackingDetailsByOrderId(Guid id) =>
        BaseUrl + $"/{id}";

    public static string Create => BaseUrl;
}