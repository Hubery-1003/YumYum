namespace YumYum.Models.ViewModels
{
	public class RecipeDetailQuery
	{
		public short RecipeId { get; set; }

		public short IngredientId { get; set; }

		public string IngredientName { get; set; } = null!;

		//public List<RecipeDetailQuery> RecipeDetails { get; set; } = new List<RecipeDetailQuery>();
	}
}
