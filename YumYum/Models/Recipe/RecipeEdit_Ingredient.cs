namespace YumYum.Models.Recipe
{
    public class RecipeEdit_Ingredient
    {
        //食材id
        public int? ingredientId { get; set; }
        //食材類型id
        public int? ingredientAttribute { get; set; }

        //食材名稱
        public string? ingredientName { get; set; }
        //食材icon
        public string? ingredientImg { get; set; }
        //食材數量
        public string? ingredientCount { get; set; }
        //食材單位ID
        public int? unitId { get; set; }

        //食材單位
        public string? ingredientunit { get; set; }
    }
}
