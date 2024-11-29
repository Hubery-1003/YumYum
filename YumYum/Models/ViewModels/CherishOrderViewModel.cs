using System.ComponentModel.DataAnnotations;

namespace YumYum.Models.ViewModels
{
	public class CherishOrderViewModel
	{
		// [訂單類]
		// 惜食訂單序號
		public int CherishId { get; set; }
		// 使用者編號(食材提供者)
		public int GiverUserId { get; set; }
		// 上架申請日期
		public DateOnly SubmitDate { get; set; }

		[Display(Name = "數量")]
		public short Quantity { get; set; }

		[Display(Name = "截止日期")]
		public DateOnly EndDate { get; set; }

		[Display(Name = "食材來源")]
		public string? ObtainSource { get; set; }

		[Display(Name = "購買日期 或 採收日期")]
		public DateOnly ObtainDate { get; set; }

		[Display(Name = "有效期限")]
		public DateOnly? CherishValidDate { get; set; }
		// 圖片路徑
		public string? CherishPhoto { get; set; }

		// [食材類]
		// 食材編號
		public short IngredientId { get; set; }

		[Display(Name = "食材名稱")]
		public string? IngredientName { get; set; }

		// 食材分類編號
		public byte IngredAttributeId { get; set; }

		[Display(Name = "食材分類")]
		public string? IngredAttributeName { get; set; }

		// [地區類]
		// 縣市
		public string? TradeCityKey { get; set; }
		public string? CityName { get; set; }
		// 鄉鎮市區
		public short TradeRegionId { get; set; }
		public string? RegionName { get; set; }

		// [聯絡類]
		[Display(Name = "暱稱")]
		public string? UserNickname { get; set; }

		// 聯絡方式
		public string? ContactLine { get; set; }
		public string? ContactPhone { get; set; }
		public string? ContactOther { get; set; }

		// [面交時段]
		//public string? TradeTimeCode { get; set; }

		// [訂單狀態類]
		public byte TradeStateCode { get; set; }
		public byte? ReasonId { get; set; }
	}
}
