using System;
using System.Collections.Generic;

namespace UserPersentationLayer.Models;

public partial class ArAddress
{
    public int AddressId { get; set; }

    public int? UserId { get; set; }

    public string AddressType { get; set; } = null!;

    public string? Addresss { get; set; }

    public string? City { get; set; }

    public string? States { get; set; }

    public string? Country { get; set; }

    public string? ZipCode { get; set; }

    public virtual ArUsers? User { get; set; }
}
