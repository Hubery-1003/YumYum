using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class Region
{
    public short RegionId { get; set; }

    public string CityKey { get; set; } = null!;

    public string RegionName { get; set; } = null!;

    public virtual ICollection<CherishDefaultInfo> CherishDefaultInfos { get; set; } = new List<CherishDefaultInfo>();

    public virtual ICollection<CherishOrderInfo> CherishOrderInfos { get; set; } = new List<CherishOrderInfo>();

    public virtual City CityKeyNavigation { get; set; } = null!;
}
