using ApartShare.Core.Entities;

namespace ApartShare.Application.Interfaces.Repository;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUserByUsernamePassword(string username, string password, CancellationToken cancellationToken);
}
