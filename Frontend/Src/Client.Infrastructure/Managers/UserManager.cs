namespace Client.Infrastructure.Managers;

public interface IUserManager
{
    Task<IResult<IEnumerable<UserResponse>>> GetAllAsync();
    Task<IResult<UserResponse>> GetByIdAsync(Guid id);
    Task<IResult> CreateAsync(SignUpRequest request);
    Task<IResult> DeleteAsync(Guid id);
}

public class UserManager(
    IHttpClientFactory factory)
    : IUserManager
{
    public async Task<IResult<IEnumerable<UserResponse>>> GetAllAsync()
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(UserRoutes.GetAll);
        return await response.ToResultAsync<IEnumerable<UserResponse>>();
    }

    public async Task<IResult<UserResponse>> GetByIdAsync(Guid id)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(UserRoutes.GetById(id));
        return await response.ToResultAsync<UserResponse>();
    }

    public async Task<IResult> CreateAsync(SignUpRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PostAsJsonAsync(UserRoutes.Create, request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .DeleteAsync(UserRoutes.Delete(id));
        return await response.ToResultAsync();
    }
}