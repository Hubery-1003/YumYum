using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace YumYum.Models;

public partial class RecipeRecord
{
    public short RecipeId { get; set; }

    public byte RecipeRecVersion { get; set; }

    public byte RecipeStatusCode { get; set; }

    public DateTime RecipeRecDate { get; set; }
    [ValidateNever]
    public virtual RecipeBrief Recipe { get; set; } = null!;
    [ValidateNever]
    public virtual RecipeState RecipeStatusCodeNavigation { get; set; } = null!;
}
