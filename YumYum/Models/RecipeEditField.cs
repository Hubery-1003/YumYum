using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class RecipeEditField
{
    public byte EditFieldId { get; set; }

    public string? EditFieldName { get; set; }

    public virtual ICollection<RecipeBrief> RecipeBriefs { get; set; } = new List<RecipeBrief>();
}
