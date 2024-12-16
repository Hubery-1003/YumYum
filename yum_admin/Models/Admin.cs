using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace yum_admin.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    [Display(Name = "帳號")]
    public string AdminAccount { get; set; } = null!;

    [Display(Name = "密碼")]
    public string AdminPassword { get; set; } = null!;

    [Display(Name = "名字")]
    public string AdminName { get; set; } = null!;

    [Display(Name = "Email")]
    public string AdminEmail { get; set; } = null!;

    [Display(Name = "頭像")]
    public string? AdminHeadShot { get; set; }

    [Display(Name = "手機")]
    public string AdminPhone { get; set; } = null!;
}
