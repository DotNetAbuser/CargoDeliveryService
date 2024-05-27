namespace Domain.Entities;

public class OrderEntity
    : BaseEntity<Guid>
{
    public Guid CreatorId { get; set; }
    public Guid? DriverId { get; set; }

    public int ProductTypeId { get; set; }

    public string? Description { get; set; }
    public double Weight { get; set; }
    public decimal TotalPrice { get; set; }
    
    public bool IsPayed { get; set; }
    
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;

    public UserEntity Creator { get; set; } = default!;
    public UserEntity? Driver { get; set; }
    public ProductTypeEntity ProductType { get; set; } = default!;
    public virtual ICollection<TrackingDetailEntity> TrackingDetails { get; set; } = [];
}