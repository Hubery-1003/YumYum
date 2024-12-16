using Microsoft.AspNetCore.Mvc;

namespace yum_admin.Models.DataTransferObject
{
	public class FoodSelectOption
	{
		public short? id { get; set; }

		[FromForm(Name = "Food")]
		public string? name { get; set; }

		[FromForm(Name = "Attr")]
		public byte? attrId { get; set; }
	}
}
