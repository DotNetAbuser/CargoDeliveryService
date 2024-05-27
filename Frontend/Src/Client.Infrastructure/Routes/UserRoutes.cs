namespace Client.Infrastructure.Routes;

public static class UserRoutes
{
    private const string? BaseUrl = "api/identity/user";

    public static string GetAll => BaseUrl;

    public static string GetById(Guid id) =>
        BaseUrl + $"/{id}";

    public static string Create => BaseUrl;

    public static string Delete(Guid id) =>
        BaseUrl + $"/{id}";
}