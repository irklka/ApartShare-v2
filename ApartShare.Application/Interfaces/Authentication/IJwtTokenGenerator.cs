namespace ApartShare.Application.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    public string GenerateToken(Guid id, string fullname);
}
