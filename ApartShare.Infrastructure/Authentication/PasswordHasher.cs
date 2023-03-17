using ApartShare.Application.Interfaces.Services;

using System.Security.Cryptography;
using System.Text;

namespace ApartShare.Infrastructure.Authentication;

public class PasswordHasher : IHashService
{
    public string Hash(string key)
    {
        using SHA256 sha256Hash = SHA256.Create();

        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(key));
        StringBuilder stringbuilder = new StringBuilder();

        for (int i = 0; i < bytes.Length; i++)
        {
            stringbuilder.Append(bytes[i].ToString("x2"));
        }

        return stringbuilder.ToString();
    }
}
