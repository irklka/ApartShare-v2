using ApartShare.Application.Interfaces;
using ApartShare.Application.Models.Users;

using MediatR;

namespace ApartShare.Web.Endpoints.Users.Register;

public record RegisterRequest(string Email, string Password, string RepeatPassword, string Login, string Fullname, string? ImageBase64)
    : IRequest;

public class RegisterHandler : IRequestHandler<RegisterRequest>
{
    private readonly IUserService _userService;
    private readonly IBase64Service _base64Service;
    private readonly IHashService _hashService;

    public RegisterHandler(IUserService userService, 
        IBase64Service base64Service,
        IHashService hashService)
    {
        _userService = userService;
        _base64Service = base64Service;
        _hashService = hashService;
    }

    public async Task Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var imageString = request.ImageBase64;
        var image = _base64Service.FromBase64(imageString);
        var password = _hashService.GetHash(request.Password);

        var newUser = new UserResiterDto
        {
            Fullname = request.Fullname,
            Email = request.Email,
            UserName = request.Login,
            Password = password,
            Image = image ?? default
        };

        await _userService.RegisterUser(newUser, cancellationToken);
    }

}
