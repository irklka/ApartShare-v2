using ApartShare.Application.Interfaces;
using ApartShare.Application.Models.Users;

using MediatR;

namespace ApartShare.Web.Endpoints.Users.Login;

public record LoginRequest(string Login, string Password)
    : IRequest<LoginResponse>;

public record LoginResponse
{
    public UserDto? User { get; init; } = default;
    public bool Failed { get; init; }
}

public class LoginHandler
    : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IUserService _userService;
    private readonly IHashService _hashService;

    public LoginHandler(IUserService userService,
        IHashService hashService)
    {
        _userService = userService;
        _hashService = hashService;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var password = _hashService.GetHash(request.Password);

        var validUserId = await _userService.ValidateUser(request.Login, password, cancellationToken);

        if (validUserId == Guid.Empty)
        {
            return new LoginResponse
            {
                Failed = true
            };
        }

        var user = await _userService.GetUserById(validUserId, cancellationToken);

        return new LoginResponse
        {
            User = user,
            Failed = false
        };
    }
}
