using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class CherishCheckReason
{
    public byte ReasonId { get; set; }

    public string ReasonText { get; set; } = null!;

    public virtual ICollection<CherishOrderCheck> CherishOrderChecks { get; set; } = new List<CherishOrderCheck>();
}
