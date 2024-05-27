namespace Shared.Contracts;

public record UserResponse(
    Guid Id,
    string LastName,
    string FirstName,
    string MiddleName,
    string Email,
    string PhoneNumber,
    DateTime Created);