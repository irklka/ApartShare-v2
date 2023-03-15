using ApartShare.Application.Interfaces;

using System.Security.Cryptography;
using System.Text;

namespace ApartShare.Application.Services;

public class HashService : IHashService
{
    public string GetHash(string key)
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
