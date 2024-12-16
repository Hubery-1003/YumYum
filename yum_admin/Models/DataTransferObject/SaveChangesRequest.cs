namespace yum_admin.Models.DataTransferObject
{
    public class SaveChangesRequest
    {

        public int RecipeId { get; set; } // 必須與前端 JSON 中的鍵名相同
        public int RecipeVersion { get; set; } // 必須與前端 JSON 中的鍵名相同
        public List<RecipeFieldUpdate> UpdatedFields { get; set; } = new List<RecipeFieldUpdate>();
    }
    public class RecipeFieldUpdate
    {
        public int FieldId { get; set; } // 與前端 JSON 鍵名一致
        public string? FieldComment { get; set; } // 與前端 JSON 鍵名一致
    }

}
