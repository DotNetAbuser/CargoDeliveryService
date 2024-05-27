namespace Shared.Contracts;

public record TrackingDetailResponse(
    Guid Id,
    Guid OrderId,
    string Location,
    DateTime Created);