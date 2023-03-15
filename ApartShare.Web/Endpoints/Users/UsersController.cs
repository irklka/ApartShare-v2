using MediatR;

using Microsoft.AspNetCore.Mvc;
using Web.Endpoints.Users.Register;

namespace Web.Endpoints.Users;

[Route("api/users")]
public class UserController : BaseApiController
{
    public UserController(IMediator mediator) : base(mediator) { }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest request, CancellationToken cancellation)
    {
        var response = await _mediator.Send(request, cancellation);

        return Ok(response);
    }
}
