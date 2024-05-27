namespace Domain.Configuration;

public class OrderConfiguration 
    : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Creator)
            .WithMany(x => x.CreatorOrders)
            .HasForeignKey(x => x.CreatorId);
        builder
            .HasOne(x => x.Driver)
            .WithMany(x => x.DriverOrders)
            .HasForeignKey(x => x.DriverId);
        builder
            .HasOne(x => x.ProductType)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.ProductTypeId);
        builder
            .HasMany(x => x.TrackingDetails)
            .WithOne(x => x.Order);

    }
}