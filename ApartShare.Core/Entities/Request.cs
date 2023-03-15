using ApartShare.Core.Enums;

namespace ApartShare.Core.Entities;

public class Request
{
    public Guid Id { get; set; }
    public RequestStatus Status { get; set; }
    public string City { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime DueDate { get; set; }
    public Guid GuestId { get; set; }
    public Guid HostId { get; set; }
    public User Guest { get; set; }
    public User Host { get; set; }
    public DateTime CreationDate { get; set; }
}