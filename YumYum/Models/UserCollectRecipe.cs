using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace YumYum.Models
{
    public partial class UserCollectRecipe
    {
        [Key]
        [Column(Order = 1)]
        public int UserID { get; set; }

        [Key]
        [Column(Order = 2)]
        public short RecipeID { get; set; }
        
        [ForeignKey(nameof(RecipeID))] // 綁定外鍵
        public RecipeBrief Recipe { get; set; } = null!;
        
        [ForeignKey(nameof(UserID))] // 綁定外鍵
        public UserSecretInfo User { get; set; } = null!;
    }
}
