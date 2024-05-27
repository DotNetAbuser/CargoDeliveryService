namespace Application.IRepositories;

public interface IOrderRepository
{
    Task<IEnumerable<OrderEntity>> GetAllWithIncludesAsync();
    Task<IEnumerable<OrderEntity>> GetFreeOrdersWithIncludesAsync();

    Task<IEnumerable<OrderEntity>> GetAllByCreatorIdWithIncludesAsync(Guid id);
    Task<IEnumerable<OrderEntity>> GetAllByDriverIdWithIncludesAsync(Guid id);
    
    Task<OrderEntity?> GetByIdAsync(Guid id);
    Task<OrderEntity?> GetByIdWithIncludesAsync(Guid id);
    Task UpdateAsync(OrderEntity entity);
    Task CreateAsync(OrderEntity entity);
}