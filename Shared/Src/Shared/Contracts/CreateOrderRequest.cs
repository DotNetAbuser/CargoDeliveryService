namespace Shared.Contracts;

public class CreateOrderRequest
{
    public Guid CreatorId { get; set; }
    public int ProductTypeId { get; set; }
    
    public string Description { get; set; } = string.Empty;
    public double Weight { get; set; }
    
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
}