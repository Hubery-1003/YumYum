namespace YumYum.Models.ViewModels
{
	public class RecipeQueryViewModel
	{
		public short RecipeId { get; set; }

		public string RecipeName { get; set; } = null!;

		public short RecipeClassId { get; set; }

		public byte RecipeStatusCode { get; set; }

		public string? FieldShot { get; set; }

		public short? FinishMinute { get; set; }

		public byte? RecipeRecVersion { get; set; }
	}
}
