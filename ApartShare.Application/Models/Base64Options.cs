namespace ApartShare.Application.Models;

public record Base64Options
{
    public const string SECTION_NAME = "Base64";
    public string Prefix { get; init; } = default!;
}
