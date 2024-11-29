namespace YumYum.Models.ViewModels
{
	public class RecipeAllUser
	{
		public List<UserQueryViewModel>? userQueryViewModel { get; set; }
		public List<RecipeQueryViewModel>? recipeQueryViewModel { get; set; }
		public List<RecipeDetailQuery>? recipeDetailQuery { get; set; }
	}
}
