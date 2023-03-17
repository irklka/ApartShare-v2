using ApartShare.Application.Interfaces;
using ApartShare.Application.Models.Users;

using MediatR;

namespace ApartShare.Web.Endpoints.User.GetUser;

public record GetUserRequest(Guid Id) 
    : IRequest<GetUserResponse>;

public record GetUserResponse(UserDto User);

public class GetUserHandler
    : IRequestHandler<GetUserRequest, GetUserResponse>
{
    private readonly IUserService _userService;
    public GetUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetUserById(request.Id, cancellationToken);

        return new GetUserResponse(user);
    }
}
