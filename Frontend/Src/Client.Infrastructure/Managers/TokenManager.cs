namespace Client.Infrastructure.Managers;

public interface ITokenManager
{
    Task<IResult> SignInAsync(SignInRequest request);
    Task<IResult> RefreshAsync(RefreshTokenRequest request);
}

public class TokenManager(
    IHttpClientFactory factory,
    ITokenService tokenService)
    : ITokenManager
{
    public async Task<IResult> SignInAsync(SignInRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PostAsJsonAsync(TokenRoutes.SignIn, request);
        var result = await response.ToResultAsync<SignInResponse>();
        if (!result.Succeeded)
            return Result.Fail(result.Messages);
        await tokenService.SetAuthTokenAsync(result.Data.AuthToken);
        await tokenService.SetRefreshTokenAsync(result.Data.RefreshToken);
        return Result.Success();
    }

    public async Task<IResult> RefreshAsync(RefreshTokenRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PostAsJsonAsync(TokenRoutes.RefreshToken, request);
        var result = await response.ToResultAsync<SignInResponse>();
        if (!result.Succeeded)
            return Result.Fail();
        await tokenService.SetAuthTokenAsync(result.Data.AuthToken);
        await tokenService.SetRefreshTokenAsync(result.Data.RefreshToken);
        return Result.Success();
    }
}