using ApartShare.Core.Entities;

namespace ApartShare.Application.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUserByUsernamePassword(string username, string password, CancellationToken cancellationToken);
}
