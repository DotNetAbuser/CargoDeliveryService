namespace Domain.Configuration;

public class ProductTypeConfiguration
    : IEntityTypeConfiguration<ProductTypeEntity>
{
    public void Configure(EntityTypeBuilder<ProductTypeEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Name)
            .IsUnique();

        builder.HasData(new List<ProductTypeEntity>
        {
            new()
            {
                Id = 1,
                Name = "Мебель",
                PriceForOneKG = 100,
                PriceForDelivery = 300
            },
            new()
            {
                Id = 2,
                Name = "Электроника",
                PriceForOneKG = 150,
                PriceForDelivery = 600
            },
            new()
            {
                Id = 3,
                Name = "Документы",
                PriceForOneKG = 200,
                PriceForDelivery = 200
            },
            new()
            {
                Id = 4,
                Name = "Предметы личной гигиены",
                PriceForOneKG = 100,
                PriceForDelivery = 300
            },
            new()
            {
                Id = 5,
                Name = "Драгоценности",
                PriceForOneKG = 150,
                PriceForDelivery = 1000
            }
        });
    }
}