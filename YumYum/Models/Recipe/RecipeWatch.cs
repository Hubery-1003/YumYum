namespace YumYum.Models
{
    public class RecipeWatch
    {
        public List<RecipeWatch_Brief>? recipeWatchBrief { get; set; }
        public List<RecipeRecordField>? recipeRecordFields { get; set; }
        public List<RecipeWatch_Ingredient>? recipeIngredient { get; set; }

        public int? userId { get; set; }
        public int? recipeId { get; set; }
        public int? collectStatus { get; set; }
    }
}
