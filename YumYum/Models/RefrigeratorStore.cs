using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class RefrigeratorStore
{
    public int StoreId { get; set; }

    public int UserId { get; set; }

    public short IngredientId { get; set; }

    public string Quantity { get; set; } = null!;

    public short UnitId { get; set; }

    public DateOnly ValidDate { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;

    public virtual UserSecretInfo User { get; set; } = null!;
}
