using System.ComponentModel;

namespace yum_admin.Models.ViewModels
{
    public class IngredientInfo
    {
        [DisplayName("編號")]
        public short id { get; set; }

        [DisplayName("食材名稱")]
        public string name { get; set; } = null!;

        [DisplayName("屬性編號")]
        public byte attrId { get; set; }

        [DisplayName("圖示")]
        public string? icon { get; set; }

        [DisplayName("屬性")]
        public string attrName { get; set; } = null!;
    }
}
