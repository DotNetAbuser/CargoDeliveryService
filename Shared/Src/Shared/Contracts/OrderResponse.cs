namespace Shared.Contracts;

public record OrderResponse(
    Guid Id,
    string CreatorLastName,
    string CreatorFirstName,
    string CreatorMiddleName,
    string CreatorPhoneNumber,
    string DriverLastName,
    string DriverFirstName,
    string DriverMiddleName,
    string DriverPhoneNumber,
    string ProductTypeName,
    string Description,
    double Weight,
    decimal TotalPrice,
    bool IsPayed,
    string From,
    string To,
    DateTime Created);