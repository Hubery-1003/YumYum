using System;
using System.Collections.Generic;

namespace yum_admin.Models;

public partial class RecipeIngredient
{
    public short RecipeId { get; set; }

    public short IngredientId { get; set; }

    public string Quantity { get; set; } = null!;

    public short UnitId { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual RecipeBrief Recipe { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
