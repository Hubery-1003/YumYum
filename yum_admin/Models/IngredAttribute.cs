using System;
using System.Collections.Generic;

namespace yum_admin.Models;

public partial class IngredAttribute
{
    public byte IngredAttributeId { get; set; }

    public string IngredAttributeName { get; set; } = null!;

    public string IngredAttributePhoto { get; set; } = null!;

    public virtual ICollection<CherishOrder> CherishOrders { get; set; } = new List<CherishOrder>();

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
