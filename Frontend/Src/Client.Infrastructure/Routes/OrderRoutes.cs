namespace Client.Infrastructure.Routes;

public class OrderRoutes
{
    private const string BaseUrl = "api/delivery/order";

    public static string GetAll => BaseUrl;

    public static string GetAllByCreatorId(Guid id) =>
        BaseUrl + $"/creator/{id}";

    public static string GetAllByDriverId(Guid id) =>
        BaseUrl + $"/driver/{id}";

    public static string GetFreeOrders => BaseUrl + "/free-orders";

    public static string GetById(Guid id) =>
        BaseUrl + $"/{id}";

    public static string Create => BaseUrl;

    public static string TakeOrder(Guid id) =>
        BaseUrl + $"/{id}/take-order";

    public static string ChangePaymentStatus(Guid id) =>
        BaseUrl + $"/{id}/change-payment-status";
}