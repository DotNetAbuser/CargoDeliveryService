namespace Domain.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Name)
            .IsUnique();

        builder
            .HasMany(x => x.Users)
            .WithOne(x => x.Role);

        builder.HasData(new List<RoleEntity>
        {
            new()
            {
                Id = (int)Role.Guest,
                Name = Role.Guest.ToString()
            },
            new()
            {
                Id = (int)Role.Driver,
                Name = Role.Driver.ToString()
            },
            new()
            {
                Id = (int)Role.Operator,
                Name = Role.Operator.ToString()
            },
            new() 
            {
                Id = (int)Role.Admin,
                Name = Role.Admin.ToString()
            }
        });
    }
}