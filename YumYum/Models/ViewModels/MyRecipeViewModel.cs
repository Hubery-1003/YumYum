namespace YumYum.Models.ViewModels
{
    public class MyRecipeViewModel
    {

        public IEnumerable<RecipeDetail>? RecipeDetails { get; set; }


        public class RecipeDetail
        {
            public int RecipeRecVersion { get; set; }
            public int RecipeStatusCode { get; set; }
            public int RecipeID { get; set; }
            public string? RecipeName { get; set; }
            public string? UserNickname { get; set; }
            public string? FieldDescript { get; set; }
            public int FinishMinute { get; set; }
            public string? FieldShot { get; set; }
            public string? IngredientName { get; set; }

            public int UserId { get; set; }

            public short RecipeId { get; set; }

            public List<string>? Ingredients { get; set; }

        }
        public partial class UserCollectRecipe
        {
            public int UserId { get; set; }

            public short RecipeId { get; set; }
        }

    }
}
