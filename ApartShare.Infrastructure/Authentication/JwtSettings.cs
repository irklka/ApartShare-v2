namespace ApartShare.Infrastructure.Authentication;

public record JwtSettings
{
    public const string SECTION_NAME = "JwtSettings";
    public string Secret { get; init; }
    public int ExpiryMinutes { get; init; }
    public string Issuer { get; init; }
    public string Audience { get; init; }
}
