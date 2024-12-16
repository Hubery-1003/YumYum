namespace yum_admin.Models.ViewModels
{

    public class RecipeDetailViewModel
    {
        public int RecipeId { get; set; }
        public string? RecipeName { get; set; }
        public string? UserNickname { get; set; }
        public int RecipeRecVersion { get; set; } // 當前版本
        public int MaxVersion { get; set; } // 最大版本
        public int PrevVersion { get; set; } // 前一版本
        public List<RecipeVersionDetail>? PrevVersions { get; set; }// 歷史版本
        public List<RecipeFieldGroupedByVersion>? RecipeFieldsByVersion { get; set; }
        public int RecipeStatusCode { get; set; } // 狀態碼
        public DateTime RecipeRecDate { get; set; } // 更新日期
        public int RecipeField { get; set; }
        public int MaxRecipeField { get; set; }
        public string FieldName { get; set; } = null!;
        public string? FieldShot { get; set; }
        public string? FieldDescript { get; set; }
        public bool FieldCheck { get; set; }
        public string? FieldComment { get; set; }
        
        //public int MaxRecipeField { get; set; }



        // 與 Recipe 關聯的所有字段
        public List<RecipeFieldDetail> RecipeFields { get; set; } = new();
    }
    public class RecipeFieldGroupedByVersion
    {
        public int RecipeStatusCode { get; set; } // 狀態碼
        public int RecipeRecVersion { get; set; } // 版本號
        public DateTime RecipeRecDate { get; set; }
        public List<RecipeFieldDetail>? RecipeFields { get; set; } // 該版本的字段列表
    }
    public class RecipeVersionDetail
    {
        public int RecipeRecVersion { get; set; }
        public int RecipeStatusCode { get; set; }
        public DateTime RecipeRecDate { get; set; }
        public byte FieldId { get; set; }

    }

    public class RecipeFieldDetail
    {
        public string? FieldShot { get; set; }
        public string? FieldDescript { get; set; }
        public bool FieldCheck { get; set; }
        public string? FieldComment { get; set; }
        public string FieldName { get; set; } = null!;
        public byte FieldId { get; set; }
    }
    public class RecipeFieldUpdate
    {
        public int FieldId { get; set; } // 必須與前端傳遞的 "FieldId" 一致
        public string? FieldComment { get; set; } // 必須與前端傳遞的 "FieldComment" 一致
    }

}
