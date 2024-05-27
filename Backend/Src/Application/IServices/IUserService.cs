namespace Application.IServices;


public interface IUserService
{
    Task<Result<IEnumerable<UserResponse>>> GetAllAsync();
    Task<Result<UserResponse>> GetByIdAsync(Guid id);
    
    Task<Result> CreateAsync(SignUpRequest request);
    Task<Result> DeleteAsync(Guid id);

}