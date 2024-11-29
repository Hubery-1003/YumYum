using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace YumYum.Models;

public partial class IngredAttribute
{
    public byte IngredAttributeId { get; set; }

    public string IngredAttributeName { get; set; } = null!;

    public string IngredAttributePhoto { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<CherishOrder> CherishOrders { get; set; } = new List<CherishOrder>();
    [JsonIgnore]
    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    [JsonIgnore]
    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
