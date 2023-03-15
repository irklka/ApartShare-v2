using ApartShare.Application.Interfaces;
using ApartShare.Application.Models;

using Microsoft.Extensions.Options;

using System.Text;

namespace ApartShare.Application.Services;

public class Base64Service : IBase64Service
{
    private readonly Base64 _options;

    public Base64Service(IOptions<Base64> options)
    {
        _options = options.Value;
    }

    public byte[] FromBase64(string? base64String)
    {
        string base64WithoutPrefix;

        try
        {
            base64WithoutPrefix = base64String.Split(",")[1];
        }
        catch
        {
            throw new ArgumentNullException($"{base64String} can not be a null.");
        }

        var result = Convert.FromBase64String(base64WithoutPrefix);

        return result;
    }

    public string ToBase64(byte[] bytes)
    {
        var prefix = _options.Prefix;
        var prefixString = new StringBuilder(prefix);

        if (bytes is null)
        {
            throw new ArgumentNullException($"{bytes} can not be a null.");
        }

        var base64String = Convert.ToBase64String(bytes);
        prefixString.Append(base64String);

        return prefixString.ToString();
    }
}
