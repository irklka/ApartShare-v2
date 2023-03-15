using ApartShare.Application.Models.Users;

namespace ApartShare.Application.Interfaces;

public interface IUserService
{
    Task RegisterUser(UserDto user, CancellationToken cancellationToken);
}
