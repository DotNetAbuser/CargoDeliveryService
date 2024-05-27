namespace Shared.Contracts;

public class CreateTrackingDetailRequest
{
    public Guid OrderId { get; set; }
    public string Location { get; set; } = string.Empty;
}