using System;
using System.Collections.Generic;

namespace yum_admin.Models;

public partial class CherishTradeTime
{
    public int TimeId { get; set; }

    public int CherishId { get; set; }

    public string TradeTimeCode { get; set; } = null!;

    public virtual CherishOrder Cherish { get; set; } = null!;
}
