using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace YumYum.Models;

public partial class RecipeRecordField
{
    public short RecipeId { get; set; }

    public byte RecipeRecVersion { get; set; }

    public byte RecipeField { get; set; }

    public string? FieldShot { get; set; }

    public string? FieldDescript { get; set; }

    public bool FieldCheck { get; set; }

    public string? FieldComment { get; set; }
    [ValidateNever]
    public virtual RecipeBrief Recipe { get; set; } = null!;
    [ValidateNever]
    public virtual RecipeField RecipeFieldNavigation { get; set; } = null!;
}
