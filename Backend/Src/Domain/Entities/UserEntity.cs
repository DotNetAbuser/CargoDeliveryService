namespace Domain.Entities;

public class UserEntity
    : BaseEntity<Guid>
{
    public int RoleId { get; set; }
    
    public string LastName { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    public string PhoneNumber { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;

    public RoleEntity Role { get; set; } = default!;
    public virtual ICollection<SessionEntity> Sessions { get; set; } = [];
    public virtual ICollection<OrderEntity> CreatorOrders { get; set; } = [];
    public virtual ICollection<OrderEntity> DriverOrders { get; set; } = [];
}