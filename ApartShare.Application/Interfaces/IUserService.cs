using ApartShare.Application.Models.Users;

namespace ApartShare.Application.Interfaces;

public interface IUserService
{
    Task RegisterUser(UserResiterDto user, CancellationToken cancellationToken);
    
    Task<UserDto> GetUserById(Guid id, CancellationToken cancellationToken);
    
    Task<Guid> ValidateUser(string username, string password, CancellationToken cancellationToken);
}
