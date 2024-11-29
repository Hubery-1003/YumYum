using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using YumYum;

namespace YumYum.Models;

public partial class YumYumDbContext : DbContext
{
    public YumYumDbContext()
    {
    }

    public YumYumDbContext(DbContextOptions<YumYumDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<CherishCheckReason> CherishCheckReasons { get; set; }

    public virtual DbSet<CherishDefaultInfo> CherishDefaultInfos { get; set; }

    public virtual DbSet<CherishDefaultTimeSet> CherishDefaultTimeSets { get; set; }

    public virtual DbSet<CherishOrder> CherishOrders { get; set; }

    public virtual DbSet<CherishOrderApplicant> CherishOrderApplicants { get; set; }

    public virtual DbSet<CherishOrderCheck> CherishOrderChecks { get; set; }

    public virtual DbSet<CherishOrderInfo> CherishOrderInfos { get; set; }

    public virtual DbSet<CherishTradeState> CherishTradeStates { get; set; }

    public virtual DbSet<CherishTradeTime> CherishTradeTimes { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<IngredAttribute> IngredAttributes { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<RecipeBrief> RecipeBriefs { get; set; }

    public virtual DbSet<RecipeClass> RecipeClasses { get; set; }

    public virtual DbSet<RecipeField> RecipeFields { get; set; }

    public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    public virtual DbSet<RecipeRecord> RecipeRecords { get; set; }

    public virtual DbSet<RecipeRecordField> RecipeRecordFields { get; set; }

    public virtual DbSet<RecipeState> RecipeStates { get; set; }

    public virtual DbSet<RefrigeratorStore> RefrigeratorStores { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<UserBio> UserBios { get; set; }

    public virtual DbSet<UserSecretInfo> UserSecretInfos { get; set; }

    public virtual DbSet<UserCollectRecipe> UserCollectRecipes { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.AdminAccount)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.AdminEmail)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.AdminHeadShot).HasMaxLength(40);
            entity.Property(e => e.AdminName).HasMaxLength(16);
            entity.Property(e => e.AdminPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AdminPhone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CherishCheckReason>(entity =>
        {
            entity.HasKey(e => e.ReasonId);

            entity.ToTable("CherishCheckReason");

            entity.Property(e => e.ReasonId)
                .ValueGeneratedOnAdd()
                .HasColumnName("ReasonID");
            entity.Property(e => e.ReasonText).HasMaxLength(5);
        });

        modelBuilder.Entity<CherishDefaultInfo>(entity =>
        {
            entity.HasKey(e => e.GiverUserId);

            entity.ToTable("CherishDefaultInfo");

            entity.Property(e => e.GiverUserId)
                .ValueGeneratedNever()
                .HasColumnName("GiverUserID");
            entity.Property(e => e.ContactLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactOther).HasMaxLength(30);
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TradeCityKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.TradeRegionId).HasColumnName("TradeRegionID");
            entity.Property(e => e.UserNickname)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.GiverUser).WithOne(p => p.CherishDefaultInfo)
                .HasForeignKey<CherishDefaultInfo>(d => d.GiverUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CherishDefaultInfo_UserSecretInfo");

            entity.HasOne(d => d.TradeCityKeyNavigation).WithMany(p => p.CherishDefaultInfos)
                .HasForeignKey(d => d.TradeCityKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CherishDefaultInfo_City");

            entity.HasOne(d => d.TradeRegion).WithMany(p => p.CherishDefaultInfos)
                .HasForeignKey(d => d.TradeRegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CherishDefaultInfo_Region");
        });

        modelBuilder.Entity<CherishDefaultTimeSet>(entity =>
        {
            entity.HasKey(e => e.TimeId);

            entity.ToTable("CherishDefaultTimeSet");

            entity.Property(e => e.TimeId).HasColumnName("TimeID");
            entity.Property(e => e.GiverUserId).HasColumnName("GiverUserID");
            entity.Property(e => e.TradeTimeCode)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.GiverUser).WithMany(p => p.CherishDefaultTimeSets)
                .HasForeignKey(d => d.GiverUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CherishDefaultTimeSet_UserSecretInfo");
        });

        modelBuilder.Entity<CherishOrder>(entity =>
        {
            entity.HasKey(e => e.CherishId);

            entity.ToTable("CherishOrder");

            entity.Property(e => e.CherishId).HasColumnName("CherishID");
            entity.Property(e => e.GiverUserId).HasColumnName("GiverUserID");
            entity.Property(e => e.IngredAttributeId).HasColumnName("IngredAttributeID");
            entity.Property(e => e.IngredientId).HasColumnName("IngredientID");
            entity.Property(e => e.ObtainSource).HasMaxLength(15);
            entity.Property(e => e.ReserveDate).HasColumnType("smalldatetime");

            entity.HasOne(d => d.GiverUser).WithMany(p => p.CherishOrders)
                .HasForeignKey(d => d.GiverUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CherishOrder_UserSecretInfo");

            entity.HasOne(d => d.IngredAttribute).WithMany(p => p.CherishOrders)
                .HasForeignKey(d => d.IngredAttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CherishOrder_IngredAttribute");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.CherishOrders)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CherishOrder_Ingredient");

            entity.HasOne(d => d.TradeStateCodeNavigation).WithMany(p => p.CherishOrders)
                .HasForeignKey(d => d.TradeStateCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CherishOrder_CherishTradeState");
        });

        modelBuilder.Entity<CherishOrderApplicant>(entity =>
        {
            entity.HasKey(e => new { e.CherishId, e.ApplicantId });

            entity.ToTable("CherishOrderApplicant");

            entity.Property(e => e.CherishId).HasColumnName("CherishID");
            entity.Property(e => e.ApplicantId).HasColumnName("ApplicantID");
            entity.Property(e => e.ApplicantContactLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApplicantContactOther).HasMaxLength(30);
            entity.Property(e => e.ApplicantContactPhone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UserNickname)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Applicant).WithMany(p => p.CherishOrderApplicants)
                .HasForeignKey(d => d.ApplicantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CherishOrderApplicant_UserSecretInfo");
        });

        modelBuilder.Entity<CherishOrderCheck>(entity =>
        {
            entity.HasKey(e => e.CherishId);

            entity.ToTable("CherishOrderCheck");

            entity.Property(e => e.CherishId)
                .ValueGeneratedNever()
                .HasColumnName("CherishID");
            entity.Property(e => e.CherishPhoto).HasMaxLength(60);
            entity.Property(e => e.OtherPhoto).HasMaxLength(60);
            entity.Property(e => e.ReasonId).HasColumnName("ReasonID");
            entity.Property(e => e.RejectText).HasMaxLength(60);
            entity.Property(e => e.ValidDatePhoto).HasMaxLength(60);

            entity.HasOne(d => d.Cherish).WithOne(p => p.CherishOrderCheck)
                .HasForeignKey<CherishOrderCheck>(d => d.CherishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CherishOrderCheck_CherishOrder");

            entity.HasOne(d => d.Reason).WithMany(p => p.CherishOrderChecks)
                .HasForeignKey(d => d.ReasonId)
                .HasConstraintName("FK_CherishOrderCheck_CherishCheckReason");
        });

        modelBuilder.Entity<CherishOrderInfo>(entity =>
        {
            entity.HasKey(e => e.CherishId);

            entity.ToTable("CherishOrderInfo");

            entity.Property(e => e.CherishId)
                .ValueGeneratedNever()
                .HasColumnName("CherishID");
            entity.Property(e => e.ContactLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactOther).HasMaxLength(30);
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TradeCityKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.TradeRegionId).HasColumnName("TradeRegionID");
            entity.Property(e => e.UserNickname).HasMaxLength(10);

            entity.HasOne(d => d.Cherish).WithOne(p => p.CherishOrderInfo)
                .HasForeignKey<CherishOrderInfo>(d => d.CherishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CherishOrderInfo_CherishOrder");

            entity.HasOne(d => d.TradeCityKeyNavigation).WithMany(p => p.CherishOrderInfos)
                .HasForeignKey(d => d.TradeCityKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CherishOrderInfo_City");

            entity.HasOne(d => d.TradeRegion).WithMany(p => p.CherishOrderInfos)
                .HasForeignKey(d => d.TradeRegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CherishOrderInfo_Region");
        });

        modelBuilder.Entity<CherishTradeState>(entity =>
        {
            entity.HasKey(e => e.TradeStateCode).HasName("PK_TradeState");

            entity.ToTable("CherishTradeState");

            entity.Property(e => e.TradeStateCode).ValueGeneratedOnAdd();
            entity.Property(e => e.TradeStateDescript).HasMaxLength(10);
        });

        modelBuilder.Entity<CherishTradeTime>(entity =>
        {
            entity.HasKey(e => e.TimeId).HasName("PK__CherishT__E04ED967F1D0706D");

            entity.ToTable("CherishTradeTime");

            entity.Property(e => e.TimeId).HasColumnName("TimeID");
            entity.Property(e => e.CherishId).HasColumnName("CherishID");
            entity.Property(e => e.TradeTimeCode)
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.Cherish).WithMany(p => p.CherishTradeTimes)
                .HasForeignKey(d => d.CherishId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CherishTradeTime_CherishOrder");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityKey);

            entity.ToTable("City");

            entity.Property(e => e.CityKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.CityName).HasMaxLength(10);
        });

        modelBuilder.Entity<IngredAttribute>(entity =>
        {
            entity.HasKey(e => e.IngredAttributeId).HasName("PK_IngredAttributon");

            entity.ToTable("IngredAttribute");

            entity.Property(e => e.IngredAttributeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("IngredAttributeID");
            entity.Property(e => e.IngredAttributeName).HasMaxLength(10);
            entity.Property(e => e.IngredAttributePhoto).HasMaxLength(40);
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.ToTable("Ingredient");

            entity.Property(e => e.IngredientId).HasColumnName("IngredientID");
            entity.Property(e => e.AttributionId).HasColumnName("AttributionID");
            entity.Property(e => e.IngredientIcon).HasMaxLength(40);
            entity.Property(e => e.IngredientName).HasMaxLength(5);

            entity.HasOne(d => d.Attribution).WithMany(p => p.Ingredients)
                .HasForeignKey(d => d.AttributionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ingredient_IngredAttribute");
        });

        modelBuilder.Entity<RecipeBrief>(entity =>
        {
            entity.HasKey(e => e.RecipeId);

            entity.ToTable("RecipeBrief");

            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");
            entity.Property(e => e.CreatorId).HasColumnName("CreatorID");
            entity.Property(e => e.RecipeClassId).HasColumnName("RecipeClassID");
            entity.Property(e => e.RecipeName).HasMaxLength(20);

            entity.HasOne(d => d.Creator).WithMany(p => p.RecipeBriefs)
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeBrief_UserSecretInfo");

            entity.HasOne(d => d.RecipeClass).WithMany(p => p.RecipeBriefs)
                .HasForeignKey(d => d.RecipeClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeBrief_RecipeClass");

            entity.HasMany(e => e.UserCollectRecipes)
                 .WithOne(uc => uc.Recipe)
                 .HasForeignKey(uc => uc.RecipeID)
                 .HasConstraintName("FK_UserCollectRecipe_RecipeBrief");
        });

        modelBuilder.Entity<RecipeClass>(entity =>
        {
            entity.ToTable("RecipeClass");

            entity.Property(e => e.RecipeClassId).HasColumnName("RecipeClassID");
            entity.Property(e => e.RecipeClassName).HasMaxLength(20);
        });

        modelBuilder.Entity<RecipeField>(entity =>
        {
            entity.HasKey(e => e.FieldId);

            entity.ToTable("RecipeField");

            entity.Property(e => e.FieldId)
                .ValueGeneratedOnAdd()
                .HasColumnName("FieldID");
            entity.Property(e => e.FieldName).HasMaxLength(5);
        });

        modelBuilder.Entity<RecipeIngredient>(entity =>
        {
            entity.HasKey(e => new { e.RecipeId, e.IngredientId });

            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");
            entity.Property(e => e.IngredientId).HasColumnName("IngredientID");
            entity.Property(e => e.Quantity).HasMaxLength(10);
            entity.Property(e => e.UnitId).HasColumnName("UnitID");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeIngredients_Ingredient");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeIngredients_RecipeBrief");

            entity.HasOne(d => d.Unit).WithMany(p => p.RecipeIngredients)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeIngredients_Unit");
        });

        modelBuilder.Entity<RecipeRecord>(entity =>
        {
            entity.HasKey(e => new { e.RecipeId, e.RecipeRecVersion });

            entity.ToTable("RecipeRecord");

            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeRecords)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeRecord_RecipeBrief");

            entity.HasOne(d => d.RecipeStatusCodeNavigation).WithMany(p => p.RecipeRecords)
                .HasForeignKey(d => d.RecipeStatusCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeRecord_RecipeState");
        });

        modelBuilder.Entity<RecipeRecordField>(entity =>
        {
            entity.HasKey(e => new { e.RecipeId, e.RecipeRecVersion, e.RecipeField });

            entity.ToTable("RecipeRecordField");

            entity.Property(e => e.RecipeId).HasColumnName("RecipeID");
            entity.Property(e => e.FieldComment).HasMaxLength(30);
            entity.Property(e => e.FieldDescript).HasMaxLength(150);
            entity.Property(e => e.FieldShot)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.RecipeFieldNavigation).WithMany(p => p.RecipeRecordFields)
                .HasForeignKey(d => d.RecipeField)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeRecordField_RecipeField");

            entity.HasOne(d => d.Recipe).WithMany(p => p.RecipeRecordFields)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RecipeRecordField_RecipeBrief");
        });

        modelBuilder.Entity<RecipeState>(entity =>
        {
            entity.HasKey(e => e.RecipeStateCode);

            entity.ToTable("RecipeState");

            entity.Property(e => e.RecipeStateCode).ValueGeneratedOnAdd();
            entity.Property(e => e.RecipeStateDescript)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<RefrigeratorStore>(entity =>
        {
            entity.HasKey(e => e.StoreId);

            entity.ToTable("RefrigeratorStore");

            entity.Property(e => e.StoreId).HasColumnName("StoreID");
            entity.Property(e => e.IngredientId).HasColumnName("IngredientID");
            entity.Property(e => e.Quantity).HasMaxLength(10);
            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Ingredient).WithMany(p => p.RefrigeratorStores)
                .HasForeignKey(d => d.IngredientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RefrigeratorStore_Ingredient");

            entity.HasOne(d => d.Unit).WithMany(p => p.RefrigeratorStores)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RefrigeratorStore_RefrigeratorStore");

            entity.HasOne(d => d.User).WithMany(p => p.RefrigeratorStores)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RefrigeratorStore_UserSecretInfo");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PK_Region_1");

            entity.ToTable("Region");

            entity.Property(e => e.RegionId).HasColumnName("RegionID");
            entity.Property(e => e.CityKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.RegionName).HasMaxLength(50);

            entity.HasOne(d => d.CityKeyNavigation).WithMany(p => p.Regions)
                .HasForeignKey(d => d.CityKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Region_City");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.ToTable("Unit");

            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.IngredAttributeId).HasColumnName("IngredAttributeID");
            entity.Property(e => e.UnitName).HasMaxLength(10);

            entity.HasOne(d => d.IngredAttribute).WithMany(p => p.Units)
                .HasForeignKey(d => d.IngredAttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Unit_IngredAttribute");
        });

        modelBuilder.Entity<UserBio>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserBio");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Fblink)
                .IsUnicode(false)
                .HasColumnName("FBLink");
            entity.Property(e => e.Fbnickname)
                .HasMaxLength(15)
                .HasColumnName("FBNickname");
            entity.Property(e => e.HeadShot).HasMaxLength(40);
            entity.Property(e => e.Igaccount)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("IGAccount");
            entity.Property(e => e.UserIntro).HasMaxLength(150);
            entity.Property(e => e.WebLink).IsUnicode(false);
            entity.Property(e => e.WebNickName).HasMaxLength(15);
            entity.Property(e => e.YoutuLink).IsUnicode(false);
            entity.Property(e => e.YoutuNickname).HasMaxLength(15);

            entity.HasOne(d => d.User).WithOne(p => p.UserBio)
                .HasForeignKey<UserBio>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserBio_UserSecretInfo");
        });

        modelBuilder.Entity<UserSecretInfo>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("UserSecretInfo");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.EmailValidCode)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserNickname).HasMaxLength(20);

            // Many-to-many relationship configuration
            //entity.HasMany(d => d.Recipes).WithMany(p => p.Users)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "UserCollectRecipe",
            //        r => r.HasOne<RecipeBrief>().WithMany()
            //            .HasForeignKey("RecipeId")
            //            .OnDelete(DeleteBehavior.ClientSetNull)
            //            .HasConstraintName("FK_UserCollectRecipe_RecipeBrief"),
            //        l => l.HasOne<UserSecretInfo>().WithMany()
            //            .HasForeignKey("UserId")
            //            .OnDelete(DeleteBehavior.ClientSetNull)
            //            .HasConstraintName("FK_UserCollectRecipe_UserSecretInfo"),
            //        j =>
            //        {
            //            j.HasKey("UserId", "RecipeId");
            //            j.ToTable("UserCollectRecipe");
            //            j.IndexerProperty<int>("UserId").HasColumnName("UserID");
            //            j.IndexerProperty<short>("RecipeId").HasColumnName("RecipeID");
            //        });


            // 將 UserSecretInfo 與 UserCollectRecipe 關聯
            entity.HasMany(e => e.UserCollectRecipes)
                  .WithOne(uc => uc.User)
                  .HasForeignKey(uc => uc.UserID)
                  .HasConstraintName("FK_UserCollectRecipe_UserSecretInfo");
        });
        modelBuilder.Entity<UserCollectRecipe>(entity =>
        {
            entity.ToTable("UserCollectRecipe");

            // 設定複合主鍵
            entity.HasKey(e => new { e.UserID, e.RecipeID });

            // 屬性設定
            entity.Property(e => e.UserID)
                .HasColumnName("UserID")
                .IsRequired();

            entity.Property(e => e.RecipeID)
                .HasColumnName("RecipeID")
                .IsRequired();

            // 外鍵設定
            entity.HasOne(e => e.Recipe) // 明確指定導航屬性
                  .WithMany(r => r.UserCollectRecipes)  // 如果 `RecipeBrief` 不需要反向關聯，保持 `WithMany()`。
                  .HasForeignKey(e => e.RecipeID)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_UserCollectRecipe_RecipeBrief");

            entity.HasOne(e => e.User) // 明確指定導航屬性
                  .WithMany(u => u.UserCollectRecipes)          // 如果 `UserSecretInfo` 不需要反向關聯，保持 `WithMany()`。
                  .HasForeignKey(e => e.UserID)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_UserCollectRecipe_UserSecretInfo");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
