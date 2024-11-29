using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class CherishOrderCheck
{
    public int CherishId { get; set; }

    public byte? ReasonId { get; set; }

    public string? RejectText { get; set; }

    public DateOnly? CherishValidDate { get; set; }

    public string CherishPhoto { get; set; } = null!;

    public string OtherPhoto { get; set; } = null!;

    public string? ValidDatePhoto { get; set; }

    public virtual CherishOrder Cherish { get; set; } = null!;

    public virtual CherishCheckReason? Reason { get; set; }
}
