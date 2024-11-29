using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class RecipeClass
{
    public short RecipeClassId { get; set; }

    public string RecipeClassName { get; set; } = null!;

    public virtual ICollection<RecipeBrief> RecipeBriefs { get; set; } = new List<RecipeBrief>();
}
