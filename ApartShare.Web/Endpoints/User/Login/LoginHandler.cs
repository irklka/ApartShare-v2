using ApartShare.Application.Interfaces;
using ApartShare.Application.Interfaces.Authentication;
using ApartShare.Application.Interfaces.Services;
using ApartShare.Application.Models.Users;

using MediatR;

namespace ApartShare.Web.Endpoints.User.Login;

public record LoginRequest(string Login, string Password)
    : IRequest<LoginResponse>;

public record LoginResponse
{
    public UserDto? User { get; init; } = default;
    public string Token { get; init; }
    public bool Failed { get; init; }
}

public class LoginHandler
    : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IUserService _userService;
    private readonly IHashService _hashService;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public LoginHandler(IUserService userService,
        IHashService hashService,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userService = userService;
        _hashService = hashService;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var password = _hashService.Hash(request.Password);

        var validUserId = await _userService.ValidateUser(request.Login, password, cancellationToken);

        if (validUserId == Guid.Empty)
        {
            return new LoginResponse
            {
                Failed = true
            };
        }

        var user = await _userService.GetUserById(validUserId, cancellationToken);
        var token = _jwtTokenGenerator.GenerateToken(validUserId, user.Fullname);

        return new LoginResponse
        {
            User = user,
            Token = token,
            Failed = false
        };
    }
}
