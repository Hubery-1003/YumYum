namespace YumYum.Models.DataTransferObject
{
    public class CherishMatch
    {
        public int CherishId { get; set; }

        public DateOnly EndDate { get; set; }

        public string IngredAttributeName { get; set; } = null!;

        public string IngredientName { get; set; } = null!;

        public short Quantity { get; set; }

        public string ObtainSource { get; set; } = null!;

        public DateOnly ObtainDate { get; set; }

        public string UserNickname { get; set; } = null!;

        public string CityName { get; set; } = null!;

        public string RegionName { get; set; } = null!;

        public string? ContactLine { get; set; }

        public string? ContactPhone { get; set; }

        public string? ContactOther { get; set; }

        public string? CherishPhoto { get; set; }

        public DateOnly? CherishValidDate { get; set; }
    }
}
