using System;
using System.Collections.Generic;

namespace yum_admin.Models;

public partial class RecipeBrief
{
    public short RecipeId { get; set; }

    public string RecipeName { get; set; } = null!;

    public short RecipeClassId { get; set; }

    public short FinishMinute { get; set; }

    public int CreatorId { get; set; }

    public byte PersonQuantity { get; set; }

    public DateOnly CreateDate { get; set; }

    public short ClickTime { get; set; }

    public virtual UserSecretInfo Creator { get; set; } = null!;

    public virtual RecipeClass RecipeClass { get; set; } = null!;

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public virtual ICollection<RecipeRecordField> RecipeRecordFields { get; set; } = new List<RecipeRecordField>();

    public virtual ICollection<RecipeRecord> RecipeRecords { get; set; } = new List<RecipeRecord>();

    public virtual ICollection<UserSecretInfo> Users { get; set; } = new List<UserSecretInfo>();
}
