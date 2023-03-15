using ApartShare.Application.Models.Users;

namespace ApartShare.Application.Models.Apartments;

public record ApartmentDto
{
    public Guid ApartmentId { get; init; }
    public string City { get; init; }
    public string Address { get; init; }
    public int? NumberOfBeds { get; init; }
    public byte[] Image { get; init; }
    public double DistanceToCenter { get; init; }
    public Guid OwnerId { get; init; }
    public UserDto Owner { get; init; }
}
