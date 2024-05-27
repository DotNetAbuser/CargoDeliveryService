namespace Domain.Configuration;

public class TrackingDetailConfiguration
    : IEntityTypeConfiguration<TrackingDetailEntity>
{
    public void Configure(EntityTypeBuilder<TrackingDetailEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(x => x.Order)
            .WithMany(x => x.TrackingDetails)
            .HasForeignKey(x => x.OrderId);
    }
}