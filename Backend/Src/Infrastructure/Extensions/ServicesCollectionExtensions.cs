namespace Infrastructure.Extensions;

public static class ServicesCollectionExtensions
{
    public static void AddRepositories(this IServiceCollection services) =>
        services
            .AddTransient<IOrderRepository, OrderRepository>()
            .AddTransient<IProductTypeRepository, ProductTypeRepository>()
            .AddTransient<ISessionRepository, SessionRepository>()
            .AddTransient<ITrackingDetailRepository, TrackingDetailRepository>()
            .AddTransient<IUserRepository, UserRepository>();
    
    public static void AddServices(this IServiceCollection services) =>
        services
            .AddTransient<IOrderService, OrderService>()
            .AddTransient<IProductTypeService, ProductTypeService>()
            .AddTransient<ITokenService, TokenService>()
            .AddTransient<ITrackingDetailService, TrackingDetailService>()
            .AddTransient<IUserService, UserService>();


}