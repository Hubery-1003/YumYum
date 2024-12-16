using System;
using System.Collections.Generic;

namespace yum_admin.Models;

public partial class RecipeRecordField
{
    public short RecipeId { get; set; }

    public byte RecipeRecVersion { get; set; }

    public byte RecipeField { get; set; }

    public string? FieldShot { get; set; }

    public string? FieldDescript { get; set; }

    public bool FieldCheck { get; set; }

    public string? FieldComment { get; set; }

    public virtual RecipeBrief Recipe { get; set; } = null!;

    public virtual RecipeField RecipeFieldNavigation { get; set; } = null!;
}
