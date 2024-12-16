using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace yum_admin.Models.DataTransferObject
{
    public class IngredientDto
    {
        [FromForm(Name = "IngredientId")]
        public short id { get; set; }

        [FromForm(Name = "IngredientName")]
        public string name { get; set; } = null!;

        [FromForm(Name = "AttributionId")]
        public byte attrId { get; set; }

        [FromForm(Name = "IngredientIcon")]
        public string? icon { get; set; }

    }
}
