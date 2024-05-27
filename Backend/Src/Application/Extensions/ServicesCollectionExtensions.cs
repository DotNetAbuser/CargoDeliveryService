namespace Application.Extensions;

public static class ServicesCollectionExtensions
{
    public static void AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
        => services.AddDbContext<ApplicationDbContext>(options => options
            .UseNpgsql(configuration.GetConnectionString(nameof(ApplicationDbContext))));
}