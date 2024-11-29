using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class RecipeStep
{
    public short RecipeId { get; set; }

    public byte StepNumber { get; set; }

    public string? StepShot { get; set; }

    public string StepDescript { get; set; } = null!;

    public virtual RecipeBrief Recipe { get; set; } = null!;
}
