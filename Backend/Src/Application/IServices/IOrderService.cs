namespace Application.IServices;

public interface IOrderService
{
    Task<Result<IEnumerable<OrderResponse>>> GetAllAsync();
    Task<Result<IEnumerable<OrderResponse>>> GetFreeOrdersAsync();
    
    Task<Result<IEnumerable<OrderResponse>>> GetAllByCreatorIdAsync(Guid id);
    Task<Result<IEnumerable<OrderResponse>>> GetAllByDriverIdAsync(Guid id);
    
    Task<Result<OrderResponse>> GetByIdAsync(Guid id);
    
    Task<Result> CreateAsync(CreateOrderRequest request);
    Task<Result> TakeOrderAsync(Guid id, TakeOrderRequest request);
    Task<Result> ChangePaymentStatusAsync(Guid id,ChangePaymentStatusRequest request);
}