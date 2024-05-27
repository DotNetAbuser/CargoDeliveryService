namespace Shared.Contracts;

public class UpdateProductTypeRequest
{
    public string Name { get; set; } = string.Empty;
    public decimal PriceForOneKG { get; set; }
    public decimal PriceForDelivery { get; set; }
}