using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class CherishDefaultTimeSet
{
    public int TimeId { get; set; }

    public int GiverUserId { get; set; }

    public string TradeTimeCode { get; set; } = null!;

    public virtual UserSecretInfo GiverUser { get; set; } = null!;
}
