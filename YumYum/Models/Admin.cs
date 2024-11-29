using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string AdminAccount { get; set; } = null!;

    public string AdminPassword { get; set; } = null!;

    public string AdminName { get; set; } = null!;

    public string AdminEmail { get; set; } = null!;

    public string? AdminHeadShot { get; set; }

    public string AdminPhone { get; set; } = null!;
}
