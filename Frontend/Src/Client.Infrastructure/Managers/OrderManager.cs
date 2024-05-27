namespace Client.Infrastructure.Managers;

public interface IOrderManager
{
    Task<IResult<IEnumerable<OrderResponse>>> GetAllAsync();
    Task<IResult<IEnumerable<OrderResponse>>> GetFreeOrdersAsync();
    
    Task<IResult<IEnumerable<OrderResponse>>> GetAllByCreatorIdAsync(Guid id);
    Task<IResult<IEnumerable<OrderResponse>>> GetAllByDriverIdAsync(Guid id);

    Task<IResult<OrderResponse>> GetByIdAsync(Guid id);

    Task<IResult> CreateAsync(CreateOrderRequest request);
    Task<IResult> TakeOrderAsync(Guid id, TakeOrderRequest request);
    Task<IResult> ChangePaymentStatusAsync(Guid id,ChangePaymentStatusRequest request);
}

public class OrderManager(
    IHttpClientFactory factory)
    : IOrderManager
{
    public async Task<IResult<IEnumerable<OrderResponse>>> GetAllAsync()
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(OrderRoutes.GetAll);
        return await response.ToResultAsync<IEnumerable<OrderResponse>>();
    }

    public async Task<IResult<IEnumerable<OrderResponse>>> GetFreeOrdersAsync()
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(OrderRoutes.GetFreeOrders);
        return await response.ToResultAsync<IEnumerable<OrderResponse>>();
    }

    public async Task<IResult<IEnumerable<OrderResponse>>> GetAllByCreatorIdAsync(Guid id)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(OrderRoutes.GetAllByCreatorId(id));
        return await response.ToResultAsync<IEnumerable<OrderResponse>>();
    }

    public async Task<IResult<IEnumerable<OrderResponse>>> GetAllByDriverIdAsync(Guid id)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(OrderRoutes.GetAllByDriverId(id));
        return await response.ToResultAsync<IEnumerable<OrderResponse>>();
    }

    public async Task<IResult<OrderResponse>> GetByIdAsync(Guid id)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .GetAsync(OrderRoutes.GetById(id));
        return await response.ToResultAsync<OrderResponse>();
    }

    public async Task<IResult> CreateAsync(CreateOrderRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PostAsJsonAsync(OrderRoutes.Create, request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> TakeOrderAsync(Guid id, TakeOrderRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PutAsJsonAsync(OrderRoutes.TakeOrder(id), request);
        return await response.ToResultAsync();
    }

    public async Task<IResult> ChangePaymentStatusAsync(Guid id, ChangePaymentStatusRequest request)
    {
        var response = await factory.CreateClient(ApplicationConstants.BaseClientName)
            .PutAsJsonAsync(OrderRoutes.ChangePaymentStatus(id), request);
        return await response.ToResultAsync();
    }
}