using Microsoft.AspNetCore.Mvc;

namespace YumYum.Models.DataTransferObject
{
    public class CherishMatchSearch
    {
        [FromForm(Name = "RegionSelect")]
        public short RegionSelect { get; set; }

        [FromForm(Name = "CitySelect")]
        public string? CitySelect { get; set; }

        [FromForm(Name = "IngredientSelect")]
        public string? IngredientSelect { get; set; }
    }
}
