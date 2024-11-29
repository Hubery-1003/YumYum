using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class RecipeState
{
    public byte RecipeStateCode { get; set; }

    public string RecipeStateDescript { get; set; } = null!;

    public virtual ICollection<RecipeRecord> RecipeRecords { get; set; } = new List<RecipeRecord>();
}
