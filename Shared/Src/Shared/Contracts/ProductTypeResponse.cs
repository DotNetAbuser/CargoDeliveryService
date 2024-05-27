namespace Shared.Contracts;

public record ProductTypeResponse(
    int Id,
    string Name,
    decimal PriceForOneKG,
    decimal PriceForDelivery);