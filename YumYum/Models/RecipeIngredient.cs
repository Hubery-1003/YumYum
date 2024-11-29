using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace YumYum.Models;

public partial class RecipeIngredient
{
    public short RecipeId { get; set; }

    public short IngredientId { get; set; }

    public string Quantity { get; set; } = null!;

    public short UnitId { get; set; }
    [ValidateNever]
    [JsonIgnore]
    public virtual Ingredient? Ingredient { get; set; } = null!;
    [ValidateNever]
    public virtual RecipeBrief? Recipe { get; set; } = null!;
    [ValidateNever]
    [JsonIgnore]
    public virtual Unit? Unit { get; set; } = null!;
}
