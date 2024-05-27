namespace Domain.Entities;

public class ProductTypeEntity
    : BaseEntity<int>
{
    public string Name { get; set; }
    public decimal PriceForOneKG { get; set; }
    public decimal PriceForDelivery { get; set; }

    public virtual ICollection<OrderEntity> Orders { get; set; } = [];
}