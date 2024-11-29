namespace YumYum.Models.Recipe
{
    public class RecipeCreate_Save
    {
        public RecipeBrief? recipeBrief { get; set; }
        public RecipeRecord? recipeRecord { get; set; }
        public List<RecipeRecordField>? recipeRecordFields { get; set; }
        public List<RecipeIngredient>? recipeIngredients{ get; set; }
        public List<string>? ingredientNames { get; set; }
    }
}
