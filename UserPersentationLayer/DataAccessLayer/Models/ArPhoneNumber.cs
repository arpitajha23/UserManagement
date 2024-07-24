using System;
using System.Collections.Generic;

namespace UserPersentationLayer.Models;

public partial class ArPhoneNumber
{
    public int PhoneNumberId { get; set; }

    public int? UserId { get; set; }

    public string PhoneType { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public virtual ArUsers? User { get; set; }
}
