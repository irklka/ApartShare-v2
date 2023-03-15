using ApartShare.Application.Interfaces;
using ApartShare.Application.Models.Users;

using MediatR;

namespace Web.Endpoints.Users.Register;

public record RegisterRequest(string Email, string Password, string Login, string Fullname, string? ImageBase64)
    : IRequest<RegisterResponse>;

public record RegisterResponse
{
    public int Id { get; init; }
    public string Email { get; init; }
    public string Login { get; init; }
    public string Fullname { get; init; }
    public string? ImageBase64 { get; init; }
}

public class RegisterHandler : IRequestHandler<RegisterRequest, RegisterResponse>
{
    private readonly IUserService _userService;
    private readonly IBase64Service _base64Service;

    public RegisterHandler(IUserService userService, IBase64Service base64Service)
    {
        _userService = userService;
        _base64Service = base64Service;
    }

    public async Task<RegisterResponse> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var imageString = request.ImageBase64;
        var image = _base64Service.FromBase64(imageString);

        var newUser = new UserDto
        {
            Fullname = request.Fullname,
            Email = request.Email,
            UserName = request.Login,
            Password = request.Password,
            Image = image ?? default
        };

        await _userService.RegisterUser(newUser, cancellationToken);

        return new RegisterResponse();
    }

}
