using System;
using System.Collections.Generic;

namespace UserPersentationLayer.Models;

public partial class ArUsers
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public string? Gender { get; set; }

    public DateOnly? DateOfJoining { get; set; }

    public DateOnly? Dob { get; set; }

    public string Email { get; set; } = null!;

    public string Passwords { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ArAddress> ArAddresses { get; set; } = new List<ArAddress>();

    public virtual ICollection<ArPhoneNumber> ArPhoneNumbers { get; set; } = new List<ArPhoneNumber>();
    public string ImageUrl { get; set; }
}
