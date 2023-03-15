namespace ApartShare.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public byte[]? ImageBase64ByteArray { get; set; }
    public Guid? ApartmentId { get; set; }
    public Apartment? Apartment { get; set; }
    public ICollection<Request> GuestRequests { get; set; }
    public ICollection<Request> HostRequests { get; set; }
}
