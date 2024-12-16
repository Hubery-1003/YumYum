using Microsoft.AspNetCore.Mvc;

namespace yum_admin.Models.DataTransferObject
{
    public class Cherish_CheckDto
    {
        public int CherishId { get; set; }

        public string? IngredAttributeName { get; set; }

        public string? IngredientName { get; set; }

        public short Quantity { get; set; }

        public DateOnly EndDate { get; set; }

        public DateTime? ReserveDate { get; set; }

        public string? ObtainSource { get; set; }

        public DateOnly ObtainDate { get; set; }

        public DateOnly? CherishValidDate { get; set; }

        [FromForm(Name ="Code")]
        public byte TradeStateCode { get; set; }

        public string? TradeStateDescript { get; set; }


        public DateOnly ModifyDate { get; set; }

        public string? ReasonText { get; set; }

        public string? RejectText { get; set; }


        public string? UserNickname { get; set; }

        public string? CityName { get; set; }

        public string? RegionName { get; set; }

        public string? ContactLine { get; set; }

        public string? ContactPhone { get; set; }

        public string? ContactOther { get; set; }

        public string? CherishPhoto { get; set; }

        public string? OtherPhoto { get; set; }

        public string? ValidDatePhoto { get; set; }
    }
}
