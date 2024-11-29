using YumYum.Models.Recipe;
namespace YumYum.Models
{
    public class RecipeCreate
    {
        public List<Ingredient>? Ingredients { get; set; }
        public List<RecipeClass>? className { get; set; }
        public List<Unit>? units { get; set; }
        public List<RecipeCreate_attribute>? attributes { get; set; }

        public int? userId { get; set; }
    }
}
