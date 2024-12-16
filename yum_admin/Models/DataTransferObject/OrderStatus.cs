namespace yum_admin.Models.DataTransferObject
{
	public class OrderStatus
	{
		public int orderId { get; set; }

		public byte stateCode { get; set; }

		public byte? reasonId { get; set; }

		public string? rejectText { get; set; }
	}
}
