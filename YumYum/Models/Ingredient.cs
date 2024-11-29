using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace YumYum.Models;

public partial class Ingredient
{
    public short IngredientId { get; set; }

    public string IngredientName { get; set; } = null!;

    public byte AttributionId { get; set; }

    public string? IngredientIcon { get; set; }

    public virtual IngredAttribute Attribution { get; set; } = null!;

    public virtual ICollection<CherishOrder> CherishOrders { get; set; } = new List<CherishOrder>();
    [JsonIgnore]
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public virtual ICollection<RefrigeratorStore> RefrigeratorStores { get; set; } = new List<RefrigeratorStore>();
}
