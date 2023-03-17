using ApartShare.Application.Interfaces.Authentication;
using ApartShare.Application.Interfaces.Services;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApartShare.Infrastructure.Authentication;
public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,
        IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
        _dateTimeProvider = dateTimeProvider;
    }

    public string GenerateToken(Guid userId, string fullname)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, fullname),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var credenials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            claims: claims,
            signingCredentials: credenials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
