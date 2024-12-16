using System;
using System.Collections.Generic;

namespace yum_admin.Models;

public partial class CherishOrderApplicant
{
    public int CherishId { get; set; }

    public int ApplicantId { get; set; }

    public string UserNickname { get; set; } = null!;

    public string? ApplicantContactLine { get; set; }

    public string? ApplicantContactPhone { get; set; }

    public string? ApplicantContactOther { get; set; }

    public virtual UserSecretInfo Applicant { get; set; } = null!;
}
