using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace YumYum.Models;

public partial class Unit
{
    public short UnitId { get; set; }

    public byte IngredAttributeId { get; set; }

    public string UnitName { get; set; } = null!;

    public virtual IngredAttribute IngredAttribute { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public virtual ICollection<RefrigeratorStore> RefrigeratorStores { get; set; } = new List<RefrigeratorStore>();
}
