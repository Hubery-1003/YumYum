﻿using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class CherishOrderInfo
{
    public int CherishId { get; set; }

    public string UserNickname { get; set; } = null!;

    public string TradeCityKey { get; set; } = null!;

    public short TradeRegionId { get; set; }

    public string? ContactLine { get; set; }

    public string? ContactPhone { get; set; }

    public string? ContactOther { get; set; }

    public virtual CherishOrder Cherish { get; set; } = null!;

    public virtual City TradeCityKeyNavigation { get; set; } = null!;

    public virtual Region TradeRegion { get; set; } = null!;
}
