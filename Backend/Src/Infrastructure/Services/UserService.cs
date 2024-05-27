namespace Infrastructure.Services;

public class UserService(
    IUserRepository userRepository)
    : IUserService
{
    public async Task<Result<IEnumerable<UserResponse>>> GetAllAsync()
    {
        var usersEntities = await userRepository.GetAllAsync();
        var usersResponse = usersEntities.Select(userEntity => 
            new UserResponse(
                Id: userEntity.Id,
                LastName: userEntity.LastName,
                FirstName: userEntity.FirstName,
                MiddleName: userEntity.MiddleName,
                Email: userEntity.Email,
                PhoneNumber: userEntity.PhoneNumber,
                Created: userEntity.Created)).ToList();
        return Result<IEnumerable<UserResponse>>.Success(usersResponse, "Пользователи успешно получены!");
    }

    public async Task<Result<UserResponse>> GetByIdAsync(Guid id)
    {
        var userEntity = await userRepository.GetByIdAsync(id);
        if (userEntity == null)
            return Result<UserResponse>.Fail("Пользователь с данным идентификатором не найден!");

        var userResponse = new UserResponse(
            Id: userEntity.Id,
            LastName: userEntity.LastName,
            FirstName: userEntity.FirstName,
            MiddleName: userEntity.MiddleName,
            Email: userEntity.Email,
            PhoneNumber: userEntity.PhoneNumber,
            Created: userEntity.Created);
        return Result<UserResponse>.Success(userResponse, "Пользователь успешно получен!");
    }

    public async Task<Result> CreateAsync(SignUpRequest request)
    {
        var isExistByEmail = await userRepository.IsExistByEmailAsync(request.Email);
        if (isExistByEmail)
            return Result<string>.Fail("Пользователь с данной почтой уже сущетсвует!");

        var isExistByPhoneNumber = await userRepository.IsExistByPhoneNumberAsync(request.PhoneNumber);
        if (isExistByPhoneNumber)
            return Result<string>.Fail("Пользователь с данным номером телефона уже сущетсвует!");

        var userEntity = new UserEntity {
            RoleId = request.RoleId,
            LastName = request.LastName,
            FirstName = request.FirstName,
            MiddleName = request.MiddleName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(request.Password)
        };
        await userRepository.CreateAsync(userEntity);
        return Result<string>.Success();
    }

    public async Task<Result> DeleteAsync(Guid id)
    {
        var userEntity = await userRepository.GetByIdAsync(id);
        if (userEntity == null)
            return Result<string>.Fail("Пользователь с данным идентификатором не найден!");

        await userRepository.DeleteAsync(userEntity);
        return Result<string>.Success("Пользователь успешно удалён");
    }
}