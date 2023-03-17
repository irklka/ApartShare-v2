namespace ApartShare.Application.Interfaces.Services;

public interface IBase64Service
{
    string ToBase64(byte[] bytes);
    byte[] FromBase64(string base64String);
}
