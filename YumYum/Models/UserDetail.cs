using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class UserDetail
{
    public int UserId { get; set; }

    public DateOnly? UserBirth { get; set; }

    public string? UserPhone { get; set; }

    public string? CityKey { get; set; }

    public short? RegionId { get; set; }

    public virtual City? CityKeyNavigation { get; set; }

    public virtual Region? Region { get; set; }

    public virtual UserSecretInfo User { get; set; } = null!;
}
