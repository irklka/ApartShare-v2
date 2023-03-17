﻿using ApartShare.Core.Entities;
using ApartShare.Application.Models.Users;
using ApartShare.Application.Interfaces;
using ApartShare.Application.Interfaces.Repository;

namespace ApartShare.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task RegisterUser(UserResiterDto user,
        CancellationToken cancellationToken)
    {
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Name = user.Fullname,
            Email = user.Email,
            Username = user.UserName,
            Password = user.Password,
            ImageBase64ByteArray = user.Image
        };

        await _userRepository.AddAsync(newUser, cancellationToken);
    }

    public async Task<Guid> ValidateUser(string username,
        string password, 
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByUsernamePassword(username, password, cancellationToken);

        if(user is null)
        {
            return Guid.Empty;
        }

        return user.Id;
    }

    public async Task<UserDto> GetUserById(Guid id, 
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(id, cancellationToken);

        var userDto = new UserDto
        {
            UserId = user.Id,
            Fullname = user.Name,
            Email = user.Email,
            UserName = user.Username,
            Image = user.ImageBase64ByteArray,
            ApartmentId = user.ApartmentId,
        };

        return userDto;
    }
}
