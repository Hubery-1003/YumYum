using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class TradeState
{
    public byte TradeStateCode { get; set; }

    public string TradeStateDescript { get; set; } = null!;

    public virtual ICollection<CherishOrder> CherishOrders { get; set; } = new List<CherishOrder>();
}
