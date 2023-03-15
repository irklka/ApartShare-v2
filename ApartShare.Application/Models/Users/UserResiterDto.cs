namespace ApartShare.Application.Models.Users;

public record UserResiterDto
{
    public Guid UserId { get; init; } = Guid.Empty;
    public string Fullname { get; init; }
    public string Email { get; init; }
    public string UserName { get; init; }
    public string Password { get; set; }
    public byte[]? Image { get; init; } = default;
}
