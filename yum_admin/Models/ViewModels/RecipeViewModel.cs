namespace yum_admin.Models.ViewModels
{
    public class RecipeViewModel
    {
        public string? RecipeStateDescription { get; set; }
        public int RecipeStateCode { get; set; }
        public int RecipeId { get; set; }
        public string? RecipeName { get; set; }
        public string? UserNickname { get; set; }
        public int RecipeField { get; set; }
        public DateTime RecipeRecDate { get; set; }
    }
}
