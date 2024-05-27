namespace Domain.Entities;

public class TrackingDetailEntity
    : BaseEntity<Guid>
{
    public Guid OrderId { get; set; }

    public string Location { get; set; } = string.Empty;

    public OrderEntity Order { get; set; } = default!;
}