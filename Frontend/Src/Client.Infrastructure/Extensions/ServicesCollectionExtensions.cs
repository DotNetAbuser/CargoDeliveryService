namespace Client.Infrastructure.Extensions;

public static class ServicesCollectionExtensions
{
    public static void AddManagers(this IServiceCollection services) =>
        services
            .AddTransient<IOrderManager, OrderManager>()
            .AddTransient<IProductTypeManager, ProductTypeManager>()
            .AddTransient<ITokenManager, TokenManager>()
            .AddTransient<ITrackingDetailManager, TrackingDetailManager>()
            .AddTransient<IUserManager, UserManager>();

    public static void AddServices(this IServiceCollection services) =>
        services
            .AddTransient<ITokenService, TokenService>();

    public static void AddAndConfigureHttpClientFactory(this IServiceCollection services) =>
        services
            .AddTransient<AuthorizationHeaderHandler>()
            .AddHttpClient(ApplicationConstants.BaseClientName)
            .ConfigureHttpClient(client => client.BaseAddress = new Uri(ApplicationConstants.BackendAddress))
            .AddHttpMessageHandler<AuthorizationHeaderHandler>();
}