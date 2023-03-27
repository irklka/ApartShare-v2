using ApartShare.Application.Mappings;
using ApartShare.Core.Entities;

using AutoMapper;

namespace ApartShare.Application.Models.Users;

public record UserRegisterDto
{
    public string Fullname { get; init; }
    public string Email { get; init; }
    public string UserName { get; init; }
    public string Password { get; set; }
    public byte[]? Image { get; init; } = default;
}
