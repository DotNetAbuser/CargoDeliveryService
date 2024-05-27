namespace Infrastructure.Services;

public class OrderService(
    IOrderRepository orderRepository,
    IProductTypeRepository productTypeRepository)
    : IOrderService
{
    public async Task<Result<IEnumerable<OrderResponse>>> GetAllAsync()
    {
        var ordersEntities = await orderRepository.GetAllWithIncludesAsync();
        var ordersResponse = ordersEntities.Select(orderEntity => 
            new OrderResponse(
                Id: orderEntity.Id,
                CreatorLastName: orderEntity.Creator.LastName,
                CreatorFirstName: orderEntity.Creator.FirstName,
                CreatorMiddleName: orderEntity.Creator.MiddleName,
                CreatorPhoneNumber: orderEntity.Creator.PhoneNumber,
                DriverLastName: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.LastName,
                DriverFirstName: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.FirstName,
                DriverMiddleName: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.MiddleName,
                DriverPhoneNumber: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.PhoneNumber,
                ProductTypeName: orderEntity.ProductType.Name ?? string.Empty,
                Description: orderEntity.Description,
                Weight: orderEntity.Weight,
                TotalPrice: orderEntity.TotalPrice,
                IsPayed: orderEntity.IsPayed,
                From: orderEntity.From,
                To: orderEntity.To,
                Created: orderEntity.Created)).ToList();
        return Result<IEnumerable<OrderResponse>>.Success(ordersResponse, "Список всех заказов успешно получен.");
    }

    public async Task<Result<IEnumerable<OrderResponse>>> GetFreeOrdersAsync()
    {
        var ordersEntities = await orderRepository.GetFreeOrdersWithIncludesAsync();
        var ordersResponse = ordersEntities.Select(orderEntity => 
            new OrderResponse(
                Id: orderEntity.Id,
                CreatorLastName: orderEntity.Creator.LastName,
                CreatorFirstName: orderEntity.Creator.FirstName,
                CreatorMiddleName: orderEntity.Creator.MiddleName,
                CreatorPhoneNumber: orderEntity.Creator.PhoneNumber,
                DriverLastName: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.LastName,
                DriverFirstName: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.FirstName,
                DriverMiddleName: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.MiddleName,
                DriverPhoneNumber: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.PhoneNumber,
                ProductTypeName: orderEntity.ProductType.Name ?? string.Empty,
                Description: orderEntity.Description,
                Weight: orderEntity.Weight,
                TotalPrice: orderEntity.TotalPrice,
                IsPayed: orderEntity.IsPayed,
                From: orderEntity.From,
                To: orderEntity.To,
                Created: orderEntity.Created)).ToList();
        return Result<IEnumerable<OrderResponse>>.Success(ordersResponse, "Список свободных заказов успешно получен.");
    }

    public async Task<Result<IEnumerable<OrderResponse>>> GetAllByCreatorIdAsync(Guid id)
    {
        var ordersEntities = await orderRepository.GetAllByCreatorIdWithIncludesAsync(id);
        var ordersResponse = ordersEntities.Select(orderEntity =>
            new OrderResponse(
                Id: orderEntity.Id,
                CreatorLastName: orderEntity.Creator.LastName,
                CreatorFirstName: orderEntity.Creator.FirstName,
                CreatorMiddleName: orderEntity.Creator.MiddleName,
                CreatorPhoneNumber: orderEntity.Creator.PhoneNumber,
                DriverLastName: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.LastName,
                DriverFirstName: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.FirstName,
                DriverMiddleName: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.MiddleName,
                DriverPhoneNumber: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.PhoneNumber,
                ProductTypeName: orderEntity.ProductType.Name ?? string.Empty,
                Description: orderEntity.Description,
                Weight: orderEntity.Weight,
                TotalPrice: orderEntity.TotalPrice,
                IsPayed: orderEntity.IsPayed,
                From: orderEntity.From,
                To: orderEntity.To,
                Created: orderEntity.Created)).ToList();
        return Result<IEnumerable<OrderResponse>>.Success(ordersResponse, "Список заказов по идентификатору их создателя успешно получен.");
    }

    public async Task<Result<IEnumerable<OrderResponse>>> GetAllByDriverIdAsync(Guid id)
    {
        var ordersEntities = await orderRepository.GetAllByDriverIdWithIncludesAsync(id);
        var ordersResponse = ordersEntities.Select(orderEntity =>
            new OrderResponse(
                Id: orderEntity.Id,
                CreatorLastName: orderEntity.Creator.LastName,
                CreatorFirstName: orderEntity.Creator.FirstName,
                CreatorMiddleName: orderEntity.Creator.MiddleName,
                CreatorPhoneNumber: orderEntity.Creator.PhoneNumber,
                DriverLastName: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.LastName,
                DriverFirstName: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.FirstName,
                DriverMiddleName: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.MiddleName,
                DriverPhoneNumber: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.PhoneNumber,
                ProductTypeName: orderEntity.ProductType.Name ?? string.Empty,
                Description: orderEntity.Description,
                Weight: orderEntity.Weight,
                TotalPrice: orderEntity.TotalPrice,
                IsPayed: orderEntity.IsPayed,
                From: orderEntity.From,
                To: orderEntity.To,
                Created: orderEntity.Created)).ToList();
        return Result<IEnumerable<OrderResponse>>.Success(ordersResponse, "Список заказов по идентификатору действующего водителя успешно получен.");
    }

    public async Task<Result<OrderResponse>> GetByIdAsync(Guid id)
    {
        var orderEntity = await orderRepository.GetByIdWithIncludesAsync(id);
        if (orderEntity == null)
            return Result<OrderResponse>.Fail("Заказ с данным идентификатором не найден!");

        var orderResponse = new OrderResponse(
            Id: orderEntity.Id,
            CreatorLastName: orderEntity.Creator.LastName,
            CreatorFirstName: orderEntity.Creator.FirstName,
            CreatorMiddleName: orderEntity.Creator.MiddleName,
            CreatorPhoneNumber: orderEntity.Creator.PhoneNumber,
            DriverLastName: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.LastName,
            DriverFirstName: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.FirstName,
            DriverMiddleName: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.MiddleName,
            DriverPhoneNumber: orderEntity.Driver == null ? string.Empty : orderEntity.Driver.PhoneNumber,
            ProductTypeName: orderEntity.ProductType.Name ?? string.Empty,
            Description: orderEntity.Description,
            Weight: orderEntity.Weight,
            TotalPrice: orderEntity.TotalPrice,
            IsPayed: orderEntity.IsPayed,
            From: orderEntity.From,
            To: orderEntity.To,
            Created: orderEntity.Created);
        return Result<OrderResponse>.Success(orderResponse ,"Заказ по идентификатору успешно получен.");
    }

    public async Task<Result> CreateAsync(CreateOrderRequest request)
    {
        var productTypeEntity = await productTypeRepository.GetByIdAsync(request.ProductTypeId);
        if (productTypeEntity == null)
            return Result<string>.Fail("Данный тип груза не найден!");

        var totalCost = productTypeEntity.PriceForOneKG * (decimal)request.Weight
                        + productTypeEntity.PriceForDelivery;
        var orderEntity = new OrderEntity {
            CreatorId = request.CreatorId,
            ProductTypeId = request.ProductTypeId,
            Description = request.Description,
            Weight = request.Weight,
            TotalPrice = totalCost,
            From = request.From,
            To = request.To
        };
        await orderRepository.CreateAsync(orderEntity);
        return Result<string>.Success("Заказ успешно создан.");
    }

    public async Task<Result> TakeOrderAsync(Guid id, TakeOrderRequest request)
    {
        var orderEntity = await orderRepository.GetByIdAsync(id);
        if (orderEntity == null)
            return Result<string>.Fail("Заказ с данным идентификатором не найден!");

        if (orderEntity.Driver != null)
            return Result<string>.Fail("Заказ уже взят другим водителем!");
        
        orderEntity.DriverId = request.DriverId;
        orderEntity.Updated = DateTime.UtcNow;
        await orderRepository.UpdateAsync(orderEntity);
        return Result<string>.Success("Заказ успешно взят.");
    }
    
    public async Task<Result> ChangePaymentStatusAsync(Guid id,ChangePaymentStatusRequest request)
    {
        var orderEntity = await orderRepository.GetByIdAsync(id);
        if (orderEntity == null)
            return Result<string>.Fail("Заказ с данным идентификатором не найден!");

        orderEntity.IsPayed = request.IsPayed;
        orderEntity.Updated = DateTime.UtcNow;
        await orderRepository.UpdateAsync(orderEntity);
        return Result<string>.Success("Статус оплаты успешно изменён.");
    }
}