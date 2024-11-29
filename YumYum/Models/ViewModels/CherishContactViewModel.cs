using System.ComponentModel.DataAnnotations;

namespace YumYum.Models.ViewModels
{
	public class CherishContactViewModel
	{
		public int GiverUserId { get; set; }

		[Required(ErrorMessage = "必填")]
		[StringLength(10, ErrorMessage = "暱稱長度不能超過10個字元")]
		[Display(Name = "暱稱")]
		public string? UserNickname { get; set; }

		[Required(ErrorMessage = "必填")]
		public string? TradeCityKey { get; set; }

		public string? CityName { get; set; }

		[Required(ErrorMessage = "必填")]
		public short TradeRegionId { get; set; }

		public string? RegionName { get; set; }

		[Display(Name = "LINE")]
		[StringLength(50, ErrorMessage = "LINE ID長度不能超過50個字元")]

		public string? ContactLine { get; set; }

		[Display(Name = "電話號碼")]
		[StringLength(15, ErrorMessage = "電話號碼長度不能超過15個字元")]

		public string? ContactPhone { get; set; }

		[Display(Name = "其他聯絡方式")]
		[StringLength(30, ErrorMessage = "其他聯絡方式長度不能超過30個字元")]

		public string? ContactOther { get; set; }
	}
}
