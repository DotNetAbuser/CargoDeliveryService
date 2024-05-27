namespace Domain.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Email)
            .IsUnique();
        builder
            .HasIndex(x => x.PhoneNumber)
            .IsUnique();

        builder
            .HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleId);
        builder
            .HasMany(x => x.Sessions)
            .WithOne(x => x.User);

        builder.HasData(new List<UserEntity>
        {
            new()
            {
                Id = Guid.NewGuid(),
                RoleId = (int)Role.Guest,
                LastName = "Гиниятуллин",
                FirstName = "Булат",
                MiddleName = "Гость",
                Email = "bulatguest@example.com",
                PhoneNumber = "+7199992222",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("qwerty")
            },
            new()
            {
                Id = Guid.NewGuid(),
                RoleId = (int)Role.Driver,
                LastName = "Гиниятуллин",
                FirstName = "Булат",
                MiddleName = "Водитель",
                Email = "bulatdriver@example.com",
                PhoneNumber = "+7199992221",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("qwerty")
            },
            new()
            {
                Id = Guid.NewGuid(),
                RoleId = (int)Role.Operator,
                LastName = "Гиниятуллин",
                FirstName = "Булат",
                MiddleName = "Оператор",
                Email = "bulatoperator@example.com",
                PhoneNumber = "+7199992223",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("qwerty")
            },
            new()
            {
                Id = Guid.NewGuid(),
                RoleId = (int)Role.Admin,
                LastName = "Гиниятуллин",
                FirstName = "Булат",
                MiddleName = "Админ",
                Email = "bulatadmin@example.com",
                PhoneNumber = "+7199992224",
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("qwerty")
            }
        });
    }
}