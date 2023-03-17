using ApartShare.Application.Interfaces;
using ApartShare.Application.Interfaces.Services;
using ApartShare.Application.Models.Users;

using FluentValidation;

using MediatR;

namespace ApartShare.Web.Endpoints.User.Register;

public record RegisterRequest(string Email, string Password, string RepeatPassword, string Login, string Fullname, string? ImageBase64)
    : IRequest;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email).EmailAddress();

        RuleFor(x => x.Password)
            .MinimumLength(6)
            .MaximumLength(50);

        RuleFor(x => x.Password == x.RepeatPassword);

        RuleFor(x => x.Login)
            .MinimumLength(3)
            .MaximumLength(20);

        RuleFor(x => x.Fullname)
            .MinimumLength(3)
            .MaximumLength(50);
    }
}

public class RegisterHandler : IRequestHandler<RegisterRequest>
{
    private readonly IUserService _userService;
    private readonly IBase64Service _base64Service;
    private readonly IHashService _hashService;
    private readonly IValidator<RegisterRequest> _validator;

    public RegisterHandler(IUserService userService, 
        IBase64Service base64Service,
        IHashService hashService,
        IValidator<RegisterRequest> validator)
    {
        _userService = userService;
        _base64Service = base64Service;
        _hashService = hashService;
        _validator = validator;
    }

    public async Task Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var imageString = request.ImageBase64;
        var image = _base64Service.FromBase64(imageString);
        var password = _hashService.Hash(request.Password);

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
