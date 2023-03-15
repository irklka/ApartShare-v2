using ApartShare.Core.Entities;
using ApartShare.Application.Interfaces;
using ApartShare.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;

namespace ApartShare.Infrastructure.Respository;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetUserByUsernamePassword(string username, 
        string password, 
        CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .Where(u => u.Username == username
                && u.Password == password)
            .FirstOrDefaultAsync(cancellationToken);

        return user;
    }
}
