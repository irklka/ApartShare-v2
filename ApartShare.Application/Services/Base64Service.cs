using ApartShare.Application.Interfaces;
using ApartShare.Application.Models;

using Microsoft.Extensions.Options;

using System.Text;

namespace ApartShare.Application.Services;

public class Base64Service : IBase64Service
{
    private readonly Base64Options _options;

    public Base64Service(IOptionsSnapshot<Base64Options> options)
    {
        _options = options.Value;
    }

    public byte[] FromBase64(string? base64String)
    {
        if (string.IsNullOrWhiteSpace(base64String))
        {
            return default!;
        }

        string base64WithoutPrefix;

        try
        {
            base64WithoutPrefix = base64String!.Split(",")[1];
        }
        catch
        {
            return default!;
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
            return string.Empty;
        }

        var base64String = Convert.ToBase64String(bytes);
        prefixString.Append(base64String);

        return prefixString.ToString();
    }
}
