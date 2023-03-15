using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Web.Endpoints;

[ApiController]
public class BaseApiController : ControllerBase
{
    protected readonly IMediator _mediator;

    public BaseApiController(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected async Task<IActionResult> HandleRequest<TRequest>(TRequest request,
        CancellationToken cancellationToken)
        where TRequest : IBaseRequest
    {
        var result = await _mediator.Send(request, cancellationToken);

        return Ok(result);
    }
}
