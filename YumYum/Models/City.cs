using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class City
{
    public string CityKey { get; set; } = null!;

    public string CityName { get; set; } = null!;

    public virtual ICollection<CherishDefaultInfo> CherishDefaultInfos { get; set; } = new List<CherishDefaultInfo>();

    public virtual ICollection<CherishOrderInfo> CherishOrderInfos { get; set; } = new List<CherishOrderInfo>();

    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();
}
