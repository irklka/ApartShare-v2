using ApartShare.Application.Models.Apartments;

namespace ApartShare.Application.Models.Users;

public record UserDto
{
    public Guid UserId { get; init; } = Guid.Empty;
    public string Fullname { get; init; }
    public string Email { get; init; }
    public string UserName { get; init; }
    public byte[]? Image { get; init; }
    public Guid? ApartmentId { get; init; } = Guid.Empty;
    public ApartmentDto? Apartment { get; init; } = default;
}
