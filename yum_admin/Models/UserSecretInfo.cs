using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace yum_admin.Models;

public partial class UserSecretInfo
{
    [Display(Name = "ID")]
    public int UserId { get; set; }

    [Display(Name = "Name")]
    public string? UserNickname { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool EmailChecked { get; set; }

    public string? EmailValidCode { get; set; }

    public virtual CherishDefaultInfo? CherishDefaultInfo { get; set; }

    public virtual ICollection<CherishDefaultTimeSet> CherishDefaultTimeSets { get; set; } = new List<CherishDefaultTimeSet>();

    public virtual ICollection<CherishOrderApplicant> CherishOrderApplicants { get; set; } = new List<CherishOrderApplicant>();

    public virtual ICollection<CherishOrder> CherishOrders { get; set; } = new List<CherishOrder>();

    public virtual ICollection<RecipeBrief> RecipeBriefs { get; set; } = new List<RecipeBrief>();

    public virtual ICollection<RefrigeratorStore> RefrigeratorStores { get; set; } = new List<RefrigeratorStore>();

    public virtual UserBio? UserBio { get; set; }

    public virtual ICollection<RecipeBrief> Recipes { get; set; } = new List<RecipeBrief>();
}
