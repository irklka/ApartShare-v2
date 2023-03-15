﻿namespace ApartShare.Core.Entities;

public class Apartment
{
    public Guid Id { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public int? BedsNumber { get; set; }
    public byte[] ImageBase64ByteArray { get; set; }
    public double DistanceToCenter { get; set; }
    public Guid OwnerId { get; set; }
    public User Owner { get; set; }
}