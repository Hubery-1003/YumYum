using System;
using System.Collections.Generic;

namespace YumYum.Models;

public partial class RecipeField
{
    public byte FieldId { get; set; }

    public string FieldName { get; set; } = null!;

    public virtual ICollection<RecipeRecordField> RecipeRecordFields { get; set; } = new List<RecipeRecordField>();
}
