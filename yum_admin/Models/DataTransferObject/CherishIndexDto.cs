namespace yum_admin.Models.DataTransferObject
{
    public class CherishIndexDto
    {
        public int CherishId { get; set; }

        public byte TradeStateCode { get; set; }

        public string? TradeStateDescript { get; set; }

        public string? IngredientName { get; set; }

        public string? IngredAttributeName { get; set; }

        public string? ReasonText { get; set; }

        public DateOnly SubmitDate { get; set; }

        public DateTime? ReserveDate { get; set; }

        public DateOnly ModifyDate { get; set; }
    }
}
