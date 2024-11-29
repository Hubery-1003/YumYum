namespace YumYum.Models
{
    public class RecipeWatch_Brief
    {
        //食譜id
        public int RecipeId { get; set; }
        //創建者id
        public int? creatorId { get; set; }
        //創建者姓名
        public string? userNickName { get; set; }
        //創建者照片
        public string? userPhoto { get; set; }
        //食譜名稱
        public string? recipeName { get; set; }
        //完成時間
        public short recipeFinishTime { get; set; }
        //食用人數
        public byte recipePeople { get; set; }
        //食譜類別
        public string? className { get; set; }

    }
}
