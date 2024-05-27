namespace Application.IRepositories;

public interface IUserRepository
{
    Task<IEnumerable<UserEntity>> GetAllAsync();
    Task<UserEntity?> GetByPhoneNumberWithRoleAsync(string phoneNumber);
    Task<UserEntity?> GetByIdWithRoleAsync(Guid id);
    Task<UserEntity?> GetByIdAsync(Guid id);
    
    Task CreateAsync(UserEntity entity);
    Task DeleteAsync(UserEntity entity);
    
    Task<bool> IsExistByEmailAsync(string email);
    Task<bool> IsExistByPhoneNumberAsync(string phoneNumber);
}