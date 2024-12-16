using System;
using System.Collections.Generic;

namespace yum_admin.Models;

public partial class RecipeClass
{
    public short RecipeClassId { get; set; }

    public string RecipeClassName { get; set; } = null!;

    public virtual ICollection<RecipeBrief> RecipeBriefs { get; set; } = new List<RecipeBrief>();
}
