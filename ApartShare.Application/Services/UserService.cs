using ApartShare.Core.Entities;
using ApartShare.Infrastructure.Persistence;

using ApartShare.Application.Interfaces;
using ApartShare.Application.Models.Users;

namespace ApartShare.Application.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task RegisterUser(UserDto userDto, CancellationToken cancellationToken)
    {
        var newUser = new User
        {
            Name = userDto.Fullname,
            Email = userDto.Email,
            UserName = userDto.UserName,
            Password = userDto.Password,
            ImageBase64ByteArray = userDto.Image
        };

        await _context.AddAsync(newUser, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
