using Microsoft.Extensions.Options;

namespace YumYum.Models.ViewModels
{
	public class UserViewModel
	{
		public int? UserId { get; set; }

		public string? UserIntro { get; set; }

		public string? HeadShot { get; set; }

		public string? Igaccount { get; set; }

		public string? Fbnickname { get; set; }

		public string? YoutuNickname { get; set; }

		public string? WebNickName { get; set; }

		public string? YoutuLink { get; set; }

		public string? Fblink { get; set; }

		public string? WebLink { get; set; }

		public string? UserNickname { get; set; }

		public UserBio? UserBio { get; set; }
		public UserSecretInfo? UserSecretInfo { get; set; }

		//public RecipeBrief? RecipeBrief { get; set; }
		//public RecipeRecord? RecipeRecord { get; set; }
		//public RecipeRecordField? RecipeRecordField { get; set; }


	}
}
	
	

