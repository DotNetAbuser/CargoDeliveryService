namespace Infrastructure.Repositories;

public class UserRepository(
    ApplicationDbContext dbContext)
    : IUserRepository
{
    public async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await dbContext.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<UserEntity?> GetByPhoneNumberWithRoleAsync(string phoneNumber)
    {
        return await dbContext.Users
            .AsNoTracking()
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
    }

    public async Task<UserEntity?> GetByIdWithRoleAsync(Guid id)
    {
        return await dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<UserEntity?> GetByIdAsync(Guid id)
    {
        return await dbContext.Users
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> IsExistByEmailAsync(string email)
    {
        return await dbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.Email == email);
    }

    public async Task<bool> IsExistByPhoneNumberAsync(string phoneNumber)
    {
        return await dbContext.Users
            .AsNoTracking()
            .AnyAsync(x => x.PhoneNumber == phoneNumber);
    }

    public async Task CreateAsync(UserEntity entity)
    {
        await dbContext.Users.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(UserEntity entity)
    {
        dbContext.Users.Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}