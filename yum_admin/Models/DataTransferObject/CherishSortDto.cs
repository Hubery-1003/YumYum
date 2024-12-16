using Microsoft.AspNetCore.Mvc;

namespace yum_admin.Models.DataTransferObject
{
    public class CherishSortDto
    {
        
        public string? name { get; set; }

        public byte attrId { get; set; }

        public byte tradeCode { get; set; }
    }
}
