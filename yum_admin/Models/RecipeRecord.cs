using System;
using System.Collections.Generic;

namespace yum_admin.Models;

public partial class RecipeRecord
{
    public short RecipeId { get; set; }

    public byte RecipeRecVersion { get; set; }

    public byte RecipeStatusCode { get; set; }

    public DateOnly RecipeRecDate { get; set; }

    public virtual RecipeBrief Recipe { get; set; } = null!;

    public virtual RecipeState RecipeStatusCodeNavigation { get; set; } = null!;
}
