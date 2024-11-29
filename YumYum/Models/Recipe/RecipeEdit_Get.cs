namespace YumYum.Models.Recipe
{
    public class RecipeEdit_Get
    {
        //拿到食譜資料
        public List<RecipeWatch_Brief>? recipeWatchBrief { get; set; }
        public List<RecipeRecordField>? recipeRecordFields { get; set; }
        public List<RecipeEdit_Ingredient>? recipeIngredient { get; set; }
        //拿到全部的資歷庫食材、單位、食譜類別、食材類別資料
        public List<Ingredient>? Ingredients { get; set; }
        public List<RecipeClass>? className { get; set; }
        public List<Unit>? units { get; set; }
        public List<RecipeCreate_attribute>? attributes { get; set; }

        public int? userId { get; set; }
        //版本號及食譜狀態
        public byte ? reipeVersion { get; set; }
        public byte? recipeStatusCode { get; set; }
    }
}
