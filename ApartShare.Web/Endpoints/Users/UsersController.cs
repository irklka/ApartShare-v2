using ApartShare.Web.Endpoints.Users.Login;
using ApartShare.Web.Endpoints.Users.Register;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Web.Endpoints.Users;

[Route("api/users")]
public class UserController : BaseApiController
{
    public UserController(IMediator mediator) : base(mediator) { }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellation)
    {
        await _mediator.Send(request, cancellation);

        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellation)
    {
        var result = await _mediator.Send(request, cancellation);

        return Ok(result);
    }
}
