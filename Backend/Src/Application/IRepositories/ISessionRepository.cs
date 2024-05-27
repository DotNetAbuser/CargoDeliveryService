using Domain.Entities;

namespace Application.IRepositories;

public interface ISessionRepository
{
    Task CreateAsync(SessionEntity entity);
    Task<SessionEntity?> GetByRefreshTokenAsync(string token);
    Task DeleteAsync(SessionEntity entity);
}