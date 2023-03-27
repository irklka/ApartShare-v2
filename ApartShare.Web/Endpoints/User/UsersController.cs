using ApartShare.Web.Endpoints.User.GetUser;
using ApartShare.Web.Endpoints.User.Login;
using ApartShare.Web.Endpoints.User.Register;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Endpoints.Users;

[Route("api/users")]
public class UserController : ApiControllerBase
{
    public UserController(IMediator mediator) : base(mediator) { }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellationToken)
    {
        await _mediator.Send(request, cancellationToken);

        return NoContent();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(request, cancellationToken);

        return Ok(result);
    }


    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUserRequest(id), cancellationToken);

        return Ok(result);
    }
}
